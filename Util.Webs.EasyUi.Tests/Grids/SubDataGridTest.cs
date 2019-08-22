using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Grids;

namespace Util.Webs.EasyUi.Tests.Grids {
    /// <summary>
    /// 子表格测试
    /// </summary>
    [TestClass]
    public class SubDataGridTest {
        /// <summary>
        /// 子表格
        /// </summary>
        private SubDataGrid _grid;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _grid = new SubDataGrid();
        }

        /// <summary>
        /// 测试生成行号
        /// </summary>
        [TestMethod]
        public void TestRowNumber() {
            _grid.RowNumber();
            Assert.AreEqual( "{'rownumbers':true}", _grid.ToString() );
        }

        /// <summary>
        /// 测试自适应布局
        /// </summary>
        [TestMethod]
        public void TestFit() {
            _grid.Fit();
            Assert.AreEqual( "{'fit':true}", _grid.ToString() );
        }

        /// <summary>
        /// 测试列自适应
        /// </summary>
        [TestMethod]
        public void TestFitColumns() {
            _grid.FitColumns();
            Assert.AreEqual( "{'fitColumns':true}", _grid.ToString() );
        }

        /// <summary>
        /// 测试分页
        /// </summary>
        [TestMethod]
        public void TestPagination() {
            _grid.Pagination( true, 30 );
            Assert.AreEqual( "{'pagination':true,'pageSize':30}", _grid.ToString() );
        }

        /// <summary>
        /// 测试排序
        /// </summary>
        [TestMethod]
        public void TestSort() {
            _grid.Sort( "a" );
            Assert.AreEqual( "{'sortName':'a','sortOrder':'desc'}", _grid.ToString() );
        }

        /// <summary>
        /// 测试选择表格行时是否同时选中复选框
        /// </summary>
        [TestMethod]
        public void TestCheckOnSelect() {
            _grid.CheckOnSelect( false );
            Assert.AreEqual( "{'checkOnSelect':false}", _grid.ToString() );
        }

        /// <summary>
        /// 测试选中复选框时是否同时选中表格行
        /// </summary>
        [TestMethod]
        public void TestSelectOnCheck() {
            _grid.SelectOnCheck( false );
            Assert.AreEqual( "{'selectOnCheck':false}", _grid.ToString() );
        }

        /// <summary>
        /// 测试是否只能选中一行
        /// </summary>
        [TestMethod]
        public void TestSingleSelect() {
            _grid.SingleSelect();
            Assert.AreEqual( "{'singleSelect':true}", _grid.ToString() );
        }

        /// <summary>
        /// 测试显示条纹
        /// </summary>
        [TestMethod]
        public void TestStrip() {
            _grid.Strip();
            Assert.AreEqual( "{'striped':true}", _grid.ToString() );
        }

        /// <summary>
        /// 测试设置加载数据的Url
        /// </summary>
        [TestMethod]
        public void TestUrl() {
            _grid.Url( "a" );
            Assert.AreEqual( "{'url':'a'}", _grid.ToString() );
        }

        /// <summary>
        /// 测试设置双击行事件
        /// </summary>
        [TestMethod]
        public void TestOnDblClickRow() {
            _grid.OnDblClickRow( "a" );
            Assert.AreEqual( "{'onDblClickRow':a}", _grid.ToString() );
        }

        /// <summary>
        /// 测试设置右键单击行事件
        /// </summary>
        [TestMethod]
        public void TestOnContextMenu() {
            _grid.OnContextMenu( "a" );
            Assert.AreEqual( "{'onRowContextMenu':a}", _grid.ToString() );
        }

        /// <summary>
        /// 测试设置加载成功事件
        /// </summary>
        [TestMethod]
        public void TestOnLoadSuccess() {
            _grid.OnLoadSuccess( "a" );
            Assert.AreEqual( "{'onLoadSuccess':a}", _grid.ToString() );
        }

        /// <summary>
        /// 测试添加列
        /// </summary>
        [TestMethod]
        public void TestColumns() {
            _grid.Columns( new SubGridColumn().Field( "a" ) );
            Assert.AreEqual( "{'columns':[[{'field':'a'}]]}", _grid.ToString() );
            _grid.Columns( new SubGridColumn().Field( "b" ) );
            Assert.AreEqual( "{'columns':[[{'field':'a'},{'field':'b'}]]}", _grid.ToString() );
        }

        /// <summary>
        /// 测试子表格
        /// </summary>
        [TestMethod]
        public void TestSubGrid() {
            _grid.SubGrid( new SubDataGrid() );
            Assert.AreEqual( "{'options':{},'subgrid':{'options':{}}}", _grid.GetOption().ToString() );
        }
    }
}
