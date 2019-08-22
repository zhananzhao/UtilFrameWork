using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Caches;

namespace Util.Tests.Caches {
    /// <summary>
    /// 默认缓存键测试
    /// </summary>
    [TestClass]
    public class DefaultCacheKeyTest {
        /// <summary>
        /// 默认缓存键
        /// </summary>
        private DefaultCacheKey _key;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _key = new DefaultCacheKey();
        }

        /// <summary>
        /// 测试获取键
        /// </summary>
        [TestMethod]
        public void TestGetKey() {
            Assert.AreEqual( "CacheKey_a", _key.GetKey( "a" ) ); 
        }
    }
}
