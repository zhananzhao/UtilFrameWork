using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Util.Security.Tests.Samples;

namespace Util.Security.Tests {
    /// <summary>
    /// 权限管理器测试
    /// </summary>
    [TestClass]
    public class PermissionManagerBaseTest {
        /// <summary>
        /// 权限管理器
        /// </summary>
        private PermissionManager _permissionManager;
        /// <summary>
        /// 模拟安全管理器
        /// </summary>
        private ISecurityManager _mockSecurityManager;
        /// <summary>
        /// 身份标识
        /// </summary>
        private Identity _identity;
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
            CreateMockSecurityManager();
            _permissionManager = new PermissionManager( CreateIdentity(), _mockSecurityManager );
        }

        /// <summary>
        /// 创建身份标识
        /// </summary>
        private Identity CreateIdentity( bool isAuthenticated = true ) {
            return new Identity( isAuthenticated, _userId,new[] { _roleId } );
        }

        /// <summary>
        /// 创建模拟安全管理器
        /// </summary>
        private void CreateMockSecurityManager() {
            _mockSecurityManager = Substitute.For<ISecurityManager>();
            _mockSecurityManager.IsInApplication( _userId.ToGuid() ).Returns( true );
            _mockSecurityManager.IsInTenant( _userId.ToGuid() ).Returns( true );
            _mockSecurityManager.GetPermissionsByResource( _resourceUri )
                .Returns( new ResourcePermissions( _resourceUri, new List<Permission> { new Permission( _roleId,false ) } ) );
        }

        /// <summary>
        /// 验证授权失败
        /// </summary>
        private void AssertFalse() {
            Assert.IsFalse( _permissionManager.HasPermission( _resourceUri ) );
        }

        /// <summary>
        /// 验证授权成功
        /// </summary>
        private void AssertTrue() {
            Assert.IsTrue( _permissionManager.HasPermission( _resourceUri ) );
        }

        /// <summary>
        /// 授权通过
        /// </summary>
        [TestMethod]
        public void TestHasPermission() {
            AssertTrue();
        }

        /// <summary>
        /// 验证身份标识为空
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public void Test_IdentityIsNull() {
            _permissionManager = new PermissionManager( null, _mockSecurityManager );
            _permissionManager.HasPermission( _resourceUri ).Returns( t => { throw new ArgumentNullException( "identity" ); } );
        }

        /// <summary>
        /// 验证安全管理器为空
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public void Test_SecurityManagerIsNull() {
            _permissionManager = new PermissionManager( CreateIdentity(), null );
            _permissionManager.HasPermission( _resourceUri ).Returns( t => { throw new ArgumentNullException( "securityManager" ); } );
        }

        /// <summary>
        /// 验证未登录
        /// </summary>
        [TestMethod]
        public void Test_IsAuthenticated() {
            _permissionManager = new PermissionManager( CreateIdentity( false ), _mockSecurityManager );
            AssertFalse();
        }

        /// <summary>
        /// 验证用户编号无效
        /// </summary>
        [TestMethod]
        public void Test_InvalidUserId() {
            _userId = "";
            _mockSecurityManager.IsInApplication( _userId.ToGuid() ).Returns( true );
            _permissionManager = new PermissionManager( CreateIdentity(), _mockSecurityManager );
            AssertFalse();
        }

        /// <summary>
        /// 验证用户是否属于当前应用程序
        /// </summary>
        [TestMethod]
        public void Test_Application() {
            _mockSecurityManager.IsInApplication( _userId.ToGuid() ).Returns( false );
            AssertFalse();
        }

        /// <summary>
        /// 验证用户是否属于当前租户
        /// </summary>
        [TestMethod]
        public void Test_Tenant() {
            _mockSecurityManager.IsInTenant( _userId.ToGuid() ).Returns( false );
            AssertFalse();
        }

        /// <summary>
        /// 忽视权限
        /// </summary>
        [TestMethod]
        public void Test_Ignore() {
            _mockSecurityManager.GetPermissionsByResource( _resourceUri )
                .Returns( new ResourcePermissions( _resourceUri, new List<Permission> { new Permission( _roleId, true ) } ) );
            _permissionManager = new PermissionManager( CreateIdentity(), _mockSecurityManager,true );
            AssertTrue();
        }

        /// <summary>
        /// 验证资源标识为空
        /// </summary>
        [TestMethod]
        public void Test_ResourceUriIsEmpty() {
            _resourceUri = "";
            AssertFalse();
        }

        /// <summary>
        /// 验证角色授权
        /// </summary>
        [TestMethod]
        public void TestRoleAuthrize() {
            _mockSecurityManager.GetPermissionsByResource( _resourceUri )
                .Returns( new ResourcePermissions( _resourceUri, new List<Permission> { new Permission( _roleId, true ) } ) );
            AssertFalse();
        }
    }
}
