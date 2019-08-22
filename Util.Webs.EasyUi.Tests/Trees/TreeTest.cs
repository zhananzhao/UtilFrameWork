using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Trees;

namespace Util.Webs.EasyUi.Tests.Trees {
    /// <summary>
    /// 树测试
    /// </summary>
    [TestClass]
    public class TreeTest {
        /// <summary>
        /// 树
        /// </summary>
        private Tree _tree;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _tree = new Tree();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( string options = "" ) {
            var result = new Str();
            result.Add( "<ul class=\"easyui-tree\"" );
            if( !options.IsEmpty() )
                result.Add( " data-options=\"{0}\"",options );
            result.Add( "></ul>" );
            Console.Write( result.ToString() );
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
            AssertResult( "checkbox:true" );
        }

        /// <summary>
        /// 测试显示复选框
        /// </summary>
        [TestMethod]
        public void TestCheckbox_OnlyLeafCheck() {
            _tree.Checkbox(true);
            AssertResult( "checkbox:true,onlyLeafCheck:true" );
        }

        /// <summary>
        /// 测试显示复选框
        /// </summary>
        [TestMethod]
        public void TestCheckbox_OnlyLeafCheck_CascadeCheck() {
            _tree.Checkbox( true,false );
            AssertResult( "checkbox:true,onlyLeafCheck:true,cascadeCheck:false" );
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
            _tree.Params( new {a = 1} );
            AssertResult( "queryParams:{'a':1}" );
        }

        /// <summary>
        /// 测试选择前事件
        /// </summary>
        [TestMethod]
        public void TestOnBeforeSelect() {
            _tree.OnBeforeSelect( "a" );
            AssertResult( "onBeforeSelect:a" );
        }

        /// <summary>
        /// 测试选择事件
        /// </summary>
        [TestMethod]
        public void TestOnSelect() {
            _tree.OnSelect( "a" );
            AssertResult( "onSelect:a" );
        }

        /// <summary>
        /// 测试仅允许选择叶节点
        /// </summary>
        [TestMethod]
        public void TestSelectLeafOnly() {
            _tree.SelectLeafOnly();
            AssertResult( "onBeforeSelect:$.easyui.fnSelectTreeLeafOnly" );
        }

        /// <summary>
        /// 测试右键菜单事件
        /// </summary>
        [TestMethod]
        public void TestOnContextMenu() {
            _tree.OnContextMenu( "a" );
            AssertResult( "onContextMenu:a" );
        }

        /// <summary>
        /// 测试设置菜单
        /// </summary>
        [TestMethod]
        public void TestMenu() {
            _tree.Menu();
            AssertResult( "onContextMenu:$.easyui.showTreeMenu_onContextMenu('')" );
        }

        /// <summary>
        /// 测试设置菜单
        /// </summary>
        [TestMethod]
        public void TestMenu_TreeId() {
            _tree.Menu( "a" );
            AssertResult( "onContextMenu:$.easyui.showTreeMenu_onContextMenu('a')" );
        }

        /// <summary>
        /// 测试设置菜单
        /// </summary>
        [TestMethod]
        public void TestMenu_TreeId_MenuId() {
            _tree.Menu( "a", "b" );
            AssertResult( "onContextMenu:$.easyui.showTreeMenu_onContextMenu('a','b')" );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [TestMethod]
        public void TestClick() {
            _tree.Click( "a" );
            AssertResult( "onClick:a" );
        }

        /// <summary>
        /// 测试单击刷新面板
        /// </summary>
        [TestMethod]
        public void TestRefreshPanel() {
            _tree.RefreshPanel( "a","b","c","d" );
            AssertResult( "onClick:$.easyui.clickTreeNodeRefreshPanel_onClick('a','b','c',d)" );
        }
    }
}
