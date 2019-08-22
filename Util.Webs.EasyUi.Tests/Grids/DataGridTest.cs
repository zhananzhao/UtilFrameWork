using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Grids;

namespace Util.Webs.EasyUi.Tests.Grids {
    /// <summary>
    /// 表格测试
    /// </summary>
    [TestClass]
    public class DataGridTest {
        /// <summary>
        /// 表格
        /// </summary>
        private DataGrid _grid;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _grid = new DataGrid();
        }

        /// <summary>
        /// 获取输出结果
        /// </summary>
        protected string GetResult( string option = "", string columns = "" ) {
            var result = new Str();
            result.Add( "<table class=\"easyui-datagrid\"", option );
            if ( !option.IsEmpty() )
                result.Add( " data-options=\"{0}\"", option );
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
        protected void AssertResult( string option = "", string columns = "" ) {
            Assert.AreEqual( GetResult( option, columns ), _grid.ToHtmlString() );
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            AssertResult();
        }

        /// <summary>
        /// 测试生成行号
        /// </summary>
        [TestMethod]
        public void TestRowNumber() {
            _grid.RowNumber();
            AssertResult( "rownumbers:true" );
        }

        /// <summary>
        /// 测试自适应布局
        /// </summary>
        [TestMethod]
        public void TestFit() {
            _grid.Fit();
            AssertResult( "fit:true" );
        }

        /// <summary>
        /// 测试列自适应
        /// </summary>
        [TestMethod]
        public void TestFitColumns() {
            _grid.FitColumns();
            AssertResult( "fitColumns:true" );
        }

        /// <summary>
        /// 测试分页
        /// </summary>
        [TestMethod]
        public void TestPagination() {
            _grid.Pagination( true, 30 );
            AssertResult( "pagination:true,pageSize:30" );
        }

        /// <summary>
        /// 测试排序
        /// </summary>
        [TestMethod]
        public void TestSort() {
            _grid.Sort( "b", false );
            AssertResult( "sortName:'b'" );
            _grid.Sort( "a" );
            AssertResult( "sortName:'a',sortOrder:'desc'" );
        }

        /// <summary>
        /// 测试选择表格行时是否同时选中复选框
        /// </summary>
        [TestMethod]
        public void TestCheckOnSelect() {
            _grid.CheckOnSelect( false );
            AssertResult( "checkOnSelect:false" );
        }

        /// <summary>
        /// 测试选中复选框时是否同时选中表格行
        /// </summary>
        [TestMethod]
        public void TestSelectOnCheck() {
            _grid.SelectOnCheck( false );
            AssertResult( "selectOnCheck:false" );
        }

        /// <summary>
        /// 测试是否只能选中一行
        /// </summary>
        [TestMethod]
        public void TestSingleSelect() {
            _grid.SingleSelect();
            AssertResult( "singleSelect:true" );
        }

        /// <summary>
        /// 测试显示条纹
        /// </summary>
        [TestMethod]
        public void TestStrip() {
            _grid.Strip();
            AssertResult( "striped:true" );
        }

        /// <summary>
        /// 测试设置工具栏Id
        /// </summary>
        [TestMethod]
        public void TestToolbar() {
            _grid.Toolbar( "a" );
            AssertResult( "toolbar:'#a'" );
        }

        /// <summary>
        /// 测试设置加载数据的Url
        /// </summary>
        [TestMethod]
        public void TestUrl() {
            _grid.Url( "a" );
            AssertResult( "url:'a'" );
        }

        /// <summary>
        /// 测试设置双击行事件
        /// </summary>
        [TestMethod]
        public void TestOnDblClickRow() {
            _grid.OnDblClickRow( "a" );
            AssertResult( "onDblClickRow:a" );
        }

        /// <summary>
        /// 测试设置右键单击行事件
        /// </summary>
        [TestMethod]
        public void TestOnContextMenu() {
            _grid.OnContextMenu( "a" );
            AssertResult( "onRowContextMenu:a" );
        }

        /// <summary>
        /// 测试列集合
        /// </summary>
        [TestMethod]
        public void TestColumns() {
            var column = new DataGridColumn();
            var column2 = new DataGridColumn();
            _grid.Columns( column, column2 );
            AssertResult( "", column.ToHtmlString() + column2.ToHtmlString() );
        }

        /// <summary>
        /// 测试冻结列
        /// </summary>
        [TestMethod]
        public void TestFrozenColumns() {
            var column = new DataGridColumn();
            column.Frozen();
            var column2 = new DataGridColumn();
            var column3 = new DataGridColumn();
            column3.Frozen();
            _grid.Columns( column, column2, column3 );
            var result = new Str();
            result.Add( "<table class=\"easyui-datagrid\">" );
            result.Add( "<thead data-options=\"frozen:true\"><tr>" );
            result.Add( column.ToHtmlString() );
            result.Add( column3.ToHtmlString() );
            result.Add( "</tr></thead>" );
            result.Add( "<thead><tr>" );
            result.Add( column2.ToHtmlString() );
            result.Add( "</tr></thead>" );
            result.Add( "</table>" );
            Assert.AreEqual( result.ToString(), _grid.ToHtmlString() );
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
            result.Add( "<table class=\"easyui-edatagrid\">" );
            result.Add( "<thead><tr>" );
            result.Add( column.ToHtmlString() );
            result.Add( "</tr></thead>" );
            result.Add( "</table>" );
            Assert.AreEqual( result.ToString(), _grid.ToHtmlString() );
        }

        /// <summary>
        /// 测试设置加载成功事件
        /// </summary>
        [TestMethod]
        public void TestOnLoadSuccess() {
            _grid.OnLoadSuccess( "a" );
            AssertResult( "onLoadSuccess:a" );
        }

        /// <summary>
        /// 测试子表格
        /// </summary>
        [TestMethod]
        public void TestSubGrid() {
            _grid.SubGrid( new SubDataGrid().Property( "a" ).Columns( new SubGridColumn().Field( "b" ).Text( "c" ) ) );
            var option = new Str();
            option.Add( "{" );
            option.Add( "'options':{}," );
            option.Add( "'subgrid':{" );
            option.Add( "'options':{" );
            option.Add( "'property':'a'," );
            option.Add( "'columns':[[" );
            option.Add( "{'field':'b','title':'c'}" );
            option.Add( "]]" );
            option.Add( "}}}" );
            AssertResult( string.Format( "onLoadSuccess:$.easyui.loadSubGrid_onLoadSuccess({0})", option ) );
        }

        /// <summary>
        /// 测试行展开详细内容
        /// </summary>
        [TestMethod]
        public void TestDetail() {
            _grid.Detail( "a",true,"b","c","d" );
            AssertResult( "view:detailview,detailFormatter:$.easyui.gridDetail_detailFormatter(),onExpandRow:$.easyui.gridDetail_onExpandRow('a',true,b,'c','d')" );
        }

        /// <summary>
        /// 测试右键菜单
        /// </summary>
        [TestMethod]
        public void TestMenu() {
            _grid.Menu();
            AssertResult( "onRowContextMenu:$.easyui.showGridMenu_onRowContextMenu('')" );

            _grid.Menu( "a" );
            AssertResult( "onRowContextMenu:$.easyui.showGridMenu_onRowContextMenu('a')" );

            _grid.Menu( "a","b" );
            AssertResult( "onRowContextMenu:$.easyui.showGridMenu_onRowContextMenu('a','b')" );
        }

        /// <summary>
        /// 测试双击打开编辑窗口
        /// </summary>
        [TestMethod]
        public void TestShowEditDialogByDblClick() {
            _grid.ShowEditDialogByDblClick("a");
            AssertResult( "onDblClickRow:$.easyui.showEditDialog_onDblClickRow('a')" );
        }
    }
}
