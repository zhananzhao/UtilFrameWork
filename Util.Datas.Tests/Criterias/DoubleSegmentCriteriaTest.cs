using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Datas.Queries.Criterias;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Tests.Criterias {
    /// <summary>
    /// 过滤double数值段测试
    /// </summary>
    [TestClass]
    public class DoubleSegmentCriteriaTest {
        /// <summary>
        /// 过滤double数值段,包含最大值和最小值
        /// </summary>
        [TestMethod]
        public void Test_Min_Max() {
            //不可空
            DoubleSegmentCriteria<Customer, double> criteria = new DoubleSegmentCriteria<Customer, double>( t => t.Db, 1.1, 10.1 );
            Assert.AreEqual( "t => ((t.Db >= 1.1) AndAlso (t.Db <= 10.1))", criteria.GetPredicate().ToString() );

            //可空
            DoubleSegmentCriteria<Customer, double?> criteria2 = new DoubleSegmentCriteria<Customer, double?>( t => t.NullableDb, 1.1, 10.1 );
            Assert.AreEqual( "t => ((t.NullableDb >= 1.1) AndAlso (t.NullableDb <= 10.1))", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 属性为int类型，则发生类型不匹配异常
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( ArgumentException ) )]
        public void Test_PropertyIsInt_Throw() {
            DoubleSegmentCriteria<Customer, int?> criteria3 = new DoubleSegmentCriteria<Customer, int?>( t => t.Age, 1.1, 10.1 );
            Assert.AreEqual( "t => ((t.Age >= 1.1) AndAlso (t.Age <= 10.1))", criteria3.GetPredicate().ToString() );
        }

        /// <summary>
        /// 最小值大于最大值，则交换大小值的位置
        /// </summary>
        [TestMethod]
        public void Test_MinGreaterMax() {
            //不可空
            DoubleSegmentCriteria<Customer, double> criteria = new DoubleSegmentCriteria<Customer, double>( t => t.Db, 10.1, 1.1 );
            Assert.AreEqual( "t => ((t.Db >= 1.1) AndAlso (t.Db <= 10.1))", criteria.GetPredicate().ToString() );

            //可空
            DoubleSegmentCriteria<Customer, double?> criteria2 = new DoubleSegmentCriteria<Customer, double?>( t => t.NullableDb, 10.1, 1.1 );
            Assert.AreEqual( "t => ((t.NullableDb >= 1.1) AndAlso (t.NullableDb <= 10.1))", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 最小值为空，忽略最小值条件
        /// </summary>
        [TestMethod]
        public void Test_MinIsNull() {
            //不可空
            DoubleSegmentCriteria<Customer, double> criteria = new DoubleSegmentCriteria<Customer, double>( t => t.Db, null, 10.1 );
            Assert.AreEqual( "t => (t.Db <= 10.1)", criteria.GetPredicate().ToString() );

            //可空
            DoubleSegmentCriteria<Customer, double?> criteria2 = new DoubleSegmentCriteria<Customer, double?>( t => t.NullableDb, null, 10.1 );
            Assert.AreEqual( "t => (t.NullableDb <= 10.1)", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 最大值为空，忽略最大值条件
        /// </summary>
        [TestMethod]
        public void Test_MaxIsNull() {
            //不可空
            DoubleSegmentCriteria<Customer, double> criteria = new DoubleSegmentCriteria<Customer, double>( t => t.Db, 1.1, null );
            Assert.AreEqual( "t => (t.Db >= 1.1)", criteria.GetPredicate().ToString() );

            //可空
            DoubleSegmentCriteria<Customer, double?> criteria2 = new DoubleSegmentCriteria<Customer, double?>( t => t.NullableDb, 1.1, null );
            Assert.AreEqual( "t => (t.NullableDb >= 1.1)", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 最大值和最小值均为null,忽略所有条件
        /// </summary>
        [TestMethod]
        public void Test_BothNull() {
            //不可空
            DoubleSegmentCriteria<Customer, double> criteria = new DoubleSegmentCriteria<Customer, double>( t => t.Db, null, null );
            Assert.IsNull( criteria.GetPredicate(), criteria.GetPredicate().ToStr() );

            //可空
            DoubleSegmentCriteria<Customer, double?> criteria2 = new DoubleSegmentCriteria<Customer, double?>( t => t.NullableDb, null, null );
            Assert.IsNull( criteria2.GetPredicate(), criteria2.GetPredicate().ToStr() );
        }
    }
}
