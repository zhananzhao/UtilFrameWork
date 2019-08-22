using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Nodes;

namespace Util.Webs.Tests.Attributes {
    /// <summary>
    /// 属性列表节点测试
    /// </summary>
    [TestClass]
    public class AttributeListNodeTest {
        /// <summary>
        /// 属性列表节点
        /// </summary>
        private AttributeListNode _node;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _node = new AttributeListNode();
        }

        /// <summary>
        /// 获取默认结果
        /// </summary>
        [TestMethod]
        public void TestGetResult_Default() {
            Assert.AreEqual( "",_node.GetResult() );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        [TestMethod]
        public void TestGetResult() {
            _node = new AttributeListNode("a");
            Assert.AreEqual( "a", _node.GetResult() );
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        [TestMethod]
        public void TestAdd_1() {
            _node.Add( "a" );
            Assert.AreEqual( "a", _node.GetResult() );
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        [TestMethod]
        public void TestAdd_2() {
            _node.Add( "a" );
            _node.Add( "b" );
            Assert.AreEqual( "a;b", _node.GetResult() );
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        [TestMethod]
        public void TestAdd_ValueSeparator() {
            _node.ValueSeparator = ",";
            _node.Add( "a" );
            _node.Add( "b" );
            Assert.AreEqual( "a,b", _node.GetResult() );
        }

        /// <summary>
        /// 清除
        /// </summary>
        [TestMethod]
        public void TestClear() {
            _node.Add( "a" );
            _node.Clear();
            Assert.AreEqual( "", _node.GetResult() );
        }
    }
}
