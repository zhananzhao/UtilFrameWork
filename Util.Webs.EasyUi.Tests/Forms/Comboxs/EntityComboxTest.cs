using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Forms.Comboxs;
using Util.Webs.EasyUi.Tests.Samples;

namespace Util.Webs.EasyUi.Tests.Forms.Comboxs {
    /// <summary>
    /// 实体组合框测试
    /// </summary>
    [TestClass]
    public class EntityComboxTest {
        /// <summary>
        /// 测试加载布尔值
        /// </summary>
        [TestMethod]
        public void TestBool() {
            var combox = new EntityCombox<User,bool>( t => t.BoolValue  );
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto',width:50\" name=\"BoolValue\">" );
            result.Add( "<option value=\"false\">否</option>" );
            result.Add( "<option value=\"true\">是</option>" );
            result.Add( "</select>" );
            Assert.AreEqual( result.ToString(), combox.ToHtmlString() );
        }

        /// <summary>
        /// 测试加载可空布尔值
        /// </summary>
        [TestMethod]
        public void TestBool_Nullable() {
            var combox = new EntityCombox<User, bool?>( t => t.NullableBoolValue );
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto',width:50\" name=\"NullableBoolValue\">" );
            result.Add( "<option value=\"false\">否</option>" );
            result.Add( "<option value=\"true\">是</option>" );
            result.Add( "</select>" );
            Assert.AreEqual( result.ToString(), combox.ToHtmlString() );
        }

        /// <summary>
        /// 绑定枚举
        /// </summary>
        [TestMethod]
        public void TestEnum() {
            var combox = new EntityCombox<User, TestEnum>( t => t.EnumValue );
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto'\" name=\"EnumValue\">" );
            result.Add( "<option value=\"1\">A1</option>" );
            result.Add( "<option value=\"2\">B1</option>" );
            result.Add( "</select>" );
            Assert.AreEqual( result.ToString(), combox.ToHtmlString() );
        }

        /// <summary>
        /// 绑定可空枚举
        /// </summary>
        [TestMethod]
        public void TestEnum_Nullable() {
            var combox = new EntityCombox<User, TestEnum?>( t => t.NullableEnumValue );
            var result = new Str();
            result.Add( "<select class=\"easyui-combobox\" data-options=\"editable:false,panelHeight:'auto'\" name=\"NullableEnumValue\">" );
            result.Add( "<option value=\"1\">A1</option>" );
            result.Add( "<option value=\"2\">B1</option>" );
            result.Add( "</select>" );
            Assert.AreEqual( result.ToString(), combox.ToHtmlString() );
        }
    }
}
