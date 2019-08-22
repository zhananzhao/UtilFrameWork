using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests {
    /// <summary>
    /// 测试操作
    /// </summary>
    [TestClass]
    public class TestTest {
        /// <summary>
        /// 获取运行时间
        /// </summary>
        [TestMethod]
        public void TestGetElapsed() {
            Util.Test test = new Util.Test();
            test.Start();
            for( int i = 0; i < 1000; i++ ) {
                object value = 1;
            }
            System.Console.Write( test.GetElapsed() );
            Assert.IsTrue( test.GetElapsed() > 0 ); 
        }
       
    }
}
