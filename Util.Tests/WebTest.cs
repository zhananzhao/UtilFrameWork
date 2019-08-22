using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests {
    /// <summary>
    /// Web单元测试
    /// </summary>
    [TestClass]
    public class WebTest {
        /// <summary>
        /// 解析相对Url,验证空值
        /// </summary>
        [TestMethod]
        public void TestResolveUrl_Validate_Empty() {
            Assert.AreEqual( "",Web.ResolveUrl( null ) );
            Assert.AreEqual( "", Web.ResolveUrl( "" ) );
        }

        /// <summary>
        /// 解析相对Url,如果是根路径，直接返回，并修正反斜杠
        /// </summary>
        [TestMethod]
        public void TestResolveUrl_RootPath() {
            Assert.AreEqual( "/a.js",Web.ResolveUrl( "/a.js" ) );
            Assert.AreEqual( "/a/b.js", Web.ResolveUrl( @"\a\b.js" ) );
        }

        /// <summary>
        /// 解析相对Url,如果是Http绝对路径，则直接返回
        /// </summary>
        [TestMethod]
        public void TestResolveUrl_Http() {
            Assert.AreEqual( "http://a.js", Web.ResolveUrl( "http://a.js" ) );
        }
    }
}
