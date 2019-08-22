using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Results;
using Util.Webs.EasyUi.Tests.Samples;

namespace Util.Webs.EasyUi.Tests.Results {
    /// <summary>
    /// DataGrid结果测试
    /// </summary>
    [TestClass]
    public class DataGridResultTest {
        /// <summary>
        /// 获取数据输出结果
        /// </summary>
        [TestMethod]
        public void TestGetResult() {
            var list = Test2.CreateList();
            var result = new DataGridResult( list, 2 );
            var expected = new Str();
            expected.Add( "{\"total\":2,\"rows\":[" );
            expected.Add( "{\"Id\":1,\"Name\":\"a\",\"Description\":\"a\"}," );
            expected.Add( "{\"Id\":2,\"Name\":\"b\",\"Description\":\"b\"}" );
            expected.Add( "]}" );
            Assert.AreEqual( expected.ToString(),result.ToString() );
        }
    }
}
