using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Tests.Samples;

namespace Util.Tests {
    /// <summary>
    /// 序列化测试
    /// </summary>
    [TestClass]
    public class SirializeTest {
        /// <summary>
        /// 序列化到字节流,验证实例为空
        /// </summary>
        [TestMethod]
        public void TestToBytes_Validate_InstanceIsNull() {
            byte[] bytes = Util.Serialize.ToBytes( null );
            Assert.AreEqual( null, Util.Serialize.FromBytes<Test2>( bytes ) );
        }

        /// <summary>
        /// 序列化到字节流
        /// </summary>
        [TestMethod]
        public void TestToBytes() {
            Test2 test = new Test2();
            test.Name = "a";
            byte[] bytes = Util.Serialize.ToBytes( test );
            Test2 result = Util.Serialize.FromBytes<Test2>( bytes );
            Assert.AreEqual( "a",result.Name );
        }
    }
}
