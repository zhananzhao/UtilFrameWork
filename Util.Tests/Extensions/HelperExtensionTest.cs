using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests.Extensions {
    /// <summary>
    /// 工具扩展
    /// </summary>
    [TestClass]
    public class HelperExtensionTest {
        /// <summary>
        /// 转换为用分隔符拼接的字符串
        /// </summary>
        [TestMethod]
        public void TestSplice() {
            Assert.AreEqual( "1,2,3", new List<int> { 1, 2, 3 }.Splice() );
            Assert.AreEqual( "'1','2','3'", new List<int> { 1, 2, 3 }.Splice( "'" ) );
        }

        /// <summary>
        /// 截断字符串
        /// </summary>
        public void TestTruncate() {
            Assert.AreEqual( "abcd", "abcdef".Truncate( 4 ) );
            Assert.AreEqual( "abcd..", "abcdef".Truncate( 4, 2 ) );
            Assert.AreEqual( "abcd>>", "abcdef".Truncate( 4, 2, ">" ) );
            Assert.AreEqual( "ab", "ab".Truncate( 4 ) );
        }
    }
}
