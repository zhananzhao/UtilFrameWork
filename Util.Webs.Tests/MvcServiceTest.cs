using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Webs.Tests {
    /// <summary>
    /// Mvc服务测试
    /// </summary>
    [TestClass]
    public class MvcServiceTest {
        /// <summary>
        /// Mvc服务
        /// </summary>
        private IMvcService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _service = new MvcService();
        }

        /// <summary>
        /// 导入Css
        /// </summary>
        [TestMethod]
        public void TestImportCss() {
            Assert.AreEqual( "<link rel=\"stylesheet\" type=\"text/css\" href=\"/Js/a.css\" />",_service.ImportCss( "/Js/a.css" ).ToString() );
        }

        /// <summary>
        /// 导入Js
        /// </summary>
        [TestMethod]
        public void TestImportJs() {
            Str expected = new Str();
            expected.Add( "<script type=\"text/javascript\" " );
            expected.Add( "src=\"/Js/a.js\" />" );
            Assert.AreEqual( "<script type=\"text/javascript\" src=\"/Js/a.js\"></script>", _service.ImportJs( "/Js/a.js" ).ToString() );
        }
    }
}
