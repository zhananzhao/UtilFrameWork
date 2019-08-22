using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Tests.Samples;

namespace Util.Tests {
    /// <summary>
    /// 系统操作测试
    /// </summary>
    [TestClass]
    public class SysTest {
        /// <summary>
        /// 克隆对象
        /// </summary>
        [TestMethod]
        public void TestClone() {
            Test2 test = new Test2 { Name = "a" };
            Test2 result = Sys.Clone( test );
            Assert.AreEqual( "a", result.Name );
            Assert.AreNotSame( test, result );
        }
    }
}
