using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests {
    /// <summary>
    /// 类型转换测试
    /// </summary>
    [TestClass]
    public class ConvTest {

        #region ToInt(转换为整型)

        /// <summary>
        ///转换为整型,值为null
        ///</summary>
        [TestMethod]
        public void TestToInt_Null() {
            Assert.AreEqual( 0, Util.Conv.ToInt( null ) );
        }

        /// <summary>
        ///转换为整型,值为空字符串
        ///</summary>
        [TestMethod]
        public void TestToInt_Empty() {
            Assert.AreEqual( 0, Util.Conv.ToInt( "" ) );
        }

        /// <summary>
        ///转换为整型,无效值
        ///</summary>
        [TestMethod]
        public void TestToInt_Invalid() {
            Assert.AreEqual( 0, Util.Conv.ToInt( "1A" ) );
        }

        /// <summary>
        ///转换为整型,有效值
        ///</summary>
        [TestMethod]
        public void TestToInt() {
            Assert.AreEqual( 1, Util.Conv.ToInt( "1" ) );
            Assert.AreEqual( 1778020, Util.Conv.ToInt( "1778019.7801684" ) );
        }

        #endregion

        #region ToIntOrNull(转换为可空整型)

        /// <summary>
        ///转换为可空整型,值为null
        ///</summary>
        [TestMethod]
        public void TestToIntOrNull_Null() {
            Assert.IsNull( Util.Conv.ToIntOrNull( null ) );
        }

        /// <summary>
        ///转换为可空整型,值为空字符串
        ///</summary>
        [TestMethod]
        public void TestToIntOrNull_Empty() {
            Assert.IsNull( Util.Conv.ToIntOrNull( "" ) );
        }

        /// <summary>
        ///转换为可空整型,无效值
        ///</summary>
        [TestMethod]
        public void TestToIntOrNull_Invalid() {
            Assert.IsNull( Util.Conv.ToIntOrNull( "1A" ) );
        }

        /// <summary>
        ///转换为可空整型,值为0
        ///</summary>
        [TestMethod]
        public void TestToIntOrNull_0() {
            Assert.AreEqual( 0, Util.Conv.ToIntOrNull( "0" ) );
        }

        /// <summary>
        ///转换为可空整型,有效值
        ///</summary>
        [TestMethod]
        public void TestToIntOrNull() {
            Assert.AreEqual( 1, Util.Conv.ToIntOrNull( "1" ) );
        }

        #endregion

        #region ToDouble(转换为双精度浮点数)

        /// <summary>
        ///转换为双精度浮点数,值为null
        ///</summary>
        [TestMethod]
        public void TestToDouble_Null() {
            Assert.AreEqual( 0, Util.Conv.ToDouble( null ) );
        }

        /// <summary>
        ///转换为双精度浮点数,值为空字符串
        ///</summary>
        [TestMethod]
        public void TestToDouble_Empty() {
            Assert.AreEqual( 0, Util.Conv.ToDouble( "" ) );
        }

        /// <summary>
        ///转换为双精度浮点数,无效值
        ///</summary>
        [TestMethod]
        public void TestToDouble_Invalid() {
            Assert.AreEqual( 0, Util.Conv.ToDouble( "1A" ) );
        }

        /// <summary>
        ///转换为双精度浮点数,有效值
        ///</summary>
        [TestMethod]
        public void TestToDouble() {
            Assert.AreEqual( 1.2, Util.Conv.ToDouble( "1.2" ) );
        }

        /// <summary>
        /// 转换为双精度浮点数,指定2位小数位数
        ///</summary>
        [TestMethod()]
        public void TestToDouble_DigitsIs2() {
            Assert.AreEqual( 12.36, Util.Conv.ToDouble( "12.355", 2 ) );
        }

        #endregion

        #region ToDoubleOrNull(转换为可空双精度浮点数)

        /// <summary>
        ///转换为可空双精度浮点数,值为null
        ///</summary>
        [TestMethod]
        public void TestToDoubleOrNull_Null() {
            Assert.IsNull( Util.Conv.ToDoubleOrNull( null ) );
        }

        /// <summary>
        ///转换为可空双精度浮点数,值为空字符串
        ///</summary>
        [TestMethod]
        public void TestToDoubleOrNull_Empty() {
            Assert.IsNull( Util.Conv.ToDoubleOrNull( "" ) );
        }

        /// <summary>
        ///转换为可空双精度浮点数,无效值
        ///</summary>
        [TestMethod]
        public void TestToDoubleOrNull_Invalid() {
            Assert.IsNull( Util.Conv.ToDoubleOrNull( "1A" ) );
        }

        /// <summary>
        ///转换为可空双精度浮点数,值为0
        ///</summary>
        [TestMethod]
        public void TestToDoubleOrNull_0() {
            Assert.AreEqual( 0, Util.Conv.ToDoubleOrNull( "0" ) );
        }

        /// <summary>
        ///转换为可空双精度浮点数,有效值
        ///</summary>
        [TestMethod]
        public void TestToDoubleOrNull() {
            Assert.AreEqual( 1.2, Util.Conv.ToDoubleOrNull( "1.2" ) );
        }

        #endregion

        #region ToDecimal(转换为高精度浮点数)

        /// <summary>
        ///转换为高精度浮点数,值为null
        ///</summary>
        [TestMethod]
        public void TestToDecimal_Null() {
            Assert.AreEqual( 0, Util.Conv.ToDecimal( null ) );
        }

        /// <summary>
        ///转换为高精度浮点数,值为空字符串
        ///</summary>
        [TestMethod]
        public void TestToDecimal_Empty() {
            Assert.AreEqual( 0, Util.Conv.ToDecimal( "" ) );
        }

        /// <summary>
        ///转换为高精度浮点数,无效值
        ///</summary>
        [TestMethod]
        public void TestToDecimal_Invalid() {
            Assert.AreEqual( 0, Util.Conv.ToDecimal( "1A" ) );
        }

        /// <summary>
        ///转换为高精度浮点数,有效值
        ///</summary>
        [TestMethod]
        public void TestToDecimal() {
            Assert.AreEqual( 1.2M, Util.Conv.ToDecimal( "1.2" ) );
        }

        /// <summary>
        /// 转换为高精度浮点数,指定2位小数位数
        ///</summary>
        [TestMethod()]
        public void TestToDecimal_DigitsIs2() {
            Assert.AreEqual( 12.24M, Util.Conv.ToDecimal( "12.235", 2 ) );
        }

        #endregion

        #region ToDecimalOrNull(转换为可空高精度浮点数)

        /// <summary>
        ///转换为可空高精度浮点数,值为null
        ///</summary>
        [TestMethod]
        public void TestToDecimalOrNull_Null() {
            Assert.IsNull( Util.Conv.ToDecimalOrNull( null ) );
        }

        /// <summary>
        ///转换为可空高精度浮点数,值为空字符串
        ///</summary>
        [TestMethod]
        public void TestToDecimalOrNull_Empty() {
            Assert.IsNull( Util.Conv.ToDecimalOrNull( "" ) );
        }

        /// <summary>
        ///转换为可空高精度浮点数,无效值
        ///</summary>
        [TestMethod]
        public void TestToDecimalOrNull_Invalid() {
            Assert.IsNull( Util.Conv.ToDecimalOrNull( "1A" ) );
        }

        /// <summary>
        ///转换为可空高精度浮点数,无效值,指定2位小数位数
        ///</summary>
        [TestMethod]
        public void TestToDecimalOrNull_Invalid_DigitsIs2() {
            Assert.IsNull( Util.Conv.ToDecimalOrNull( "1A", 2 ) );
        }

        /// <summary>
        ///转换为可空高精度浮点数,值为0
        ///</summary>
        [TestMethod]
        public void TestToDecimalOrNull_0() {
            Assert.AreEqual( 0, Util.Conv.ToDecimalOrNull( "0" ) );
        }

        /// <summary>
        ///转换为可空高精度浮点数,有效值
        ///</summary>
        [TestMethod]
        public void TestToDecimalOrNull() {
            Assert.AreEqual( 1.2M, Util.Conv.ToDecimalOrNull( "1.2" ) );
        }

        /// <summary>
        /// 转换为可空高精度浮点数,指定2位小数位数
        ///</summary>
        [TestMethod()]
        public void ToDecimalOrNull_DigitsIs2() {
            Assert.AreEqual( 12.24M, Util.Conv.ToDecimalOrNull( "12.235", 2 ) );
        }

        #endregion

        #region ToGuid(转换为Guid)

        /// <summary>
        ///转换为Guid,值为null
        ///</summary>
        [TestMethod]
        public void TestToGuid_Null() {
            Assert.AreEqual( Guid.Empty, Util.Conv.ToGuid( null ) );
        }

        /// <summary>
        ///转换为Guid,值为空字符串
        ///</summary>
        [TestMethod]
        public void TestToGuid_Empty() {
            Assert.AreEqual( Guid.Empty, Util.Conv.ToGuid( "" ) );
        }

        /// <summary>
        ///转换为Guid,无效值
        ///</summary>
        [TestMethod]
        public void TestToGuid_Invalid() {
            Assert.AreEqual( Guid.Empty, Util.Conv.ToGuid( "1A" ) );
        }

        /// <summary>
        ///转换为Guid,有效值
        ///</summary>
        [TestMethod]
        public void TestToGuid() {
            Assert.AreEqual( new Guid( "B9EB56E9-B720-40B4-9425-00483D311DDC" ), Util.Conv.ToGuid( "B9EB56E9-B720-40B4-9425-00483D311DDC" ) );
        }

        #endregion

        #region ToGuidOrNull(转换为可空Guid)

        /// <summary>
        ///转换为可空Guid,值为null
        ///</summary>
        [TestMethod]
        public void TestToGuidOrNull_Null() {
            Assert.IsNull( Util.Conv.ToGuidOrNull( null ) );
        }

        /// <summary>
        ///转换为可空Guid,值为空字符串
        ///</summary>
        [TestMethod]
        public void TestToGuidOrNull_Empty() {
            Assert.IsNull( Util.Conv.ToGuidOrNull( "" ) );
        }

        /// <summary>
        ///转换为可空Guid,无效值
        ///</summary>
        [TestMethod]
        public void TestToGuidOrNull_Invalid() {
            Assert.IsNull( Util.Conv.ToGuidOrNull( "1A" ) );
        }

        /// <summary>
        ///转换为可空Guid,有效值
        ///</summary>
        [TestMethod]
        public void TestToGuidOrNull() {
            Assert.AreEqual( new Guid( "B9EB56E9-B720-40B4-9425-00483D311DDC" ), Util.Conv.ToGuidOrNull( "B9EB56E9-B720-40B4-9425-00483D311DDC" ) );
        }

        #endregion

        #region ToGuidList(转换为Guid集合)

        /// <summary>
        /// 转换为Guid集合,验证空字符串
        /// </summary>
        [TestMethod]
        public void TestToGuidList_Empty() {
            Assert.AreEqual( 0, Util.Conv.ToGuidList( "" ).Count );
        }

        /// <summary>
        /// 转换为Guid集合,验证最后为逗号
        /// </summary>
        [TestMethod]
        public void TestToGuidList_LastIsComma() {
            Assert.AreEqual( 1, Util.Conv.ToGuidList( "83B0233C-A24F-49FD-8083-1337209EBC9A," ).Count );
        }

        /// <summary>
        /// 转换为Guid集合,验证中间包含逗号
        /// </summary>
        [TestMethod]
        public void TestToGuidList_MiddleIsComma() {
            const string guid = "83B0233C-A24F-49FD-8083-1337209EBC9A,,EAB523C6-2FE7-47BE-89D5-C6D440C3033A,";
            Assert.AreEqual( 2, Util.Conv.ToGuidList( guid ).Count );
            Assert.AreEqual( new Guid( "83B0233C-A24F-49FD-8083-1337209EBC9A" ), Util.Conv.ToGuidList( guid )[0] );
            Assert.AreEqual( new Guid( "EAB523C6-2FE7-47BE-89D5-C6D440C3033A" ), Util.Conv.ToGuidList( guid )[1] );
        }

        /// <summary>
        /// 转换为Guid集合,仅1个Guid
        /// </summary>
        [TestMethod]
        public void TestToGuidList_1Guid() {
            const string guid = "83B0233C-A24F-49FD-8083-1337209EBC9A";
            Assert.AreEqual( 1, Util.Conv.ToGuidList( guid ).Count );
            Assert.AreEqual( new Guid( guid ), Util.Conv.ToGuidList( guid )[0] );
        }

        /// <summary>
        /// 转换为Guid集合,2个Guid
        /// </summary>
        [TestMethod]
        public void TestToGuidList_2Guid() {
            const string guid = "83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A";
            Assert.AreEqual( 2, Util.Conv.ToGuidList( guid ).Count );
            Assert.AreEqual( new Guid( "83B0233C-A24F-49FD-8083-1337209EBC9A" ), Util.Conv.ToGuidList( guid )[0] );
            Assert.AreEqual( new Guid( "EAB523C6-2FE7-47BE-89D5-C6D440C3033A" ), Util.Conv.ToGuidList( guid )[1] );
        }

        #endregion

        #region ToDate(转换为日期)

        /// <summary>
        ///转换为日期,值为null
        ///</summary>
        [TestMethod]
        public void TestToDate_Null() {
            Assert.AreEqual( DateTime.MinValue, Util.Conv.ToDate( null ) );
        }

        /// <summary>
        ///转换为日期,值为空字符串
        ///</summary>
        [TestMethod]
        public void TestToDate_Empty() {
            Assert.AreEqual( DateTime.MinValue, Util.Conv.ToDate( "" ) );
        }

        /// <summary>
        ///转换为日期,无效值
        ///</summary>
        [TestMethod]
        public void TestToDate_Invalid() {
            Assert.AreEqual( DateTime.MinValue, Util.Conv.ToDate( "1A" ) );
        }

        /// <summary>
        ///转换为日期,有效值
        ///</summary>
        [TestMethod]
        public void TestToDate() {
            Assert.AreEqual( new DateTime( 2000, 1, 1 ), Util.Conv.ToDate( "2000-1-1" ) );
        }

        #endregion

        #region ToDateOrNull(转换为可空日期)

        /// <summary>
        ///转换为可空日期,值为null
        ///</summary>
        [TestMethod]
        public void TestToDateOrNull_Null() {
            Assert.IsNull( Util.Conv.ToDateOrNull( null ) );
        }

        /// <summary>
        ///转换为可空日期,值为空字符串
        ///</summary>
        [TestMethod]
        public void TestToDateOrNull_Empty() {
            Assert.IsNull( Util.Conv.ToDateOrNull( "" ) );
        }

        /// <summary>
        ///转换为可空日期,无效值
        ///</summary>
        [TestMethod]
        public void TestToDateOrNull_Invalid() {
            Assert.IsNull( Util.Conv.ToDateOrNull( "1A" ) );
        }

        /// <summary>
        ///转换为可空日期,有效值
        ///</summary>
        [TestMethod]
        public void TestToDateOrNull() {
            Assert.AreEqual( new DateTime( 2000, 1, 1 ), Util.Conv.ToDateOrNull( "2000-1-1" ) );
        }

        #endregion

        #region ToBool(转换为布尔值)

        /// <summary>
        ///转换为布尔值,值为null
        ///</summary>
        [TestMethod]
        public void TestToBool_Null() {
            Assert.AreEqual( false, Util.Conv.ToBool( null ) );
        }

        /// <summary>
        ///转换为布尔值,值为空字符串
        ///</summary>
        [TestMethod]
        public void TestToBool_Empty() {
            Assert.AreEqual( false, Util.Conv.ToBool( "" ) );
        }

        /// <summary>
        ///转换为布尔值,无效值
        ///</summary>
        [TestMethod]
        public void TestToBool_Invalid() {
            Assert.AreEqual( false, Util.Conv.ToBool( "1A" ) );
        }

        /// <summary>
        ///转换为布尔值,值为False
        ///</summary>
        [TestMethod]
        public void TestToBool_False() {
            Assert.AreEqual( false, Util.Conv.ToBool( "0" ) );
            Assert.AreEqual( false, Util.Conv.ToBool( "否" ) );
            Assert.AreEqual( false, Util.Conv.ToBool( "no" ) );
            Assert.AreEqual( false, Util.Conv.ToBool( "No" ) );
            Assert.AreEqual( false, Util.Conv.ToBool( "false" ) );
            Assert.AreEqual( false, Util.Conv.ToBool( "False" ) );
        }

        /// <summary>
        ///转换为布尔值,值为True
        ///</summary>
        [TestMethod]
        public void TestToBool_True() {
            Assert.AreEqual( true, Util.Conv.ToBool( "1" ) );
            Assert.AreEqual( true, Util.Conv.ToBool( "是" ) );
            Assert.AreEqual( true, Util.Conv.ToBool( "yes" ) );
            Assert.AreEqual( true, Util.Conv.ToBool( "Yes" ) );
            Assert.AreEqual( true, Util.Conv.ToBool( "true" ) );
            Assert.AreEqual( true, Util.Conv.ToBool( "True" ) );
        }

        #endregion

        #region ToBoolOrNull(转换为可空布尔值)

        /// <summary>
        ///转换为可空布尔值,值为null
        ///</summary>
        [TestMethod]
        public void TestToBoolOrNull_Null() {
            Assert.IsNull( Util.Conv.ToBoolOrNull( null ) );
        }

        /// <summary>
        ///转换为可空布尔值,值为空字符串
        ///</summary>
        [TestMethod]
        public void TestToBoolOrNull_Empty() {
            Assert.IsNull( Util.Conv.ToBoolOrNull( "" ) );
        }

        /// <summary>
        ///转换为可空布尔值,无效值
        ///</summary>
        [TestMethod]
        public void TestToBoolOrNull_Invalid() {
            Assert.IsNull( Util.Conv.ToBoolOrNull( "1A" ) );
        }

        /// <summary>
        ///转换为布尔值,值为False
        ///</summary>
        [TestMethod]
        public void TestToBoolOrNull_False() {
            Assert.AreEqual( false, Util.Conv.ToBoolOrNull( "0" ) );
            Assert.AreEqual( false, Util.Conv.ToBoolOrNull( "否" ) );
            Assert.AreEqual( false, Util.Conv.ToBoolOrNull( "no" ) );
            Assert.AreEqual( false, Util.Conv.ToBoolOrNull( "No" ) );
            Assert.AreEqual( false, Util.Conv.ToBoolOrNull( "false" ) );
            Assert.AreEqual( false, Util.Conv.ToBoolOrNull( "False" ) );
        }

        /// <summary>
        ///转换为布尔值,值为True
        ///</summary>
        [TestMethod]
        public void TestToBoolOrNull_True() {
            Assert.AreEqual( true, Util.Conv.ToBoolOrNull( "1" ) );
            Assert.AreEqual( true, Util.Conv.ToBoolOrNull( "是" ) );
            Assert.AreEqual( true, Util.Conv.ToBoolOrNull( "yes" ) );
            Assert.AreEqual( true, Util.Conv.ToBoolOrNull( "Yes" ) );
            Assert.AreEqual( true, Util.Conv.ToBoolOrNull( "true" ) );
            Assert.AreEqual( true, Util.Conv.ToBoolOrNull( "True" ) );
        }

        #endregion

        #region ToString(转换为字符串)

        /// <summary>
        ///转换为字符串,值为null
        ///</summary>
        [TestMethod]
        public void TestToString_Null() {
            Assert.AreEqual( string.Empty, Util.Conv.ToString( null ) );
        }

        /// <summary>
        ///转换为字符串,值为空字符串
        ///</summary>
        [TestMethod]
        public void TestToString_Empty() {
            Assert.AreEqual( string.Empty, Util.Conv.ToString( " " ) );
        }

        /// <summary>
        ///转换为字符串,有效值
        ///</summary>
        [TestMethod]
        public void TestToString() {
            Assert.AreEqual( "1", Util.Conv.ToString( 1 ) );
        }

        #endregion

        #region To(通用泛型转换)

        #region 目标为int

        /// <summary>
        ///通用泛型转换,目标为整数，值为null
        ///</summary>
        [TestMethod]
        public void TestTo_Int_Null() {
            Assert.AreEqual( 0, Conv.To<int>( null ) );
        }

        /// <summary>
        ///通用泛型转换,目标为整数,值为空字符串
        ///</summary>
        [TestMethod]
        public void TestTo_Int_Empty() {
            Assert.AreEqual( 0, Conv.To<int>( "" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为整数,无效值
        ///</summary>
        [TestMethod]
        public void TestTo_Int_Invalid() {
            Assert.AreEqual( 0, Conv.To<int>( "1A" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为整数,有效值
        ///</summary>
        [TestMethod]
        public void TestTo_Int() {
            Assert.AreEqual( 1, Conv.To<int>( "1" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为可空整数,无效值
        ///</summary>
        [TestMethod]
        public void TestTo_IntOrNull_Invalid() {
            Assert.IsNull( Conv.To<int?>( "1A" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为可空整数,有效值
        ///</summary>
        [TestMethod]
        public void TestTo_IntOrNull() {
            Assert.AreEqual( 1, Conv.To<int?>( "1" ) );
        }

        #endregion

        #region 目标为Guid

        /// <summary>
        ///通用泛型转换,目标为Guid,无效值
        ///</summary>
        [TestMethod]
        public void TestTo_Guid_Invalid() {
            Assert.AreEqual( Guid.Empty, Conv.To<Guid>( "1A" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为Guid,有效值
        ///</summary>
        [TestMethod]
        public void TestTo_Guid() {
            Assert.AreEqual( new Guid( "B9EB56E9-B720-40B4-9425-00483D311DDC" ),
                Conv.To<Guid>( "B9EB56E9-B720-40B4-9425-00483D311DDC" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为可空Guid,无效值
        ///</summary>
        [TestMethod]
        public void TestTo_GuidOrNull_Invalid() {
            Assert.IsNull( Conv.To<Guid?>( "1A" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为可空Guid,有效值
        ///</summary>
        [TestMethod]
        public void TestTo_GuidOrNull() {
            Assert.AreEqual( new Guid( "B9EB56E9-B720-40B4-9425-00483D311DDC" ),
                Conv.To<Guid?>( "B9EB56E9-B720-40B4-9425-00483D311DDC" ) );
        }

        #endregion

        #region 目标为string

        /// <summary>
        ///通用泛型转换,目标为string,有效值
        ///</summary>
        [TestMethod]
        public void TestTo_String() {
            Assert.AreEqual( "123", Conv.To<string>( 123 ) );
        }

        #endregion

        #region 目标为double

        /// <summary>
        ///通用泛型转换,目标为double,无效值
        ///</summary>
        [TestMethod]
        public void TestTo_Double_Invalid() {
            Assert.AreEqual( 0, Conv.To<double>( "1A" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为double,有效值
        ///</summary>
        [TestMethod]
        public void TestTo_Double() {
            Assert.AreEqual( 12.5, Conv.To<double>( "12.5" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为可空double,无效值
        ///</summary>
        [TestMethod]
        public void TestTo_DoubleOrNull_Invalid() {
            Assert.IsNull( Conv.To<double?>( "1A" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为可空double,有效值
        ///</summary>
        [TestMethod]
        public void TestTo_DoubleOrNull() {
            Assert.AreEqual( 12.5, Conv.To<double?>( "12.5" ) );
        }

        #endregion

        #region 目标为decimal

        /// <summary>
        ///通用泛型转换,目标为decimal,无效值
        ///</summary>
        [TestMethod]
        public void TestTo_Decimal_Invalid() {
            Assert.AreEqual( 0, Conv.To<decimal>( "1A" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为decimal,有效值
        ///</summary>
        [TestMethod]
        public void TestTo_Decimal() {
            Assert.AreEqual( 12.5M, Conv.To<decimal>( "12.5" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为可空decimal,无效值
        ///</summary>
        [TestMethod]
        public void TestTo_DecimalOrNull_Invalid() {
            Assert.IsNull( Conv.To<decimal?>( "1A" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为可空decimal,有效值
        ///</summary>
        [TestMethod]
        public void TestTo_DecimalOrNull() {
            Assert.AreEqual( 12.5M, Conv.To<decimal?>( "12.5" ) );
        }

        #endregion

        #region 目标为bool

        /// <summary>
        ///通用泛型转换,目标为bool,无效值
        ///</summary>
        [TestMethod]
        public void TestTo_Bool_Invalid() {
            Assert.AreEqual( false, Conv.To<bool>( "1A" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为bool,有效值
        ///</summary>
        [TestMethod]
        public void TestTo_Bool() {
            Assert.AreEqual( true, Conv.To<bool>( 1 ) );
        }

        /// <summary>
        ///通用泛型转换,目标为可空bool,无效值
        ///</summary>
        [TestMethod]
        public void TestTo_BoolOrNull_Invalid() {
            Assert.IsNull( Conv.To<bool?>( "1A" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为可空bool,有效值
        ///</summary>
        [TestMethod]
        public void TestTo_BoolOrNull() {
            Assert.AreEqual( true, Conv.To<bool?>( "true" ) );
        }

        #endregion

        #region 目标为DateTime

        /// <summary>
        ///通用泛型转换,目标为DateTime,无效值
        ///</summary>
        [TestMethod]
        public void TestTo_DateTime_Invalid() {
            Assert.AreEqual( DateTime.MinValue, Conv.To<DateTime>( "1A" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为DateTime,有效值
        ///</summary>
        [TestMethod]
        public void TestTo_DateTime() {
            Assert.AreEqual( new DateTime( 2000, 1, 1 ), Conv.To<DateTime>( "2000-1-1" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为可空DateTime,无效值
        ///</summary>
        [TestMethod]
        public void TestTo_DateTimeOrNull_Invalid() {
            Assert.IsNull( Conv.To<DateTime?>( "1A" ) );
        }

        /// <summary>
        ///通用泛型转换,目标为可空DateTime,有效值
        ///</summary>
        [TestMethod]
        public void TestTo_DateTimeOrNull() {
            Assert.AreEqual( new DateTime( 2000, 1, 1 ), Conv.To<DateTime?>( "2000-1-1" ) );
        }

        #endregion

        #endregion
    }
}
