using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Util.ApplicationServices.Tests.Samples;
using Util.Datas;

namespace Util.ApplicationServices.Tests {
    /// <summary>
    /// 树型实体批操作服务测试
    /// </summary>
    [TestClass]
    public class TreeBatchServiceBaseTest {
        /// <summary>
        /// 批操作服务
        /// </summary>
        private TreeBatchService _service;
        /// <summary>
        /// 模拟工作单元
        /// </summary>
        private IUnitOfWork _mockUnitOfWork;
        /// <summary>
        /// 模拟仓储
        /// </summary>
        private ITreeEntityRepository _mockRepository;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _mockUnitOfWork = Substitute.For<IUnitOfWork>();
            _mockRepository = CreateMockRepository();
            _service = new TreeBatchService( _mockUnitOfWork, _mockRepository );
        }

        /// <summary>
        /// 创建模拟仓储
        /// </summary>
        private ITreeEntityRepository CreateMockRepository() {
            var result = Substitute.For<ITreeEntityRepository>();
            result.Find().Returns( new EnumerableQuery<TreeEntity>( new List<TreeEntity>() ) );
            return result;
        }

        /// <summary>
        /// 测试添加空集合操作
        /// </summary>
        [TestMethod]
        public void Test_Add_Empty() {
            var list = _service.Save( TreeDto.CreateEmptyList(), TreeDto.CreateEmptyList(), TreeDto.CreateEmptyList() );
            Assert.AreEqual( 0, list.Count );
        }

        /// <summary>
        /// 测试添加操作
        /// </summary>
        [TestMethod]
        public void Test_Add_1() {
            var input = new List<TreeDto> { new TreeDto{Id = "1",SortId = 1} };
            var list = _service.Save( input, TreeDto.CreateEmptyList(), TreeDto.CreateEmptyList() );
            Assert.AreEqual( 1, list.Count );
            Assert.AreEqual( 1, list[0].Level );
            Assert.AreEqual( "1,", list[0].Path );
        }

        /// <summary>
        /// 测试添加操作
        /// </summary>
        [TestMethod]
        public void Test_Add_2() {
            var input = new List<TreeDto> {
                new TreeDto{Id = "1",SortId = 1},
                new TreeDto{Id = "2",SortId = 1}
            };
            var list = _service.Save( input, TreeDto.CreateEmptyList(), TreeDto.CreateEmptyList() );
            Assert.AreEqual( 2, list.Count );
            Assert.AreEqual( 1, list[0].Level );
            Assert.AreEqual( "1,", list[0].Path );
            Assert.AreEqual( 1, list[1].Level );
            Assert.AreEqual( "2,", list[1].Path );
        }

        /// <summary>
        /// 测试添加操作，验证重复
        /// </summary>
        [TestMethod]
        public void Test_Add_Repeat() {
            var input = new List<TreeDto> {
                new TreeDto{Id = "1",SortId = 1},
                new TreeDto{Id = "1",SortId = 2}
            };
            var list = _service.Save( input, TreeDto.CreateEmptyList(), TreeDto.CreateEmptyList() );
            Assert.AreEqual( 1, list.Count );
        }

        /// <summary>
        /// 测试添加嵌套结构
        /// </summary>
        [TestMethod]
        public void Test_Add_Nested_1() {
            var input = new List<TreeDto> {
                new TreeDto{Id = "1",SortId = 1},
                new TreeDto{Id = "2",ParentId = 1,SortId = 1}
            };
            var result = _service.Save( input, TreeDto.CreateEmptyList(), TreeDto.CreateEmptyList() );
            Assert.AreEqual( 2, result.Count, "result.Count" );
            Assert.AreEqual( 1, result[0].Level, "result[0].Level" );
            Assert.AreEqual( "1,", result[0].Path );
            Assert.AreEqual( 2, result[1].Level, "result[1].Level" );
            Assert.AreEqual( "1,2,", result[1].Path );
        }

        /// <summary>
        /// 测试添加嵌套结构
        /// </summary>
        [TestMethod]
        public void Test_Add_Nested_2() {
            var input = new List<TreeDto> {
                new TreeDto{Id = "2",ParentId = 1,SortId = 1},
                new TreeDto{Id = "1",SortId = 1}
            };
            var result = _service.Save( input, TreeDto.CreateEmptyList(), TreeDto.CreateEmptyList() );
            Assert.AreEqual( 2, result.Count );
            Assert.AreEqual( 2, result[0].Level );
            Assert.AreEqual( "1,2,", result[0].Path );
            Assert.AreEqual( 1, result[1].Level );
            Assert.AreEqual( "1,", result[1].Path );
        }

