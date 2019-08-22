using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.EasyUi.Buttons;

namespace Util.Webs.EasyUi.Tests.Buttons {
    /// <summary>
    /// 按钮测试
    /// </summary>
    [TestClass]
    public class ButtonTest {

        #region 测试初始化

        /// <summary>
        /// 链接按钮
        /// </summary>
        private Button _button;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _button = new Button( "a" );
        }

        /// <summary>
        /// 创建输出结果
        /// </summary>
        private string CreateResult( string options = "",string @class = "") {
            if ( !options.IsEmpty() )
                options = " " + options;
            var result = new Str();
            result.Add( "<a href=\"javascript:void(0)\" class=\"easyui-linkbutton{0}\"{1}>a</a>", GetClass( @class ), options );
            return result.ToString();
        }

        /// <summary>
        /// 获取class
        /// </summary>
        private string GetClass( string @class ) {
            if ( @class.IsEmpty() )
                return string.Empty;
            return string.Format( " {0}", @class );
        }

        /// <summary>
        /// 断言选项
        /// </summary>
        private void AssertOptions( string option ) {
            Assert.AreEqual( CreateResult( string.Format( "data-options=\"{0}\"", option ) ), _button.ToHtmlString() );
        }

        #endregion

        #region 基础属性

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            Assert.AreEqual( CreateResult(), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试宽度
        /// </summary>
        [TestMethod]
        public void TestWidth() {
            _button.Width( 100 );
            AssertOptions( "width:100" );
        }

        /// <summary>
        /// 测试高度
        /// </summary>
        [TestMethod]
        public void TestHeight() {
            _button.Height( 100 );
            AssertOptions( "height:100" );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [TestMethod]
        public void TestDisable() {
            _button.Disable();
            AssertOptions( "disabled:true" );
        }

        /// <summary>
        /// 测试平滑效果
        /// </summary>
        [TestMethod]
        public void TestPlain() {
            _button.Plain();
            AssertOptions( "plain:true" );
        }

        /// <summary>
        /// 测试图标
        /// </summary>
        [TestMethod]
        public void TestIcon() {
            _button.Icon( "a" );
            AssertOptions( "iconCls:'a'" );
        }

        /// <summary>
        /// 测试图标对齐
        /// </summary>
        [TestMethod]
        public void TestIconAlign() {
            _button.IconAlign( Align.Right );
            AssertOptions( "iconAlign:'right'" );
        }

        /// <summary>
        /// 测试小按钮
        /// </summary>
        [TestMethod]
        public void TestSmall() {
            _button.Small();
            AssertOptions( "size:'small'" );
        }

        /// <summary>
        /// 测试大按钮
        /// </summary>
        [TestMethod]
        public void TestLarge() {
            _button.Large();
            AssertOptions( "size:'large'" );
        }

        /// <summary>
        /// 测试单击回调函数
        /// </summary>
        [TestMethod]
        public void TestClick() {
            _button.Click( "a()" );
            Assert.AreEqual( CreateResult( "onClick=\"a()\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 设置href
        /// </summary>
        [TestMethod]
        public void TestHref() {
            _button.Href( "a" );
            Assert.AreEqual( "<a href=\"a\" class=\"easyui-linkbutton\">a</a>", _button.ToHtmlString() );
        }

        #endregion

        #region 工具提示

        /// <summary>
        /// 测试工具提示
        /// </summary>
        [TestMethod]
        public void TestToolTip() {
            _button.ToolTip( "a" );
            Assert.AreEqual( CreateResult( "title=\"a\"", "easyui-tooltip" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试工具提示，设置对齐方式
        /// </summary>
        [TestMethod]
        public void TestToolTip_Align() {
            _button.ToolTip( "a", Align.Right );
            Assert.AreEqual( CreateResult( "title=\"a\" data-options=\"position:'right'\"", "easyui-tooltip" ),
                _button.ToHtmlString() );
        }

        #endregion

        #region 表单操作

        #region Submit(提交表单)

        /// <summary>
        /// 测试提交表单
        /// </summary>
        [TestMethod]
        public void TestSubmit() {
            _button.Submit();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.submit(null,null,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试提交表单
        /// </summary>
        [TestMethod]
        public void TestSubmit_BeforeHandler() {
            _button.Submit( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.submit(a,null,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试提交表单
        /// </summary>
        [TestMethod]
        public void TestSubmit_BeforeHandler_SuccessHandler() {
            _button.Submit( "a", "b" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.submit(a,b,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试提交表单
        /// </summary>
        [TestMethod]
        public void TestSubmit_BeforeHandler_SuccessHandler_FormId() {
            _button.Submit( "a", "b", "c" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.submit(a,b,'c','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试提交表单
        /// </summary>
        [TestMethod]
        public void TestSubmit_FormId() {
            _button.Submit( "", "", "c" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.submit(null,null,'c','')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region Query(查询)

        /// <summary>
        /// 测试查询
        /// </summary>
        [TestMethod]
        public void TestQuery() {
            _button.Query();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.query('','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试查询
        /// </summary>
        [TestMethod]
        public void TestQuery_FormId() {
            _button.Query( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.query('a','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试查询
        /// </summary>
        [TestMethod]
        public void TestQuery_GridId() {
            _button.Query( "", "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.query('','a')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试查询
        /// </summary>
        [TestMethod]
        public void TestQuery_FormId_GridId() {
            _button.Query( "a", "b" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.query('a','b')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region Refresh(刷新)

        /// <summary>
        /// 测试刷新
        /// </summary>
        [TestMethod]
        public void TestRefresh() {
            _button.Refresh();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.refresh('','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试刷新
        /// </summary>
        [TestMethod]
        public void TestRefresh_FormId_GridId() {
            _button.Refresh( "a", "b" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.refresh('a','b')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region Delete(删除)

        /// <summary>
        /// 测试删除
        /// </summary>
        [TestMethod]
        public void TestDelete() {
            _button.Delete();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.deleteByUrl('',null,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试删除
        /// </summary>
        [TestMethod]
        public void TestDelete_Url() {
            _button.Delete( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.deleteByUrl('a',null,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试删除
        /// </summary>
        [TestMethod]
        public void TestDelete_Url_Callback() {
            _button.Delete( "a", "b" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.deleteByUrl('a',b,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试删除
        /// </summary>
        [TestMethod]
        public void TestDelete_Url_Callback_GridId() {
            _button.Delete( "a", "b", "c" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.deleteByUrl('a',b,'c','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试删除
        /// </summary>
        [TestMethod]
        public void TestDelete_GridId() {
            _button.Delete( "", "", "c" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.deleteByUrl('',null,'c','')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #endregion

        #region 表格操作

        #region AddByGrid(添加表格行)

        /// <summary>
        /// 测试添加表格行
        /// </summary>
        [TestMethod]
        public void TestAddByGrid() {
            _button.AddByGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.add({},'')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试添加表格行
        /// </summary>
        [TestMethod]
        public void TestAddByGrid_Row() {
            _button.AddByGrid( new { a = 1 } );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.add({'a':1},'')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试添加表格行
        /// </summary>
        [TestMethod]
        public void TestAddByGrid_GridId() {
            _button.AddByGrid( null, "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.add({},'a')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试添加表格行
        /// </summary>
        [TestMethod]
        public void TestAddByGrid_Row_GridId() {
            _button.AddByGrid( new { a = 1 }, "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.add({'a':1},'a')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试添加表格行
        /// </summary>
        [TestMethod]
        public void TestAddByGrid_Row_GridId_BeforeHandler() {
            _button.AddByGrid( new { a = 1 }, "a","b" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.add({'a':1},'a',b)\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region EditByGrid(编辑表格行)

        /// <summary>
        /// 测试编辑表格行
        /// </summary>
        [TestMethod]
        public void TestEditByGrid() {
            _button.EditByGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.edit()\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试编辑表格行
        /// </summary>
        [TestMethod]
        public void TestEditByGrid_GridId() {
            _button.EditByGrid( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.edit('a')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region CancelByGrid(取消表格行编辑状态)

        /// <summary>
        /// 测试取消表格行编辑状态
        /// </summary>
        [TestMethod]
        public void TestCancelByGrid() {
            _button.CancelByGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.cancel()\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试取消表格行编辑状态
        /// </summary>
        [TestMethod]
        public void TestCancelByGrid_GridId() {
            _button.CancelByGrid( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.cancel('a')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region DeleteByGrid(删除表格行)

        /// <summary>
        /// 测试删除表格行
        /// </summary>
        [TestMethod]
        public void TestDeleteByGrid() {
            _button.DeleteByGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.deleteById()\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试删除表格行
        /// </summary>
        [TestMethod]
        public void TestDeleteByGrid_GridId() {
            _button.DeleteByGrid( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.deleteById('a')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region SaveByGrid(保存表格)

        /// <summary>
        /// 测试保存表格
        /// </summary>
        [TestMethod]
        public void TestSaveByGrid() {
            _button.SaveByGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.save('',null,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试保存表格
        /// </summary>
        [TestMethod]
        public void TestSaveByGrid_Url() {
            _button.SaveByGrid( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.save('a',null,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试保存表格
        /// </summary>
        [TestMethod]
        public void TestSaveByGrid_Handler() {
            _button.SaveByGrid( "", "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.save('',a,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试保存表格
        /// </summary>
        [TestMethod]
        public void TestSaveByGrid_Url_Handler() {
            _button.SaveByGrid( "a", "b" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.save('a',b,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试保存表格
        /// </summary>
        [TestMethod]
        public void TestSaveByGrid_Url_Handler_GridId() {
            _button.SaveByGrid( "a", "b", "c" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.save('a',b,'c','')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region SubmitIdsByGrid(提交checkbox选中的Id列表)

        /// <summary>
        /// 测试提交checkbox选中的Id列表
        /// </summary>
        [TestMethod]
        public void TestSubmitIdsByGrid() {
            _button.SubmitIdsByGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.submitIds('',null,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试提交checkbox选中的Id列表
        /// </summary>
        [TestMethod]
        public void TestSubmitIdsByGrid_Url() {
            _button.SubmitIdsByGrid( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.submitIds('a',null,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试提交checkbox选中的Id列表
        /// </summary>
        [TestMethod]
        public void TestSubmitIdsByGrid_Handler() {
            _button.SubmitIdsByGrid( "", "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.submitIds('',a,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试提交checkbox选中的Id列表
        /// </summary>
        [TestMethod]
        public void TestSubmitIdsByGrid_Url_Handler() {
            _button.SubmitIdsByGrid( "a", "b" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.submitIds('a',b,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试提交checkbox选中的Id列表
        /// </summary>
        [TestMethod]
        public void TestSubmitIdsByGrid_Url_Handler_GridId() {
            _button.SubmitIdsByGrid( "a", "b", "c" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.submitIds('a',b,'c','')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #endregion

        #region 树型表格操作

        #region AddRootByTreeGrid(添加树型表格根节点)

        /// <summary>
        /// 测试添加树型表格根节点
        /// </summary>
        [TestMethod]
        public void TestAddRootByTreeGrid() {
            _button.AddRootByTreeGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.addRoot({},'')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试添加树型表格根节点
        /// </summary>
        [TestMethod]
        public void TestAddRootByTreeGrid_Row() {
            _button.AddRootByTreeGrid( new { a = 1 } );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.addRoot({'a':1},'')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试添加树型表格根节点
        /// </summary>
        [TestMethod]
        public void TestAddRootByTreeGrid_GridId() {
            _button.AddRootByTreeGrid( null, "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.addRoot({},'a')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试添加树型表格根节点
        /// </summary>
        [TestMethod]
        public void TestAddRootByTreeGrid_Row_GridId() {
            _button.AddRootByTreeGrid( new { a = 1 }, "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.addRoot({'a':1},'a')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试添加树型表格根节点
        /// </summary>
        [TestMethod]
        public void TestAddRootByTreeGrid_Row_GridId_BeforeHandler() {
            _button.AddRootByTreeGrid( new { a = 1 }, "a","b" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.addRoot({'a':1},'a',b)\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region AddToChildByTreeGrid(添加树型表格下级节点)

        /// <summary>
        /// 测试添加树型表格下级节点
        /// </summary>
        [TestMethod]
        public void TestAddToChildByTreeGrid() {
            _button.AddToChildByTreeGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.addToChild({},'')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试添加树型表格下级节点
        /// </summary>
        [TestMethod]
        public void TestAddToChildByTreeGrid_Row() {
            _button.AddToChildByTreeGrid( new { a = 1 } );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.addToChild({'a':1},'')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试添加树型表格下级节点
        /// </summary>
        [TestMethod]
        public void TestAddToChildByTreeGrid_GridId() {
            _button.AddToChildByTreeGrid( null, "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.addToChild({},'a')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试添加树型表格下级节点
        /// </summary>
        [TestMethod]
        public void TestAddToChildByTreeGrid_Row_GridId() {
            _button.AddToChildByTreeGrid( new { a = 1 }, "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.addToChild({'a':1},'a')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region EditByTreeGrid(编辑树型表格节点)

        /// <summary>
        /// 测试编辑树型表格节点
        /// </summary>
        [TestMethod]
        public void TestEditByTreeGrid() {
            _button.EditByTreeGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.edit()\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试编辑树型表格节点
        /// </summary>
        [TestMethod]
        public void TestEditByTreeGrid_GridId() {
            _button.EditByTreeGrid( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.edit('a')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region DeleteByTreeGrid(删除树型表格节点)

        /// <summary>
        /// 测试删除树型表格节点
        /// </summary>
        [TestMethod]
        public void TestDeleteByTreeGrid() {
            _button.DeleteByTreeGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.deleteById()\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试删除树型表格节点
        /// </summary>
        [TestMethod]
        public void TestDeleteByTreeGrid_GridId() {
            _button.DeleteByTreeGrid( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.deleteById('a')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region CancelByTreeGrid(取消树型表格节点编辑状态)

        /// <summary>
        /// 测试取消树型表格节点编辑状态
        /// </summary>
        [TestMethod]
        public void TestCancelByTreeGrid() {
            _button.CancelByTreeGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.cancel()\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试取消树型表格节点编辑状态
        /// </summary>
        [TestMethod]
        public void TestCancelByTreeGrid_GridId() {
            _button.CancelByTreeGrid( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.cancel('a')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region SaveByTreeGrid(保存树型表格)

        /// <summary>
        /// 测试保存树型表格
        /// </summary>
        [TestMethod]
        public void TestSaveByTreeGrid() {
            _button.SaveByTreeGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.save('',null,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试保存树型表格
        /// </summary>
        [TestMethod]
        public void TestSaveByTreeGrid_Url() {
            _button.SaveByTreeGrid( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.save('a',null,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试保存树型表格
        /// </summary>
        [TestMethod]
        public void TestSaveByTreeGrid_Handler() {
            _button.SaveByTreeGrid( "", "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.save('',a,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试保存树型表格
        /// </summary>
        [TestMethod]
        public void TestSaveByTreeGrid_Url_Handler() {
            _button.SaveByTreeGrid( "a", "b" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.save('a',b,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试保存树型表格
        /// </summary>
        [TestMethod]
        public void TestSaveByTreeGrid_Url_Handler_GridId() {
            _button.SaveByTreeGrid( "a", "b", "c" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.save('a',b,'c','')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region SubmitIdsByTreeGrid(提交checkbox选中的Id列表)

        /// <summary>
        /// 测试提交checkbox选中的Id列表
        /// </summary>
        [TestMethod]
        public void TestSubmitIdsByTreeGrid() {
            _button.SubmitIdsByTreeGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.submitIds('',null,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试提交checkbox选中的Id列表
        /// </summary>
        [TestMethod]
        public void TestSubmitIdsByTreeGrid_Url() {
            _button.SubmitIdsByTreeGrid( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.submitIds('a',null,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试提交checkbox选中的Id列表
        /// </summary>
        [TestMethod]
        public void TestSubmitIdsByTreeGrid_Handler() {
            _button.SubmitIdsByTreeGrid( "", "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.submitIds('',a,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试提交checkbox选中的Id列表
        /// </summary>
        [TestMethod]
        public void TestSubmitIdsByTreeGrid_Url_Handler() {
            _button.SubmitIdsByTreeGrid( "a", "b" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.submitIds('a',b,'','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试提交checkbox选中的Id列表
        /// </summary>
        [TestMethod]
        public void TestSubmitIdsByTreeGrid_Url_Handler_GridId() {
            _button.SubmitIdsByTreeGrid( "a", "b", "c" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.submitIds('a',b,'c','')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region QueryByTreeGrid(查询树型表格)

        /// <summary>
        /// 查询树型表格
        /// </summary>
        [TestMethod]
        public void TestQueryByTreeGrid() {
            _button.QueryByTreeGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.query('','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 查询树型表格
        /// </summary>
        [TestMethod]
        public void TestQueryByTreeGrid_FormId() {
            _button.QueryByTreeGrid( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.query('a','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 查询树型表格
        /// </summary>
        [TestMethod]
        public void TestQueryByTreeGrid_GridId() {
            _button.QueryByTreeGrid( "", "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.query('','a')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region RefreshByTreeGrid(刷新树型表格)

        /// <summary>
        /// 测试刷新树型表格
        /// </summary>
        [TestMethod]
        public void TestRefreshByTreeGrid() {
            _button.RefreshByTreeGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.refresh('','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试刷新树型表格
        /// </summary>
        [TestMethod]
        public void TestRefreshByTreeGrid_FormId() {
            _button.RefreshByTreeGrid( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.refresh('a','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试刷新树型表格
        /// </summary>
        [TestMethod]
        public void TestRefreshByTreeGrid_GridId() {
            _button.RefreshByTreeGrid( "", "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.refresh('','a')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region MoveUpByTreeGrid(上移树型表格节点)

        /// <summary>
        /// 测试上移树型表格节点
        /// </summary>
        [TestMethod]
        public void TestMoveUpByTreeGrid() {
            _button.MoveUpByTreeGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.moveUp()\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试上移树型表格节点
        /// </summary>
        [TestMethod]
        public void TestMoveUpByTreeGrid_GridId() {
            _button.MoveUpByTreeGrid( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.moveUp('a')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region MoveDownByTreeGrid(下移树型表格节点)

        /// <summary>
        /// 测试下移树型表格节点
        /// </summary>
        [TestMethod]
        public void TestMoveDownByTreeGrid() {
            _button.MoveDownByTreeGrid();
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.moveDown()\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试下移树型表格节点
        /// </summary>
        [TestMethod]
        public void TestMoveDownByTreeGrid_GridId() {
            _button.MoveDownByTreeGrid( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.treegrid.moveDown('a')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #endregion

        #region 表格展开操作

        /// <summary>
        /// 测试展开添加新行
        /// </summary>
        [TestMethod]
        public void TestAddByDetail() {
            _button.AddByDetail("a");
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.addByDetail('a')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试展开更新行
        /// </summary>
        [TestMethod]
        public void TestEditByDetail() {
            _button.EditByDetail( "a" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.grid.editByDetail('a')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试提交表单
        /// </summary>
        [TestMethod]
        public void TestSubmitByDetail_BeforeHandler_SuccessHandler_FormId() {
            _button.SubmitByDetail( "a", "b", "c" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.submitByDetail(a,b,'c','')\"" ), _button.ToHtmlString() );
        }

        #endregion

        #region 树操作

        /// <summary>
        /// 测试提交选中的Id列表
        /// </summary>
        [TestMethod]
        public void TestSubmitIdsByTree() {
            _button.SubmitIdsByTree( "a", "b", "", "d" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.tree.submitIds('a',b,'','d')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试提交选中的Id列表
        /// </summary>
        [TestMethod]
        public void TestSubmitIdsByTree_2() {
            _button.SubmitIdsByTree( "a", "b", "c","d" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.tree.submitIds('a',b,'c','d')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试删除树节点
        /// </summary>
        [TestMethod]
        public void TestDeleteByTree() {
            _button.DeleteByTree( "a", "b", "c" );
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.tree.deleteByUrl('a',b,'c','')\"" ), _button.ToHtmlString() );
        }

        /// <summary>
        /// 测试提交表单
        /// </summary>
        [TestMethod]
        public void TestSubmitByTree() {
            _button.SubmitByTree("a","b","c","d");
            Assert.AreEqual( CreateResult( "onClick=\"$.easyui.submitByTree(a,b,'c','d')\"" ), _button.ToHtmlString() );
        }

        #endregion
    }
}
