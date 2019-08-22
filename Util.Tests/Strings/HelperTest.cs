using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests.Strings {
    /// <summary>
    /// 测试字符串工具操作
    /// </summary>
    [TestClass]
    public class HelperTest {

        #region PinYin(获取拼音简码)

        /// <summary>
        /// 获取拼音简码
        /// </summary>
        [TestMethod]
        public void TestPinYin() {
            Assert.AreEqual( "", Str.PinYin( null ) );
            Assert.AreEqual( "", Str.PinYin( "" ) );
            Assert.AreEqual( "zg", Str.PinYin( "中国" ) );
            Assert.AreEqual( "a1bcb2", Str.PinYin( "a1宝藏b2" ) );
            Assert.AreEqual( "tt", Str.PinYin( "饕餮" ) );
        }

        #endregion

        #region Splice(拼接集合元素)

        /// <summary>
        /// 拼接int集合元素，默认用逗号分隔，不带引号
        /// </summary>
        [TestMethod]
        public void TestSplice_Int() {
            Assert.AreEqual( "1,2,3", Str.Splice( new List<int> { 1, 2, 3 } ) );
        }

        /// <summary>
        /// 拼接int集合元素，带单引号
        /// </summary>
        [TestMethod]
        public void TestSplice_Int_SingleQuotes() {
            Assert.AreEqual( "'1','2','3'", Str.Splice( new List<int> { 1, 2, 3 }, "'" ) );
        }

        /// <summary>
        /// 拼接int集合元素，空分隔符
        /// </summary>
        [TestMethod]
        public void TestSplice_Int_EmptySeparator() {
            Assert.AreEqual( "123", Str.Splice( new List<int> { 1, 2, 3 }, "","" ) );
        }

        /// <summary>
        /// 拼接int集合元素，带双引号
        /// </summary>
        [TestMethod]
        public void TestSplice_Int_DoubleQuotes() {
            Assert.AreEqual( "\"1\",\"2\",\"3\"", Str.Splice( new List<int> { 1, 2, 3 }, "\"" ) );
        }

        /// <summary>
        /// 拼接int集合元素，用空格分隔
        /// </summary>
        [TestMethod]
        public void TestSplice_Int_Blank() {
            Assert.AreEqual( "1 2 3", Str.Splice( new List<int> { 1, 2, 3 },""," " ) );
        }

        /// <summary>
        /// 拼接int集合元素，用分号分隔
        /// </summary>
        [TestMethod]
        public void TestSplice_Int_Semicolon() {
            Assert.AreEqual( "1;2;3", Str.Splice( new List<int> { 1, 2, 3 }, "", ";" ) );
        }

        /// <summary>
        /// 拼接字符串集合元素
        /// </summary>
        [TestMethod]
        public void TestSplice_String() {
            Assert.AreEqual( "1,2,3", Str.Splice( new List<string> { "1", "2", "3" } ) );
        }

        /// <summary>
        /// 拼接字符串集合元素，带单引号
        /// </summary>
        [TestMethod]
        public void TestSplice_String_SingleQuotes() {
            Assert.AreEqual( "'1','2','3'", Str.Splice( new List<string> { "1", "2", "3" }, "'" ) );
        }

        /// <summary>
        /// 拼接Guid集合元素
        /// </summary>
        [TestMethod]
        public void TestSplice_Guid() {
            Assert.AreEqual( "83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A".ToLower(),
                Str.Splice( new List<Guid> {
                    new Guid( "83B0233C-A24F-49FD-8083-1337209EBC9A" ),
                    new Guid( "EAB523C6-2FE7-47BE-89D5-C6D440C3033A" )
                } ) );
        }

        /// <summary>
        /// 拼接Guid集合元素，带单引号
        /// </summary>
        [TestMethod]
        public void TestSplice_Guid_SingleQuotes() {
            Assert.AreEqual( "'83B0233C-A24F-49FD-8083-1337209EBC9A','EAB523C6-2FE7-47BE-89D5-C6D440C3033A'".ToLower(),
                Str.Splice( new List<Guid> {
                    new Guid( "83B0233C-A24F-49FD-8083-1337209EBC9A" ),
                    new Guid( "EAB523C6-2FE7-47BE-89D5-C6D440C3033A" )
                }, "'" ) );
        }

        #endregion

        #region FirstUpper(将值的首字母大写)

        /// <summary>
        /// 将值的首字母大写
        /// </summary>
        [TestMethod]
        public void TestFirstUpper() {
            const string text = "aBc";
            string actual = Str.FirstUpper( text );
            Assert.AreEqual( "ABc", actual );
        }

        #endregion

        #region ToCamel(将字符串转成驼峰形式)

        /// <summary>
        /// 将字符串转成驼峰形式
        /// </summary>
        [TestMethod]
        public void TestToCamel() {
            Assert.AreEqual( "Abc", Str.ToCamel( "aBc" ) );
        }

        #endregion

        #region ContainsChinese(是否包含中文)

        /// <summary>
        /// 测试是否包含中文
        /// </summary>
        [TestMethod]
        public void TestContainsChinese() {
            Assert.IsTrue( Str.ContainsChinese( "a中1文b" ) );
            Assert.IsFalse( Str.ContainsChinese( "a1b" ) );
        }

        #endregion

        #region TestContainsNumber(是否包含数字)

        /// <summary>
        /// 测试是否包含数字
        /// </summary>
        [TestMethod]
        public void TestContainsNumber() {
            Assert.IsTrue( Str.ContainsNumber( "a中1文b" ) );
            Assert.IsTrue( Str.ContainsNumber( "a中2文b" ) );
            Assert.IsTrue( Str.ContainsNumber( "a中3文b" ) );
            Assert.IsTrue( Str.ContainsNumber( "a中4文b" ) );
            Assert.IsTrue( Str.ContainsNumber( "a中5文b" ) );
            Assert.IsTrue( Str.ContainsNumber( "a中6文b" ) );
            Assert.IsTrue( Str.ContainsNumber( "a中7文b" ) );
            Assert.IsTrue( Str.ContainsNumber( "a中8文b" ) );
            Assert.IsTrue( Str.ContainsNumber( "a中9文b" ) );
            Assert.IsTrue( Str.ContainsNumber( "a中0文b" ) );
            Assert.IsFalse( Str.ContainsNumber( "ab" ) );
        }

        #endregion

        #region Distinct(去除重复)

        /// <summary>
        /// 去除重复
        /// </summary>
        [TestMethod]
        public void TestDistinct() {
            Assert.AreEqual( "5", Str.Distinct( "55555" ) );
            Assert.AreEqual( "45", Str.Distinct( "45454545" ) );
        }

        #endregion

        #region Truncate(截断字符串)

        /// <summary>
        /// 截断字符串
        /// </summary>
        [TestMethod]
        public void TestTruncate() {
            Assert.AreEqual( "", Str.Truncate( null, 4 ) );
            Assert.AreEqual( "", Str.Truncate( "", 4 ) );
            Assert.AreEqual( "abcd", Str.Truncate( "abcdef", 4 ) );
            Assert.AreEqual( "abcd..", Str.Truncate( "abcdef", 4, 2 ) );
            Assert.AreEqual( "abcd--", Str.Truncate( "abcdef", 4, 2, "-" ) );
            Assert.AreEqual( "ab", Str.Truncate( "ab", 4 ) );
        }

        #endregion

        #region ToSimplifiedChinese(转换为简体中文)

        /// <summary>
        /// 转换为简体中文
        /// </summary>
        [TestMethod]
        public void TestToSimplifiedChinese() {
            Assert.AreEqual( "国", Str.ToSimplifiedChinese( "國" ) );
        }

        #endregion

        #region ToTraditionalChinese(转换为繁体中文)

        /// <summary>
        /// 转换为繁体中文
        /// </summary>
        [TestMethod]
        public void TestToTraditionalChinese() {
            Assert.AreEqual( "國", Str.ToTraditionalChinese( "国" ) );
        }

        #endregion

        #region GetLastProperty(获取最后一个属性)

        /// <summary>
        /// 获取最后一个属性
        /// </summary>
        [TestMethod]
        public void TestGetLastProperty() {
            Assert.AreEqual( "", Str.GetLastProperty( null ) );
            Assert.AreEqual( "", Str.GetLastProperty( "" ) );
            Assert.AreEqual( "A", Str.GetLastProperty( "A" ) );
            Assert.AreEqual( "B", Str.GetLastProperty( "A.B" ) );
            Assert.AreEqual( "C", Str.GetLastProperty( "A.B.C" ) );
        }

        #endregion
    }
}
