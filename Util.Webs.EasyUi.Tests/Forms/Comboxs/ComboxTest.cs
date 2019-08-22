using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Forms.Comboxs;
using Util.Webs.EasyUi.Tests.Samples;

namespace Util.Webs.EasyUi.Tests.Forms.Comboxs {
    /// <summary>
    /// 组合框测试
    /// </summary>
    [TestClass]
    public class ComboxTest {
        /// <summary>
        /// 组合框
        /// </summary>
        private Combox _combox;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _combox = new Combox();
        }

        /// <summary>
        /// 添加项
        /// </summary>
        [TestMethod]
        public void TestAdd() {
            _combox.Add( "a" ).Add( "b", 2 ).Value( "2" );
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto'\">" );
            result.Add( "<option>a</option>" );
            result.Add( "<option value=\"2\" selected=\"selected\">b</option>" );
            result.Add( "</select>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 测试组合框面板高度
        /// </summary>
        [TestMethod]
        public void TestPanelHeight() {
            _combox.Add( "a" ).PanelHeight( "100" );
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'100'\">" );
            result.Add( "<option>a</option>" );
            result.Add( "</select>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 绑定bool值
        /// </summary>
        [TestMethod]
        public void TestBool() {
            _combox.Bool();
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto',width:50\">" );
            result.Add( "<option value=\"false\">否</option>" );
            result.Add( "<option value=\"true\">是</option>" );
            result.Add( "</select>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 设置一个默认选项
        /// </summary>
        [TestMethod]
        public void TestBool_DefaultItem() {
            _combox.Bool("a");
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto',width:50\">" );
            result.Add( "<option>a</option>" );
            result.Add( "<option value=\"false\">否</option>" );
            result.Add( "<option value=\"true\">是</option>" );
            result.Add( "</select>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 绑定枚举
        /// </summary>
        [TestMethod]
        public void TestEnum() {
            _combox.Enum<TestEnum>();
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto'\">" );
            result.Add( "<option value=\"1\">A1</option>" );
            result.Add( "<option value=\"2\">B1</option>" );
            result.Add( "</select>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 绑定枚举默认项
        /// </summary>
        [TestMethod]
        public void TestEnum_DefaultItem() {
            _combox.Enum<TestEnum>( "a" );
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto'\">" );
            result.Add( "<option>a</option>" );
            result.Add( "<option value=\"1\">A1</option>" );
            result.Add( "<option value=\"2\">B1</option>" );
            result.Add( "</select>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 添加默认值
        /// </summary>
        [TestMethod]
        public void TestAddDefault() {
            _combox.Enum<TestEnum>();
            _combox.AddDefault( "a" );
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto'\">" );
            result.Add( "<option>a</option>" );
            result.Add( "<option value=\"1\">A1</option>" );
            result.Add( "<option value=\"2\">B1</option>" );
            result.Add( "</select>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 转为Json
        /// </summary>
        [TestMethod]
        public void TestToJson() {
            var list = new List<ComboxItem>();
            list.Add( new ComboxItem( "a1",1,"a" ) );
            list.Add( new ComboxItem( "a2", 2, "a" ) );
            list.Add( new ComboxItem( "b1", 3, "b" ) );
            list.Add( new ComboxItem( "b2", 4, "b" ) );
            var result = new Str();
            result.Add( "[" );
            result.Add( "{\"value\":1,\"text\":\"a1\",\"group\":\"a\"}," );
            result.Add( "{\"value\":2,\"text\":\"a2\",\"group\":\"a\"}," );
            result.Add( "{\"value\":3,\"text\":\"b1\",\"group\":\"b\"}," );
            result.Add( "{\"value\":4,\"text\":\"b2\",\"group\":\"b\"}" );
            result.Add( "]" );
            Assert.AreEqual( result.ToString(),Combox.ToJson( list ) );
        }

        /// <summary>
        /// 设置远程加载
        /// </summary>
        [TestMethod]
        public void TestLoad() {
            _combox.Load( "a" );
            var result = new Str();
            result.Add( "<input class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto',url:'a',valueField:'value',textField:'text',groupField:'group'\"/>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 设置远程加载的字段名
        /// </summary>
        [TestMethod]
        public void TestLoad_Field() {
            _combox.Load( "a","b","c","d" );
            var result = new Str();
            result.Add( "<input class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto',url:'a',valueField:'b',textField:'c',groupField:'d'\"/>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 设置联动子控件
        /// </summary>
        [TestMethod]
        public void TestChild() {
            _combox.Child( "a" );
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto'" );
            result.Add( ",onChange:$.easyui.textbox_onChange([$.easyui.setChildCombox_onChange('a','id')])\"" );
            result.Add( "></select>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 设置联动子控件
        /// </summary>
        [TestMethod]
        public void TestChild_Param() {
            _combox.Child( "a", "b" );
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto'" );
            result.Add( ",onChange:$.easyui.textbox_onChange([$.easyui.setChildCombox_onChange('a','b')])\"" );
            result.Add( "></select>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 设置联动子控件
        /// </summary>
        [TestMethod]
        public void TestChild_Url() {
            _combox.Child( "a", "b","c" );
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto'" );
            result.Add( ",onChange:$.easyui.textbox_onChange([$.easyui.setChildCombox_onChange('a','b','c')])\"" );
            result.Add( "></select>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 设置延迟加载的值
        /// </summary>
        [TestMethod]
        public void TestLazyValue() {
            _combox.Id( "id1" ).LazyValue( "a" );
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto',onLoadSuccess:$.easyui.setComboxLazyValue_onLoadSuccess('id1')\" id=\"id1\" lazyValue=\"a\">" );
            result.Add( "</select>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 测试文本改变回调函数
        /// </summary>
        [TestMethod]
        public void TestOnChange() {
            _combox.OnChange( "a" ).OnChange( "b" );
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto',onChange:$.easyui.textbox_onChange([a,b])\">" );
            result.Add( "</select>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 测试添加隐藏控件
        /// </summary>
        [TestMethod]
        public void TestHidden() {
            _combox.Hidden("a","1");
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto',onChange:$.easyui.textbox_onChange([$.easyui.setComboxHiddenText_onChange('a')])\"></select>" );
            result.Add( "<input type=\"hidden\" name=\"a\" value=\"1\"/>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [TestMethod]
        public void TestRequired() {
            _combox.Required();
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto',required:true\"></select>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }

        /// <summary>
        /// 设置远程加载
        /// </summary>
        [TestMethod]
        public void TestUrl() {
            _combox.Id( "id1" ).Url( "a","1" );
            var result = new Str();
            result.Add( "<input class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto',url:'a',valueField:'value',textField:'text',groupField:'group',onLoadSuccess:$.easyui.setComboxLazyValue_onLoadSuccess('id1')\" id=\"id1\" lazyValue=\"1\"/>" );
            Assert.AreEqual( result.ToString(), _combox.ToHtmlString() );
        }
    }
}
