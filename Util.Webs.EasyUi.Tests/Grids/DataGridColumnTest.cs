using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Configs;
using Util.Webs.EasyUi.Forms.Comboxs;
using Util.Webs.EasyUi.Grids;
using Util.Webs.EasyUi.Tests.Samples;

namespace Util.Webs.EasyUi.Tests.Grids {
    /// <summary>
    /// 表格列测试
    /// </summary>
    [TestClass]
    public class DataGridColumnTest {
        /// <summary>
        /// 表格列
        /// </summary>
        private DataGridColumn _column;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _column = new DataGridColumn();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        public static string GetResult( string option = "",string text = "" ) {
            var result = new Str();
            result.Add( "<th " );
            if( !option.IsEmpty() )
                result.Add( "data-options=\"{0}\"",option );
            result.Add( ">" );
            if( !text.IsEmpty() )
                result.Add( text );
            result.Add( "</th>" );
            return result.ToString();
        }

        /// <summary>
        /// 断言
        /// </summary>
        private void AssertResult( string option = "", string text = "" ) {
            Assert.AreEqual( GetResult( option, text ), _column.ToHtmlString() );
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            AssertResult();
        }

        /// <summary>
        /// 测试字段名
        /// </summary>
        [TestMethod]
        public void TestField() {
            _column.Field( "a" );
            AssertResult( "field:'a'" );
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [TestMethod]
        public void TestText() {
            _column.Text( "a" );
            AssertResult( "","a" );
        }

        /// <summary>
        /// 测试对齐方式
        /// </summary>
        [TestMethod]
        public void TestAlign() {
            _column.Align();
            AssertResult( "halign:'center',align:'left'" );
        }

        /// <summary>
        /// 测试对齐方式
        /// </summary>
        [TestMethod]
        public void TestAlign_Head() {
            _column.Align( AlignLeftRigthCenter.Center, AlignLeftRigthCenter.Right );
            AssertResult( "halign:'center',align:'right'" );
        }

        /// <summary>
        /// 测试排序
        /// </summary>
        [TestMethod]
        public void TestSort() {
            _column.Sort();
            AssertResult( "sortable:true" );
        }

        /// <summary>
        /// 测试是否显示复选框
        /// </summary>
        [TestMethod]
        public void TestCheckBox() {
            _column.CheckBox();
            AssertResult( "checkbox:true" );
        }

        /// <summary>
        /// 测试格式化
        /// </summary>
        [TestMethod]
        public void TestFormat() {
            _column.Format( "a" );
            AssertResult( "formatter:a" );
        }

        /// <summary>
        /// 测试格式化布尔值
        /// </summary>
        [TestMethod]
        public void TestFormatBool() {
            _column.FormatBool();
            AssertResult( "formatter:$.easyui.formatBool" );
        }

        /// <summary>
        /// 测试格式化日期
        /// </summary>
        [TestMethod]
        public void TestFormatDate() {
            _column.FormatDate();
            AssertResult( "formatter:$.easyui.formatDate" );
        }

        /// <summary>
        /// 测试可编辑
        /// </summary>
        [TestMethod]
        public void TestEdit() {
            _column.Edit();
            AssertResult( "editor:{type:'text'}" );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [TestMethod]
        public void TestEdit_Required() {
            _column.Edit().Required();
            AssertResult( "editor:{type:'validatebox',options:{required:true}}" );
        }

        /// <summary>
        /// 测试必填项，并设置消息
        /// </summary>
        [TestMethod]
        public void TestEdit_Required_Message() {
            _column.Edit().Required("a");
            AssertResult( "editor:{type:'validatebox',options:{required:true,missingMessage:'a'}}" );
        }

        /// <summary>
        /// 测试最大长度
        /// </summary>
        [TestMethod]
        public void TestEdit_MaxLength() {
            _column.Edit().MaxLength( 10 );
            AssertResult( "editor:{type:'validatebox',options:{validType:'maxLength[10]'}}" );
        }

        /// <summary>
        /// 测试长度
        /// </summary>
        [TestMethod]
        public void TestEdit_Length() {
            _column.Edit().Length( 1,2 );
            AssertResult( "editor:{type:'validatebox',options:{validType:'length[1,2]'}}" );
        }

        /// <summary>
        /// 测试整数文本框
        /// </summary>
        [TestMethod]
        public void TestEdit_Date() {
            _column.Edit().Date();
            AssertResult( "editor:{type:'datebox',options:{editable:false}}" );
        }

        /// <summary>
        /// 测试数值文本框
        /// </summary>
        [TestMethod]
        public void TestEdit_Number() {
            _column.Edit().Number(1);
            AssertResult( "editor:{type:'numberbox',options:{precision:1}}" );
        }

        /// <summary>
        /// 测试数值文本框验证
        /// </summary>
        [TestMethod]
        public void TestEdit_Number_Validate() {
            _column.Edit().Number( -1 );
            AssertResult( "editor:{type:'numberbox',options:{precision:0}}" );
        }

        /// <summary>
        /// 测试整数文本框
        /// </summary>
        [TestMethod]
        public void TestEdit_Int() {
            _column.Edit().Int();
            AssertResult( "editor:{type:'numberbox',options:{precision:0}}" );
        }

        /// <summary>
        /// 测试编辑复选框
        /// </summary>
        [TestMethod]
        public void TestEdit_CheckBox() {
            _column.Edit().CheckBox();
            AssertResult( "editor:{type:'checkbox',options:{on:1,off:0}}" );
        }

        /// <summary>
        /// 测试编辑下拉列表框
        /// </summary>
        [TestMethod]
        public void TestEdit_Combox_Url() {
            _column.Edit().Combox( "a" );
            AssertResult( "formatter:$.easyui.formatComboxFromUrl('a','value','text'),editor:{type:'combobox',options:{url:'a',valueField:'value',textField:'text',groupField:'group',onBeforeLoad:$.easyui.loadGridColumnCombox_onBeforeLoad('a')}}" );
        }

        /// <summary>
        /// 测试编辑下拉列表框
        /// </summary>
        [TestMethod]
        public void TestEdit_Combox_Data() {
            _column.Edit().Combox( new[] { new ComboxItem( "text1", "value1" ) } );
            AssertResult( "formatter:$.easyui.formatCombox([{'value':'value1','text':'text1','group':''}],'value','text'),editor:{type:'combobox',options:{data:[{'value':'value1','text':'text1','group':''}],valueField:'value',textField:'text',groupField:'group'}}" );
        }

        /// <summary>
        /// 测试编辑下拉列表框
        /// </summary>
        [TestMethod]
        public void TestEdit_Combox_Enum() {
            _column.Edit().Combox<TestEnum>();
            AssertResult( "formatter:$.easyui.formatCombox([{'value':'1','text':'A1','group':''},{'value':'2','text':'B1','group':''}],'value','text'),editor:{type:'combobox',options:{data:[{'value':'1','text':'A1','group':''},{'value':'2','text':'B1','group':''}],valueField:'value',textField:'text',groupField:'group'}}" );
        }

        /// <summary>
        /// 测试组合框面板高度
        /// </summary>
        [TestMethod]
        public void TestPanelHeight() {
            _column.Edit().Int().PanelHeight( "100" );
            AssertResult( "editor:{type:'numberbox',options:{precision:0,panelHeight:'100'}}" );
        }

        /// <summary>
        /// 测试是否可编辑
        /// </summary>
        [TestMethod]
        public void TestEditable() {
            _column.Edit().Int().Editable( false );
            AssertResult( "editor:{type:'numberbox',options:{precision:0,editable:false}}" );
        }

        /// <summary>
        /// 测试编辑下拉树
        /// </summary>
        [TestMethod]
        public void TestEdit_ComboTree() {
            _column.Edit().ComboTree( "a" );
            AssertResult( "formatter:$.easyui.formatComboxFromUrl('a','id','text'),editor:{type:'combotree',options:{url:'a',onBeforeLoad:$.easyui.loadGridColumnComboTree_onBeforeLoad('a')}}" );
        }

        /// <summary>
        /// 测试格式化图片
        /// </summary>
        [TestMethod]
        public void TestFormatImage() {
            _column.FormatImage(1,1,true);
            AssertResult( "formatter:$.easyui.formatImage(1,1,true)" );
        }

        /// <summary>
        /// 测试查找带回
        /// </summary>
        [TestMethod]
        public void TestLookup() {
            _column.Edit().Lookup( new LookupOption{ Url = "a",Editable = false});
            AssertResult( "editor:{type:'lookup',options:{'url':'a','editable':false}}" );
        }
    }
}
