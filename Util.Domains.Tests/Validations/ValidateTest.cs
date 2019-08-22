using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Domains.Tests.Validations {
    /// <summary>
    /// 验证测试
    /// </summary>
    [TestClass]
    public class ValidateTest {
        /// <summary>
        /// 客户
        /// </summary>
        private Customer _customer;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _customer = Customer.GetCustomer();
        }

        /// <summary>
        /// 验证必填项，通过字符串设置错误消息
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Warning))]
        public void TestValidateEnglishName_Required_ErrorMessage() {
            try {
                _customer.EnglishName = null;
                _customer.Validate();
            }
            catch ( Warning ex ) {
                Assert.AreEqual( "英文名不能为空", ex.Message );
                throw;
            }
        }

        /// <summary>
        /// 添加验证规则
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( Warning ) )]
        public void TestAddValidationRule() {
            try {
                _customer.EnglishName = "abcd";
                _customer.AddValidationRule( new CustomerEnglishNameValidationRule( _customer ) );
                _customer.Validate();
            }
            catch ( Warning ex ) {
                Assert.AreEqual( "客户英文名长度不能大于1", ex.Message );
                throw;
            }
        }

        /// <summary>
        /// 设置验证处理器,不进行任何操作，所以不会抛出异常
        /// </summary>
        [TestMethod]
        public void TestSetValidationHandler_NotThow() {
            _customer.EnglishName = null;
            _customer.SetValidationHandler( new NothingValidationHandler() );
            _customer.Validate();
        }
    }
}
