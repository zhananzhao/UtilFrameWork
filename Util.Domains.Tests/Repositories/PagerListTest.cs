using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Repositories;
using Util.Domains.Tests.Sample;

namespace Util.Domains.Tests.Repositories {
    /// <summary>
    /// 分页集合测试
    /// </summary>
    [TestClass]
    public class PagerListTest {
        /// <summary>
        /// 分页集合
        /// </summary>
        private PagerList<Customer> _list;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _list = new PagerList<Customer>( 1,2,3,"Name" );
            _list.Add( Customer.GetCustomerA() );
            _list.Add( Customer.GetCustomerB() );
        }

        /// <summary>
        /// 元素个数
        /// </summary>
        [TestMethod]
        public void TestCount() {
            Assert.AreEqual( 2, _list.Count );
        }

        /// <summary>
        /// 用索引获取元素
        /// </summary>
        [TestMethod]
        public void TestIndex() {
            Assert.AreEqual( "B",_list[1].Name );
        }

        /// <summary>
        /// 转换类型
        /// </summary>
        [TestMethod]
        public void TestConvert() {
            var result = _list.Convert( t => new CustomerInfo() );
            Assert.AreEqual( 2,result.Count );
            Assert.AreEqual( 1, result.Page );
            Assert.AreEqual( 2, result.PageSize );
            Assert.AreEqual( 3,result.TotalCount );
            Assert.AreEqual( 2, result.PageCount );
            Assert.AreEqual( "Name", result.Order );
        }
    }
}
