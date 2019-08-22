using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests {
    /// <summary>
    /// 随机数操作测试
    /// </summary>
    [TestClass]
    public class RandomTest {
        /// <summary>
        /// 获取指定范围的随机整数
        /// </summary>
        [TestMethod]
        public void TestGetInt() {
            Util.Random random = new Util.Random();
            var result1 = random.GetInt( 1, 1000 );
            var result2 = random.GetInt( 1, 1000 );
            Console.WriteLine( "result1:{0}", result1 );
            Console.WriteLine( "result2:{0}", result2 );
            Assert.IsTrue( result1 >= 1 && result1 < 1000 );
            Assert.IsTrue( result1 != result2 );
        }

        /// <summary>
        /// 获取随机排序的集合
        /// </summary>
        [TestMethod]
        public void TestSort_Validate_InputIsNull() {
            int[] input = null;
            Assert.IsNull( Util.Random.GetSortList( input ) );
        }

        /// <summary>
        /// 获取随机排序的集合
        /// </summary>
        [TestMethod]
        public void TestSort() {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var list = Util.Random.GetSortList( input );
            Console.WriteLine( list.Splice() );
            Assert.AreNotEqual( "1,2,3,4,5,6,7,8,9,10", list.Splice() );
        }

        /// <summary>
        /// 获取随机排序的集合
        /// </summary>
        [TestMethod]
        public void TestSortList() {
            var input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var list = Util.Random.GetSortList( input );
            Console.WriteLine( list.Splice() );
            Assert.AreNotEqual( "1,2,3,4,5,6,7,8,9,10", list.Splice() );
        }
    }
}
