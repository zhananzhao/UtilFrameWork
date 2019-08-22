using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Domains.Tests.EntityBases {
    /// <summary>
    /// 整型标识实体测试
    /// </summary>
    [TestClass]
    public class IntEntityBaseTest {
        /// <summary>
        /// 客户
        /// </summary>
        private Customer _customer;
        /// <summary>
        /// 客户2
        /// </summary>
        private Customer _customer2;

        /// <summary>
        /// 初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _customer = new Customer();
            _customer2 = new Customer();
        }

        /// <summary>
        /// 如果不带参数创建整型标识的实体，不会自动生成标识，标识为0
        /// </summary>
        [TestMethod]
        public void TestCreateEntity_NotArgument_IntId_IdIs0() {
            Assert.AreEqual( 0, _customer.Id );
        }

        /// <summary>
        /// 如果用参数10创建整型标识的实体，标识被设置为10
        /// </summary>
        [TestMethod]
        public void TestCreateEntity_ArgumentIs10_IntId_IdIs10() {
            _customer = new Customer( 10 );
            Assert.AreEqual( 10, _customer.Id );
        }

        /// <summary>
        /// 新创建的实体不相等
        /// </summary>
        [TestMethod]
        public void TestNewEntityIsNotEquals() {
            Assert.IsFalse( _customer.Equals( _customer2 ) );
            Assert.IsFalse( _customer.Equals( null ) );

            Assert.IsFalse( _customer == _customer2 );
            Assert.IsFalse( _customer == null );
            Assert.IsFalse( null == _customer2 );

            Assert.IsTrue( _customer != _customer2 );
            Assert.IsTrue( _customer != null );
            Assert.IsTrue( null != _customer2 );
        }

        /// <summary>
        /// 当两个实体的标识相同，则实体相同
        /// </summary>
        [TestMethod]
        public void TestEntityEquals_IdEquals() {
            _customer = new Customer( 1 );
            _customer2 = new Customer( 1 );
            Assert.IsTrue( _customer.Equals( _customer2 ) );
            Assert.IsTrue( _customer == _customer2 );
            Assert.IsFalse( _customer != _customer2 );
        }
    }
}
