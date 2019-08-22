using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Layouts;
using Util.Webs.TextWriters;

namespace Util.Webs.EasyUi.Tests.Layouts {
    /// <summary>
    /// 布局测试
    /// </summary>
    [TestClass]
    public class LayoutTest {
        /// <summary>
        /// 布局
        /// </summary>
        private Layout _layout;
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
            _layout = new Layout( _writer, false );
        }

        /// <summary>
        /// 输出起始标签
        /// </summary>
        [TestMethod]
        public void TestBegin() {
            _layout.Begin();
            Assert.AreEqual( "<div class=\"easyui-layout\">", _writer.GetResult() );
        }

        /// <summary>
        /// 用using输出容器标签
        /// </summary>
        [TestMethod]
        public void TestUsing() {
            using ( _layout.Begin() ) {
            }
            Assert.AreEqual( "<div class=\"easyui-layout\"></div>", _writer.GetResult() );
        }

        /// <summary>
        /// 设置自适应布局
        /// </summary>
        [TestMethod]
        public void TestFit() {
            _layout = new Layout( _writer, true );
            _layout.Begin();
            Assert.AreEqual( "<div class=\"easyui-layout\" data-options=\"fit:true\">", _writer.GetResult() );
        }
    }
}
