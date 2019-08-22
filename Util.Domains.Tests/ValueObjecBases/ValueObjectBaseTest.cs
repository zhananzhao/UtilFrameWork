using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Domains.Tests.ValueObjecBases {
    /// <summary>
    /// 值对象测试
    /// </summary>
    [TestClass]
    public class ValueObjectBaseTest {
        /// <summary>
        /// 地址1
        /// </summary>
        private Address _address1;
        /// <summary>
        /// 地址2
        /// </summary>
        private Address _address2;
        /// <summary>
        /// 地址3
        /// </summary>
        private Address _address3;
        /// <summary>
        /// 地址4
        /// </summary>
        private Address _address4;
        /// <summary>
        /// 地址5
        /// </summary>
        private Address _address5;
        /// <summary>
        /// 客户
        /// </summary>
        private Customer _customer;
        /// <summary>
        /// 地6
        /// </summary>
        private Address _address6;
        /// <summary>
        /// 地址7
        /// </summary>
        private Address _address7;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _address1 = new Address("a","b");
            _address2 = new Address( "a", "b" );
            _address3 = new Address( "1", "" );
            _customer = new Customer( 5 );
            _address4 = new Address( "a", "b", _customer );
            _address5 = new Address( "a", "b", _customer );
            _address6 = new Address( "a", "b", _customer,new Address("a","b") );
            _address7 = new Address( "a", "b", _customer, new Address( "a", "b" ) );
        }

        /// <summary>
        /// 测试对象相等性
        /// </summary>
        [TestMethod]
        public void TestEquals() {
            Assert.IsFalse( _address1.Equals( null ) );
            Assert.IsFalse( _address1 == null );
            Assert.IsFalse( null == _address1 );
            Assert.IsFalse( _address1.Equals(new Customer()) );
            Assert.IsTrue( _address1.Equals( _address2 ), "_address1.Equals( _address2 )" );
            Assert.IsTrue( _address1 == _address2, "_address1 == _address2" );
            Assert.IsFalse( _address1 != _address2, "_address1 != _address2" );
            Assert.IsFalse( _address1 == _address3, "_address1 == _address3" );
            Assert.IsTrue( _address4 == _address5, "_address4 == _address5" );
            Assert.IsTrue( _address4.Equals( _address5 ), "_address4.Equals( _address5 )" );
            Assert.IsFalse( _address6 == _address7, "_address6 == _address7" );
            Assert.IsFalse( _address6.Equals( _address7 ), "_address6.Equals( _address7 )" );
        }

        /// <summary>
        /// 测试哈希
        /// </summary>
        [TestMethod]
        public void TestGetHashCode() {
            Assert.IsTrue( _address1.GetHashCode() == _address2.GetHashCode() );
        }

        /// <summary>
        /// 测试克隆
        /// </summary>
        [TestMethod]
        public void TestClone() {
            _address3 = _address1.Clone();
            Assert.IsTrue( _address1 == _address3 );
        }
    }
}
