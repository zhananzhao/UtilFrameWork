using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Configs;

namespace Util.Webs.EasyUi.Tests.Configs {
    /// <summary>
    /// 子表格配置项测试
    /// </summary>
    [TestClass]
    public class SubGridOptionTest {
        /// <summary>
        /// 子表格配置项
        /// </summary>
        private SubGridOption _option;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _option = new SubGridOption();
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            Assert.AreEqual( "{'options':{}}", _option.ToString() );
        }

        /// <summary>
        /// 测试表格项
        /// </summary>
        [TestMethod]
        public void TestOption() {
            _option.Options.FitColumns = true;
            Assert.AreEqual( "{'options':{'fitColumns':true}}", _option.ToString() );
        }

        /// <summary>
        /// 测试子表格项
        /// </summary>
        [TestMethod]
        public void TestSubGridOption() {
            var subGridOption = new SubGridOption { Options = { FitColumns = true } };
            _option.SetSubGrid( subGridOption );
            Assert.AreEqual( "{'options':{},'subgrid':{'options':{'fitColumns':true}}}", _option.ToString() );
        }
    }
}
