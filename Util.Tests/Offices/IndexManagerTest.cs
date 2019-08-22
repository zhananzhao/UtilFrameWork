using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Offices;

namespace Util.Tests.Offices {
    /// <summary>
    /// 索引管理器测试
    /// </summary>
    [TestClass]
    public class IndexManagerTest {
        /// <summary>
        /// 索引管理器
        /// </summary>
        private IndexManager _manager;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _manager = new IndexManager();
        }

        /// <summary>
        /// 获取索引
        /// </summary>
        [TestMethod]
        public void TestGetIndex() {
            Assert.AreEqual( 0, _manager.GetIndex() );
            Assert.AreEqual( 1, _manager.GetIndex() );
        }

        /// <summary>
        /// 添加索引
        /// </summary>
        [TestMethod]
        public void TestAddIndex() {
            _manager.AddIndex(1);
            Assert.AreEqual( 0, _manager.GetIndex() );
            Assert.AreEqual( 2, _manager.GetIndex() );
        }

        /// <summary>
        /// 添加索引
        /// </summary>
        [TestMethod]
        public void TestAddIndex_2() {
            Assert.AreEqual( 0, _manager.GetIndex(10) );
            _manager.AddIndex( 15 );
            Assert.AreEqual( 10, _manager.GetIndex(5) );
            Assert.AreEqual( 16, _manager.GetIndex() );
        }

        /// <summary>
        /// 添加索引
        /// </summary>
        [TestMethod]
        public void TestAddIndex_3() {
            _manager.AddIndex( 0 );
            _manager.AddIndex( 1 );
            _manager.AddIndex( 2,2 );
            Assert.AreEqual( 4, _manager.GetIndex() );
        }

        /// <summary>
        /// 添加索引
        /// </summary>
        [TestMethod]
        public void TestAddIndex_4() {
            _manager.AddIndex( 1 );
            _manager.AddIndex( 2, 2 );
            Assert.AreEqual( 0, _manager.GetIndex() );
        }
    }
}
