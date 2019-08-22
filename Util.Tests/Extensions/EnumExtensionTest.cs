using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Tests.Enums;

namespace Util.Tests.Extensions {
    /// <summary>
    /// 枚举扩展测试
    /// </summary>
    [TestClass]
    public class EnumExtensionTest {
        /// <summary>
        /// 获取描述
        /// </summary>
        [TestMethod]
        public void TestDescription() {
            Assert.AreEqual( EnumTest.DEBUG_DESCRIPTION, EnumTest.DEBUG_INSTANCE.Description() );
        }

        /// <summary>
        /// 获取成员值
        /// </summary>
        [TestMethod]
        public void TestValue() {
            Assert.AreEqual( EnumTest.DEBUG_VALUE, EnumTest.DEBUG_INSTANCE.Value() );
        }

        /// <summary>
        /// 获取泛型成员值
        /// </summary>
        [TestMethod]
        public void TestValue_Generic() {
            Assert.AreEqual( EnumTest.DEBUG_VALUE.ToString(), EnumTest.DEBUG_INSTANCE.Value<string>() );
        }
    }
}
