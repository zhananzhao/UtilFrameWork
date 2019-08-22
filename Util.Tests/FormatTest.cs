using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests {
    /// <summary>
    /// 格式化测试
    /// </summary>
    [TestClass]
    public class FormatTest {
        /// <summary>
        /// 移除decimal尾随0
        /// </summary>
        [TestMethod]
        public void TestRemoveEnd0() {
            Assert.AreEqual( "0.12", Format.RemoveEnd0( 0.12M ) );
            Assert.AreEqual( "0.12", Format.RemoveEnd0( .12M ) );
            Assert.AreEqual( "12", Format.RemoveEnd0( 12M ) );
            Assert.AreEqual( "1200", Format.RemoveEnd0( 1200M ) );
            Assert.AreEqual( "120.01", Format.RemoveEnd0( 120.01M ) );
            Assert.AreEqual( "12", Format.RemoveEnd0( 12.00M ) );
            Assert.AreEqual( "12.00010001", Format.RemoveEnd0( 012.0001000100M ) );
        }
    }
}
