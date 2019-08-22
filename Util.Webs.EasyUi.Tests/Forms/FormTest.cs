using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Forms;
using Util.Webs.TextWriters;

namespace Util.Webs.EasyUi.Tests.Forms {
    /// <summary>
    /// 表单测试
    /// </summary>
    [TestClass]
    public class FormTest {
        /// <summary>
        /// 表单
        /// </summary>
        private Form _form;
        /// <summary>
        /// 文本写入器
        /// </summary>
        private StringBuilderWriter _writer;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _writer = new StringBuilderWriter();
            _form = new Form( _writer );
        }

        /// <summary>
        /// 断言结果
        /// </summary>
        private void AssertResult( string options,string end = "" ) {
            var result = new Str();
            result.Add( "<form {0}>{1}", options,end );
            Assert.AreEqual( result.ToString(), _writer.GetResult() );
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            Assert.AreEqual( "", _writer.GetResult() );
        }

        /// <summary>
        /// 测试Id
        /// </summary>
        [TestMethod]
        public void TestId() {
            _form.Id( "a" ).Begin();
            AssertResult( "id=\"a\"" );
        }

        /// <summary>
        /// 测试End
        /// </summary>
        [TestMethod]
        public void TestBegin_End() {
            using( _form.Id( "a" ).Begin() ) {
            }
            AssertResult( "id=\"a\"","</form>" );
        }

        /// <summary>
        /// 测试Action
        /// </summary>
        [TestMethod]
        public void TestAction() {
            _form.Action( "a" ).Begin();
            AssertResult( "action=\"a\"" );
        }

        /// <summary>
        /// 测试确认消息
        /// </summary>
        [TestMethod]
        public void TestConfirm() {
            _form.Confirm( "a" ).Begin();
            AssertResult( "confirm=\"a\"" );
        }

        /// <summary>
        /// 测试Post提交方式
        /// </summary>
        [TestMethod]
        public void TestPost() {
            _form.Post().Begin();
            AssertResult( "method=\"post\"" );
        }
    }
}
