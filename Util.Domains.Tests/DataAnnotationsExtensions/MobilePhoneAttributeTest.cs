using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;
using Util.Validations.DataAnnotations;

namespace Util.Domains.Tests.DataAnnotationsExtensions {
    /// <summary>
    /// 手机号验证
    /// </summary>
    [TestClass]
    public class MobilePhoneAttributeTest {
        /// <summary>
        /// 测试
        /// </summary>
        private Test1 _test;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _test = new Test1();
        }

        /// <summary>
        /// 验证空值
        /// </summary>
        [TestMethod]
        public void Test_Empty() {
            _test.MobilePhone = "";
            _test.Validate();
        }

        /// <summary>
        /// 验证无效手机号
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Warning))]
        public void Test_Invalid() {
            try {
                _test.MobilePhone = "1";
                _test.Validate();
            }
            catch( Warning ex ) {
                Assert.AreEqual( ValidatorResources.InvalidMobilePhone,ex.Message );
                throw;
            }
        }
        /// <summary>
        /// 验证有效值
        /// </summary>
        [TestMethod]
        public void Test_Valid() {
            _test.MobilePhone = "13012345678";
            _test.Validate();
        }
    }
}
