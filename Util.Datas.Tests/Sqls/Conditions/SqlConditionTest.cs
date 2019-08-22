using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Datas.Sql.Queries.Builders.Conditions;

namespace Util.Datas.Tests.Sqls.Conditions {
    /// <summary>
    /// Sql条件测试
    /// </summary>
    [TestClass]
    public class SqlConditionTest {
        /// <summary>
        /// Sql条件
        /// </summary>
        private ISqlCondition _condition;

        /// <summary>
        /// 相等条件
        /// </summary>
        [TestMethod]
        public void TestEqual() {
            _condition = SqlCondition.Create( "a", "@",Operator.Equal );
            Assert.AreEqual( "a=@a", _condition.GetCondition() );
        }

        /// <summary>
        /// 不相等条件
        /// </summary>
        [TestMethod]
        public void TestNotEqual() {
            _condition = SqlCondition.Create( "a", "@", Operator.NotEqual );
            Assert.AreEqual( "a!=@a", _condition.GetCondition() );
        }

        /// <summary>
        /// 大于操作
        /// </summary>
        [TestMethod]
        public void TestGreater() {
            _condition = SqlCondition.Create( "a", "@", Operator.Greater );
            Assert.AreEqual( "a>@a", _condition.GetCondition() );
        }

        /// <summary>
        /// 小于操作
        /// </summary>
        [TestMethod]
        public void TestLess() {
            _condition = SqlCondition.Create( "a", "@", Operator.Less );
            Assert.AreEqual( "a<@a", _condition.GetCondition() );
        }

        /// <summary>
        /// 大于等于操作
        /// </summary>
        [TestMethod]
        public void TestGreaterEqual() {
            _condition = SqlCondition.Create( "a", "@", Operator.GreaterEqual );
            Assert.AreEqual( "a>=@a", _condition.GetCondition() );
        }

        /// <summary>
        /// 小于等于操作
        /// </summary>
        [TestMethod]
        public void TestLessEqual() {
            _condition = SqlCondition.Create( "a", "@", Operator.LessEqual );
            Assert.AreEqual( "a<=@a", _condition.GetCondition() );
        }

        /// <summary>
        /// 头尾匹配操作
        /// </summary>
        [TestMethod]
        public void TestContains() {
            _condition = SqlCondition.Create( "a", "@", Operator.Contains );
            Assert.AreEqual( "a Like @a", _condition.GetCondition() );
        }

        /// <summary>
        /// 头匹配操作
        /// </summary>
        [TestMethod]
        public void TestStarts() {
            _condition = SqlCondition.Create( "a", "@", Operator.Starts );
            Assert.AreEqual( "a Like @a", _condition.GetCondition() );
        }

        /// <summary>
        /// 尾匹配操作
        /// </summary>
        [TestMethod]
        public void TestEnds() {
            _condition = SqlCondition.Create( "a", "@", Operator.Ends );
            Assert.AreEqual( "a Like @a", _condition.GetCondition() );
        }

        /// <summary>
        /// 获取参数名
        /// </summary>
        [TestMethod]
        public void TestGetParamName() {
            Assert.AreEqual( "a",SqlCondition.GetParamName( "a" ) );
            Assert.AreEqual( "a_b", SqlCondition.GetParamName( "a.b" ) );
            Assert.AreEqual( "a_b", SqlCondition.GetParamName( "a.[b]" ) ); 
        }
    }
}
