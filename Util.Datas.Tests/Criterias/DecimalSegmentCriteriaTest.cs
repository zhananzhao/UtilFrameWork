using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Datas.Queries.Criterias;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Tests.Criterias {
    /// <summary>
    /// 过滤decimal数值段测试
    /// </summary>
    [TestClass]
    public class DecimalSegmentCriteriaTest {
        /// <summary>
        /// 过滤decimal数值段,包含最大值和最小值
        /// </summary>
        [TestMethod]
        public void Test_Min_Max() {
            //不可空
            DecimalSegmentCriteria<Customer, decimal> criteria = new DecimalSegmentCriteria<Customer, decimal>( t => t.Dec, 1.1M, 10.1M );
            Assert.AreEqual( "t => ((t.Dec >= 1.1) AndAlso (t.Dec <= 10.1))", criteria.GetPredicate().ToString() );

            //可空
            DecimalSegmentCriteria<Customer, decimal?> criteria2 = new DecimalSegmentCriteria<Customer, decimal?>( t => t.NullableDec, 1.1M, 10.1M );
            Assert.AreEqual( "t => ((t.NullableDec >= 1.1) AndAlso (t.NullableDec <= 10.1))", criteria2.GetPredicate().ToString() );
        }
    }
}
