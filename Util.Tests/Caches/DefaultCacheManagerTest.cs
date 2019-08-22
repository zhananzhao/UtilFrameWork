using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Caches;
using Util.Tests.Samples;

namespace Util.Tests.Caches {
    /// <summary>
    /// 默认缓存管理器测试
    /// </summary>
    [TestClass]
    public class DefaultCacheManagerTest {

        #region 测试初始化

        /// <summary>
        /// 默认缓存管理器
        /// </summary>
        private DefaultCacheManager _manager;

        /// <summary>
        /// 模拟测试仓储1
        /// </summary>
        private ITest3Repository _mockRepository;

        /// <summary>
        /// 模拟缓存提供程序
        /// </summary>
        private ICacheProvider _mockCacheProvider;

        /// <summary>
        /// 键
        /// </summary>
        private string _key;

        /// <summary>
        /// 实际缓存键
        /// </summary>
        private string _cacheKey;

        /// <summary>
        /// 缓存过期标记键
        /// </summary>
        private string _signKey;

        /// <summary>
        /// 测试对象
        /// </summary>
        private Test3 _testA;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _mockCacheProvider = Substitute.For<ICacheProvider>();
            _manager = new DefaultCacheManager( _mockCacheProvider,new DefaultCacheKey() );
            _mockRepository = Substitute.For<ITest3Repository>();
            _key = "a";
            _cacheKey = "CacheKey_a";
            _signKey = "CacheKey_Sign_a";
            _testA = Test3.CreateA();
        }

        #endregion

        #region Get(获取缓存)

        /// <summary>
        /// 测试首次获取缓存，从仓储加载，并添加到缓存
        /// </summary>
        [TestMethod]
        public void TestGet_First() {
            //设置仓储操作
            _mockRepository.GetTest3().Returns( _testA );
            //首次读取缓存
            var result = _manager.Get( _key, () => _mockRepository.GetTest3(), 10 );
            //验证添加缓存过期标记
            _mockCacheProvider.Received().Add( _signKey, "a", 10 );
            //验证添加缓存
            _mockCacheProvider.Received().Add( _cacheKey, _testA, 20 );
            //验证已从仓储获取数据
            _mockRepository.Received().GetTest3();
            //验证结果
            Assert.IsNotNull( result );
            Assert.AreEqual( "A", result.Name );
        }

        /// <summary>
        /// 测试第二次获取缓存，不再读取仓储
        /// </summary>
        [TestMethod]
        public void TestGet_Second() {
            //设置仓储操作
            _mockRepository.GetTest3().Returns( _testA );
            //设置仅当调用了添加缓存方法后，才能获取
            _mockCacheProvider.When( t => t.Add( _cacheKey, _testA, 20 ) )
                .Do( invocation => _mockCacheProvider.Get<Test3>( _cacheKey ).Returns( _testA ) );
            _mockCacheProvider.When( t => t.Add( _signKey, "a", 10 ) )
                .Do( invocation => _mockCacheProvider.Get<string>( _signKey ).Returns( "a" ) );

            //首次读取缓存
            _manager.Get( _key, () => _mockRepository.GetTest3(), 10 );
            //第二次读取缓存
            var result = _manager.Get( _key, () => _mockRepository.GetTest3(), 10 );

            //验证仓储只被调用一次，说明第二次从缓存中读取
            _mockRepository.Received(1).GetTest3();
            //验证缓存只被添加一次
            _mockCacheProvider.Received( 1 ).Add( _cacheKey, _testA, 20 );
            //验证结果
            Assert.IsNotNull( result );
            Assert.AreEqual( "A", result.Name );
        }

