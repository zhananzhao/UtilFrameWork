using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Layouts;
using Util.Webs.TextWriters;

namespace Util.Webs.EasyUi.Tests.Layouts {
    /// <summary>
    /// 选项卡测试
    /// </summary>
    [TestClass]
    public class TabsTest {
        /// <summary>
        /// 选项卡配置项
        /// </summary>
        private Tabs _option;
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
            _option = new Tabs( _writer );
        }

        /// <summary>
        /// 验证结果
        /// </summary>
        private void AssertResult( string options = "" ) {
            var result = new Str();
            result.Add( "<div class=\"easyui-tabs\" data-options=\"{0}\">",options );
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
        /// 测试启用平滑效果
        /// </summary>
        [TestMethod]
        public void TestPlain() {
            _option.Plain().Begin();
            AssertResult( "plain:true" );
        }

        /// <summary>
        /// 测试自适应
        /// </summary>
        [TestMethod]
        public void TestFit() {
            _option.Fit().Begin();
            AssertResult( "fit:true" );
        }

        /// <summary>
        /// 测试显示边框
        /// </summary>
        [TestMethod]
        public void TestBorder() {
            _option.Border( false ).Begin();
            AssertResult( "border:false" );
        }

        /// <summary>
        /// 测试面板位置
        /// </summary>
        [TestMethod]
        public void TestTabPosition() {
            _option.TabPosition( Align.Right ).Begin();
            AssertResult( "tabPosition:'right'" );
        }

        /// <summary>
        /// 测试选项卡标题宽度
        /// </summary>
        [TestMethod]
        public void TestHeaderWidth() {
            _option.HeaderWidth( 100 ).Begin();
            AssertResult( "headerWidth:100" );
        }

        /// <summary>
        /// 测试选项卡面板宽度
        /// </summary>
        [TestMethod]
        public void TestTabWidth() {
            _option.TabWidth( 100 ).Begin();
            AssertResult( "tabWidth:100" );
        }

        /// <summary>
        /// 测试选项卡面板高度
        /// </summary>
        [TestMethod]
        public void TestTabHeight() {
            _option.TabHeight( 100 ).Begin();
            AssertResult( "tabHeight:100" );
        }
    }
}
