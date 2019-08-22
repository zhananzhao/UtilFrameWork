using System;
using Json.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Tests.Samples;

namespace Util.Webs.Tests {
    /// <summary>
    /// Json测试
    /// </summary>
    [TestClass]
    public class JsonTest {
        /// <summary>
        /// 测试循环引用序列化
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( JsonSerializationException ) )]
        public void TestLoop() {
            A a = new A {Name = "a"};
            B b = new B {Name = "b"};
            C c = new C {Name = "c"};
            a.B = b;
            b.C = c;
            c.A = a;
            Console.Write( Json.ToJson( c ) );
        }

        /// <summary>
        /// 转成Json,验证空
        /// </summary>
        [TestMethod]
        public void TestToJson_Validate_Null() {
            Assert.AreEqual( "{}", Json.ToJson( null ) ); 
        }

        /// <summary>
        /// 测试转成Json
        /// </summary>
        [TestMethod]
        public void TestToJson() {
            Str result = new Str();
            result.Add( "{" );
            result.Add( "\"Name\":\"a\"," );
            result.Add( "\"nickname\":\"b\"," );
            result.Add( "\"func\":c," );
            result.Add( "\"Value\":null," );
            result.Add( "\"Date\":\"2012/1/1 0:00:00\"," );
            result.Add( "\"Age\":1," );
            result.Add( "\"isShow\":true" );
            result.Add( "}" );
            Console.Write( result );
            Assert.AreEqual( result.ToString(), Json.ToJson( Customer.Create() ) ); 
        }

        /// <summary>
        /// 测试转成对象
        /// </summary>
        [TestMethod]
        public void TestToObject() {
            Str result = new Str();
            result.Add( "{" );
            result.Add( "\"Name\":\"a\"" );
            result.Add( "}" );
            var customer = Json.ToObject<Customer>( result.ToString() );
            Assert.AreEqual( "a", customer.Name );
        }

        /// <summary>
        /// 测试转成Json，不带{}
        /// </summary>
        [TestMethod]
        public void ToJsonWithoutBrackets() {
            var result = new Str();
            result.Add( "\"Name\":\"a\"," );
            result.Add( "\"nickname\":\"b\"," );
            result.Add( "\"func\":c," );
            result.Add( "\"Value\":null," );
            result.Add( "\"Date\":\"2012/1/1 0:00:00\"," );
            result.Add( "\"Age\":1," );
            result.Add( "\"isShow\":true" );
            Assert.AreEqual( result.ToString(), Json.ToJsonWithoutBrackets( Customer.Create() ) );
        }

        /// <summary>
        /// 测试转成Json，不带{}
        /// </summary>
        [TestMethod]
        public void ToJsonWithoutBrackets_Empty() {
            Assert.AreEqual( "{}", Json.ToJsonWithoutBrackets( new{} ) );
        }
    }
}
