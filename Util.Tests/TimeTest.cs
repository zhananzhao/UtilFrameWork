using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests {
    /// <summary>
    /// 时间操作测试
    /// </summary>
    [TestClass]
    public class TimeTest {

        #region 常量

        /// <summary>
        /// 日期字符串,"2012-01-02"
        /// </summary>
        public const string DATE_STRING1 = "2012-01-02";

        /// <summary>
        /// 日期,2012-01-02
        /// </summary>
        public static readonly DateTime DATE1 = DateTime.Parse( DATE_STRING1 );

        /// <summary>
        /// 日期字符串,"2012-11-12"
        /// </summary>
        public const string DATE_STRING2 = "2012-11-12";

        /// <summary>
        /// 日期,2012-11-12
        /// </summary>
        public static readonly DateTime DATE2 = DateTime.Parse( DATE_STRING2 );

        /// <summary>
        /// 日期时间字符串,"2012-01-02 01:02:03"
        /// </summary>
        public const string DATETIME_STRING1 = "2012-01-02 01:02:03";

        /// <summary>
        /// 日期时间,2012-01-02 01:02:03
        /// </summary>
        public static readonly DateTime DATETIME1 = DateTime.Parse( DATETIME_STRING1 );

        /// <summary>
        /// 日期时间字符串,"2012-11-12 13:04:05"
        /// </summary>
        public const string DATETIME_STRING2 = "2012-11-12 13:04:05";

        /// <summary>
        /// 日期时间,2012-11-12 13:04:05
        /// </summary>
        public static readonly DateTime DATETIME2 = DateTime.Parse( DATETIME_STRING2 );

        #endregion

        #region 测试清理

        /// <summary>
        /// 测试清理
        /// </summary>
        [TestCleanup]
        public void TestClear() {
            Time.Reset();
        }

        #endregion

        #region SetTime(设置时间)

        /// <summary>
        /// 设置时间
        /// </summary>
        [TestMethod]
        public void TestSetTime() {
            Time.SetTime( DATETIME1 );
            Assert.AreEqual( DATETIME1, Time.GetDateTime() );
        }

        #endregion

        #region Reset(重置时间)

        /// <summary>
        /// 重置时间
        /// </summary>
        [TestMethod]
        public void TestReset() {
            Time.SetTime( DATETIME1 );
            Time.Reset();
            Assert.AreEqual( DateTime.Now.ToString(), Time.GetDateTime().ToString() );
        }

        #endregion

        #region GetDate(获取当前日期)

        /// <summary>
        /// 获取当前日期
        /// </summary>
        [TestMethod]
        public void TestGetDate() {
            Assert.AreEqual( DateTime.Now.Date.ToString(), Time.GetDate().ToString() );
        }

        #endregion

        #region GetUnixTimestamp(获取Unix时间戳)

        /// <summary>
        /// 获取Unix时间戳，1970-1-1 12:12:12 的时间戳为15132
        /// </summary>
        [TestMethod]
        public void TestGetUnixTimestamp_19700101121212_15132() {
            Assert.AreEqual( 15132, Time.GetUnixTimestamp( new DateTime( 1970, 01, 01, 12, 12, 12 ) ) );
        }

        /// <summary>
        /// 获取Unix时间戳，2000-12-12 12:12:12 的时间戳为976594332
        /// </summary>
        [TestMethod]
        public void TestGetUnixTimestamp_20001212121212_976594332() {
            Assert.AreEqual( 976594332, Time.GetUnixTimestamp( new DateTime( 2000, 12, 12, 12, 12, 12 ) ) );
        }

        /// <summary>
        /// 获取Unix时间戳，2014-02-18 04:24:59 的时间戳为1392668699
        /// </summary>
        [TestMethod]
        public void TestGetUnixTimestamp_20140218042459_1392668699() {
            Assert.AreEqual( 1392668699, Time.GetUnixTimestamp( new DateTime( 2014, 02, 18, 04, 24, 59 ) ) );
        }

        #endregion

        #region GetTimeFromUnixTimestamp(从Unix时间戳获取时间)

        /// <summary>
        /// 从Unix时间戳获取时间，时间戳为15132的时间是1970-1-1 12:12:12
        /// </summary>
        [TestMethod]
        public void TestGetTimeFromUnixTimestamp_15132_19700101121212() {
            Assert.AreEqual( new DateTime( 1970, 01, 01, 12, 12, 12 ), Time.GetTimeFromUnixTimestamp( 15132 ) );
        }

        /// <summary>
        /// 从Unix时间戳获取时间，时间戳为976594332的时间是2000-12-12 12:12:12
        /// </summary>
        [TestMethod]
        public void TestGetTimeFromUnixTimestamp_976594332_20001212121212() {
            Assert.AreEqual( new DateTime( 2000, 12, 12, 12, 12, 12 ), Time.GetTimeFromUnixTimestamp( 976594332 ) );
        }

        /// <summary>
        /// 从Unix时间戳获取时间，时间戳为1392668699的时间是2014-02-18 04:24:59
        /// </summary>
        [TestMethod]
        public void TestGetTimeFromUnixTimestamp_1392668699_20140218042459() {
            Assert.AreEqual( new DateTime( 2014, 02, 18, 04, 24, 59 ), Time.GetTimeFromUnixTimestamp( 1392668699 ) );
        }

        #endregion

        #region Format(格式化时间间隔)

        /// <summary>
        /// 测试格式化时间间隔，仅显示秒
        /// </summary>
        [TestMethod]
        public void TestFormat_TimeSpan_OnlySecond() {
            TimeSpan span = new DateTime( 2000, 1, 1, 1, 0, 1 ) - new DateTime( 2000, 1, 1, 1, 0, 0 );
            Assert.AreEqual( "1秒", Time.Format( span ) );
        }

        /// <summary>
        /// 测试格式化时间间隔，仅显示分钟
        /// </summary>
        [TestMethod]
        public void TestFormat_TimeSpan_OnlyMinute() {
            TimeSpan span = new DateTime( 2000, 1, 1, 1, 1, 0 ) - new DateTime( 2000, 1, 1, 1, 0, 0 );
            Assert.AreEqual( "1分", Time.Format( span ) );
        }

        /// <summary>
        /// 测试格式化时间间隔，仅显示小时
        /// </summary>
        [TestMethod]
        public void TestFormat_TimeSpan_OnlyHour() {
            TimeSpan span = new DateTime( 2000, 1, 1, 1, 0, 0 ) - new DateTime( 2000, 1, 1, 0, 0, 0 );
            Assert.AreEqual( "1小时", Time.Format( span ) );
        }

        /// <summary>
        /// 测试格式化时间间隔，仅显示天
        /// </summary>
        [TestMethod]
        public void TestFormat_TimeSpan_OnlyDay() {
            TimeSpan span = new DateTime( 2000, 1, 2, 0, 0, 0 ) - new DateTime( 2000, 1, 1, 0, 0, 0 );
            Assert.AreEqual( "1天", Time.Format( span ) );
        }

        /// <summary>
        /// 测试格式化时间间隔
        /// </summary>
        [TestMethod]
        public void TestFormat_TimeSpan() {
            TimeSpan span = new DateTime( 2000, 1, 2, 0, 2, 0 ) - new DateTime( 2000, 1, 1, 0, 0, 0 );
            Assert.AreEqual( "1天2分", Time.Format( span ) );
        }

        #endregion
    }
}
