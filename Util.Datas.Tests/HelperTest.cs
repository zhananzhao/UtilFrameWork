using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Tests {
    /// <summary>
    /// 数据操作测试
    /// </summary>
    [TestClass]
    public class HelperTest {
        /// <summary>
        /// 将实体集合转换为DataTable
        /// </summary>
        [TestMethod]
        public void TestToDataTable() {
            var customers = Customer.GetCustomers();
            DataTable result = Util.Datas.Helper.ToDataTable( customers );
            Assert.AreEqual( 3,result.Rows.Count );
            Assert.AreEqual( "A", result.Rows[0]["Name"] );
        }
    }
}
