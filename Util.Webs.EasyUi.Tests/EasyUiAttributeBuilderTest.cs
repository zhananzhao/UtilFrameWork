using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Webs.EasyUi.Tests {
    /// <summary>
    /// Easyui属性生成器测试
    /// </summary>
    [TestClass]
    public class EasyUiAttributeBuilderTest {
        /// <summary>
        /// Easyui属性生成器
        /// </summary>
        private EasyUiAttributeBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _builder = new EasyUiAttributeBuilder();
        }

        /// <summary>
        /// 添加data-options属性
        /// </summary>
        [TestMethod]
        public void TestAddDataOption_1() {
            _builder.AddDataOption( "a","1" );
            Assert.AreEqual( "data-options=\"a:1\"",_builder.ToString() );
        }

        /// <summary>
        /// 添加data-options属性
        /// </summary>
        [TestMethod]
        public void TestAddDataOption_2() {
            _builder.AddDataOption( "a", "1" );
            _builder.AddDataOption( "b","2" );
            Assert.AreEqual( "data-options=\"a:1,b:2\"", _builder.ToString() );
        }

        /// <summary>
        /// 修改data-options属性
        /// </summary>
        [TestMethod]
        public void TestAddDataOption_3() {
            _builder.AddDataOption( "a", "1" );
            _builder.AddDataOption( "a", "2" );
            Assert.AreEqual( "data-options=\"a:2\"", _builder.ToString() );
        }

        /// <summary>
        /// 修改data-options属性
        /// </summary>
        [TestMethod]
        public void TestAddDataOption_4() {
            _builder.AddDataOption( "a", "1" );
            _builder.AddDataOption( "b", "2" );
            _builder.AddDataOption( "a", "2" );
            Assert.AreEqual( "data-options=\"a:2,b:2\"", _builder.ToString() );
        }

        /// <summary>
        /// 修改data-options属性
        /// </summary>
        [TestMethod]
        public void TestAddDataOption_5() {
            _builder.AddDataOption( "a", "1" );
            _builder.AddDataOption( "b", "2" );
            _builder.AddDataOption( "a", "'a1'" );
            Assert.AreEqual( "data-options=\"a:'a1',b:2\"", _builder.ToString() );
        }

        /// <summary>
        /// 添加data-options属性
        /// </summary>
        [TestMethod]
        public void TestAddDataOption_6() {
            _builder.AddDataOption( "a", "1",true );
            Assert.AreEqual( "data-options=\"a:'1'\"", _builder.ToString() );
        }

        /// <summary>
        /// 添加data-options属性
        /// </summary>
        [TestMethod]
        public void TestAddDataOption_7() {
            _builder.AddDataOption( "a", true );
            Assert.AreEqual( "data-options=\"a:true\"", _builder.ToString() );
        }

        /// <summary>
        /// 添加data-options属性
        /// </summary>
        [TestMethod]
        public void TestAddDataOption_8() {
            _builder.AddDataOption( "a", true );
            _builder.AddDataOption( "b:1" );
            Assert.AreEqual( "data-options=\"a:true,b:1\"", _builder.ToString() );
        }

        /// <summary>
        /// 添加data-options属性
        /// </summary>
        [TestMethod]
        public void TestAddDataOption_9() {
            _builder.AddDataOption("");
            Assert.AreEqual( "", _builder.ToString() );
        }
    }
}
