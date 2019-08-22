using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Datas.Queries.Criterias;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Tests.Criterias {
    /// <summary>
    /// 测试整数段过滤条件
    /// </summary>
    [TestClass]
    public class IntSegmentCriteriaTest {
        /// <summary>
        /// 过滤整数段,包含最大值和最小值
        /// </summary>
        [TestMethod]
        public void Test_Min_Max() {
            //不可空
            IntSegmentCriteria<Customer, int> criteria = new IntSegmentCriteria<Customer, int>( t => t.Tel, 1, 10 );
            Assert.AreEqual( "t => ((t.Tel >= 1) AndAlso (t.Tel <= 10))", criteria.GetPredicate().ToString() );

            //可空
            IntSegmentCriteria<Customer, int?> criteria2 = new IntSegmentCriteria<Customer, int?>( t => t.Age, 1, 10 );
            Assert.AreEqual( "t => ((t.Age >= 1) AndAlso (t.Age <= 10))", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 最小值大于最大值，则交换大小值的位置
        /// </summary>
        [TestMethod]
        public void Test_MinGreaterMax() {
            //不可空
            IntSegmentCriteria<Customer, int> criteria = new IntSegmentCriteria<Customer, int>( t => t.Tel, 10, 1 );
            Assert.AreEqual( "t => ((t.Tel >= 1) AndAlso (t.Tel <= 10))", criteria.GetPredicate().ToString() );

            //可空
            IntSegmentCriteria<Customer, int?> criteria2 = new IntSegmentCriteria<Customer, int?>( t => t.Age, 10, 1 );
            Assert.AreEqual( "t => ((t.Age >= 1) AndAlso (t.Age <= 10))", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 最小值为空，忽略最小值条件
        /// </summary>
        [TestMethod]
        public void Test_MinIsNull() {
            //不可空
            IntSegmentCriteria<Customer, int> criteria = new IntSegmentCriteria<Customer, int>( t => t.Tel, null, 10 );
            Assert.AreEqual( "t => (t.Tel <= 10)", criteria.GetPredicate().ToString() );

            //可空
            IntSegmentCriteria<Customer, int?> criteria2 = new IntSegmentCriteria<Customer, int?>( t => t.Age, null, 10 );
            Assert.AreEqual( "t => (t.Age <= 10)", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 最大值为空，忽略最大值条件
        /// </summary>
        [TestMethod]
        public void Test_MaxIsNull() {
            //不可空
            IntSegmentCriteria<Customer, int> criteria = new IntSegmentCriteria<Customer, int>( t => t.Tel, 1, null );
            Assert.AreEqual( "t => (t.Tel >= 1)", criteria.GetPredicate().ToString() );

            //可空
            IntSegmentCriteria<Customer, int?> criteria2 = new IntSegmentCriteria<Customer, int?>( t => t.Age, 1, null );
            Assert.AreEqual( "t => (t.Age >= 1)", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 最大值和最小值均为null,忽略所有条件
        /// </summary>
        [TestMethod]
        public void Test_BothNull() {
            //不可空
            IntSegmentCriteria<Customer, int> criteria = new IntSegmentCriteria<Customer, int>( t => t.Tel, null, null );
            Assert.IsNull( criteria.GetPredicate(), criteria.GetPredicate().ToStr() );

            //可空
            IntSegmentCriteria<Customer, int?> criteria2 = new IntSegmentCriteria<Customer, int?>( t => t.Age, null, null );
            Assert.IsNull( criteria2.GetPredicate(), criteria2.GetPredicate().ToStr() );
        }
    }
}
