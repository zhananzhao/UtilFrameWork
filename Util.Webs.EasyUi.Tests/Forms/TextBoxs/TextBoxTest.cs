using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Forms.TextBoxs;

namespace Util.Webs.EasyUi.Tests.Forms.TextBoxs {
    /// <summary>
    /// 文本框测试
    /// </summary>
    [TestClass]
    public class TextBoxTest {
        /// <summary>
        /// 文本框
        /// </summary>
        private TextBox _textBox;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _textBox = new TextBox();
        }

        /// <summary>
        /// 创建输出结果
        /// </summary>
        private string CreateReuslt( string options = null ) {
            var result = new Str();
            result.Add(  "<input class=\"easyui-textbox\"" );
            if( options.IsEmpty() == false )
                result.Add( " data-options=\"{0}\"",options );
            result.Add( "/>" );
            return result.ToString();
        }

        /// <summary>
        /// 断言结果
        /// </summary>
        private void AssertResult( string options = null ) {
            Assert.AreEqual( CreateReuslt( options ), _textBox.ToHtmlString() );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            AssertResult();
        }

        /// <summary>
        /// 测试名称
        /// </summary>
        [TestMethod]
        public void TestName() {
            _textBox.Name( "a" );
            var result = new Str();
            result.Add( "<input class=\"easyui-textbox\" name=\"a\"/>" );
            Assert.AreEqual( result.ToString(), _textBox.ToHtmlString() );
        }

        /// <summary>
        /// 测试多次设置名称
        /// </summary>
        [TestMethod]
        public void TestName_Multiple() {
            _textBox.Name( "b" ).Name( "a" );
            var result = new Str();
            result.Add( "<input class=\"easyui-textbox\" name=\"a\"/>" );
            Assert.AreEqual( result.ToString(), _textBox.ToHtmlString() );
        }

        /// <summary>
        /// 设置宽度
        /// </summary>
        [TestMethod]
        public void TestWidth_Empty() {
            _textBox.Width( null );
            AssertResult();
        }

        /// <summary>
        /// 设置宽度
        /// </summary>
        [TestMethod]
        public void TestWidth_Px() {
            _textBox.Width( 10 );
            AssertResult( "width:10" );
        }

        /// <summary>
        /// 设置宽度
        /// </summary>
        [TestMethod]
        public void TestWidth_Percent() {
            _textBox.Width( 100, true );
            AssertResult("width:'100%'");
        }

