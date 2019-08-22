using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Security.Tests {
    /// <summary>
    /// 资源权限集合测试
    /// </summary>
    [TestClass]
    public class ResourcePermissionsTest {
        /// <summary>
        /// 资源权限
        /// </summary>
        private ResourcePermissions _resourcePermissions;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _resourcePermissions = new ResourcePermissions( "r",new List<Permission> {
                new Permission( "a",false ),
                new Permission( "b",true ),
                new Permission( "c",false ),
                new Permission( "c",true ),
            } );
        }

        /// <summary>
        /// 参数为空
        /// </summary>
        [TestMethod]
        public void TestHasPermission_Null() {
            Assert.IsFalse(_resourcePermissions.HasPermission( null ));
        }

        /// <summary>
        /// 拥有一个角色A，验证通过
        /// </summary>
        [TestMethod]
        public void TestHasPermission_1() {
            Assert.IsTrue( _resourcePermissions.HasPermission( "a" ) );
        }

        /// <summary>
        /// 拥有一个角色B，被拒绝
        /// </summary>
        [TestMethod]
        public void TestHasPermission_2() {
            Assert.IsFalse( _resourcePermissions.HasPermission( "b" ) );
        }

        /// <summary>
        /// 拥有一个角色C，被拒绝
        /// </summary>
        [TestMethod]
        public void TestHasPermission_3() {
            Assert.IsFalse( _resourcePermissions.HasPermission( "c" ) );
        }

        /// <summary>
        /// 拥有一个角色D，未找到该角色，无权访问
        /// </summary>
        [TestMethod]
        public void TestHasPermission_4() {
            Assert.IsFalse( _resourcePermissions.HasPermission( "d" ) );
        }

        /// <summary>
        /// 拥有2个角色A和D，A被授权，D未找到该角色被忽略，通过验证
        /// </summary>
        [TestMethod]
        public void TestHasPermission_5() {
            Assert.IsTrue( _resourcePermissions.HasPermission( "a", "d" ) );
        }

        /// <summary>
        /// 拥有3个角色A、B、D，A被授权，B被拒绝，拒绝优先级更高，无权访问
        /// </summary>
        [TestMethod]
        public void TestHasPermission_6() {
            Assert.IsFalse( _resourcePermissions.HasPermission( "a","b", "d" ) );
        }
    }
}
