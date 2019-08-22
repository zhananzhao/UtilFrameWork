using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Forms.ComboTrees;

namespace Util.Webs.EasyUi.Tests.Forms.ComboTrees {
    /// <summary>
    /// 组合框树
    /// </summary>
    [TestClass]
    public class ComboTreeTest {
        /// <summary>
        /// 树
        /// </summary>
        private ComboTree _tree;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _tree = new ComboTree();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( string options = "" ) {
            var result = new Str();
            result.Add( "<select class=\"easyui-combotree\"" );
            if ( !options.IsEmpty() )
                result.Add( " data-options=\"{0}\"", options );
            result.Add( "></select>" );
            return result.ToString();
        }

        /// <summary>
        /// 断言结果
        /// </summary>
        private void AssertResult( string options = "" ) {
            Assert.AreEqual( GetResult( options ), _tree.ToHtmlString() );
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            AssertResult();
        }

        /// <summary>
        /// 测试url
        /// </summary>
        [TestMethod]
        public void TestUrl() {
            _tree.Url( "a" );
            AssertResult( "url:'a'" );
        }

        /// <summary>
        /// 测试url
        /// </summary>
        [TestMethod]
        public void TestUrl_Value() {
            _tree.Id( "id1" ).Url( "a", "b" );
            var result = new Str();
            result.Add( "<select class=\"easyui-combotree\" id=\"id1\" lazyValue=\"b\" data-options=\"onLoadSuccess:$.easyui.setComboTreeLazyValue_onLoadSuccess('id1'),url:'a'\">" );
            result.Add( "</select>" );
            Console.WriteLine( result );
            Assert.AreEqual( result.ToString(), _tree.ToHtmlString() );
        }

        /// <summary>
        /// 测试启用动画效果
        /// </summary>
        [TestMethod]
        public void TestAnimate() {
            _tree.Animate();
            AssertResult( "animate:true" );
        }

        /// <summary>
        /// 测试显示复选框
        /// </summary>
        [TestMethod]
        public void TestCheckbox() {
            _tree.Checkbox();
            AssertResult( "multiple:true" );
        }

        /// <summary>
        /// 测试显示复选框
        /// </summary>
        [TestMethod]
        public void TestCheckbox_OnlyLeafCheck() {
            _tree.Checkbox( true );
            AssertResult( "multiple:true,onlyLeafCheck:true" );
        }

        /// <summary>
        /// 测试显示复选框
        /// </summary>
        [TestMethod]
        public void TestCheckbox_OnlyLeafCheck_CascadeCheck() {
            _tree.Checkbox( true, false );
            AssertResult( "multiple:true,onlyLeafCheck:true,cascadeCheck:false" );
        }

        /// <summary>
        /// 测试启用拖拽
        /// </summary>
        [TestMethod]
        public void TestEnableDrag() {
            _tree.EnableDrag();
            AssertResult( "dnd:true" );
        }

        /// <summary>
        /// 测试请求参数
        /// </summary>
        [TestMethod]
        public void TestParams_Null() {
            _tree.Params( null );
            AssertResult( "queryParams:{}" );
        }

        /// <summary>
        /// 测试请求参数
        /// </summary>
        [TestMethod]
        public void TestParams() {
            _tree.Params( new { a = 1 } );
            AssertResult( "queryParams:{'a':1}" );
        }

        /// <summary>
        /// 设置延迟加载的值
        /// </summary>
        [TestMethod]
        public void TestLazyValue() {
            _tree.Id( "id1" ).LazyValue( "a" );
            var result = new Str();
            result.Add( "<select class=\"easyui-combotree\" id=\"id1\" lazyValue=\"a\" data-options=\"onLoadSuccess:$.easyui.setComboTreeLazyValue_onLoadSuccess('id1')\">" );
            result.Add( "</select>" );
            Console.WriteLine(result);
            Assert.AreEqual( result.ToString(), _tree.ToHtmlString() );
        }
    }
}
