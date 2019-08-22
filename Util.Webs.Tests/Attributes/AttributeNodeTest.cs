using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Nodes;

namespace Util.Webs.Tests.Attributes {
    /// <summary>
    /// 属性节点测试
    /// </summary>
    [TestClass]
    public class AttributeNodeTest {
        /// <summary>
        /// 属性节点
        /// </summary>
        private AttributeNode _node;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _node = new AttributeNode("a");
        }

        /// <summary>
        /// 获取默认结果
        /// </summary>
        [TestMethod]
        public void TestGetResult_Default() {
            Assert.AreEqual( "",_node.GetResult() );
        }

        /// <summary>
        /// 添加一个属性值
        /// </summary>
        [TestMethod]
        public void TestAdd_1Value() {
            _node.Add( "1" );
            Assert.AreEqual( "a=\"1\"",_node.GetResult() );
        }

        /// <summary>
        /// 添加2个属性值，默认用分号隔开
        /// </summary>
        [TestMethod]
        public void TestAdd_2Value() {
            _node.Add( "1" );
            _node.Add( "2" );
            Assert.AreEqual( "a=\"1;2\"", _node.GetResult() );
        }

        /// <summary>
        /// 测试值分隔符
        /// </summary>
        [TestMethod]
        public void TestValueSeparator() {
            _node = new AttributeNode( "a" );
            _node.ValueSeparator = ",";
            _node.Add( "1" );
            _node.Add( "2" );
            Assert.AreEqual( "a=\"1,2\"", _node.GetResult() );
        }

        /// <summary>
        /// 测试属性分隔符
        /// </summary>
        [TestMethod]
        public void TestAttributeSeparator() {
            _node = new AttributeNode( "a" );
            _node.AttributeSeparator = "|";
            _node.Add( "1" );
            Assert.AreEqual( "a|\"1\"", _node.GetResult() );
        }

        /// <summary>
        /// 测试属性值引号
        /// </summary>
        [TestMethod]
        public void TestValueQuotes() {
            _node = new AttributeNode( "a" );
            _node.ValueQuotes = "'";
            _node.Add( "1" );
            Assert.AreEqual( "a='1'", _node.GetResult() );
        }
    }
}
