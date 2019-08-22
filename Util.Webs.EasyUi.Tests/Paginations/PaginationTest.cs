using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Paginations;

namespace Util.Webs.EasyUi.Tests.Paginations {
    /// <summary>
    /// 分页测试
    /// </summary>
    [TestClass]
    public class PaginationTest {
        /// <summary>
        /// 分页组件
        /// </summary>
        private Pagination _pagination;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _pagination = new Pagination();
        }

        /// <summary>
        /// 验证结果
        /// </summary>
        private void AssertResult( string options = "" ) {
            var result = new Str();
            result.Add( "<div class=\"easyui-pagination\"" );
            if( !options.IsEmpty() )
                result.Add( " data-options=\"{0}\"",options );
            result.Add( "></div>" );
            Assert.AreEqual( result.ToString(), _pagination.ToHtmlString() );
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            AssertResult();
        }

        /// <summary>
        /// 测试总记录数
        /// </summary>
        [TestMethod]
        public void TestTotal() {
            _pagination.Total( 10 );
            AssertResult( "total:10" );
        }

        /// <summary>
        /// 测试页大小
        /// </summary>
        [TestMethod]
        public void TestPageSize() {
            _pagination.PageSize( 10 );
            AssertResult( "pageSize:10" );
        }

        /// <summary>
        /// 测试行数集合
        /// </summary>
        [TestMethod]
        public void TestPageList() {
            _pagination.PageList( 10,20,100 );
            AssertResult( "pageList:[10,20,100]" );
        }

        /// <summary>
        /// 测试当前第几页
        /// </summary>
        [TestMethod]
        public void TestPageNumber() {
            _pagination.PageNumber( 10 );
            AssertResult( "pageNumber:10" );
        }

        /// <summary>
        /// 测试分页事件
        /// </summary>
        [TestMethod]
        public void TestOnSelectPage() {
            _pagination.OnSelectPage( "a" );
            AssertResult( "onSelectPage:a" );
        }

        /// <summary>
        /// 测试设置Url
        /// </summary>
        [TestMethod]
        public void TestUrl() {
            _pagination.Url( "a","b" );
            AssertResult( "onSelectPage:$.easyui.clickPageButton_onSelectPage('a',b)" );
        }
    }
}
