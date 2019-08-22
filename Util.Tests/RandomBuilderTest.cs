using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Tests.Samples;

namespace Util.Tests {
    /// <summary>
    /// 随机数生成器测试
    /// </summary>
    [TestClass]
    public class RandomBuilderTest {
        /// <summary>
        /// 随机数生成器
        /// </summary>
        private RandomBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _builder = new RandomBuilder();
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        [TestMethod]
        public void TestGenerateString() {
            var old = string.Empty;
            for( int i = 0; i < 100; i++ ) {
                var result = _builder.GenerateString( 100 );
                Assert.IsTrue( old != result,"!=" );
                Assert.IsTrue( result.Length > 0,">0" );
                Assert.IsTrue( result.Length <= 100,"<=100" );
            }
        }

        /// <summary>
        /// 生成随机字母
        /// </summary>
        [TestMethod]
        public void TestGenerateLetters() {
            var old = string.Empty;
            for ( int i = 0; i < 100; i++ ) {
                var result = _builder.GenerateLetters( 100 );
                Assert.IsTrue( old != result, "!=" );
                Assert.IsTrue( result.Length > 0, ">0" );
                Assert.IsTrue( result.Length <= 100, "<=100" );
                Assert.IsFalse( Str.ContainsChinese( result ) );
                Assert.IsFalse( Str.ContainsNumber( result ) );
            }
        }

        /// <summary>
        /// 生成随机数字
        /// </summary>
        [TestMethod]
        public void TestGenerateInt() {
            int? old = null;
            for ( int i = 0; i < 100; i++ ) {
                var result = _builder.GenerateInt( 100 );
                Assert.IsTrue( old != result, "!=" );
                Assert.IsTrue( result >= 0, ">=0" );
                Assert.IsTrue( result <= 100, "<=100" );
            }
        }

        /// <summary>
        /// 生成随机布尔值
        /// </summary>
        [TestMethod]
        public void TestGenerateBool() {
            var result = new List<bool>();
            for( int i = 0; i < 100; i++ ) {
                result.Add( _builder.GenerateBool() );
            }
            Assert.IsTrue( result.Contains( true ), "true" );
            Assert.IsTrue( result.Contains( false ), "false" );
        }

        /// <summary>
        /// 生成随机日期
        /// </summary>
        [TestMethod]
        public void TestGenerateDate() {
            Assert.IsTrue( _builder.GenerateDate() != DateTime.MinValue );
            Assert.IsTrue( _builder.GenerateDate() != DateTime.MaxValue );
        }

        /// <summary>
        /// 生成随机枚举
        /// </summary>
        [TestMethod]
        public void TestGenerateEnum() {
            var result = new List<LogType>();
            for ( int i = 0; i < 100; i++ ) {
                result.Add( _builder.GenerateEnum<LogType>() );
            }
            Assert.IsTrue( result.Contains( LogType.Debug ), "LogType.Debug" );
            Assert.IsTrue( result.Contains( LogType.Error ), "LogType.Error" );
        }
    }
}
