using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Validations;

namespace Util.Tests.Validations {
    /// <summary>
    /// 验证结果集合测试
    /// </summary>
    [TestClass]
    public class ValidationResultCollectionTest {
        /// <summary>
        /// 验证结果集合
        /// </summary>
        private ValidationResultCollection _results;

        /// <summary>
        /// 验证初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _results = new ValidationResultCollection();
        }

        /// <summary>
        /// 在默认情况下，结果集合个数为0
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            Assert.AreEqual( 0, _results.Count );
            Assert.IsTrue( _results.IsValid );
        }

        /// <summary>
        /// 添加一个null值，直接忽略
        /// </summary>
        [TestMethod]
        public void TestAdd_Null() {
            _results.Add( null );
            _results.Add( ValidationResult.Success );
            Assert.AreEqual( 0, _results.Count );
        }

        /// <summary>
        /// 添加1个验证结果
        /// </summary>
        [TestMethod]
        public void TestAdd_1Result() {
            _results.Add( new ValidationResult( "a" ) );
            Assert.AreEqual( 1, _results.Count );
            Assert.AreEqual( "a", _results.First().ErrorMessage );
            Assert.IsFalse( _results.IsValid );
            foreach ( var result in _results ) {
                Assert.AreEqual( "a", result.ErrorMessage );
            }
        }

        /// <summary>
        /// 添加一个null验证结果集合，直接忽略
        /// </summary>
        [TestMethod]
        public void TestAddResults_Null() {
            _results.AddResults( null );
            Assert.AreEqual( 0,_results.Count );
        }

        /// <summary>
        /// 添加2个验证结果
        /// </summary>
        [TestMethod]
        public void TestAddResults_2Result() {
            _results.AddResults( new[] { new ValidationResult( "a" ), new ValidationResult( "b" ) } );
            Assert.AreEqual( 2, _results.Count );
            Assert.AreEqual( "b", _results.Last().ErrorMessage );
        }
    }
}
