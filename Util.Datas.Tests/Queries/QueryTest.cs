using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Datas.Queries;
using Util.Datas.SqlServer.Queries;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Tests.Queries {
    /// <summary>
    /// 查询测试
    /// </summary>
    [TestClass]
    public class QueryTest {
        /// <summary>
        /// 查询对象
        /// </summary>
        Query<Customer,int> _query;

        /// <summary>
        /// 初始化测试
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _query = new Query<Customer,int>();
        }

        /// <summary>
        /// 添加1个查询条件
        /// </summary>
        [TestMethod]
        public void TestAdd_1Criteria() {
            _query.Filter( t => t.Name == "A" );
            Expression<Func<Customer, bool>> expected = t => t.Name == "A";
            Assert.AreEqual( expected.ToString(), _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 添加2个查询条件
        /// </summary>
        [TestMethod]
        public void TestAdd_2Criteria() {
            _query.Filter( t => t.Name == "A" );
            _query.Filter( d => d.Age == 1 );
            Expression<Func<Customer, bool>> expected = t => t.Name == "A" && t.Age == 1;
            Assert.AreEqual( expected.ToString(), _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 使用or选项过滤
        /// </summary>
        [TestMethod]
        public void TestFilter_Or() {
            _query.Filter( t => t.Name == "A" );
            _query.Filter( d => d.Age == 1,true );
            Expression<Func<Customer, bool>> expected = t => t.Name == "A" || t.Age == 1;
            Assert.AreEqual( expected.ToString(), _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 使用And连接，当前查询对象未设置条件
        /// </summary>
        [TestMethod]
        public void TestAnd_SelfPredicateIsNull() {
            _query.And( t => t.Name == "A" );
            Expression<Func<Customer, bool>> expected = t => t.Name == "A";
            Assert.AreEqual( expected.ToString(), _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 使用Or连接，当前查询对象未设置条件
        /// </summary>
        [TestMethod]
        public void TestOr_SelfPredicateIsNull() {
            _query.Or( t => t.Name == "A" );
            Expression<Func<Customer, bool>> expected = t => t.Name == "A";
            Assert.AreEqual( expected.ToString(), _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 2个查询对象与连接
        /// </summary>
        [TestMethod]
        public void TestAnd() {
            //给第一个查询对象添加条件
            _query.Filter( t => t.Name == "A" );

            //创建第2个查询对象
            var query2 = new Query<Customer, int>();
            query2.Filter( t => t.Age == 1 );

            //将第2个查询对象合并到第1个查询对象
            _query.And( query2 );

            //验证
            Expression<Func<Customer, bool>> expected = t => t.Name == "A" && t.Age == 1;
            Assert.AreEqual( expected.ToString(), _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 验证And连接时，传入null
        /// </summary>
        [TestMethod]
        public void TestAnd_ValidateNull() {
            SqlServerQuery query=new SqlServerQuery();
            query.Select("");
            var sqlbuilder = query.GetSqlBuilder();
            query.NewSqlBuilder();
           // query.Less();

            Expression<Func<Customer, bool>> _expression = null;
            _query.And( _expression );
            Assert.AreEqual( null, _query.GetPredicate() );
        }

        /// <summary>
        /// 2个查询对象或连接
        /// </summary>
        [TestMethod]
        public void TestOr() {
            //给第一个查询对象添加条件
            _query.Filter( t => t.Name == "A" );

            //创建第2个查询对象
            Query<Customer, int> query2 = new Query<Customer, int>();
            query2.Filter( t => t.Age == 1 );

            //将第2个查询对象合并到第1个查询对象
            _query.Or( query2 );

            //验证
            Expression<Func<Customer, bool>> expected = t => t.Name == "A" || t.Age == 1;
            Assert.AreEqual( expected.ToString(), _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 查询对象使用And和Or连接
        /// </summary>
        [TestMethod]
        public void TestAnd_Or() {
            //给第一个查询对象添加条件
            _query.Filter( t => t.Name == "A" );
            _query.Filter( t => t.EnglishName == "A" );

            //创建第2个查询对象
            Query<Customer, int> query2 = new Query<Customer, int>();
            query2.Filter( t => t.Name == "B" );
            query2.Filter( t => t.Age == 1 );

            //用或操作将第2个查询对象合并到第1个查询对象
            _query.Or( query2 );

            //创建第3个查询对象
            Query<Customer, int> query3 = new Query<Customer, int>();
            query3.Filter( t => t.Name == "C" );
            query3.Filter( t => t.Age > 10 );

            //用与操作将第3个查询对象合并到第1个查询对象
            _query.And( query3 );

            //验证
            Expression<Func<Customer, bool>> expected = t => ( ( t.Name == "A" && t.EnglishName == "A" ) 
                || ( t.Name == "B" && t.Age == 1 ) ) && ( t.Name == "C" && t.Age > 10 );
            Assert.AreEqual( expected.ToString(), _query.GetPredicate().ToString() );
        }

        /// <summary>
        /// 查询对象可清空后再使用
        /// </summary>
        [TestMethod]
        public void TestClear() {
            //给第一个查询对象添加条件
            _query.Filter( t => t.Name == "A" );

            //创建第2个查询对象
            Query<Customer, int> query2 = new Query<Customer, int>();
            query2.Filter( t => t.Age == 1 );

            //或操作合并查询对象
            _query.Or( query2 );

            //清空第2个查询对象，再添加条件
            query2.Clear();
            query2.Filter( t => t.Name == "C" );

            //与操作合并查询对象
            _query.And( query2 );

            //验证
            Expression<Func<Customer, bool>> expected = t => ( t.Name == "A"|| t.Age == 1 ) && t.Name == "C";
            Assert.AreEqual( expected.ToString(), _query.GetPredicate().ToString() );
        }
    }
}
