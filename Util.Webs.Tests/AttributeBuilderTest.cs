using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Webs.Tests {
    /// <summary>
    /// 属性生成器测试
    /// </summary>
    [TestClass]
    public class AttributeBuilderTest {
        /// <summary>
        /// 属性生成器
        /// </summary>
        private AttributeBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _builder = new AttributeBuilder();
        }

        /// <summary>
        /// 获取默认结果
        /// </summary>
        [TestMethod]
        public void TestGetResult_Default() {
            Assert.AreEqual( "",_builder.GetResult() );
        }

        /// <summary>
        /// 验证添加属性名为空值
        /// </summary>
        [TestMethod]
        public void TestAdd_Validate_NameIsEmpty() {
            _builder.Add( "", "a" );
            Assert.AreEqual( "", _builder.GetResult() );
        }

        /// <summary>
        /// 添加1个属性
        /// </summary>
        [TestMethod]
        public void TestAdd_1Attribute() {
            _builder.Add( "class","a" );
            Console.WriteLine(_builder.GetResult());
            Assert.AreEqual( "class=\"a\"",_builder.GetResult() );
        }

        /// <summary>
        /// 为同1个属性添加两个值
        /// </summary>
        [TestMethod]
        public void TestAdd_1Attribute_2Value() {
            _builder.Add( "class", "a" );
            _builder.Add( "class", "b" );
            Console.WriteLine(_builder.GetResult());
            Assert.AreEqual( "class=\"a;b\"", _builder.GetResult() );
        }

        /// <summary>
        /// 添加2个属性
        /// </summary>
        [TestMethod]
        public void TestAdd_2Attribute() {
            _builder.Add( "class", "a" );
            _builder.Add( "name", "b" );
            Console.WriteLine(_builder.GetResult());
            Assert.AreEqual( "class=\"a\" name=\"b\"", _builder.GetResult() );
        }

        /// <summary>
        /// 为同1个属性添加两个值，使用逗号分隔
        /// </summary>
        [TestMethod]
        public void TestAdd_1Attribute_2Value_Comma() {
            _builder.Add( "class", "a","," );
            _builder.Add( "class", "b", "," );
            Console.WriteLine(_builder.GetResult());
            Assert.AreEqual( "class=\"a,b\"", _builder.GetResult() );
        }

        /// <summary>
        /// 为class属性添加两个值，通过空格分隔
        /// </summary>
        [TestMethod]
        public void TestAddClass_2Value() {
            _builder.AddClass( "a" );
            _builder.AddClass( "b" );
            Console.WriteLine(_builder.GetResult());
            Assert.AreEqual( "class=\"a b\"", _builder.GetResult() );
        }

        /// <summary>
        /// 更新class属性
        /// </summary>
        [TestMethod]
        public void TestUpdateClass() {
            _builder.AddClass( "a" );
            _builder.UpdateClass( "b" );
            Console.WriteLine(_builder.GetResult());
            Assert.AreEqual( "class=\"b\"", _builder.GetResult() );
        }

        /// <summary>
        /// 测试属性分隔符
        /// </summary>
        [TestMethod]
        public void TestAttributeSeparator() {
            _builder = new AttributeBuilder(":");
            _builder.Add( "class", "a" );
            Assert.AreEqual( "class:\"a\"", _builder.GetResult() );
        }

        /// <summary>
        /// 测试属性节点分隔符
        /// </summary>
        [TestMethod]
        public void TestNodeSeparator() {
            _builder = new AttributeBuilder( ":","," );
            _builder.Add( "a", "1" );
            _builder.Add( "b", "2" );
            Assert.AreEqual( "a:\"1\",b:\"2\"", _builder.GetResult() );
        }

        /// <summary>
        /// 更新属性
        /// </summary>
        [TestMethod]
        public void TestUpdate() {
            _builder.Add( "class", "a" );
            _builder.Update( "class", "b" );
            Assert.AreEqual( "class=\"b\"", _builder.GetResult() );
        }

        /// <summary>
        /// 添加属性列表
        /// </summary>
        [TestMethod]
        public void TestAdd_Attributes() {
            _builder.Add( "a", "1" );
            _builder.Add( "b=\"2\"" );
            Assert.AreEqual( "a=\"1\" b=\"2\"", _builder.GetResult() );
        }
    }
}