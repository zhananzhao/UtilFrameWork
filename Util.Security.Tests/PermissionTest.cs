using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Security.Tests {
    /// <summary>
    /// 权限测试
    /// </summary>
    [TestClass]
    public class PermissionTest {
        /// <summary>
        /// 权限
        /// </summary>
        Permission _permission;
        /// <summary>
        /// 角色编号
        /// </summary>
        private string _roleId;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _roleId = " a";
            _permission = new Permission( _roleId, false );
        }

        /// <summary>
        /// 权限验证成功
        /// </summary>
        [TestMethod]
        public void TestHasPermission_Success() {
            Assert.AreEqual( true, _permission.HasPermission( _roleId ) );
        }

        /// <summary>
        /// 处理参数空格和大小写问题
        /// </summary>
        [TestMethod]
        public void TestHasPermission_Filter_Success() {
            Assert.AreEqual( true, _permission.HasPermission( "A " ) );
        }

        /// <summary>
        /// 角色编号不匹配，返回null
        /// </summary>
        [TestMethod]
        public void TestHasPermission_RoleIdIsNotMatch_ReturnNull() {
            Assert.IsNull( _permission.HasPermission( "b" ) );
        }

        /// <summary>
        /// 拒绝该角色
        /// </summary>
        [TestMethod]
        public void TestHasPermission_Deny() {
            _permission = new Permission( _roleId, true );
            Assert.AreEqual( false, _permission.HasPermission( _roleId ) );
        } 
    }
}
