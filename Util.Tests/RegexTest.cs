using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests {
    /// <summary>
    /// 正则表达式操作测试
    /// </summary>
    [TestClass]
    public class RegexTest {
        /// <summary>
        /// 测试是否匹配模式
        /// </summary>
        [TestMethod]
        public void TestIsMatch() {
            string pattern = @"^\d.*";
            Assert.IsFalse( Regex.IsMatch( "abc",pattern ) );
            Assert.IsTrue( Regex.IsMatch( "123", pattern ) );
        }
    }
}
