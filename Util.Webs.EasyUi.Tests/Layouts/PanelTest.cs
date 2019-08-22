using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Layouts;
using Util.Webs.TextWriters;

namespace Util.Webs.EasyUi.Tests.Layouts {
    /// <summary>
    /// 面板测试
    /// </summary>
    [TestClass]
    public class PanelTest {
        /// <summary>
        /// 面板
        /// </summary>
        private Panel _option;
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
            _option = new Panel( _writer );
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            Assert.AreEqual( "",  _writer.GetResult() );
        }

        /// <summary>
        /// 测试自适应
        /// </summary>
        [TestMethod]
        public void TestFit() {
            _option.Fit().Begin();
            Assert.AreEqual( "<div class=\"easyui-panel\" data-options=\"fit:true\">",  _writer.GetResult() );
        }

        /// <summary>
        /// 测试设置页脚
        /// </summary>
        [TestMethod]
        public void TestFooter() {
            _option.Footer( "a" ).Begin();
            Assert.AreEqual( "<div class=\"easyui-panel\" data-options=\"footer:'#a'\">",  _writer.GetResult() );
        }
    }
}
