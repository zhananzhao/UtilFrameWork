using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Datas.Queries.Criterias;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Tests.Criterias {
    /// <summary>
    /// 过滤日期时间段条件
    /// </summary>
    [TestClass]
    public class DateTimeSegmentCriteriaTest {
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
            DateTimeSegmentCriteria<Customer, DateTime> criteria = new DateTimeSegmentCriteria<Customer, DateTime>( t => t.Birthday, _min, _max );
            Assert.AreEqual( "t => ((t.Birthday >= 2000/1/1 10:10:10) AndAlso (t.Birthday <= 2000/1/2 10:10:10))", criteria.GetPredicate().ToString() );

            //可空
            DateTimeSegmentCriteria<Customer, DateTime?> criteria2 = new DateTimeSegmentCriteria<Customer, DateTime?>( t => t.NullableBirthday, _min, _max );
            Assert.AreEqual( "t => ((t.NullableBirthday >= 2000/1/1 10:10:10) AndAlso (t.NullableBirthday <= 2000/1/2 10:10:10))", criteria2.GetPredicate().ToString() );
        }
    }
}
