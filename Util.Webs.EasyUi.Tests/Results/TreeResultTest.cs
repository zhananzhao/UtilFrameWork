using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Results;
using Util.Webs.EasyUi.Trees;

namespace Util.Webs.EasyUi.Tests.Results {
    /// <summary>
    /// 树结果测试
    /// </summary>
    [TestClass]
    public class TreeResultTest {
        /// <summary>
        /// 树结果
        /// </summary>
        private TreeResult _result;

        /// <summary>
        /// 测试空值
        /// </summary>
        [TestMethod]
        public void TestNull() {
            _result = new TreeResult( null );
            Assert.AreEqual( "[]", _result.ToString() );
        }

        /// <summary>
        /// 测试1个节点
        /// </summary>
        [TestMethod]
        public void Test_1Node() {
            var node = new TreeNode { Id = "1", Text = "a", Attributes = new { url = "b" } };
            _result = new TreeResult( new[] { node } );
            Assert.AreEqual( "[{\"id\":\"1\",\"text\":\"a\",\"attributes\":{\"url\":\"b\"}}]", _result.ToString() );
        }

        /// <summary>
        /// 测试异步加载时，节点状态设为closed
        /// </summary>
        [TestMethod]
        public void Test_Async_State() {
            var node = new TreeNode { Id = "1", Text = "a" };
            _result = new TreeResult( new[] { node },true );
            Assert.AreEqual( "[{\"id\":\"1\",\"text\":\"a\",\"state\":\"closed\"}]", _result.ToString() );
        }

        /// <summary>
        /// 测试2个节点
        /// </summary>
        [TestMethod]
        public void Test_2Node() {
            var node = new TreeNode { Id = "1", Text = "a" };
            var node2 = new TreeNode { Id = "2", Text = "b" };
            _result = new TreeResult( new[] { node, node2 } );
            Assert.AreEqual( "[{\"id\":\"1\",\"text\":\"a\"},{\"id\":\"2\",\"text\":\"b\"}]", _result.ToString() );
        }

        /// <summary>
        /// 测试2个节点，有嵌套
        /// </summary>
        [TestMethod]
        public void Test_2Node_Children() {
            var node = new TreeNode { Id = "1", Text = "a",Level = 1};
            var node2 = new TreeNode { Id = "2", ParentId = "1", Text = "b", Level = 2 };
            _result = new TreeResult( new[] { node, node2 } );
            var expected = new Str();
            expected.Add( "[{\"id\":\"1\",\"text\":\"a\"," );
            expected.Add( "\"children\":[{\"id\":\"2\",\"ParentId\":\"1\",\"text\":\"b\"}]" );
            expected.Add( "}]" );
            Assert.AreEqual( expected.ToString(), _result.ToString() );
        }

        /// <summary>
        /// 测试3个节点，有嵌套
        /// </summary>
        [TestMethod]
        public void Test_3Node_Children() {
            var node = new TreeNode { Id = "1" };
            var node2 = new TreeNode { Id = "2", ParentId = "1" };
            var node3 = new TreeNode { Id = "3", ParentId = "2" };
            _result = new TreeResult( new[] { node2, node3, node } );
            var expected = new Str();
            expected.Add( "[{\"id\":\"1\",\"children\":[" );
            expected.Add( "{\"id\":\"2\",\"ParentId\":\"1\",\"children\":[" );
            expected.Add( "{\"id\":\"3\",\"ParentId\":\"2\"}]" );
            expected.Add( "}]}]" );
            Assert.AreEqual( expected.ToString(), _result.ToString() );
        }

        /// <summary>
        /// 测试3个节点，有嵌套，根据级数判断
        /// </summary>
        [TestMethod]
        public void Test_3Node_Children_Level() {
            var node = new TreeNode { Id = "1",ParentId = "11",Level = 1 };
            var node2 = new TreeNode { Id = "2", ParentId = "1", Level = 2 };
            var node3 = new TreeNode { Id = "3", ParentId = "2", Level = 3 };
            _result = new TreeResult( new[] { node2, node3, node } );
            var expected = new Str();
            expected.Add( "[{\"id\":\"1\",\"ParentId\":\"11\",\"children\":[" );
            expected.Add( "{\"id\":\"2\",\"ParentId\":\"1\",\"children\":[" );
            expected.Add( "{\"id\":\"3\",\"ParentId\":\"2\"}]" );
            expected.Add( "}]}]" );
            Assert.AreEqual( expected.ToString(), _result.ToString() );
        }
    }
}
