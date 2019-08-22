using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Datas.Sql.Queries.Builders;
using Util.Datas.SqlServer.Queries.Builders;
using Util.Domains.Repositories;

namespace Util.Datas.Tests.Sqls.SqlServers {
    /// <summary>
    /// SqlServer2012 Sql生成器测试
    /// </summary>
    [TestClass]
    public class SqlBuilder2012Test {
        /// <summary>
        /// Sql生成器
        /// </summary>
        private ISqlBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _builder = new SqlBuilder2012();
        }

        /// <summary>
        /// 设置分页
        /// </summary>
        [TestMethod]
        public void TestGetSql_Pager() {
            _builder.From( "t" ).SetPager( new Pager( 1, 20, "a" ) );
            var result = new Str();
            result.Add( "Select * From t " );
            result.Add( "Order By a Offset 0 Rows Fetch Next 20 Rows Only" );
            Assert.AreEqual( result.ToString(), _builder.GetSql() );
        }
    }
}
