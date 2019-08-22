using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Forms.TextBoxs;
using Util.Webs.EasyUi.Tests.Samples;

namespace Util.Webs.EasyUi.Tests.Forms.TextBoxs {
    /// <summary>
    /// 实体文本框测试
    /// </summary>
    [TestClass]
    public class EntityTextBoxTest {
        /// <summary>
        /// 创建输出结果
        /// </summary>
        private string CreateReuslt( string name, string options = null ) {
            var result = new Str();
            result.Add( "<input class=\"easyui-textbox\" name=\"{0}\"", name );
            if ( options.IsEmpty() == false )
                result.Add( " data-options=\"{0}\"", options );
            result.Add( "/>" );
            return result.ToString();
        }

        /// <summary>
        /// 测试name属性
        /// </summary>
        [TestMethod]
        public void TestName() {
            var textBox = new EntityTextBox<User, string>( t => t.Description );
            Assert.AreEqual( CreateReuslt( "Description" ), textBox.ToHtmlString() );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [TestMethod]
        public void TestRequired() {
            var textBox = new EntityTextBox<User, string>( t => t.Name );
            Assert.AreEqual( CreateReuslt( "Name", "required:true,missingMessage:'姓名不能为空'" ), textBox.ToHtmlString() );
        }

        /// <summary>
        /// 测试字符串长度
        /// </summary>
        [TestMethod]
        public void TestLength() {
            var textBox = new EntityTextBox<User, string>( t => t.StringLength );
            Assert.AreEqual( CreateReuslt( "StringLength", "validType:'length[2,5]'" ), textBox.ToHtmlString() );
        }

        /// <summary>
        /// 测试字符串长度
        /// </summary>
        [TestMethod]
        public void TestMaxLength() {
            var textBox = new EntityTextBox<User, string>( t => t.StringMaxLength );
            Assert.AreEqual( CreateReuslt( "StringMaxLength", "validType:'maxLength[5]'" ), textBox.ToHtmlString() );
        }

        /// <summary>
        /// 测试显示为日期
        /// </summary>
        [TestMethod]
        public void TestDate() {
            var textBox = new EntityTextBox<User, DateTime>( t => t.DateTimeValue );
            Assert.AreEqual( "<input class=\"easyui-datebox\" name=\"DateTimeValue\" data-options=\"editable:false\"/>", textBox.ToHtmlString() );
        }
    }
}