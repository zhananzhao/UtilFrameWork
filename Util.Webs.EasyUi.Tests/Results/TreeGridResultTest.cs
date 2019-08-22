using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Results;
using Util.Webs.EasyUi.Trees;

namespace Util.Webs.EasyUi.Tests.Results {
    /// <summary>
    /// 树型表格结果测试
    /// </summary>
    [TestClass]
    public class TreeGridResultTest {
        /// <summary>
        /// 树型表格结果
        /// </summary>
        private TreeGridResult _result;

        /// <summary>
        /// 默认使用TreeResult输出
        /// </summary>
        [TestMethod]
        public void TestNull() {
            _result = new TreeGridResult( null );
            Assert.AreEqual( "[]", _result.ToString() );
        }

        /// <summary>
        /// 当设置总行数，将使用DataGridResult输出
        /// </summary>
        [TestMethod]
        public void TestNull_Total() {
            _result = new TreeGridResult( null, false, 0 );
            Assert.AreEqual( "{\"total\":\"0\",\"rows\":[]}", _result.ToString() );
        }

        /// <summary>
        /// 设置异步，叶节点状态设为closed
        /// </summary>
        [TestMethod]
        public void TestAync_TreeResult() {
            var node = new TreeNode { Id = "1", Text = "a" };
            _result = new TreeGridResult( new[] { node }, true );
            Assert.AreEqual( "[{\"id\":\"1\",\"text\":\"a\",\"state\":\"closed\"}]", _result.ToString() );
        }

        /// <summary>
        /// 设置异步，叶节点状态设为closed
        /// </summary>
        [TestMethod]
        public void TestAync_DataGridResult() {
            var node = new TreeNode { Id = "1", Text = "a" };
            _result = new TreeGridResult( new[] { node }, true, 1 );
            var expected = new Str();
            expected.Add( "{\"total\":1,\"rows\":[" );
            expected.Add( "{\"id\":\"1\",\"text\":\"a\",\"state\":\"closed\"}" );
            expected.Add( "]}" );
            Assert.AreEqual( expected.ToString(), _result.ToString() );
        }
    }
}
