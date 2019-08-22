using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Datas.Sql;
using Util.Datas.Sql.Queries.Builders;
using Util.Datas.SqlServer.Queries.Builders;
using Util.Domains.Repositories;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Tests.Sqls.SqlServers {
    /// <summary>
    /// SqlServer Sql生成器测试
    /// </summary>
    [TestClass]
    public class SqlBuilderTest {

        #region 测试初始化

        /// <summary>
        /// Sql生成器
        /// </summary>
        private ISqlBuilder _builder;

        /// <summary>
        /// 客户
        /// </summary>
        private Customer _customer;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _builder = new SqlBuilder();
            _customer = Customer.GetCustomerA();
        }

        #endregion

        #region 测试默认值

        /// <summary>
        /// 测试默认值
        /// </summary>
        [TestMethod]
        public void Test_Default() {
            Assert.AreEqual( "", _builder.GetPredicate() );
            Assert.IsTrue( _builder.GetParams().Count == 0 );
        }

        #endregion

        #region 条件过滤

        /// <summary>
        /// 过滤条件
        /// </summary>
        [TestMethod]
        public void TestFilter() {
            _builder.Filter( "Name", _customer.Name );
            Assert.AreEqual( "Name=@Name", _builder.GetPredicate() );
            Assert.AreEqual( _customer.Name, _builder.GetParams()["Name"] );
        }

        /// <summary>
        /// 过滤条件,验证列名
        /// </summary>
        [TestMethod]
        public void TestFilter_NameIsEmpty() {
            _builder.Filter( "", _customer.Name );
            Assert.AreEqual( "", _builder.GetPredicate() );
            Assert.IsTrue( _builder.GetParams().Count == 0 );
        }

        /// <summary>
        /// 过滤条件,忽略null
        /// </summary>
        [TestMethod]
        public void TestFilter_IgnoreNull() {
            _builder.Filter( "Name", null );
            Assert.AreEqual( "", _builder.GetPredicate() );
            Assert.IsTrue( _builder.GetParams().Count == 0 );
        }

        /// <summary>
        /// 过滤条件,忽略空值
        /// </summary>
        [TestMethod]
        public void TestFilter_IgnoreEmpty() {
            _builder.Filter( "Name", "" );
            Assert.AreEqual( "", _builder.GetPredicate() );
            Assert.IsTrue( _builder.GetParams().Count == 0 );
        }

        /// <summary>
        /// 相等操作
        /// </summary>
        [TestMethod]
        public void TestEqual() {
            _builder.Equal( "Name", _customer.Name );
            Assert.AreEqual( "Name=@Name", _builder.GetPredicate() );
            Assert.AreEqual( _customer.Name, _builder.GetParams()["Name"] );
        }

        /// <summary>
        /// 相等操作
        /// </summary>
        [TestMethod]
        public void TestEqual_2() {
            _builder.Equal( "a.Name", _customer.Name );
            Assert.AreEqual( "a.Name=@a_Name", _builder.GetPredicate() );
            Assert.AreEqual( _customer.Name, _builder.GetParams()["a_Name"] );
        }

        /// <summary>
        /// 不相等操作
        /// </summary>
        [TestMethod]
        public void TestNotEqual() {
            _builder.NotEqual( "Name", _customer.Name );
            Assert.AreEqual( "Name!=@Name", _builder.GetPredicate() );
            Assert.AreEqual( _customer.Name, _builder.GetParams()["Name"] );
        }

        /// <summary>
        /// 不相等操作
        /// </summary>
        [TestMethod]
        public void TestNotEqual_2() {
            _builder.NotEqual( "a.Name", _customer.Name );
            Assert.AreEqual( "a.Name!=@a_Name", _builder.GetPredicate() );
            Assert.AreEqual( _customer.Name, _builder.GetParams()["a_Name"] );
        }

        /// <summary>
        /// 大于操作
        /// </summary>
        [TestMethod]
        public void TestGreater() {
            _builder.Greater( "Name", _customer.Name );
            Assert.AreEqual( "Name>@Name", _builder.GetPredicate() );
            Assert.AreEqual( _customer.Name, _builder.GetParams()["Name"] );
        }

        /// <summary>
        /// 大于操作
        /// </summary>
        [TestMethod]
        public void TestGreater_2() {
            _builder.Greater( "a.Name", _customer.Name );
            Assert.AreEqual( "a.Name>@a_Name", _builder.GetPredicate() );
            Assert.AreEqual( _customer.Name, _builder.GetParams()["a_Name"] );
        }

        /// <summary>
        /// 小于操作
        /// </summary>
        [TestMethod]
        public void TestLess() {
            _builder.Less( "Name", _customer.Name );
            Assert.AreEqual( "Name<@Name", _builder.GetPredicate() );
            Assert.AreEqual( _customer.Name, _builder.GetParams()["Name"] );
        }

        /// <summary>
        /// 小于操作
        /// </summary>
        [TestMethod]
        public void TestLess_2() {
            _builder.Less( "a.Name", _customer.Name );
            Assert.AreEqual( "a.Name<@a_Name", _builder.GetPredicate() );
            Assert.AreEqual( _customer.Name, _builder.GetParams()["a_Name"] );
        }

        /// <summary>
        /// 大于等于操作
        /// </summary>
        [TestMethod]
        public void TestGreaterEqual() {
            _builder.GreaterEqual( "Name", _customer.Name );
            Assert.AreEqual( "Name>=@Name", _builder.GetPredicate() );
            Assert.AreEqual( _customer.Name, _builder.GetParams()["Name"] );
        }

        /// <summary>
        /// 大于等于操作
        /// </summary>
        [TestMethod]
        public void TestGreaterEqual_2() {
            _builder.GreaterEqual( "a.Name", _customer.Name );
            Assert.AreEqual( "a.Name>=@a_Name", _builder.GetPredicate() );
            Assert.AreEqual( _customer.Name, _builder.GetParams()["a_Name"] );
        }

        /// <summary>
        /// 小于等于操作
        /// </summary>
        [TestMethod]
        public void TestLessEqual() {
            _builder.LessEqual( "Name", _customer.Name );
            Assert.AreEqual( "Name<=@Name", _builder.GetPredicate() );
            Assert.AreEqual( _customer.Name, _builder.GetParams()["Name"] );
        }

        /// <summary>
        /// 小于等于操作
        /// </summary>
        [TestMethod]
        public void TestLessEqual_2() {
            _builder.LessEqual( "a.Name", _customer.Name );
            Assert.AreEqual( "a.Name<=@a_Name", _builder.GetPredicate() );
            Assert.AreEqual( _customer.Name, _builder.GetParams()["a_Name"] );
        }

        /// <summary>
        /// 头尾匹配操作
        /// </summary>
        [TestMethod]
        public void TestContains() {
            _builder.Contains( "Name", _customer.Name );
            Assert.AreEqual( "Name Like @Name", _builder.GetPredicate() );
            Assert.AreEqual( string.Format( "%{0}%", _customer.Name ), _builder.GetParams()["Name"] );
        }

        /// <summary>
        /// 头尾匹配操作
        /// </summary>
        [TestMethod]
        public void TestContains_2() {
            _builder.Contains( "a.Name", _customer.Name );
            Assert.AreEqual( "a.Name Like @a_Name", _builder.GetPredicate() );
            Assert.AreEqual( string.Format( "%{0}%", _customer.Name ), _builder.GetParams()["a_Name"] );
        }

        /// <summary>
        /// 头匹配操作
        /// </summary>
        [TestMethod]
        public void TestStarts() {
            _builder.Starts( "Name", _customer.Name );
            Assert.AreEqual( "Name Like @Name", _builder.GetPredicate() );
            Assert.AreEqual( string.Format( "{0}%", _customer.Name ), _builder.GetParams()["Name"] );
        }

        /// <summary>
        /// 尾匹配操作
        /// </summary>
        [TestMethod]
        public void TestEnds() {
            _builder.Ends( "Name", _customer.Name );
            Assert.AreEqual( "Name Like @Name", _builder.GetPredicate() );
            Assert.AreEqual( string.Format( "%{0}", _customer.Name ), _builder.GetParams()["Name"] );
        }

        /// <summary>
        /// In操作,验证null
        /// </summary>
        [TestMethod]
        public void TestIn_Validate_Null() {
            _builder.In( "Name", null );
            Assert.AreEqual( "", _builder.GetPredicate() );
            Assert.AreEqual( 0, _builder.GetParams().Count );
        }

        /// <summary>
        /// In操作,验证元素为null
        /// </summary>
        [TestMethod]
        public void TestIn_Validate_ItemIsNull() {
            object param1 = null;
            _builder.In( "Name", new[] {param1} );
            Assert.AreEqual( "", _builder.GetPredicate() );
            Assert.AreEqual( 0, _builder.GetParams().Count );
        }

        /// <summary>
        /// In操作
        /// </summary>
        [TestMethod]
        public void TestIn() {
            var list = new List<string> {"a", "b"};
            _builder.In( "Name", list );
            Assert.AreEqual( "Name In (@Name0,@Name1)", _builder.GetPredicate() );
            Assert.AreEqual( "a", _builder.GetParams()["Name0"] );
            Assert.AreEqual( "b", _builder.GetParams()["Name1"] );
        }

        /// <summary>
        /// In操作
        /// </summary>
        [TestMethod]
        public void TestIn_2() {
            var list = new List<string> {"a", "b"};
            _builder.In( "a.Name", list );
            Assert.AreEqual( "a.Name In (@a_Name0,@a_Name1)", _builder.GetPredicate() );
            Assert.AreEqual( "a", _builder.GetParams()["a_Name0"] );
            Assert.AreEqual( "b", _builder.GetParams()["a_Name1"] );
        }

        /// <summary>
        /// 添加两个条件
        /// </summary>
        [TestMethod]
        public void Test_Add2Condition() {
            _builder.Equal( "a", 1 ).Contains( "b", 1 );
            Assert.AreEqual( "a=@a And b Like @b", _builder.GetPredicate() );
        }

        #endregion

        #region 连接

        /// <summary>
        /// 添加1个And条件
        /// </summary>
        [TestMethod]
        public void TestAnd_1Condition() {
            _builder.And( "a=1" );
            Assert.AreEqual( "a=1", _builder.GetPredicate() );
        }

        /// <summary>
        /// 添加2个And条件
        /// </summary>
        [TestMethod]
        public void TestAnd_2Condition() {
            _builder.And( "a=1" ).And( "a=2" );
            Assert.AreEqual( "a=1 And a=2", _builder.GetPredicate() );
        }

        /// <summary>
        /// 测试And条件传入null
        /// </summary>
        [TestMethod]
        public void TestAnd_Validate_Null() {
            _builder.And( "" ).From( "t" );
            Assert.AreEqual( "Select * From t ", _builder.GetSql() );
            Assert.AreEqual( "", _builder.GetPredicate() );
            Assert.AreEqual( 0, _builder.GetParams().Count );
        }

        /// <summary>
        /// 添加1个Or条件
        /// </summary>
        [TestMethod]
        public void TestOr_1Condition() {
            _builder.Or( "a=1" );
            Assert.AreEqual( "a=1", _builder.GetPredicate() );
        }

        /// <summary>
        /// 添加2个Or条件
        /// </summary>
        [TestMethod]
        public void TestOr_2Condition() {
            _builder.Or( "a=1" ).Or( "a=2" );
            Assert.AreEqual( "(a=1) Or (a=2)", _builder.GetPredicate() );
        }

        /// <summary>
        /// 测试Or条件传入null
        /// </summary>
        [TestMethod]
        public void TestOr_Validate_Null() {
            _builder.Or( "" ).From( "t" );
            Assert.AreEqual( "Select * From t ", _builder.GetSql() );
            Assert.AreEqual( "", _builder.GetPredicate() );
            Assert.AreEqual( 0, _builder.GetParams().Count );
        }

        #endregion

        #region Sql结果

        /// <summary>
        /// 验证表名不能为空
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( InvalidOperationException ) )]
        public void TestGetSql_Validate_TableIsEmpty() {
            try {
                _builder.GetSql();
            }
            catch( InvalidOperationException ex ) {
                Assert.AreEqual( SqlResource.TableIsEmpty, ex.Message );
                throw;
            }
        }

        /// <summary>
        /// 验证分页必须设置OrderBy
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( InvalidOperationException ) )]
        public void TestGetSql_Validate_OrderBy_Pager() {
            try {
                _builder.From( "a" );
                _builder.SetPager( new Pager() );
                _builder.GetSql();
            }
            catch( InvalidOperationException ex ) {
                Assert.AreEqual( SqlResource.PagerOrderIsEmpty, ex.Message );
                throw;
            }
        }

        /// <summary>
        /// 设置表
        /// </summary>
        [TestMethod]
        public void TestGetSql_Table() {
            _builder.From( "a" );
            Assert.AreEqual( "Select * From a ", _builder.GetSql() );
        }

        /// <summary>
        /// 设置列
        /// </summary>
        [TestMethod]
        public void TestGetSql_Columns() {
            _builder.From( "t" ).Select( "a,b" );
            Assert.AreEqual( "Select a,b From t ", _builder.GetSql() );
        }

        /// <summary>
        /// 设置1个条件
        /// </summary>
        [TestMethod]
        public void TestGetSql_1Condition() {
            _builder.From( "t" ).Equal( "a", 1 );
            Assert.AreEqual( "Select * From t Where a=@a ", _builder.GetSql() );
        }

        /// <summary>
        /// 设置2个条件
        /// </summary>
        [TestMethod]
        public void TestGetSql_2Condition() {
            _builder.From( "t" ).Equal( "a", 1 ).Starts( "b", 2 );
            Assert.AreEqual( "Select * From t Where a=@a And b Like @b ", _builder.GetSql() );
        }

        /// <summary>
        /// 设置Or条件
        /// </summary>
        [TestMethod]
        public void TestGetSql_Or_1() {
            _builder.From( "t" ).Equal( "a", 1 ).Starts( "b", 2 ).Or( "a=1" );
            Assert.AreEqual( "Select * From t Where (a=@a And b Like @b) Or (a=1) ", _builder.GetSql() );
        }

        /// <summary>
        /// 设置Or条件
        /// </summary>
        [TestMethod]
        public void TestGetSql_Or_2() {
            var builder = new SqlBuilder().Equal( "c", 1 ).Contains( "d", 2 );
            _builder.From( "t" ).Equal( "a", 1 ).Starts( "b", 2 ).Or( builder.GetPredicate() );
            Assert.AreEqual( "Select * From t Where (a=@a And b Like @b) Or (c=@c And d Like @d) ", _builder.GetSql() );
        }

        /// <summary>
        /// 设置分组
        /// </summary>
        [TestMethod]
        public void TestGetSql_GroupBy() {
            _builder.From( "t" ).GroupBy( "a" );
            Assert.AreEqual( "Select * From t Group By a", _builder.GetSql() );
        }

        /// <summary>
        /// 设置分组条件
        /// </summary>
        [TestMethod]
        public void TestGetSql_Having() {
            _builder.From( "t" ).GroupBy( "a", "b" );
            Assert.AreEqual( "Select * From t Group By a Having b", _builder.GetSql() );
        }

        /// <summary>
        /// 设置排序
        /// </summary>
        [TestMethod]
        public void TestGetSql_OrderBy() {
            _builder.From( "t" ).OrderBy( "a" );
            Assert.AreEqual( "Select * From t Order By a ", _builder.GetSql() );
        }

        /// <summary>
        /// 设置分页
        /// </summary>
        [TestMethod]
        public void TestGetSql_Pager() {
            _builder.From( "t" ).SetPager( new Pager( 1, 20, "a" ) );
            var result = new Str();
            result.Add( "With Temp As ( Select * , Row_Number() Over( Order By a ) as SortNumber From t ) " );
            result.Add( "Select * From Temp Where SortNumber Between 1 and 20" );
            Assert.AreEqual( result.ToString(), _builder.GetSql() );
        }

        /// <summary>
        /// 获取总行数Sql
        /// </summary>
        [TestMethod]
        public void TestGetCountSql() {
            _builder.From( "t" ).Equal( "a", 1 );
            var result = new Str();
            result.Add( "Select Count(*) From t Where a=@a " );
            Assert.AreEqual( result.ToString(), _builder.GetCountSql() );
        }

        #endregion
    }
}
