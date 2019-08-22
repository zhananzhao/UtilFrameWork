using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Webs.Tests {
    /// <summary>
    /// 数组生成器测试
    /// </summary>
    [TestClass]
    public class ArrayBuilderTest {
        /// <summary>
        /// 数组生成器
        /// </summary>
        private ArrayBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _builder = new ArrayBuilder();
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            Assert.AreEqual( "",_builder.ToString() );
        }

        /// <summary>
        /// 测试添加
        /// </summary>
        [TestMethod]
        public void TestAdd() {
            _builder.Add( "a" );
            Assert.AreEqual( "[a]", _builder.ToString() );
            _builder.Add( "b" );
            Assert.AreEqual( "[a,b]", _builder.ToString() );
            _builder.Add( null );
            Assert.AreEqual( "[a,b]", _builder.ToString() );
        }

        /// <summary>
        /// 测试设置方法
        /// </summary>
        [TestMethod]
        public void TestMethod() {
            _builder.Method = "a";
            Assert.AreEqual( "", _builder.ToString() );
            _builder.Add( "b" );
            Assert.AreEqual( "a([b])", _builder.ToString() );
        }
    }
}
