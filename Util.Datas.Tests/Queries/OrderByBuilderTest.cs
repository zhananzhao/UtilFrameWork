using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Datas.Queries;
using Util.Datas.Queries.OrderBys;

namespace Util.Datas.Tests.Queries {
    /// <summary>
    /// 排序生成器测试
    /// </summary>
    [TestClass]
    public class OrderByBuilderTest {
        /// <summary>
        /// 排序生成器
        /// </summary>
        private OrderByBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _builder = new OrderByBuilder();
        }

        /// <summary>
        /// 验证未添加排序
        /// </summary>
        [TestMethod]
        public void TestGenerate_Empty() {
            Assert.AreEqual( "", _builder.Generate() );
        }

        /// <summary>
        /// 生成排序字符串
        /// </summary>
        [TestMethod]
        public void TestGenerate() {
            _builder.Add( "A" );
            _builder.Add( "B", true );
            _builder.Add( "C.D", OrderDirection.Desc );
            Assert.AreEqual( "A,B desc,C.D desc", _builder.Generate() );
        }
    }
}