        /// <summary>
        /// 测试添加嵌套结构
        /// </summary>
        [TestMethod]
        public void Test_Add_Nested_3() {
            var input = new List<TreeDto> {
                new TreeDto{Id = "3",ParentId = 2,SortId = 1},
                new TreeDto{Id = "2",ParentId = 1,SortId = 1},
                new TreeDto{Id = "1",SortId = 1}
            };
            var result = _service.Save( input, TreeDto.CreateEmptyList(), TreeDto.CreateEmptyList() );
            Assert.AreEqual( 3, result[0].Level, "result[0].Level" );
            Assert.AreEqual( "1,2,3,", result[0].Path );
            Assert.AreEqual( 2, result[1].Level );
            Assert.AreEqual( "1,2,", result[1].Path );
            Assert.AreEqual( 1, result[2].Level );
            Assert.AreEqual( "1,", result[2].Path );
        }

        /// <summary>
        /// 测试修改，无变化
        /// </summary>
        [TestMethod]
        public void Test_Update_NoChanges() {
            _mockRepository.Find( 1 ).Returns( TreeEntity.Create() );
            _mockRepository.Find( 2 ).Returns( new TreeEntity( 2, "1,2,", 2 ) { SortId = 1, ParentId = 1 } );
            var input = new List<TreeDto> {
                new TreeDto{Id = "1",Path="1,",Level = 1,SortId = 1,Version = new byte[]{1}},
                new TreeDto{Id = "2",Path="1,2,",Level = 2,ParentId = 1,SortId = 1,Version = new byte[]{1}}
            };
            var result = _service.Save( TreeDto.CreateEmptyList(), input, TreeDto.CreateEmptyList() );
            Assert.AreEqual( 2, result.Count );
            Assert.AreEqual( 1, result[0].Level );
            Assert.AreEqual( "1,", result[0].Path );
            Assert.AreEqual( 2, result[1].Level );
            Assert.AreEqual( "1,2,", result[1].Path );
        }

        /// <summary>
        /// 测试修改，验证重复
        /// </summary>
        [TestMethod]
        public void Test_Update_Repeat() {
            _mockRepository.Find( 1 ).Returns( TreeEntity.Create() );
            var input = new List<TreeDto> {
                new TreeDto{Id = "1",Path="1,",Level = 1,ParentId = 2,SortId = 1,Version = new byte[]{1}},
                new TreeDto{Id = "1",Path="1,",Level = 1,ParentId = 2,SortId = 2,Version = new byte[]{1}},
            };
            var result = _service.Save( TreeDto.CreateEmptyList(), input, TreeDto.CreateEmptyList() );
            Assert.AreEqual( 1, result.Count, "result.Count" );
        }

        /// <summary>
        /// 测试修改，将1,2修改为2,1
        /// </summary>
        [TestMethod]
        public void Test_Update_1() {
            _mockRepository.Find( 1 ).Returns( TreeEntity.Create() );
            _mockRepository.Find( 2 ).Returns( new TreeEntity( 2, "1,2,", 2 ) { SortId = 1, ParentId = 1 } );
            var input = new List<TreeDto> {
                new TreeDto{Id = "1",Path="1,",Level = 1,ParentId = 2,SortId = 1,Version = new byte[]{1}},
                new TreeDto{Id = "2",Path="1,2,",Level = 2,SortId = 1,Version = new byte[]{1}}};
            var result = _service.Save( TreeDto.CreateEmptyList(), input, TreeDto.CreateEmptyList() );
            Assert.AreEqual( 2, result.Count, "result.Count" );
            Assert.AreEqual( 2, result[0].Level, "result[0].Level" );
            Assert.AreEqual( "2,1,", result[0].Path );
            Assert.AreEqual( 1, result[1].Level );
            Assert.AreEqual( "2,", result[1].Path );
        }