        /// <summary>
        /// 测试提示消息
        /// </summary>
        [TestMethod]
        public void TestPrompt() {
            _textBox.Prompt( "a" );
            AssertResult( "prompt:'a'" );
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [TestMethod]
        public void TestValue() {
            _textBox.Value( "a" );
            AssertResult( "value:'a'" );
        }

        /// <summary>
        /// 测试密码框
        /// </summary>
        [TestMethod]
        public void TestPassword() {
            _textBox.Password();
            AssertResult( "type:'password'" );
        }

        /// <summary>
        /// 测试多行文本框
        /// </summary>
        [TestMethod]
        public void TestMultiLine() {
            _textBox.MultiLine( 1,2 );
            AssertResult( "multiline:true,width:1,height:2" );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [TestMethod]
        public void TestDisable() {
            _textBox.Disable();
            AssertResult( "disabled:true" );
        }

        /// <summary>
        /// 测试只读
        /// </summary>
        [TestMethod]
        public void TestReadOnly() {
            _textBox.ReadOnly();
            AssertResult( "readonly:true" );
        }

        /// <summary>
        /// 测试是否可编辑
        /// </summary>
        [TestMethod]
        public void TestEditable() {
            _textBox.Editable(false);
            AssertResult( "editable:false" );
        }

        /// <summary>
        /// 测试图标class
        /// </summary>
        [TestMethod]
        public void TestIcon() {
            _textBox.Icon( "a" );
            AssertResult( "iconCls:'a',iconWidth:18,iconAlign:'right'" );
        }

        /// <summary>
        /// 测试图标宽度
        /// </summary>
        [TestMethod]
        public void TestIcon_Width() {
            _textBox.Icon( "a", 1 );
            AssertResult( "iconCls:'a',iconWidth:1,iconAlign:'right'" );
        }

        /// <summary>
        /// 测试图标对齐
        /// </summary>
        [TestMethod]
        public void TestIcon_Align() {
            _textBox.Icon( "a", 18, AlignLeftRigth.Left );
            AssertResult( "iconCls:'a',iconWidth:18,iconAlign:'left'" );
        }

        /// <summary>
        /// 测试按钮图标和单击回调函数
        /// </summary>
        [TestMethod]
        public void TestButton_Icon_Callback() {
            _textBox.Button( "a","b" );
            AssertResult( "buttonIcon:'a',onClickButton:b,buttonAlign:'right'" );
        }

        /// <summary>
        /// 测试按钮文本
        /// </summary>
        [TestMethod]
        public void TestButton_Text() {
            _textBox.Button( "a", "b","c" );
            AssertResult( "buttonIcon:'a',onClickButton:b,buttonText:'c',buttonAlign:'right'" );
        }

        /// <summary>
        /// 测试按钮对齐方式
        /// </summary>
        [TestMethod]
        public void TestButton_Align() {
            _textBox.Button( "a", "b", "c", AlignLeftRigth.Left );
            AssertResult( "buttonIcon:'a',onClickButton:b,buttonText:'c',buttonAlign:'left'" );
        }

        /// <summary>
        /// 测试文本改变回调函数
        /// </summary>
        [TestMethod]
        public void TestOnChange() {
            _textBox.OnChange( "a" );
            AssertResult( "onChange:$.easyui.textbox_onChange([a])" );
            _textBox.OnChange( "b" );
            AssertResult( "onChange:$.easyui.textbox_onChange([a,b])" );
        }

        /// <summary>
        /// 测试延迟验证
        /// </summary>
        [TestMethod]
        public void TestDelay() {
            _textBox.Delay( 1000 );
            AssertResult( "delay:1000" );
        }

        /// <summary>
        /// 测试提示位置
        /// </summary>
        [TestMethod]
        public void TestTipPosition() {
            _textBox.TipPosition( AlignLeftRigth.Left );
            AssertResult( "tipPosition:'left'" );
        }

        /// <summary>
        /// 测试关闭验证
        /// </summary>
        [TestMethod]
        public void TestNoValidate() {
            _textBox.NoValidate();
            AssertResult( "novalidate:true" );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [TestMethod]
        public void TestRequired() {
            _textBox.Required();
            AssertResult( "required:true" );
        }

        /// <summary>
        /// 测试必填项,设为false
        /// </summary>
        [TestMethod]
        public void TestRequired_False() {
            _textBox.Required( false );
            AssertResult( "required:false" );
        }

        /// <summary>
        /// 测试必填项消息
        /// </summary>
        [TestMethod]
        public void TestRequired_Message() {
            _textBox.Required("a");
            AssertResult( "required:true,missingMessage:'a'" );
        }

        /// <summary>
        /// 测试Email验证
        /// </summary>
        [TestMethod]
        public void TestEmail() {
            _textBox.Email();
            AssertResult( "validType:'email'" );
        }

        /// <summary>
        /// 测试手机号验证
        /// </summary>
        [TestMethod]
        public void TestMobilePhone() {
            _textBox.MobilePhone();
            AssertResult( "validType:'mobilePhone'" );
        }

        /// <summary>
        /// 测试Url验证
        /// </summary>
        [TestMethod]
        public void TestValidateUrl() {
            _textBox.ValidateUrl();
            AssertResult( "validType:'url'" );
        }

        /// <summary>
        /// 验证字符串长度
        /// </summary>
        [TestMethod]
        public void TestLength() {
            _textBox.Length(1,2);
            AssertResult( "validType:'length[1,2]'" );
        }

        /// <summary>
        /// 验证字符串最小长度
        /// </summary>
        [TestMethod]
        public void TestMinLength() {
            _textBox.MinLength( 2 );
            AssertResult( "validType:'minLength[2]'" );
        }

        /// <summary>
        /// 验证字符串最大长度
        /// </summary>
        [TestMethod]
        public void TestMaxLength() {
            _textBox.MaxLength( 2 );
            AssertResult( "validType:'maxLength[2]'" );
        }

        /// <summary>
        /// 测试同时验证Email和最小长度
        /// </summary>
        [TestMethod]
        public void Test_Email_MinLength() {
            _textBox.Email().MinLength( 2 );
            AssertResult( "validType:['email','minLength[2]']" );
        }

        /// <summary>
        /// 测试远程验证
        /// </summary>
        [TestMethod]
        public void TestRemote() {
            _textBox.Remote("a","b");
            AssertResult( "validType:'remote[&quot;a&quot;,&quot;b&quot;]'" );
        }

        /// <summary>
        /// 测试相等验证
        /// </summary>
        [TestMethod]
        public void TestEqualTo() {
            _textBox.EqualTo( "a" );
            AssertResult( "validType:'equalTo[&quot;a&quot;,&quot;&quot;]'" );
        }

        /// <summary>
        /// 测试相等验证
        /// </summary>
        [TestMethod]
        public void TestEqualTo_Message() {
            _textBox.EqualTo( "a","b" );
            AssertResult( "validType:'equalTo[&quot;a&quot;,&quot;b&quot;]'" );
        }

        /// <summary>
        /// 测试最大值验证
        /// </summary>
        [TestMethod]
        public void TestMax() {
            _textBox.Max( 1 );
            AssertResult( "validType:'max[&quot;1&quot;,&quot;&quot;]'" );
        }

        /// <summary>
        /// 测试最大值验证消息
        /// </summary>
        [TestMethod]
        public void TestMax_Message() {
            _textBox.Max( 1, "a" );
            AssertResult( "validType:'max[&quot;1&quot;,&quot;a&quot;]'" );
        }

        /// <summary>
        /// 测试最大值验证
        /// </summary>
        [TestMethod]
        public void TestMax_Double() {
            _textBox.Max( 1.1 );
            AssertResult( "validType:'max[&quot;1.1&quot;,&quot;&quot;]'" );
        }

        /// <summary>
        /// 测试最大值验证消息
        /// </summary>
        [TestMethod]
        public void TestMax_Message_Double() {
            _textBox.Max( 1.1, "a" );
            AssertResult( "validType:'max[&quot;1.1&quot;,&quot;a&quot;]'" );
        }

        /// <summary>
        /// 测试最小值验证
        /// </summary>
        [TestMethod]
        public void TestMin() {
            _textBox.Min( 1 );
            AssertResult( "validType:'min[&quot;1&quot;,&quot;&quot;]'" );
        }

        /// <summary>
        /// 测试最小值验证消息
        /// </summary>
        [TestMethod]
        public void TestMin_Message() {
            _textBox.Min( 1.1, "a" );
            AssertResult( "validType:'min[&quot;1.1&quot;,&quot;a&quot;]'" );
        }

        /// <summary>
        /// 测试数值范围
        /// </summary>
        [TestMethod]
        public void TestRange() {
            _textBox.Range( 1.1, 2.2 );
            AssertResult( "validType:'range[&quot;1.1&quot;,&quot;2.2&quot;,&quot;&quot;]'" );
        }

        /// <summary>
        /// 测试数值范围消息
        /// </summary>
        [TestMethod]
        public void TestRange_Message() {
            _textBox.Range( 1.1, 2.2,"a" );
            AssertResult( "validType:'range[&quot;1.1&quot;,&quot;2.2&quot;,&quot;a&quot;]'" );
        }

        /// <summary>
        /// 测试日期
        /// </summary>
        [TestMethod]
        public void TestDate() {
            _textBox.Date();
            Assert.AreEqual( "<input class=\"easyui-datebox\" data-options=\"editable:false\"/>", _textBox.ToHtmlString() );
        }

        /// <summary>
        /// 测试日期时间
        /// </summary>
        [TestMethod]
        public void TestDateTime() {
            _textBox.DateTime();
            Assert.AreEqual( "<input class=\"easyui-datetimebox\" data-options=\"editable:false\"/>", _textBox.ToHtmlString() );
        }

        /// <summary>
        /// 测试时间
        /// </summary>
        [TestMethod]
        public void TestTime() {
            _textBox.Time();
            Assert.AreEqual( "<input class=\"easyui-timespinner\"/>", _textBox.ToHtmlString() );
        }

        /// <summary>
        /// 测试数值类型
        /// </summary>
        [TestMethod]
        public void TestNumber() {
            _textBox.Number(1);
            Assert.AreEqual( "<input class=\"easyui-numberbox\" data-options=\"precision:1\"/>", _textBox.ToHtmlString() );
        }

        /// <summary>
        /// 测试数值类型验证
        /// </summary>
        [TestMethod]
        public void TestNumber_Validate() {
            _textBox.Number( -1 );
            Assert.AreEqual( "<input class=\"easyui-numberbox\" data-options=\"precision:0\"/>", _textBox.ToHtmlString() );
        }

        /// <summary>
        /// 测试整数类型
        /// </summary>
        [TestMethod]
        public void TestInt() {
            _textBox.Int();
            Assert.AreEqual( "<input class=\"easyui-numberbox\" data-options=\"precision:0\"/>", _textBox.ToHtmlString() );
        }
    }
}