        /// <summary>
        /// 测试并发更新
        /// </summary>
        [TestMethod]
        public void TestGet_Concurrency() {
            //设置仓储操作
            _mockRepository.GetTest3().Returns( _testA );
            //设置仅当调用了添加缓存方法后，才能获取
            _mockCacheProvider.When( t => t.Add( _cacheKey, _testA, 20 ) )
                .Do( invocation => _mockCacheProvider.Get<Test3>( _cacheKey ).Returns( _testA ) );
            _mockCacheProvider.When( t => t.Add( _signKey, "a", 10 ) )
                .Do( invocation => _mockCacheProvider.Get<string>( _signKey ).Returns( "a" ) );

            //并发读取缓存
            UnitTest.TestConcurrency( () => {
                var manager = new DefaultCacheManager( _mockCacheProvider, new DefaultCacheKey() );
                manager.Get( _key, () => _mockRepository.GetTest3(), 10 );
            }, 5 );

            //验证仓储只被调用一次，说明同时只有一个线程能更新缓存
            _mockRepository.Received( 1 ).GetTest3();
            //验证缓存只被添加一次
            _mockCacheProvider.Received( 1 ).Add( _cacheKey, _testA, 20 );
        }

        /// <summary>
        /// 已缓存,当缓存标记过期，重新更新缓存
        /// </summary>
        [TestMethod]
        public void TestGet_Concurrency2() {
            //模拟已加载缓存
            _mockCacheProvider.Get<Test3>( _cacheKey ).Returns( _testA );
            //模拟缓存过期标记已到期
            _mockCacheProvider.Get<string>( _signKey ).Returns( "" );
            //添加缓存过期标记后，返回"a"
            _mockCacheProvider.When( t => t.Add( _signKey, "a", 10 ) )
                .Do( invocation => _mockCacheProvider.Get<string>( _signKey ).Returns( "a" ) );

            //并发读取缓存
            UnitTest.TestConcurrency( () => {
                var manager = new DefaultCacheManager( _mockCacheProvider, new DefaultCacheKey() );
                manager.Get( _key, () => _mockRepository.GetTest3(), 10 );
            }, 5 );

            //验证添加缓存过期标记1次
            _mockCacheProvider.Received(1).Add( _signKey, "a", 10 );
            //验证不会调用添加缓存
            _mockCacheProvider.DidNotReceive().Add( _cacheKey, _testA, 20 );
            //验证缓存在过期时被更新
            _mockCacheProvider.Received( 1 ).Update( _cacheKey, Arg.Any<object>(), 20 );
        }

        /// <summary>
        /// 测试缓存过期时间单位为分
        /// </summary>
        [TestMethod]
        public void TestGetByMinutes() {
            //设置仓储操作
            _mockRepository.GetTest3().Returns( _testA );
            //读取缓存
            _manager.GetByMinutes( _key, () => _mockRepository.GetTest3(), 1 );
            //验证读取和添加缓存
            _mockCacheProvider.Received().Add( _cacheKey, _testA, 120 );
        }

        /// <summary>
        /// 测试缓存过期时间单位为小时
        /// </summary>
        [TestMethod]
        public void TestGetByHours() {
            //设置仓储操作
            _mockRepository.GetTest3().Returns( _testA );
            //读取缓存
            _manager.GetByHours( _key, () => _mockRepository.GetTest3(), 1 );
            //验证读取和添加缓存
            _mockCacheProvider.Received().Add( _cacheKey, _testA, 7200 );
        }

        #endregion

        #region Update(更新缓存)

        /// <summary>
        /// 更新缓存
        /// </summary>
        [TestMethod]
        public void TestUpdate() {
            _manager.Update( _key, 1, 1 );
            _mockCacheProvider.Received().Update( _signKey, "a", 1 );
            _mockCacheProvider.Received().Update( _cacheKey, 1, 2 );
        }

        #endregion

        #region Remove(移除缓存)

        /// <summary>
        /// 移除缓存
        /// </summary>
        [TestMethod]
        public void TestRemove() {
            _manager.Remove( _key );
            _mockCacheProvider.Received().Remove( _signKey );
            _mockCacheProvider.Received().Remove( _cacheKey );
        }

        #endregion

        #region Clear(清空缓存)

        /// <summary>
        /// 清空缓存
        /// </summary>
        [TestMethod]
        public void TestClear() {
            _manager.Clear();
            _mockCacheProvider.Received().Clear();
        }

        #endregion
    }
}
