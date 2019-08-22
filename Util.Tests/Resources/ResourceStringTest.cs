using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests.Resources {
    /// <summary>
    /// 资源字符串测试
    /// </summary>
    [TestClass]
    public class ResourceStringTest {
        /// <summary>
        /// 验证资源名不能为空
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetString_ValidateResourceName() {
            try {
                ResourceHelper.GetString( "", "Key" );
            }
            catch ( ArgumentNullException ex ) {
                Assert.IsTrue( ex.Message.Contains( "resourceName" ) );
                throw;
            }
        }

        /// <summary>
        /// 验证键名不能为空
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public void TestGetString_ValidateKey() {
            try {
                ResourceHelper.GetString( "TestCoreResource", "" );
            }
            catch ( ArgumentNullException ex ) {
                Assert.IsTrue( ex.Message.Contains( "key" ) );
                throw;
            }
        }

        /// <summary>
        /// 获取资源字符串，使用完全限定的资源名，资源文件在本地程序集中
        /// </summary>
        [TestMethod]
        public void TestGetString_FullName_LocalAssembly() {
            Assert.AreEqual( TestCoreResource.Key, ResourceHelper.GetString( "Util.Tests.Resources.TestCoreResource", "Key" ) );
        }

        /// <summary>
        /// 获取资源字符串，仅使用资源名，资源文件在本地程序集中
        /// </summary>
        [TestMethod]
        public void TestGetString_OnlyResourceName_LocalAssembly() {
            Assert.AreEqual( TestCoreResource.Key, ResourceHelper.GetString( "TestCoreResource", "Key" ) );
        }

        /// <summary>
        /// 获取资源字符串，使用完全限定的资源名，资源文件在外部程序集中
        /// </summary>
        [TestMethod]
        public void TestGetString_FullName_ExternalAssembly() {
            Assert.AreEqual( R.SystemError, ResourceHelper.GetString( "Util.R", "SystemError" ) );
        }

        /// <summary>
        /// 获取资源字符串，仅使用资源名，资源文件在外部程序集中
        /// </summary>
        [TestMethod]
        public void TestGetString_OnlyResourceName_ExternalAssembly() {
            Assert.AreEqual( R.SystemError, ResourceHelper.GetString( "R", "SystemError" ) );
        }

        /// <summary>
        /// 获取资源字符串，资源文件在外部程序集中,设置程序集名称
        /// </summary>
        [TestMethod]
        [Ignore]
        public void TestGetString_ExternalAssembly_SetAssemblyName() {
            //Assert.AreEqual( TestDomainResource.CustomerNameIsEmpty, Resource.GetString( "TestDomainResource", "CustomerNameIsEmpty", "Test.Unit.Domains" ) );
        }
    }
}
