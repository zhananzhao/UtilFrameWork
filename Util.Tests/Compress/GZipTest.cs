using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests.Compress {
    /// <summary>
    /// GZip压缩测试
    /// </summary>
    [TestClass]
    public class GZipTest {
        /// <summary>
        /// 测试文本
        /// </summary>
        private const string Text = "嘿嘿，哈哈   s3*&^!@#$%^&*()_+}{|123 456 gdfdsf \\/@~ & %20 ^()*!$";

        /// <summary>
        /// 压缩和解压缩文本
        /// </summary>
        [TestMethod]
        public void Test_String() {
            var compressText = Util.Compress.GZip.Compress( Text );
            var result = Util.Compress.GZip.Decompress( compressText );
            Console.Write( compressText );
            Assert.AreEqual( Text, result );
        }

        /// <summary>
        /// 压缩和解压缩字节流
        /// </summary>
        [TestMethod]
        public void Test_Bytes() {
            var buffer = Util.File.StringToBytes( Text );
            var compressBuffer = Util.Compress.GZip.Compress( buffer );
            var result = Util.Compress.GZip.Decompress( compressBuffer );
            Assert.AreEqual( buffer.Length, result.Length );
            for ( int i = 0; i < buffer.Length; i++ ) {
                Assert.AreEqual( buffer[i], result[i] );
            }
        }

        /// <summary>
        /// 压缩和解压缩字节流
        /// </summary>
        [TestMethod]
        public void Test_Stream() {
            var buffer = Util.File.StringToBytes( Text );
            Stream stream = new MemoryStream( buffer );
            var compressStream = Util.Compress.GZip.Compress( stream );
            var result = Util.Compress.GZip.Decompress( compressStream );
            Assert.AreEqual( buffer.Length, result.Length );
            for ( int i = 0; i < buffer.Length; i++ ) {
                Assert.AreEqual( buffer[i], result[i] );
            }
        }

        /// <summary>
        /// 验证压缩空值
        /// </summary>
        [TestMethod]
        public void TestCompress_Empty() {
            string text = null;
            Assert.AreEqual( "", Util.Compress.GZip.Compress( text ) );
            Assert.AreEqual( "", Util.Compress.GZip.Compress( "" ) );
            Assert.AreEqual( "", Util.Compress.GZip.Compress( " " ) );
        }

        /// <summary>
        /// 验证解压缩空值
        /// </summary>
        [TestMethod]
        public void TestDecompress_Empty() {
            string text = null;
            Assert.AreEqual( "", Util.Compress.GZip.Decompress( text ) );
            Assert.AreEqual( "", Util.Compress.GZip.Decompress( "" ) );
            Assert.AreEqual( "", Util.Compress.GZip.Decompress( " " ) );
        }

        /// <summary>
        /// 测试压缩性能
        /// </summary>
        [TestMethod]
        [Ignore]
        public void TestPerformance() {
            for ( int i = 0; i < 100; i++ ) {
                const string text = Util.Const.ChinesePinYin;
                var compressText = Util.Compress.GZip.Compress( text );
                var result = Util.Compress.GZip.Decompress( compressText );
            }
        }
    }
}
