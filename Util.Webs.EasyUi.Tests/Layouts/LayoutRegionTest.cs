using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Layouts;
using Util.Webs.TextWriters;

namespace Util.Webs.EasyUi.Tests.Layouts {
    /// <summary>
    /// 布局区域测试
    /// </summary>
    [TestClass]
    public class LayoutRegionTest {
        /// <summary>
        /// 布局区域
        /// </summary>
        private LayoutRegion _option;
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
            _option = new LayoutRegion( _writer );
        }

        /// <summary>
        /// 断言结果
        /// </summary>
        private void AssertResult( string options ) {
            var result = new Str();
            result.Add( "<div data-options=\"{0}\">",options );
            Assert.AreEqual( result.ToString(), _writer.GetResult() );
        }

        /// <summary>
        /// 输出默认选项
        /// </summary>
        [TestMethod]
        public void Test_Default() {
            Assert.AreEqual( "", _writer.GetResult() );
        }

        /// <summary>
        /// 设置为顶部区域
        /// </summary>
        [TestMethod]
        public void TestTop() {
            _option.Top().Begin();
            AssertResult( "region:'north'" );
        }

        /// <summary>
        /// 设置为底部区域
        /// </summary>
        [TestMethod]
        public void TestBottom() {
            _option.Bottom().Begin();
            AssertResult( "region:'south'" );
        }

        /// <summary>
        /// 设置为左侧区域
        /// </summary>
        [TestMethod]
        public void TestLeft() {
            _option.Left().Begin();
            AssertResult( "region:'west'" );
        }

        /// <summary>
        /// 设置为右侧区域
        /// </summary>
        [TestMethod]
        public void TestRight() {
            _option.Right().Begin();
            AssertResult( "region:'east'" );
        }

        /// <summary>
        /// 设置为中间内容区域
        /// </summary>
        [TestMethod]
        public void TestCenter() {
            _option.Center().Begin();
            AssertResult( "region:'center'" );
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        [TestMethod]
        public void TestTitle() {
            _option.Title( "a" ).Begin();
            AssertResult( "title:'a'" );
        }

        /// <summary>
        /// 设置为顶部区域，并设置标题
        /// </summary>
        [TestMethod]
        public void TestTop_Title() {
            _option.Top().Title( "a" ).Begin();
            AssertResult( "region:'north',title:'a'" );
        }
        
        /// <summary>
        /// 显示边框
        /// </summary>
        [TestMethod]
        public void TestBorder() {
            _option.Border( false ).Begin();
            AssertResult( "border:false" );
        }

        /// <summary>
        /// 显示分隔条
        /// </summary>
        [TestMethod]
        public void TestSplit() {
            _option.Split().Begin();
            AssertResult( "split:true" );
        }

        /// <summary>
        /// 设置图标
        /// </summary>
        [TestMethod]
        public void TestIconClass() {
            _option.Icon( "a" ).Begin();
            AssertResult( "iconCls:'a'" );
        }

        /// <summary>
        /// 设置Url
        /// </summary>
        [TestMethod]
        public void TestHref() {
            _option.Href( "a" ).Begin();
            AssertResult( "href:'a'" );
        }

        /// <summary>
        /// 允许折叠
        /// </summary>
        [TestMethod]
        public void TestCollapsible() {
            _option.Collapsible( false ).Begin();
            AssertResult( "collapsible:false" );
        }

        /// <summary>
        /// 设置最小宽度
        /// </summary>
        [TestMethod]
        public void TestMinWidth() {
            _option.MinWidth( 100 ).Begin();
            AssertResult( "width:100,minWidth:100" );
        }

        /// <summary>
        /// 设置最小高度
        /// </summary>
        [TestMethod]
        public void TestMinHeight() {
            _option.MinHeight( 100 ).Begin();
            AssertResult( "height:100,minHeight:100" );
        }

        /// <summary>
        /// 设置最大宽度
        /// </summary>
        [TestMethod]
        public void TestMaxWidth() {
            _option.MaxWidth( 100 ).Begin();
            AssertResult( "maxWidth:100" );
        }

        /// <summary>
        /// 设置最大高度
        /// </summary>
        [TestMethod]
        public void TestMaxHeight() {
            _option.MaxHeight( 100 ).Begin();
            AssertResult( "maxHeight:100" );
        }
    }
}
