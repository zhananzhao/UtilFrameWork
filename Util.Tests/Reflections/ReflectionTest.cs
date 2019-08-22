using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Tests.Samples;

namespace Util.Tests.Reflections {
    /// <summary>
    /// 反射操作测试
    /// </summary>
    [TestClass]
    public class ReflectionTest {
        /// <summary>
        /// 测试
        /// </summary>
        private User _user;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _user = new User();
        }

        /// <summary>
        /// 动态创建实例
        /// </summary>
        [TestMethod]
        public void TestCreateInstance() {
            const string className = "Util.Tests.Samples.Test2";
            Assert.IsNotNull( Util.Reflection.CreateInstance<Test2>( className ) );
            var result = Util.Reflection.CreateInstance<Test2>( className, "a" );
            Assert.AreEqual( "a",result.Name );
        }

        /// <summary>
        /// 测试是否布尔类型
        /// </summary>
        [TestMethod]
        public void TestIsBool() {
            Assert.IsTrue( Util.Reflection.IsBool( _user.BoolValue.GetType() ), "BoolValue GetType" );
            Assert.IsTrue( Util.Reflection.IsBool( _user.GetType().GetMember( "BoolValue" )[0] ), "BoolValue" );
            Assert.IsTrue( Util.Reflection.IsBool( _user.GetType().GetMember( "NullableBoolValue" )[0] ), "NullableBoolValue" );
            Assert.IsFalse( Util.Reflection.IsBool( _user.GetType().GetMember( "EnumValue" )[0] ), "EnumValue" );
        }

        /// <summary>
        /// 测试是否枚举类型
        /// </summary>
        [TestMethod]
        public void TestIsEnum() {
            Assert.IsTrue( Util.Reflection.IsEnum( _user.EnumValue.GetType() ), "EnumValue GetType" );
            Assert.IsTrue( Util.Reflection.IsEnum( _user.GetType().GetMember( "EnumValue" )[0] ), "EnumValue" );
            Assert.IsTrue( Util.Reflection.IsEnum( _user.GetType().GetMember( "NullableEnumValue" )[0] ), "NullableEnumValue" );
            Assert.IsFalse( Util.Reflection.IsEnum( _user.GetType().GetMember( "BoolValue" )[0] ), "BoolValue" );
            Assert.IsFalse( Util.Reflection.IsEnum( _user.GetType().GetMember( "NullableBoolValue" )[0] ), "NullableBoolValue" );
        }

        /// <summary>
        /// 测试是否日期类型
        /// </summary>
        [TestMethod]
        public void TestIsDate() {
            Assert.IsTrue( Util.Reflection.IsDate( _user.DateValue.GetType() ), "DateValue GetType" );
            Assert.IsTrue( Util.Reflection.IsDate( _user.GetType().GetMember( "DateValue" )[0] ), "DateValue" );
            Assert.IsTrue( Util.Reflection.IsDate( _user.GetType().GetMember( "NullableDateValue" )[0] ), "NullableDateValue" );
            Assert.IsFalse( Util.Reflection.IsDate( _user.GetType().GetMember( "EnumValue" )[0] ), "EnumValue" );
        }

        /// <summary>
        /// 测试是否整型
        /// </summary>
        [TestMethod]
        public void TestIsInt() {
            Assert.IsTrue( Util.Reflection.IsInt( _user.IntValue.GetType() ), "IntValue GetType" );
            Assert.IsTrue( Util.Reflection.IsInt( _user.GetType().GetMember( "IntValue" )[0] ), "IntValue" );
            Assert.IsTrue( Util.Reflection.IsInt( _user.GetType().GetMember( "NullableIntValue" )[0] ), "NullableIntValue" );

            Assert.IsTrue( Util.Reflection.IsInt( _user.ShortValue.GetType() ), "ShortValue GetType" );
            Assert.IsTrue( Util.Reflection.IsInt( _user.GetType().GetMember( "ShortValue" )[0] ), "ShortValue" );
            Assert.IsTrue( Util.Reflection.IsInt( _user.GetType().GetMember( "NullableShortValue" )[0] ), "NullableShortValue" );

            Assert.IsTrue( Util.Reflection.IsInt( _user.LongValue.GetType() ), "LongValue GetType" );
            Assert.IsTrue( Util.Reflection.IsInt( _user.GetType().GetMember( "LongValue" )[0] ), "LongValue" );
            Assert.IsTrue( Util.Reflection.IsInt( _user.GetType().GetMember( "NullableLongValue" )[0] ), "NullableLongValue" );
        }

        /// <summary>
        /// 测试是否数值类型
        /// </summary>
        [TestMethod]
        public void TestIsNumber() {
            Assert.IsTrue( Util.Reflection.IsNumber( _user.DoubleValue.GetType() ), "DoubleValue GetType" );
            Assert.IsTrue( Util.Reflection.IsNumber( _user.GetType().GetMember( "DoubleValue" )[0] ), "DoubleValue" );
            Assert.IsTrue( Util.Reflection.IsNumber( _user.GetType().GetMember( "NullableDoubleValue" )[0] ), "NullableDoubleValue" );

            Assert.IsTrue( Util.Reflection.IsNumber( _user.DecimalValue.GetType() ), "DecimalValue GetType" );
            Assert.IsTrue( Util.Reflection.IsNumber( _user.GetType().GetMember( "DecimalValue" )[0] ), "DecimalValue" );
            Assert.IsTrue( Util.Reflection.IsNumber( _user.GetType().GetMember( "NullableDecimalValue" )[0] ), "NullableDecimalValue" );

            Assert.IsTrue( Util.Reflection.IsNumber( _user.FloatValue.GetType() ), "FloatValue GetType" );
            Assert.IsTrue( Util.Reflection.IsNumber( _user.GetType().GetMember( "FloatValue" )[0] ), "FloatValue" );
            Assert.IsTrue( Util.Reflection.IsNumber( _user.GetType().GetMember( "NullableFloatValue" )[0] ), "NullableFloatValue" );
        }

        /// <summary>
        /// 获取实现了接口的所有具体类型
        /// </summary>
        [TestMethod]
        public void TestGetByInterface() {
            var assembly = Assembly.GetExecutingAssembly();
            List<ITest> tests = Reflection.GetByInterface<ITest>( assembly );
            Assert.AreEqual( 2,tests.Count );
        }
    }
}
