using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Webs.Tests {
    /// <summary>
    /// 参数生成器测试
    /// </summary>
    [TestClass]
    public class ParamBuilderTest {
        /// <summary>
        /// 参数生成器
        /// </summary>
        private ParamBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _builder = new ParamBuilder();
        }

        /// <summary>
        /// 测试默认结果
        /// </summary>
        [TestMethod]
        public void TestGetResult_Default() {
            Assert.AreEqual( "",_builder.GetResult() );
        }

        /// <summary>
        /// 添加空值
        /// </summary>
        [TestMethod]
        public void TestAdd_Empty() {
            _builder.Add( "" );
            Assert.AreEqual( "",_builder.GetResult() );
        }

        /// <summary>
        /// 添加空值
        /// </summary>
        [TestMethod]
        public void TestAdd_Empty_Quotes() {
            _builder.Add( "",true );
            Assert.AreEqual( "", _builder.GetResult() );
        }

        /// <summary>
        /// 添加空值
        /// </summary>
        [TestMethod]
        public void TestAdd_Empty_Default_Quotes() {
            _builder.Add( "","''", true );
            Assert.AreEqual( "''", _builder.GetResult() );
        }

        /// <summary>
        /// 添加值
        /// </summary>
        [TestMethod]
        public void TestAdd_1() {
            _builder.Add( "a" );
            Assert.AreEqual( "a", _builder.GetResult() );
        }

        /// <summary>
        /// 添加值
        /// </summary>
        [TestMethod]
        public void TestAdd_2() {
            _builder.Add( "a" );
            _builder.Add( "b" );
            Assert.AreEqual( "a,b", _builder.GetResult() );
        }

        /// <summary>
        /// 添加值
        /// </summary>
        [TestMethod]
        public void TestAdd_3() {
            _builder.Add( "","null" );
            _builder.Add( "b" );
            Assert.AreEqual( "null,b", _builder.GetResult() );
        }

        /// <summary>
        /// 添加值
        /// </summary>
        [TestMethod]
        public void TestAdd_4() {
            _builder.Add( "a", true );
            Assert.AreEqual( "'a'", _builder.GetResult() );
        }

        /// <summary>
        /// 添加值
        /// </summary>
        [TestMethod]
        public void TestAdd_5() {
            _builder.Add( "a", "null",true );
            _builder.Add( "b",true );
            Assert.AreEqual( "'a','b'", _builder.GetResult() );
        }

        /// <summary>
        /// 测试分隔符
        /// </summary>
        [TestMethod]
        public void TestQuotes() {
            _builder = new ParamBuilder( "\"" );
            _builder.Add( "a",true );
            _builder.Add( "b" );
            Assert.AreEqual( "\"a\",b", _builder.GetResult() );
        }

        /// <summary>
        /// 测试分隔符
        /// </summary>
        [TestMethod]
        public void TestSeparator() {
            _builder = new ParamBuilder( "'", ";" );
            _builder.Add( "a" );
            _builder.Add( "b" );
            Assert.AreEqual( "a;b", _builder.GetResult() );
        }
    }
}
