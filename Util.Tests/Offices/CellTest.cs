using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Offices;

namespace Util.Tests.Offices {
    /// <summary>
    /// 单元格测试
    /// </summary>
    [TestClass]
    public class CellTest {
        /// <summary>
        /// 单元格
        /// </summary>
        private Cell _cell;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _cell = new Cell( "a" );
            _cell.Row = new Row(2);
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [TestMethod]
        public void TestValue() {
            Assert.AreEqual( "a",_cell.Value.ToString() );
        }

        /// <summary>
        /// 验证行为空时获取行索引
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRowIndex_Validate_RowIsNull() {
            _cell.Row = null;
            var index = _cell.RowIndex;
        }

        /// <summary>
        /// 测试行索引
        /// </summary>
        [TestMethod]
        public void TestRowIndex() {
            Assert.AreEqual( 2, _cell.RowIndex );
        }

        /// <summary>
        /// 测试列索引
        /// </summary>
        [TestMethod]
        public void TestColumnIndex() {
            Assert.AreEqual( 0,_cell.ColumnIndex );
        }

        /// <summary>
        /// 测试结束行索引
        /// </summary>
        [TestMethod]
        public void TestEndRowIndex() {
            Assert.AreEqual( 2, _cell.EndRowIndex );
            _cell.RowSpan = 2;
            Assert.AreEqual( 3, _cell.EndRowIndex );
            _cell.RowSpan = 0;
            Assert.AreEqual( 2, _cell.EndRowIndex );
            _cell.RowSpan = -1;
            Assert.AreEqual( 2, _cell.EndRowIndex );
        }

        /// <summary>
        /// 测试结束列索引
        /// </summary>
        [TestMethod]
        public void TestEndColumnIndex() {
            Assert.AreEqual( 0, _cell.EndColumnIndex );
            _cell.ColumnSpan = 2;
            Assert.AreEqual( 1, _cell.EndColumnIndex );
            _cell.ColumnSpan = 0;
            Assert.AreEqual( 0, _cell.EndColumnIndex );
            _cell.ColumnSpan = -1;
            Assert.AreEqual( 0, _cell.EndColumnIndex );
        }

        /// <summary>
        /// 测试是否需要合并
        /// </summary>
        [TestMethod]
        public void TestNeedMerge() {
            Assert.IsFalse( _cell.NeedMerge );
            _cell.RowSpan = 2;
            Assert.IsTrue( _cell.NeedMerge, "RowSpan = 2" );
            _cell.RowSpan = 1;
            _cell.ColumnSpan = 2;
            Assert.IsTrue( _cell.NeedMerge, "ColumnSpan = 2" );
            _cell.RowSpan = 2;
            _cell.ColumnSpan = 2;
            Assert.IsTrue( _cell.NeedMerge, "RowSpan = 2 && ColumnSpan = 2" );
        }
    }
}
