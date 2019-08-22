using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Webs.Tests {
    /// <summary>
    /// Json属性生成器测试
    /// </summary>
    [TestClass]
    public class JsonAttributeBuilderTest {
        /// <summary>
        /// Json属性生成器
        /// </summary>
        private JsonAttributeBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _builder = new JsonAttributeBuilder();
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        [TestMethod]
        public void TestAdd_1() {
            _builder.Add( "a","1" );
            Assert.AreEqual( "a:1",_builder.GetResult() );
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        [TestMethod]
        public void TestAdd_2() {
            _builder.Add( "a", "1" );
            _builder.Add( "b", "2","'" );
            Assert.AreEqual( "a:1,b:'2'", _builder.GetResult() );
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        [TestMethod]
        public void TestAdd_3() {
            _builder.Add( "a", "1" );
            _builder.Add( "b:'2'" );
            Assert.AreEqual( "a:1,b:'2'", _builder.GetResult() );
        }
    }
}
