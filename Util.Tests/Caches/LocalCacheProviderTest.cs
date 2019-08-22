using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Caches;
using Util.Tests.Samples;

namespace Util.Tests.Caches {
    /// <summary>
    /// 本地缓存提供程序测试
    /// </summary>
    [TestClass]
    public class LocalCacheProviderTest {
        /// <summary>
        /// 本地缓存提供程序
        /// </summary>
        private LocalCacheProvider _cache;
        /// <summary>
        /// 测试对象
        /// </summary>
        private User _user;
        /// <summary>
        /// 键
        /// </summary>
        private string _key;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _cache = new LocalCacheProvider();
            _user = new User { DoubleValue = 999 };
            _key = "a";
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        [TestCleanup]
        public void TestClear() {
            _cache.Clear();
        }

        /// <summary>
        /// 测试添加缓存，验证key
        /// </summary>
        [TestMethod]
        public void TestValidateKey() {
            _cache.Remove( null );
            _cache.Add( null, _user, 10 );
            Assert.IsNull( _cache.Get<User>( null ),"null" );
            _cache.Add( "", _user, 10 );
            Assert.IsNull( _cache.Get<User>( "" ) );
        }

        /// <summary>
        /// 测试添加缓存
        /// </summary>
        [TestMethod]
        public void TestAdd() {
            Assert.IsNull( _cache.Get<User>( _key ) );
            _cache.Add( _key, _user, 10 );
            Assert.IsNotNull( _cache.Get<User>( _key ) );
            Assert.AreEqual( 999, _cache.Get<User>( _key ).DoubleValue );
        }

        /// <summary>
        /// 测试添加缓存，对key进行过滤
        /// </summary>
        [TestMethod]
        public void TestAdd_FilterKey() {
            const string key2 = "A ";
            _cache.Add( key2, _user, 10 );
            Assert.IsNotNull( _cache.Get<User>( key2 ) );
            Assert.AreEqual( 999, _cache.Get<User>( _key ).DoubleValue );
        }

        /// <summary>
        /// 测试修改
        /// </summary>
        [TestMethod]
        public void TestUpdate() {
            const string key2 = "A ";
            _cache.Add( _key, _user, 10 );
            var user = new User {DoubleValue = 888};
            _cache.Update( null, user,10 );
            _cache.Update( key2, user,10 );
            Assert.AreEqual( 888, _cache.Get<User>( _key ).DoubleValue );
        }

        /// <summary>
        /// 测试修改时间
        /// </summary>
        [TestMethod]
        [Ignore]
        public void TestUpdate_Time() {
            Assert.IsNull( _cache.Get<User>( _key ) );
            _cache.Add( _key, _user, 1 );
            Thread.Sleep( 500 );
            Assert.IsNotNull( _cache.Get<User>( _key ) );
            _cache.Update( _key, new User { DoubleValue = 888 },1 );
            Thread.Sleep( 800 );
            Assert.IsNotNull( _cache.Get<User>( _key ) );
            Assert.AreEqual( 888, _cache.Get<User>( _key ).DoubleValue );
            _cache.Update( _key, new User { DoubleValue = 888 },1 );
            Thread.Sleep( 1200 );
            Assert.IsNull( _cache.Get<User>( _key ) );
        }

        /// <summary>
        /// 测试移除
        /// </summary>
        [TestMethod]
        public void TestRemove() {
            const string keyB = "B";
            _cache.Add( _key, _user, 10 );
            _cache.Add( keyB, _user, 10 );
            Assert.IsNotNull( _cache.Get<User>( _key ) );
            Assert.IsNotNull( _cache.Get<User>( keyB ) );

            _cache.Remove( "A " );
            Assert.IsNull( _cache.Get<User>( _key ) );
            Assert.IsNotNull( _cache.Get<User>( keyB ) );
        }
    }
}
