using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Domains.Tests.EntityBases {
    /// <summary>
    /// 字符串标识实体测试
    /// </summary>
    [TestClass]
    public class StringEntityBaseTest {
        /// <summary>
        /// 部门
        /// </summary>
        private Department _department;
        /// <summary>
        /// 部门2
        /// </summary>
        private Department _department2;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _department = new Department();
            _department2 = new Department();
        }

        /// <summary>
        /// 如果不带参数创建字符串型标识的实体，不会自动生成标识，标识为空
        /// </summary>
        [TestMethod]
        public void TestCreateEntity_NotArgument_StringId_IdIsNull() {
            Assert.IsNull( _department.Id );
        }

        /// <summary>
        /// 如果用字符串"ABC"创建字符串类型标识的实体，标识被设置为"ABC"
        /// </summary>
        [TestMethod]
        public void TestCreateEntity_ArgumentIsABC_StringId_IdIsABC() {
            _department = new Department( "ABC" );
            Assert.AreEqual( "ABC", _department.Id );
        }

        /// <summary>
        /// 新创建的实体不相等
        /// </summary>
        [TestMethod]
        public void TestNewEntityIsNotEquals() {
            Assert.IsFalse( _department.Equals( _department2 ) );
            Assert.IsFalse( _department.Equals( null ) );

            Assert.IsFalse( _department == _department2 );
            Assert.IsFalse( _department == null );
            Assert.IsFalse( null == _department2 );

            Assert.IsTrue( _department != _department2 );
            Assert.IsTrue( _department != null );
            Assert.IsTrue( null != _department2 );
        }

        /// <summary>
        /// 当两个实体的标识相同，则实体相同
        /// </summary>
        [TestMethod]
        public void TestEntityEquals_IdEquals() {
            _department = new Department( "A" );
            _department2 = new Department( "A" );
            Assert.IsTrue( _department.Equals( _department2 ) );
            Assert.IsTrue( _department == _department2 );
            Assert.IsFalse( _department != _department2 );
        }

        /// <summary>
        /// 字符串标识实体，默认标识为空字符串，无法验证通过
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( Warning ) )]
        public void TestValidate_DefaultIdIsEmpty_Invalid() {
            try {
                _department.Validate();
            }
            catch ( Warning ex ) {
                Assert.IsTrue( ex.Message.Contains( "Id" ) );
                throw;
            }
        }
    }
}
