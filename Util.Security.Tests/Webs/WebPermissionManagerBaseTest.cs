using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Util.Security.Tests.Samples;
using Util.Security.Webs;

namespace Util.Security.Tests.Webs {
    /// <summary>
    /// Web权限管理器测试
    /// </summary>
    [TestClass]
    public class WebPermissionManagerBaseTest {
        /// <summary>
        /// Web权限管理器
        /// </summary>
        private WebPermissionManager _permissionManager;
        /// <summary>
        /// 模拟安全管理器
        /// </summary>
        private ISecurityManager _mockSecurityManager;
        /// <summary>
        /// Http上下文
        /// </summary>
        private IHttpContextAdapter _httpContext;
        /// <summary>
        /// 用户编号
        /// </summary>
        private string _userId;
        /// <summary>
        /// 资源标识
        /// </summary>
        private string _resourceUri;
        /// <summary>
        /// 角色编号
        /// </summary>
        private string _roleId;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _userId = Guid.NewGuid().ToString();
            _resourceUri = "a";
            _roleId = "b";
            CreateHttpContext();
            CreateMockSecurityManager();
            _permissionManager = new WebPermissionManager( _httpContext, _mockSecurityManager,false );
            _resourceUri = "a";
        }

        /// <summary>
        /// 创建Http上下文
        /// </summary>
        private void CreateHttpContext() {
            _httpContext = Substitute.For<IHttpContextAdapter>();
            _httpContext.GetIdentity().Returns( CreateIdentity() );
        }

        /// <summary>
        /// 创建身份标识
        /// </summary>
        private Identity CreateIdentity() {
            return new Identity( true, _userId, new[] { _roleId } );
        }

        /// <summary>
        /// 创建模拟安全管理器
        /// </summary>
        private void CreateMockSecurityManager() {
            _mockSecurityManager = Substitute.For<ISecurityManager>();
            _mockSecurityManager.IsInApplication( _userId.ToGuid() ).Returns( true );
            _mockSecurityManager.IsInTenant( _userId.ToGuid() ).Returns( true );
            _mockSecurityManager.GetPermissionsByResource( _resourceUri )
                .Returns( new ResourcePermissions( _resourceUri, new List<Permission> { new Permission( _roleId, false ) } ) );
        }

        /// <summary>
        /// 成功授权
        /// </summary>
        [TestMethod]
        public void TestHasPermission() {
            Assert.IsTrue( _permissionManager.HasPermission( _resourceUri ) );
        }
    }
}
