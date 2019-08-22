using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Offices;

namespace Util.Tests.Offices {
    /// <summary>
    /// 表格测试
    /// </summary>
    [TestClass]
    public class TableTest {

        #region 测试初始化

        /// <summary>
        /// 表格
        /// </summary>
        private Table _table;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _table = new Table();
        }

        #endregion

        #region 测试默认值

        /// <summary>
        /// 测试默认值
        /// </summary>
        [TestMethod]
        public void Test_Default() {
            Assert.IsTrue( _table.GetHeader().Count == 0 );
            Assert.IsTrue( _table.GetBody().Count == 0 );
            Assert.AreEqual( 0, _table.ColumnNumber );
        }

        #endregion

        #region ColumnNumber(列数)

        /// <summary>
        /// 测试列数
        /// </summary>
        [TestMethod]
        public void TestColumnNumber_1() {
            _table.AddBodyRow( "a" );
            Assert.AreEqual( 1, _table.ColumnNumber );
        }

        /// <summary>
        /// 测试列数
        /// </summary>
        [TestMethod]
        public void TestColumnNumber_2() {
            _table.AddBodyRow( "a", 2 );
            Assert.AreEqual( 2, _table.ColumnNumber );
        }

        /// <summary>
        /// 测试列数
        /// </summary>
        [TestMethod]
        public void TestColumnNumber_3() {
            _table.AddHeadRow( "a" );
            Assert.AreEqual( 1, _table.ColumnNumber );
        }

        /// <summary>
        /// 测试列数
        /// </summary>
        [TestMethod]
        public void TestColumnNumber_4() {
            _table.AddHeadRow( "a", "b" );
            Assert.AreEqual( 2, _table.ColumnNumber );
        }

        /// <summary>
        /// 测试列数
        /// </summary>
        [TestMethod]
        public void TestColumnNumber_5() {
            _table.AddHeadRow( "a", "b" );
            _table.AddBodyRow( "a", 2 );
            Assert.AreEqual( 2, _table.ColumnNumber );
        }

        #endregion

        #region 自动调整第一行的列数

        /// <summary>
        /// 测试自动调整第一行的列数
        /// </summary>
        [TestMethod]
        public void TestFirstRow_1() {
            _table.AddHeadRow( "a" );
            Assert.AreEqual( 1, _table.GetHeader()[0].ColumnNumber );
            _table.AddHeadRow( "b", "c" );
            Assert.AreEqual( 2, _table.GetHeader()[0].ColumnNumber );
        }

        /// <summary>
        /// 测试自动调整第一行的列数
        /// </summary>
        [TestMethod]
        public void TestFirstRow_2() {
            _table.AddHeadRow( "a", "b" );
            Assert.AreEqual( 2, _table.GetHeader()[0].ColumnNumber );
            _table.AddHeadRow( "c", "d" );
            Assert.AreEqual( 2, _table.GetHeader()[0].ColumnNumber );
        }

        /// <summary>
        /// 测试自动调整第一行的列数
        /// </summary>
        [TestMethod]
        public void TestFirstRow_3() {
            _table.AddHeadRow( "a" );
            Assert.AreEqual( 1, _table.GetHeader()[0].ColumnNumber );
            _table.AddBodyRow( "c", "d" );
            Assert.AreEqual( 2, _table.GetHeader()[0].ColumnNumber );
        }

        #endregion

        #region AddHeadRow(添加表头)

