using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Grids;

namespace Util.Webs.EasyUi.Tests.Grids {
    /// <summary>
    /// 子表格列测试
    /// </summary>
    [TestClass]
    public class SubGridColumnTest {
        /// <summary>
        /// 子表格列
        /// </summary>
        private SubGridColumn _column;

        /// <summary>
        /// 初始化测试
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _column = new SubGridColumn();
        }

        /// <summary>
        /// 测试字段
        /// </summary>
        [TestMethod]
        public void TestField() {
            _column.Field( "a" );
            Assert.AreEqual( "{'field':'a'}",_column.ToString() );
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [TestMethod]
        public void TestText() {
            _column.Text( "a" );
            Assert.AreEqual( "{'title':'a'}", _column.ToString() );
        }

        /// <summary>
        /// 测试对齐方式
        /// </summary>
        [TestMethod]
        public void TestAlign() {
            _column.Align( AlignLeftRigthCenter.Center, AlignLeftRigthCenter.Center );
            Assert.AreEqual( "{'halign':'center','align':'center'}", _column.ToString() );
        }

        /// <summary>
        /// 测试复选框
        /// </summary>
        [TestMethod]
        public void TestCheckBox() {
            _column.CheckBox();
            Assert.AreEqual( "{'checkbox':true}", _column.ToString() );
        }

        /// <summary>
        /// 测试格式化
        /// </summary>
        [TestMethod]
        public void TestFormat() {
            _column.Format( "a" );
            Assert.AreEqual( "{'formatter':a}", _column.ToString() );
        }

        /// <summary>
        /// 测试格式化布尔值
        /// </summary>
        [TestMethod]
        public void TestFormatBool() {
            _column.FormatBool();
            Assert.AreEqual( "{'formatter':$.easyui.formatBool}", _column.ToString() );
        }

        /// <summary>
        /// 测试格式化日期
        /// </summary>
        [TestMethod]
        public void TestFormatDate() {
            _column.FormatDate();
            Assert.AreEqual( "{'formatter':$.easyui.formatDate}", _column.ToString() );
        }

        /// <summary>
        /// 测试宽度
        /// </summary>
        [TestMethod]
        public void TestWidth() {
            _column.Width( 10 );
            Assert.AreEqual( "{'width':'10'}", _column.ToString() );
            _column.Width( 10,true );
            Assert.AreEqual( "{'width':'10%'}", _column.ToString() );
        }

        /// <summary>
        /// 测试高度
        /// </summary>
        [TestMethod]
        public void TestHeight() {
            _column.Height( 10 );
            Assert.AreEqual( "{'height':10}", _column.ToString() );
        }
    }
}
