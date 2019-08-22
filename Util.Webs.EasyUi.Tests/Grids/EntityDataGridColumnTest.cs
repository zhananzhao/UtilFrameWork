using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Grids;
using Util.Webs.EasyUi.Tests.Samples;

namespace Util.Webs.EasyUi.Tests.Grids {
    /// <summary>
    /// 实体表格列测试
    /// </summary>
    [TestClass]
    public class EntityDataGridColumnTest {
        /// <summary>
        /// 测试name属性
        /// </summary>
        [TestMethod]
        public void TestName() {
            var column = new EntityDataGridColumn<User, string>( t => t.Description,null,false );
            Assert.AreEqual( DataGridColumnTest.GetResult( "field:'Description'" ), column.ToHtmlString() );
        }
    }
}
