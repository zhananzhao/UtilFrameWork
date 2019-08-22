using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Layouts;
using Util.Webs.TextWriters;

namespace Util.Webs.EasyUi.Tests.Layouts {
    /// <summary>
    /// 选项卡面板
    /// </summary>
    [TestClass]
    public class TabPanelTest {
        /// <summary>
        /// 选项卡面板
        /// </summary>
        private TabPanel _option;
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
            _option = new TabPanel( _writer );
        }

        /// <summary>
        /// 验证结果
        /// </summary>
        private void AssertResult( string options = "" ) {
            var result = new Str();
            result.Add( "<div data-options=\"{0}\">",options );
            Assert.AreEqual( result.ToString(),  _writer.GetResult() );
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
            _option.Id( "a" ).Begin();
            AssertResult( "id:'a'" );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [TestMethod]
        public void TestTitle() {
            _option.Title( "a" ).Begin();
            AssertResult( "title:'a'" );
        }

        /// <summary>
        /// 测试允许折叠
        /// </summary>
        [TestMethod]
        public void TestCollapsible() {
            _option.Collapsible().Begin();
            AssertResult( "collapsible:true" );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [TestMethod]
        public void TestContent() {
            _option.Content( "a" ).Begin();
            AssertResult( "content:'a'" );
        }

        /// <summary>
        /// 测试远程加载url
        /// </summary>
        [TestMethod]
        public void TestUrl() {
            _option.Url( "a" ).Begin();
            AssertResult( "href:'a'" );
        }

        /// <summary>
        /// 测试设置缓存
        /// </summary>
        [TestMethod]
        public void TestCache() {
            _option.Cache( false ).Begin();
            AssertResult( "cache:false" );
        }

        /// <summary>
        /// 测试设置图标
        /// </summary>
        [TestMethod]
        public void TestIcon() {
            _option.Icon( "a" ).Begin();
            AssertResult( "iconCls:'a'" );
        }

        /// <summary>
        /// 测试允许关闭
        /// </summary>
        [TestMethod]
        public void TestClosable() {
            _option.Closable().Begin();
            AssertResult( "closable:true" );
        }

        /// <summary>
        /// 测试选中
        /// </summary>
        [TestMethod]
        public void TestSelect() {
            _option.Select().Begin();
            AssertResult( "selected:true" );
        }
    }
}
