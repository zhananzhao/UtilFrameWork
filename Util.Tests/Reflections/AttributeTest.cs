using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Tests.Samples;

namespace Util.Tests.Reflections {
    /// <summary>
    /// 特性操作测试
    /// </summary>
    [TestClass]
    public class AttributeTest {
        /// <summary>
        /// 获取描述
        /// </summary>
        [TestMethod]
        public void TestGetDescription() {
            Assert.AreEqual( "", Util.Reflection.GetDescription<LogType>( "A" ) ); 
            Assert.AreEqual( "错误", Util.Reflection.GetDescription<LogType>( "Error" ) ); 
        }
    }
}
