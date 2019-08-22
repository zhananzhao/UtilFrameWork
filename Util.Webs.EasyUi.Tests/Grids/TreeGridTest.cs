using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Grids;

namespace Util.Webs.EasyUi.Tests.Grids {
    /// <summary>
    /// 树型表格测试
    /// </summary>
    [TestClass]
    public class TreeGridTest {
        /// <summary>
        /// 表格
        /// </summary>
        private TreeGrid _grid;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _grid = new TreeGrid();
        }

        /// <summary>
        /// 获取输出结果
        /// </summary>
        protected string GetResult( string option = "", string columns = "", string attribute = "data-options" ) {
            var result = new Str();
            result.Add( "<table class=\"easyui-treegrid\"", option );
            if ( !option.IsEmpty() )
                result.Add( " {0}=\"{1}\"",attribute, option );
            result.Add( ">" );
            result.Add( "<thead><tr>" );
            if ( !columns.IsEmpty() )
                result.Add( columns );
            result.Add( "</tr></thead>" );
            result.Add( "</table>" );
            return result.ToString();
        }

        /// <summary>
        /// 断言
        /// </summary>
        protected void AssertResult( string option = "", string columns = "", string attribute = "data-options" ) {
            Assert.AreEqual( GetResult( option, columns, attribute ), _grid.ToHtmlString() );
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            AssertResult();
        }

        /// <summary>
        /// 设置Id字段
        /// </summary>
        [TestMethod]
        public void TestIdField() {
            _grid.IdField( "a" );
            AssertResult( "idField:'a'" );
        }

        /// <summary>
        /// 设置树字段名
        /// </summary>
        [TestMethod]
        public void TestTreeField() {
            _grid.TreeField("a");
            AssertResult( "treeField:'a'" );
        }

        /// <summary>
        /// 测试设置右键单击行事件
        /// </summary>
        [TestMethod]
        public void TestOnContextMenu() {
            _grid.OnContextMenu( "a" );
            AssertResult( "onContextMenu:a" );
        }

        /// <summary>
        /// 测试启用拖拽
        /// </summary>
        [TestMethod]
        public void TestEnableDrag() {
            _grid.EnableDrag();
            AssertResult( "1", "", "enableDrag" );
        }

        /// <summary>
        /// 测试启用拖拽，设置允许拖动的最小级数
        /// </summary>
        [TestMethod]
        public void TestEnableDrag_Level() {
            _grid.EnableDrag(2);
            AssertResult( "2", "", "enableDrag" );
        }

        /// <summary>
        /// 测试开启动画效果
        /// </summary>
        [TestMethod]
        public void TestAnimate() {
            _grid.Animate();
            AssertResult( "animate:true" );
        }

        /// <summary>
        /// 测试右键菜单
        /// </summary>
        [TestMethod]
        public void TestMenu() {
            _grid.Menu();
            AssertResult( "onContextMenu:$.easyui.showTreeGridMenu_onContextMenu('')" );

            _grid.Menu( "a" );
            AssertResult( "onContextMenu:$.easyui.showTreeGridMenu_onContextMenu('a')" );

            _grid.Menu( "a", "b" );
            AssertResult( "onContextMenu:$.easyui.showTreeGridMenu_onContextMenu('a','b')" );
        }

        /// <summary>
        /// 测试编辑状态
        /// </summary>
        [TestMethod]
        public void TestColumnEdit() {
            var column = new DataGridColumn();
            column.Edit();
            _grid.Columns( column );
            var result = new Str();
            result.Add( "<table class=\"easyui-etreegrid\">" );
            result.Add( "<thead><tr>" );
            result.Add( column.ToHtmlString() );
            result.Add( "</tr></thead>" );
            result.Add( "</table>" );
            Assert.AreEqual( result.ToString(), _grid.ToHtmlString() );
        }
    }
}
