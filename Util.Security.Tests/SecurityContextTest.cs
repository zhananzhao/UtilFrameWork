using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Security.Tests {
    /// <summary>
    /// 安全上下文测试
    /// </summary>
    [TestClass]
    public class SecurityContextTest {
        /// <summary>
        /// 获取安全主体
        /// </summary>
        [TestMethod]
        public void TestUser() {
            IPrincipal principal = SecurityContext.User;
            Assert.IsNotNull( principal );
        }

        /// <summary>
        /// 获取身份标识
        /// </summary>
        [TestMethod]
        public void TestIdentity() {
            Identity identity = SecurityContext.Identity;
            Assert.IsNotNull( identity );
        }
    }
}