        /// <summary>
        /// 测试修改,将1,2,3修改为3,2,1
        /// </summary>
        [TestMethod]
        public void Test_Update_2() {
            _mockRepository.Find( 1 ).Returns( TreeEntity.Create() );
            _mockRepository.Find( 2 ).Returns( new TreeEntity( 2, "1,2,", 2 ) { SortId = 1, ParentId = 1 } );
            _mockRepository.Find( 3 ).Returns( new TreeEntity( 3, "1,2,3,", 3 ) { SortId = 1, ParentId = 2 } );
            var input = new List<TreeDto> {
                new TreeDto{Id = "1",Path="1,",Level = 1,ParentId = 2,SortId = 1,Version = new byte[]{1}},
                new TreeDto{Id = "2",Path="1,2,",Level = 2,ParentId = 3,SortId = 1,Version = new byte[]{1}},
                new TreeDto{Id = "3",Path="1,2,3,",Level = 3,SortId = 1,Version = new byte[]{1}}
            };
            var result = _service.Save( TreeDto.CreateEmptyList(), input, TreeDto.CreateEmptyList() );
            Assert.AreEqual( 3, result.Count, "result.Count" );
            Assert.AreEqual( 3, result[0].Level, "result[0].Level" );
            Assert.AreEqual( "3,2,1,", result[0].Path );
            Assert.AreEqual( 2, result[1].Level );
            Assert.AreEqual( "3,2,", result[1].Path );
            Assert.AreEqual( 1, result[2].Level );
            Assert.AreEqual( "3,", result[2].Path );
        }

        /// <summary>
        /// 测试修改，将1,2,3,4修改为3,4,1,2
        /// </summary>
        [TestMethod]
        public void Test_Update_3() {
            _mockRepository.Find( 1 ).Returns( TreeEntity.Create() );
            _mockRepository.Find( 2 ).Returns( new TreeEntity( 2, "1,2,", 2 ) { SortId = 1, ParentId = 1 } );
            _mockRepository.Find( 3 ).Returns( new TreeEntity( 3, "1,2,3,", 3 ) { SortId = 1, ParentId = 2 } );
            _mockRepository.Find( 4 ).Returns( new TreeEntity( 4, "1,2,3,4,", 4 ) { SortId = 1, ParentId = 3 } );
            var input = new List<TreeDto> {
                new TreeDto{Id = "1",Path="1,",Level = 1,ParentId = 4,SortId = 1,Version = new byte[]{1}},
                new TreeDto{Id = "2",Path="1,2,",Level = 2,ParentId = 1,SortId = 1,Version = new byte[]{1}},
                new TreeDto{Id = "3",Path="1,2,3,",Level = 3,SortId = 1,Version = new byte[]{1}},
                new TreeDto{Id = "4",Path="1,2,3,4",Level = 4,ParentId = 3,SortId = 1,Version = new byte[]{1}},
            };
            var result = _service.Save( TreeDto.CreateEmptyList(), input, TreeDto.CreateEmptyList() );
            Assert.AreEqual( 4, result.Count, "result.Count" );
            Assert.AreEqual( 3, result[0].Level, "result[0].Level" );
            Assert.AreEqual( "3,4,1,", result[0].Path );
            Assert.AreEqual( 4, result[1].Level, "result[1].Level" );
            Assert.AreEqual( "3,4,1,2,", result[1].Path );
            Assert.AreEqual( 1, result[2].Level, "result[2].Level" );
            Assert.AreEqual( "3,", result[2].Path );
            Assert.AreEqual( 2, result[3].Level, "result[2].Level" );
            Assert.AreEqual( "3,4,", result[3].Path );
        }

        /// <summary>
        /// 测试添加和删除存在重复
        /// </summary>
        [TestMethod]
        public void Test_Add_Delete_Repeat() {
            var input = new List<TreeDto> {
                new TreeDto{Id = "1",SortId = 1}
            };
            var list = _service.Save( input, TreeDto.CreateEmptyList(), input );
            Assert.AreEqual( 0, list.Count );
        }

        /// <summary>
        /// 测试修改和删除存在重复
        /// </summary>
        [TestMethod]
        public void Test_Update_Delete_Repeat() {
            var input = new List<TreeDto> { new TreeDto{Id = "1",Path="1,",Level = 1,ParentId = 4,SortId = 1,Version = new byte[]{1}} };
            var list = _service.Save( TreeDto.CreateEmptyList(),input, input );
            Assert.AreEqual( 0, list.Count );
        }
    }
}