        /// <summary>
        /// 添加表头
        /// </summary>
        [TestMethod]
        public void TestAddHeadRow_1() {
            _table.AddHeadRow( "a" );
            Assert.IsTrue( _table.GetHeader().Count == 1 );
            Assert.AreEqual( "a", _table.GetHeader()[0][0].Value );
            Assert.AreEqual( 1, _table.GetHeader()[0][0].ColumnSpan );
            Assert.AreEqual( 1, _table.GetHeader()[0][0].RowSpan );
            Assert.AreEqual( 0, _table.GetHeader()[0][0].RowIndex );
            Assert.AreEqual( 0, _table.GetHeader()[0][0].ColumnIndex );
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        [TestMethod]
        public void TestAddHeadRow_2() {
            _table.AddHeadRow( "a", "b" );
            Assert.IsTrue( _table.GetHeader().Count == 1, _table.GetHeader().Count.ToString() );
            Assert.AreEqual( "a", _table.GetHeader()[0][0].Value );
            Assert.AreEqual( "b", _table.GetHeader()[0][1].Value );
            Assert.AreEqual( 1, _table.GetHeader()[0][1].ColumnSpan );
            Assert.AreEqual( 1, _table.GetHeader()[0][1].RowSpan );
            Assert.AreEqual( 0, _table.GetHeader()[0][1].RowIndex );
            Assert.AreEqual( 1, _table.GetHeader()[0][1].ColumnIndex );
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        [TestMethod]
        public void TestAddHeadRow_3() {
            _table.AddHeadRow( "a", "b" );
            _table.AddHeadRow( "c", "d" );
            Assert.IsTrue( _table.GetHeader().Count == 2, _table.GetHeader().Count.ToString() );
            Assert.AreEqual( "a", _table.GetHeader()[0][0].Value );
            Assert.AreEqual( "b", _table.GetHeader()[0][1].Value );
            Assert.AreEqual( "c", _table.GetHeader()[1][0].Value );
            Assert.AreEqual( "d", _table.GetHeader()[1][1].Value );
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        [TestMethod]
        public void TestAddHeadRow_4() {
            _table.AddHeadRow( new Cell( "a" ) );
            Assert.IsTrue( _table.GetHeader().Count == 1 );
            Assert.AreEqual( "a", _table.GetHeader()[0][0].Value );
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        [TestMethod]
        public void TestAddHeadRow_5() {
            _table.AddHeadRow( "a" );
            _table.AddHeadRow( "a", "b" );
            Assert.IsTrue( _table.GetHeader().Count == 2 );
            Assert.AreEqual( "a", _table.GetHeader()[0][0].Value );
            Assert.AreEqual( 2, _table.GetHeader()[0][0].ColumnSpan );
            Assert.AreEqual( 2, _table.ColumnNumber );
        }

        /// <summary>
        /// 添加表头
        /// </summary>
        [TestMethod]
        public void TestAddHeadRow_6() {
            _table.AddHeadRow( new Cell( "a" ) );
            _table.AddHeadRow( new Cell( "a" ), new Cell( "b", 2 ) );
            Assert.IsTrue( _table.GetHeader().Count == 2 );
            Assert.AreEqual( "a", _table.GetHeader()[0][0].Value );
            Assert.AreEqual( 3, _table.GetHeader()[0][0].ColumnSpan );
            Assert.AreEqual( 3, _table.ColumnNumber );
        }

        /// <summary>
        /// 当设置行跨度时，将为受影响的行添加占位单元格
        /// </summary>
        [TestMethod]
        public void TestAddHeadRow_7() {
            _table.AddHeadRow( new Cell( "a", 1, 2 ) );
            Assert.IsTrue( _table.GetHeader().Count == 2, "==2" );
            Assert.AreEqual( 0, _table.GetHeader()[1][0].ColumnIndex );
            Assert.IsTrue( _table.GetHeader()[1][0].IsNull(), "IsNull" );
        }

        /// <summary>
        /// 为受影响的行添加占位单元格
        /// </summary>
        [TestMethod]
        public void TestAddHeadRow_8() {
            _table.AddHeadRow( new Cell( "a", 1, 3 ), new Cell( "b", 1, 3 ), new Cell( "c", 1, 3 ), new Cell( "d", 2, 2 ) );
            _table.AddHeadRow( new Cell( "e", 2 ) );
            Assert.IsTrue( _table.GetHeader().Count == 3, "==3" );
            Assert.AreEqual( "e", _table.GetHeader()[1][4].Value.ToString() );
            Assert.AreEqual( 5, _table.GetHeader()[1][4].ColumnIndex );
        }

        #endregion

        #region HeadRowCount(表头行数)

        /// <summary>
        /// 测试表头行数
        /// </summary>
        [TestMethod]
        public void TestHeadRowCount() {
            Assert.AreEqual( 0, _table.HeadRowCount );
            _table.AddHeadRow( "a", "b" );
            Assert.AreEqual( 1, _table.HeadRowCount );
            _table.AddHeadRow( "a", "b" );
            Assert.AreEqual( 2, _table.HeadRowCount );
        }

        #endregion

        #region AddBodyRow(添加正文)

        /// <summary>
        /// 添加正文
        /// </summary>
        [TestMethod]
        public void TestAddBodyRow() {
            Assert.AreEqual( 0, _table.GetBody().Count );
            _table.AddBodyRow( "a", 1 );
            Assert.AreEqual( 1, _table.GetBody().Count );
            Assert.AreEqual( "a", _table.GetBody()[0][0].Value.ToString() );
            Assert.AreEqual( "1", _table.GetBody()[0][1].Value.ToString() );
            _table.AddBodyRow( "b" );
            Assert.AreEqual( 2, _table.GetBody().Count );
        }

        #endregion

        #region Title(总标题)

        /// <summary>
        /// 测试总标题
        /// </summary>
        [TestMethod]
        public void TestTitle() {
            Assert.AreEqual( "", _table.Title );
            _table.AddBodyRow( "a" );
            Assert.AreEqual( "", _table.Title );
            _table.AddHeadRow( "a", "b" );
            Assert.AreEqual( "", _table.Title );
            _table.ClearHeader();
            _table.AddHeadRow( "a" );
            Assert.AreEqual( "a", _table.Title );
            _table.AddHeadRow( "c", "d" );
            Assert.AreEqual( "a", _table.Title );
        }

        #endregion
    }
}
