using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Menus;

namespace Util.Webs.EasyUi.Tests.Menus {
    /// <summary>
    /// 菜单测试
    /// </summary>
    [TestClass]
    public class MenuTest {
        /// <summary>
        /// 菜单
        /// </summary>
        private Menu _menu;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _menu = new Menu( "a" );
        }

        /// <summary>
        /// 获取输出结果
        /// </summary>
        protected string GetResult( string options = "",string items = "" ) {
            var result = new Str();
            result.Add( "<div id=\"a\" class=\"easyui-menu\"" );
            if ( !options.IsEmpty() )
                result.Add( " data-options=\"{0}\"", options );
            result.Add( ">" );
            if ( !items.IsEmpty() )
                result.Add( items );
            result.Add( "</div>" );
            return result.ToString();
        }

        /// <summary>
        /// 断言
        /// </summary>
        protected void AssertResult( string options = "", string items = "" ) {
            Assert.AreEqual( GetResult( options, items ), _menu.ToHtmlString() );
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            AssertResult();
        }

        /// <summary>
        /// 测试zIndex
        /// </summary>
        [TestMethod]
        public void TestZIndex() {
            _menu.ZIndex( 1 );
            AssertResult( "zIndex:1" );
        }

        /// <summary>
        /// 测试位置
        /// </summary>
        [TestMethod]
        public void TestPosition() {
            _menu.Position( 1,2 );
            AssertResult( "left:1,top:2" );
        }

        /// <summary>
        /// 测试最小宽度
        /// </summary>
        [TestMethod]
        public void TestMinWidth() {
            _menu.MinWidth(1);
            AssertResult( "minWidth:1" );
        }

        /// <summary>
        /// 测试显示持续时间
        /// </summary>
        [TestMethod]
        public void TestDuration() {
            _menu.Duration( 1 );
            AssertResult( "duration:1" );
        }

        /// <summary>
        /// 设置是否隐藏菜单
        /// </summary>
        [TestMethod]
        public void TestHideOnUnhover() {
            _menu.HideOnUnHover( false );
            AssertResult( "hideOnUnhover:false" );
        }

        /// <summary>
        /// 设置单击事件
        /// </summary>
        [TestMethod]
        public void TestClick() {
            _menu.Click( "a" );
            AssertResult( "onClick:a" );
        }

        /// <summary>
        /// 设置菜单项
        /// </summary>
        [TestMethod]
        public void TestItems() {
            _menu.Items( new MenuItem() );
            AssertResult( "","<div ></div>" );

            _menu.Items( new MenuItem() );
            AssertResult( "", "<div ></div><div ></div>" );
        }
    }
}
