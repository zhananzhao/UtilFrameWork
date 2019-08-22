using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Offices;

namespace Util.Tests.Offices {
    /// <summary>
    /// 行测试
    /// </summary>
    [TestClass]
    public class RowTest {
        /// <summary>
        /// 行
        /// </summary>
        private Row _row;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _row = new Row( 2 );
        }

        /// <summary>
        /// 测试列数
        /// </summary>
        [TestMethod]
        public void TestColumnNumber() {
            _row.Add( "a" );
            Assert.AreEqual( 1, _row.ColumnNumber );
            _row.Add( "a", 2, 3 );
            Assert.AreEqual( 3, _row.ColumnNumber );
            _row.Add( new Cell( "a", 3, 2 ) );
            Assert.AreEqual( 6, _row.ColumnNumber );
        }

        /// <summary>
        /// 测试添加单元格时自动设置列索引
        /// </summary>
        [TestMethod]
        public void TestAdd_1() {
            _row.Add( "a" );
            Assert.AreEqual( 0, _row.Cells[0].ColumnIndex );
        }

        /// <summary>
        /// 设置列跨度
        /// </summary>
        [TestMethod]
        public void TestAdd_2() {
            _row.Add( "a", 2 );
            Assert.AreEqual( 0, _row.Cells[0].ColumnIndex );
            _row.Add( "b" );
            Assert.AreEqual( 2, _row.Cells[1].ColumnIndex );
        }

        /// <summary>
        /// 添加空单元格
        /// </summary>
        [TestMethod]
        public void TestAdd_3() {
            _row.Add( new NullCell() { ColumnSpan = 2 } );
            _row.Add( "b" );
            Assert.AreEqual( 2, _row.Cells[1].ColumnIndex );
        }

        /// <summary>
        /// 添加两个连续空单元格
        /// </summary>
        [TestMethod]
        public void TestAdd_4() {
            _row.Add( new NullCell(){ColumnSpan = 2} );
            _row.Add( new NullCell() { ColumnSpan = 5 } );
            _row.Add( "b" );
            Assert.AreEqual("b", _row.Cells[2].Value.ToString() );
            Assert.AreEqual( 7, _row.Cells[2].ColumnIndex );
        }

        /// <summary>
        /// 添加两个不连续空单元格
        /// </summary>
        [TestMethod]
        public void TestAdd_5() {
            _row.Add( new NullCell() { ColumnSpan = 2 } );
            _row.Add( new NullCell() { ColumnIndex = 5 } );
            Assert.AreEqual( 5, _row.Cells[1].ColumnIndex );
        }

        /// <summary>
        /// 向两个空单元格中插入
        /// </summary>
        [TestMethod]
        public void TestAdd_6() {
            _row.Add( new NullCell() { ColumnSpan = 2 } );
            _row.Add( new NullCell() { ColumnIndex = 5 } );
            _row.Add( "b" );
            Assert.AreEqual( "b", _row.Cells[2].Value.ToString() );
            Assert.AreEqual( 2, _row.Cells[2].ColumnIndex );
        }

        /// <summary>
        /// 向两个空单元格中插入
        /// </summary>
        [TestMethod]
        public void TestAdd_7() {
            _row.Add( new NullCell() { ColumnSpan = 2 } );
            _row.Add( new NullCell() { ColumnIndex = 5 } );
            _row.Add( "a",3 );
            _row.Add( "b" );
            Assert.AreEqual( "a", _row.Cells[2].Value.ToString() );
            Assert.AreEqual( 2, _row.Cells[2].ColumnIndex );
            Assert.AreEqual( "b", _row.Cells[3].Value.ToString() );
            Assert.AreEqual( 6, _row.Cells[3].ColumnIndex );
        }
    }
}
