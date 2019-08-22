using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Domains.Tests.EntityBases {
    /// <summary>
    /// Guid标识实体测试
    /// </summary>
    [TestClass]
    public class GuidEntityBaseTest {
        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee;
        /// <summary>
        /// 员工2
        /// </summary>
        private Employee _employee2;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _employee = new Employee();
            _employee2 = new Employee();
        }

        /// <summary>
        /// 如果不带参数创建Guid类型标识的实体，会自动生成标识，标识不为Guid.Empty
        /// </summary>
        [TestMethod]
        public void TestCreateEntity_NotArgument_GuidId_IdIsNotEmpty() {
            Assert.AreNotEqual( Guid.Empty, _employee.Id );
        }

        /// <summary>
        /// 如果用Guid值创建Guid类型标识的实体，标识被设置为Guid
        /// </summary>
        [TestMethod]
        public void TestCreateEntity_ArgumentIsNewGuid_GuidId_IdIsNewGuid() {
            Guid id = Guid.NewGuid();
            _employee = new Employee( id );
            Assert.AreEqual( id, _employee.Id );
        }

        /// <summary>
        /// 新创建的实体不相等
        /// </summary>
        [TestMethod]
        public void TestNewEntityIsNotEquals() {
            Assert.IsFalse( _employee.Equals( _employee2 ) );
            Assert.IsFalse( _employee.Equals( null ) );

            Assert.IsFalse( _employee == _employee2 );
            Assert.IsFalse( _employee == null );
            Assert.IsFalse( null == _employee2 );

            Assert.IsTrue( _employee != _employee2 );
            Assert.IsTrue( _employee != null );
            Assert.IsTrue( null != _employee2 );
        }

        /// <summary>
        /// 当两个实体的标识相同，则实体相同
        /// </summary>
        [TestMethod]
        public void TestEntityEquals_IdEquals() {
            Guid id = Guid.NewGuid();
            _employee = new Employee( id );
            _employee2 = new Employee( id );
            Assert.IsTrue( _employee.Equals( _employee2 ) );
            Assert.IsTrue( _employee == _employee2 );
            Assert.IsFalse( _employee != _employee2 );
        }

        /// <summary>
        /// 测试状态输出
        /// </summary>
        [TestMethod]
        public void TestToString() {
            _employee = new Employee{ Name = "a" };
            Assert.AreEqual( string.Format( "Id:{0},姓名:a", _employee.Id ), _employee.ToString() );
        }

        /// <summary>
        /// Id为空Guid，无法验证通过
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( Warning ) )]
        public void TestValidate_IdIsEmpty_Invalid() {
            try {
                _employee = new Employee( Guid.Empty );
                _employee.Validate();
            }
            catch ( Warning ex ) {
                Assert.IsTrue( ex.Message.Contains( "Id" ) );
                throw;
            }
        }
    }
}
