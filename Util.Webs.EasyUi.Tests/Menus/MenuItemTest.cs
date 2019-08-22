using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Menus;

namespace Util.Webs.EasyUi.Tests.Menus {
    /// <summary>
    /// 菜单项测试
    /// </summary>
    [TestClass]
    public class MenuItemTest {
        /// <summary>
        /// 菜单项
        /// </summary>
        private MenuItem _item;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _item = new MenuItem();
        }

        /// <summary>
        /// 获取输出结果
        /// </summary>
        protected string GetResult( string options = "",string text= "" ) {
            var result = new Str();
            result.Add( "<div " );
            if ( !options.IsEmpty() ) {
                result.Add( "data-options=\"{0}\"", options );
            }
            result.Add( ">{0}",text );
            result.Add( "</div>" );
            return result.ToString();
        }

        /// <summary>
        /// 断言
        /// </summary>
        protected void AssertResult( string options = "", string text = "" ) {
            Assert.AreEqual( GetResult( options, text ), _item.ToHtmlString() );
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            AssertResult();
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [TestMethod]
        public void TestText() {
            _item.Text( "a" );
            AssertResult( "","a" );
        }

        /// <summary>
        /// 测试图标
        /// </summary>
        [TestMethod]
        public void TestIcon() {
            _item.Icon( "a" );
            AssertResult( "iconCls:'a'" );
        }

        /// <summary>
        /// 设置Url
        /// </summary>
        [TestMethod]
        public void TestHref() {
            _item.Href( "a" );
            AssertResult( "href:'a'" );
        }

        /// <summary>
        /// 禁用菜单项
        /// </summary>
        [TestMethod]
        public void TestDisable() {
            _item.Disable();
            AssertResult( "disabled:true" );
        }

        /// <summary>
        /// 设置单击事件处理函数
        /// </summary>
        [TestMethod]
        public void TestClick() {
            _item.Click( "a" );
            Assert.AreEqual( "<div onclick=\"a\"></div>", _item.ToHtmlString() );
        }
    }
}
