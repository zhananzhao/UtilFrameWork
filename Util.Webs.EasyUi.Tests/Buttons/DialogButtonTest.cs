using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Buttons;

namespace Util.Webs.EasyUi.Tests.Buttons {
    /// <summary>
    /// 弹出窗口按钮测试
    /// </summary>
    [TestClass]
    public class DialogButtonTest {
        /// <summary>
        /// 弹出窗口按钮
        /// </summary>
        private DialogButton _button;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _button = new DialogButton( "a" );
        }

        /// <summary>
        /// 创建输出结果
        /// </summary>
        private string CreateResult( string name,string value ) {
            var result = new Str();
            result.Add( GetBaseOptions() );
            result.Add( "{0}:{1}", name, value );
            return CreateResult( result.ToString() );
        }

        /// <summary>
        /// 获取基础选项
        /// </summary>
        private string GetBaseOptions() {
            var result = new Str();
            result.Add( "title:'a'," );
            result.Add( "buttons:'dialogButtons'," );
            return result.ToString();
        }

        /// <summary>
        /// 创建输出结果
        /// </summary>
        private string CreateResult( string html ) {
            var result = new Str();
            result.Add( "<a href=\"javascript:void(0)\" class=\"easyui-linkbutton\" " );
            result.Add( "onClick=\"$.easyui.dialog({" );
            result.Add( html );
            result.Add( "})\"" );
            result.Add( ">a</a>" );
            return result.ToString();
        }

        /// <summary>
        /// 测试弹出网址
        /// </summary>
        [TestMethod]
        public void TestUrl() {
            _button.Url( "a" );
            Assert.AreEqual( CreateResult( "url", "'a'" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试弹出窗口底部按钮
        /// </summary>
        [TestMethod]
        public void TestButtons() {
            _button.Buttons( "a" );
            var result = new Str();
            result.Add( "title:'a'," );
            result.Add( "buttons:'a'" );
            Assert.AreEqual( CreateResult( result.ToString() ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试弹出窗口图标
        /// </summary>
        [TestMethod]
        public void TestDialogIcon() {
            _button.DialogIcon( "a" );
            Assert.AreEqual( CreateResult( "icon", "'a'" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试弹出窗口尺寸
        /// </summary>
        [TestMethod]
        public void TestDialogSize() {
            _button.DialogSize( 100,200 );
            var result = new Str();
            result.Add( GetBaseOptions() );
            result.Add( "width:100,height:200" );
            Assert.AreEqual( CreateResult( result.ToString() ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试允许弹出窗口最大化
        /// </summary>
        [TestMethod]
        public void TestMaximizable() {
            _button.Maximizable( false );
            Assert.AreEqual( CreateResult( "maximizable", "false" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试弹出窗口关闭回调函数
        /// </summary>
        [TestMethod]
        public void TestOnClose() {
            _button.OnClose( "a" );
            Assert.AreEqual( CreateResult( "closeCallback", "a" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试关闭弹出窗口
        /// </summary>
        [TestMethod]
        public void TestCloseDialog() {
            _button.CloseDialog();
            var result = new Str();
            result.Add( "<a href=\"javascript:void(0)\" class=\"easyui-linkbutton\" " );
            result.Add( "onClick=\"$.easyui.closeDialog()\"" );
            result.Add( ">a</a>" );
            Assert.AreEqual( result.ToString(), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试初始化事件
        /// </summary>
        [TestMethod]
        public void TestOnInit() {
            _button.OnInit( "a" );
            Assert.AreEqual( CreateResult( "onInit", "a" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试显示编辑窗口
        /// </summary>
        [TestMethod]
        public void TestShowEditDialog() {
            _button.ShowEditDialog();
            Assert.AreEqual( CreateResult( "onInit", "$.easyui.initEditDialog" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试显示详细窗口
        /// </summary>
        [TestMethod]
        public void TestShowDetailDialog() {
            _button.ShowDetailDialog();
            Assert.AreEqual( CreateResult( "onInit", "$.easyui.initDetailDialog" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试在控件后添加Html
        /// </summary>
        [TestMethod]
        public void TestAddAfter() {
            _button.AddAfter( "a" );
            Assert.AreEqual( "<a href=\"javascript:void(0)\" class=\"easyui-linkbutton\" onClick=\"$.easyui.dialog({title:'a',buttons:'dialogButtons'})\">a</a>a", _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试显示编辑窗口-树
        /// </summary>
        [TestMethod]
        public void TestShowEditDialogByTree() {
            _button.ShowEditDialogByTree( "a" );
            Assert.AreEqual( CreateResult( "onInit", "$.easyui.initEditDialogByTree('a')" ), _button.ToHtmlString() );
        }
    }
}
