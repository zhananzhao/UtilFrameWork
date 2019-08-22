using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests.Extensions {
    /// <summary>
    /// 日期时间扩展测试
    /// </summary>
    [TestClass]
    public class DateTimeExtensionTest {
        /// <summary>
        /// 获取格式化日期时间字符串
        /// </summary>
        [TestMethod]
        public void TestToDateTimeString() {
            string date = "2012-01-02 11:11:11";
            Assert.AreEqual( date, Conv.ToDate( date ).ToDateTimeString() );
            Assert.AreEqual( "2012-01-02 11:11", Conv.ToDate( date ).ToDateTimeString( true ) );
            Assert.AreEqual( "", Conv.ToDateOrNull( "" ).ToDateTimeString() );
            Assert.AreEqual( date, Conv.ToDateOrNull( date ).ToDateTimeString() );
        }

        /// <summary>
        /// 获取格式化日期字符串
        /// </summary>
        [TestMethod]
        public void TestToDateString() {
            string date = "2012-01-02";
            Assert.AreEqual( date, Conv.ToDate( date ).ToDateString() );
            Assert.AreEqual( "", Conv.ToDateOrNull( "" ).ToDateString() );
            Assert.AreEqual( date, Conv.ToDateOrNull( date ).ToDateString() );
        }

        /// <summary>
        /// 获取格式化时间字符串
        /// </summary>
        [TestMethod]
        public void TestToTimeString() {
            string date = "2012-01-02 11:11:11";
            Assert.AreEqual( "11:11:11", Conv.ToDate( date ).ToTimeString() );
            Assert.AreEqual( "", Conv.ToDateOrNull( "" ).ToTimeString() );
            Assert.AreEqual( "11:11:11", Conv.ToDateOrNull( date ).ToTimeString() );
        }

        /// <summary>
        /// 获取格式化毫秒字符串
        /// </summary>
        [TestMethod]
        public void TestToMillisecondString() {
            string date = "2012-01-02 11:11:11.123";
            Assert.AreEqual( date, Conv.ToDate( date ).ToMillisecondString() );
            Assert.AreEqual( "", Conv.ToDateOrNull( "" ).ToMillisecondString() );
            Assert.AreEqual( date, Conv.ToDateOrNull( date ).ToMillisecondString() );
        }

        /// <summary>
        /// 获取格式化中文日期字符串
        /// </summary>
        [TestMethod]
        public void TestToChineseDateString() {
            string date = "2012-01-02";
            Assert.AreEqual( "2012年1月2日", Conv.ToDate( date ).ToChineseDateString() );
            Assert.AreEqual( "2012年12月12日", Conv.ToDate( "2012-12-12" ).ToChineseDateString() );
            Assert.AreEqual( "", Conv.ToDateOrNull( "" ).ToChineseDateString() );
            Assert.AreEqual( "2012年1月2日", Conv.ToDateOrNull( date ).ToChineseDateString() );
        }

        /// <summary>
        /// 获取格式化中文日期时间字符串
        /// </summary>
        [TestMethod]
        public void TestToChineseDateTimeString() {
            string date = "2012-01-02 11:11:11";
            Assert.AreEqual( "2012年1月2日 11时11分11秒", Conv.ToDate( date ).ToChineseDateTimeString() );
            Assert.AreEqual( "2012年12月12日 11时11分11秒", Conv.ToDate( "2012-12-12 11:11:11" ).ToChineseDateTimeString() );
            Assert.AreEqual( "2012年1月2日 11时11分", Conv.ToDate( date ).ToChineseDateTimeString( true ) );
            Assert.AreEqual( "", Conv.ToDateOrNull( "" ).ToChineseDateTimeString() );
            Assert.AreEqual( "2012年1月2日 11时11分11秒", Conv.ToDateOrNull( date ).ToChineseDateTimeString() );
        }
    }
}
