using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests {
    /// <summary>
    /// 网络操作测试
    /// </summary>
    [TestClass]
    public class NetTest {
        /// <summary>
        /// 获取Ip
        /// </summary>
        [TestMethod]
        public void TestGetIp() {
            Console.WriteLine( Net.Ip );
            Assert.IsFalse( Net.Ip.IsEmpty() );
        }
    }
}
