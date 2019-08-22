using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Datas.Queries.Criterias;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Tests.Criterias {
    /// <summary>
    /// 过滤日期段条件
    /// </summary>
    [TestClass]
    public class DateSegmentCriteriaTest {
        /// <summary>
        /// 最小日期
        /// </summary>
        private DateTime? _min;
        /// <summary>
        /// 最大日期
        /// </summary>
        private DateTime? _max;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _min = Conv.ToDate( "2000-1-1 10:10:10" );
            _max = Conv.ToDate( "2000-1-2 10:10:10" );
        }

        /// <summary>
        /// 过滤日期段,包含最大值和最小值
        /// </summary>
        [TestMethod]
        public void Test_Min_Max() {
            //不可空
            DateSegmentCriteria<Customer, DateTime> criteria = new DateSegmentCriteria<Customer, DateTime>( t => t.Birthday, _min, _max );
            Assert.AreEqual( "t => ((t.Birthday >= 2000/1/1 0:00:00) AndAlso (t.Birthday < 2000/1/3 0:00:00))", criteria.GetPredicate().ToString() );

            //可空
            DateSegmentCriteria<Customer, DateTime?> criteria2 = new DateSegmentCriteria<Customer, DateTime?>( t => t.NullableBirthday, _min, _max );
            Assert.AreEqual( "t => ((t.NullableBirthday >= 2000/1/1 0:00:00) AndAlso (t.NullableBirthday < 2000/1/3 0:00:00))", criteria2.GetPredicate().ToString() );
        }
    }
}
