using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests.Strings {
    /// <summary>
    /// 字符串生成器测试
    /// </summary>
    [TestClass]
    public class StrTest {

        #region 测试初始化

        /// <summary>
        /// 字符串
        /// </summary>
        private Str Builder { get; set; }

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            Builder = new Str();
        }

        #endregion

        #region 默认输出

        /// <summary>
        /// 默认输出空字符串
        /// </summary>
        [TestMethod]
        public void TestToString_Empty() {
            Assert.AreEqual( Str.Empty, Builder.ToString() );
        }

        #endregion

        #region 添加内容

        /// <summary>
        /// 添加一个字符串类型的值
        /// </summary>
        [TestMethod]
        public void TestAdd_1Value_String() {
            Builder.Add( "a" );
            Assert.AreEqual( "a", Builder.ToString() );
        }

        /// <summary>
        /// 添加一个整数类型的值
        /// </summary>
        [TestMethod]
        public void TestAdd_1Value_Int() {
            Builder.Add( 1 );
            Assert.AreEqual( "1", Builder.ToString() );
        }

        /// <summary>
        /// 添加2个值
        /// </summary>
        [TestMethod]
        public void TestAdd_2Value() {
            Builder.Add( "a" );
            Builder.Add( 1 );
            Assert.AreEqual( "a1", Builder.ToString() );
        }

        /// <summary>
        /// 添加1个参数
        /// </summary>
        [TestMethod]
        public void TestAdd_1Params() {
            Builder.Add( "a{0}b", 1 );
            Assert.AreEqual( "a1b", Builder.ToString() );
        }

        /// <summary>
        /// 添加2个参数
        /// </summary>
        [TestMethod]
        public void TestAdd_2Params() {
            Builder.Add( "a{0}b{1}", 1, 5.5 );
            Assert.AreEqual( "a1b5.5", Builder.ToString() );
        }

        /// <summary>
        /// 验证添加空参数
        /// </summary>
        [TestMethod]
        public void TestAdd_Validate_ParamIsNull() {
            Builder.Add( "a{0}b", null );
            Assert.AreEqual( "ab", Builder.ToString() );
        }

        /// <summary>
        /// 验证添加空参数
        /// </summary>
        [TestMethod]
        public void TestAdd_Validate_ParamIsNull2() {
            Builder.Add( "a{0}b{1}", null, null );
            Assert.AreEqual( "ab", Builder.ToString() );
        }

        /// <summary>
        /// 测试添加括号 {
        /// </summary>
        [TestMethod]
        public void TestAdd_1() {
            Builder.Add( "{" );
            Builder.Add( "}" );
            Assert.AreEqual( "{}",Builder.ToString() );
        }

        #endregion

        #region 添加换行

        /// <summary>
        /// 测试换行
        /// </summary>
        [TestMethod]
        public void TestAddLine() {
            Builder.AddLine();
            Assert.AreEqual( "\r\n", Builder.ToString() );
        }

        /// <summary>
        /// 测试换行,添加内容
        /// </summary>
        [TestMethod]
        public void TestAddLine_Value() {
            Builder.AddLine( 1 );
            Builder.Add( "b" );
            Assert.AreEqual( "1\r\nb", Builder.ToString() );
        }

        /// <summary>
        /// 测试换行,带参数
        /// </summary>
        [TestMethod]
        public void TestAddLine_Params() {
            Builder.AddLine( "a{0}", 1 );
            Builder.Add( "b" );
            Assert.AreEqual( "a1\r\nb", Builder.ToString() );
        }

        #endregion

        #region 清除字符串

        /// <summary>
        /// 测试清空字符串
        /// </summary>
        [TestMethod]
        public void TestClear() {
            Builder.Add( "a" );
            Builder.Clear();
            Assert.AreEqual( "", Builder.ToString() );
        }

        /// <summary>
        /// 移除末尾的字符串
        /// </summary>
        [TestMethod]
        public void TestRemoveEnd() {
            Builder.Add( "a," );
            Builder.RemoveEnd( "," );
            Assert.AreEqual( "a",Builder.ToString() );
        }

        /// <summary>
        /// 1. 功能：移除末尾字符串，
        /// 2. 场景：从"ab"中移除"a",
        /// 3. 预期：返回"ab"
        /// </summary>
        [TestMethod]
        public void TestRemoveEnd_2() {
            Builder.Add( "ab" );
            Builder.RemoveEnd( "a" );
            Assert.AreEqual( "ab", Builder.ToString() );
        }

        /// <summary>
        /// 1. 功能：移除末尾字符串，
        /// 2. 场景：从"abc"中移除"bc",
        /// 3. 预期：返回"a"
        /// </summary>
        [TestMethod]
        public void TestRemoveEnd_3() {
            Builder.Add( "abc" );
            Builder.RemoveEnd( "bc" );
            Assert.AreEqual( "a", Builder.ToString() );
        }

        #endregion

        #region 性能测试

        /// <summary>
        /// 测试实例化的性能
        /// </summary>
        [TestMethod]
        [Ignore]
        public void TestPerformance_New() {
            Str str = new Str();
            str.Add( "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" );
            str.Add( "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" );
            str.Add( "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" );
            str.Add( "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" );
            for( int i = 0; i < 10000000; i++ ) {
                str = new Str();
            }
        }

        /// <summary>
        /// 测试Clear方法的性能
        /// </summary>
        [TestMethod]
        [Ignore]
        public void TestPerformance_Clear() {
            Str str = new Str();
            str.Add( "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" );
            str.Add( "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" );
            str.Add( "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" );
            str.Add( "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" );
            for ( int i = 0; i < 10000000; i++ ) {
                str.Clear();
            }
        }

        #endregion
    }
}
