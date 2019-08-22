using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Domains.Tests {
    /// <summary>
    /// 树型实体基类测试
    /// </summary>
    [TestClass]
    public class TreeEntityBaseTest {
        /// <summary>
        /// 初始化一级节点，Guid标识
        /// </summary>
        [TestMethod]
        public void TestInitPath_1Level_Guid() {
            var id = Guid.NewGuid();
            var treeObject = new GuidTreeObject( id );
            treeObject.InitPath();
            Assert.AreEqual( 1, treeObject.Level );
            Assert.AreEqual( id + ",", treeObject.Path );
        }

        /// <summary>
        /// 初始化二级节点，Guid标识
        /// </summary>
        [TestMethod]
        public void TestInitPath_2Level_Guid() {
            var parentId = Guid.NewGuid();
            var id = Guid.NewGuid();
            var parent = new GuidTreeObject( parentId );
            parent.InitPath();
            var treeObject = new GuidTreeObject( id ) { Parent = parent };
            treeObject.InitPath();
            Assert.AreEqual( 2, treeObject.Level );
            Assert.AreEqual( string.Format( "{0},{1},",parentId,id ), treeObject.Path );
        }

        /// <summary>
        /// 初始化3级节点
        /// </summary>
        [TestMethod]
        public void TestInitPath_3Level_Guid() {
            Guid oneLevelId = Guid.NewGuid();
            Guid twoLevelId = Guid.NewGuid();
            Guid threeLevelId = Guid.NewGuid();
            var oneLevel = new GuidTreeObject( oneLevelId );
            oneLevel.InitPath();
            var twoLevel = new GuidTreeObject( twoLevelId ) { Parent = oneLevel };
            twoLevel.InitPath();
            var treeObject = new GuidTreeObject( threeLevelId ) { Parent = twoLevel };
            treeObject.InitPath();
            Assert.AreEqual( 3, treeObject.Level );
            Assert.AreEqual( string.Format( "{0},{1},{2},", oneLevelId, twoLevelId, threeLevelId ), treeObject.Path );
        }

        /// <summary>
        /// 从路径中获取所有上级节点编号
        /// </summary>
        [TestMethod]
        public void TestGetParentIdsFromPath_Null() {
            var entity = new GuidTreeObject( Guid.NewGuid(), null );
            Assert.AreEqual( 0, entity.GetParentIdsFromPath().Count );
        }

        /// <summary>
        /// 从路径中获取所有上级节点编号
        /// </summary>
        [TestMethod]
        public void TestGetParentIdsFromPath_Empty() {
            var entity = new GuidTreeObject( Guid.NewGuid(),"" );
            Assert.AreEqual( 0, entity.GetParentIdsFromPath().Count );
        }

        /// <summary>
        /// 从路径中获取所有上级节点编号
        /// </summary>
        [TestMethod]
        public void TestGetParentIdsFromPath_1Level() {
            Guid oneLevelId = Guid.NewGuid();
            var entity = new GuidTreeObject( oneLevelId );
            entity.InitPath();
            Assert.AreEqual( 0, entity.GetParentIdsFromPath().Count );
        }

        /// <summary>
        /// 从路径中获取所有上级节点编号
        /// </summary>
        [TestMethod]
        public void TestGetParentIdsFromPath_2Level() {
            var parentId = Guid.NewGuid();
            var id = Guid.NewGuid();
            var parent = new GuidTreeObject( parentId );
            parent.InitPath();
            var entity = new GuidTreeObject( id ) { Parent = parent };
            entity.InitPath();
            Assert.AreEqual( 1, entity.GetParentIdsFromPath().Count );
            Assert.AreEqual( parentId, entity.GetParentIdsFromPath()[0] );
        }
    }
}
