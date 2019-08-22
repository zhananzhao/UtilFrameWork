using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Domains.Tests.EntityBases {
    /// <summary>
    /// 空对象测试
    /// </summary>
    [TestClass]
    public class NullObjectTest {
        /// <summary>
        /// 正常实体不是空对象
        /// </summary>
        [TestMethod]
        public void TestIsNull_Entity() {
            Customer customer = new Customer();
            Assert.IsFalse( customer.IsNull() );
        }

        /// <summary>
        /// 空实体对象
        /// </summary>
        [TestMethod]
        public void TestIsNull_EmptyEntity() {
            Customer customer = Customer.Null;
            Assert.IsTrue( customer.IsNull() );
        }
    }
}
