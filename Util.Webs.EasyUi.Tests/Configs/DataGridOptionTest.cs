using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Configs;

namespace Util.Webs.EasyUi.Tests.Configs {
    /// <summary>
    /// 表格配置项测试
    /// </summary>
    [TestClass]
    public class DataGridOptionTest {
        /// <summary>
        /// 表格配置项
        /// </summary>
        private DataGridOption _option;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _option = new DataGridOption();
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            Assert.AreEqual( "{}", _option.ToString() ); 
        }

        /// <summary>
        /// 测试列集合
        /// </summary>
        [TestMethod]
        public void TestAddColumn_Validate_Null() {
            _option.AddColumn( null );
            Assert.AreEqual( "{}", _option.ToString() );
        }

        /// <summary>
        /// 测试列集合
        /// </summary>
        [TestMethod]
        public void TestAddColumn() {
            _option.AddColumn( new DataGridColumnOption() );
            Assert.AreEqual( "{'columns':[[{}]]}", _option.ToString() );
        }
    }
}
