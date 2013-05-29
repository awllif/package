using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rock.Interface;
using Rock.Container;

namespace CK_PluginOrder
{
    [PlugNameAttribute("采购申请"),
    PlugQueryFormAttribute("Order_Qurey"),
    PlugWriterAttribute(""),
    PlugQueryCmdAttribute("8b904afc-6b23-4bd7-ae33-3ce8a7f93cdf"),
    PlugActionAttribute("商品类别"),
    PlugDescriptionAttribute("商品类别 ")]
    public partial class CKPlugApplyOrder : PluginNode
    {
    
        public CKPlugApplyOrder()
        {
        }
        public override void Initialization()
        {
            //NodeBitmap = Resource.driver;
            //注册功能按钮
            Command cmdAdd = new Command("创建采购单", iapplication, CommandTriger.OFF, (int)ImageType.ADD);
            Command cmdEdit = new Command("采购单编辑", iapplication, CommandTriger.ON, (int)ImageType.EDIT);
            Command cmdDetail = new Command("采购单详情表", iapplication, CommandTriger.ON, (int)ImageType.PRINT01);
            // Command cmdPrint = new Command("人员查看", iapplication, CommandTriger.ON, (int)ImageType.PRINT02);
            cmdAdd.Click += new EventHandler(cmdAdd_Click);
            cmdEdit.Click += new EventHandler(cmdEdit_Click);
            cmdDetail.Click += new EventHandler(cmdDetail_Click);
            //建立功能按钮点击处理函数
            RegCommand(cmdAdd, cmdEdit,cmdDetail);

            //标题,字段,宽度,是否主键,是否显示
            this.InitialCaption();
            ////颜色控制列表
            //this.RegWhere(new object[] { 
            //                            new object[]{ "F_StateName","草稿",Color.Red},
            //            new object[]{ "F_StateName","关闭",Color.Gray},
            //            new object[]{ "F_StateName","发布",Color.Green}});

            ////分组
            //this.RegGroup(new object[] { "F_EventName" });
        }

        void cmdDetail_Click(object sender, EventArgs e)
        {
//            报表以后再设计
        }
     
        void cmdEdit_Click(object sender, EventArgs e)
        {
            FormCreateOrder FCO = new FormCreateOrder(iapplication, idataservice);
            FCO.ShowForm(FormType.Edit);
        }
        void cmdAdd_Click(object sender, EventArgs e)
        {
            FormCreateOrder FCO = new FormCreateOrder(iapplication,idataservice);
            IRight ir = (IRight)iapplication.GetService(typeof(IRight));
            FCO.RegStatickElement("F_CREATEUSER", System.Data.SqlDbType.Int, ir.UserId);
            FCO.RegStatickElement("F_CREATEAGENCY", System.Data.SqlDbType.Int, ir.AgencyId);
           // FCO.RegStatickElement("F_CREATENAME", System.Data.SqlDbType.VarChar, ir.UserName);
           // FCO.RegStatickElement("F_CREATEAGENCY", System.Data.SqlDbType.VarChar, ir.AgencyName);
            FCO.ShowForm(FormType.Insert);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }

   [PlugNameAttribute("采购审批"),
   PlugQueryFormAttribute("Order_Qurey"),
   PlugWriterAttribute(""),
   PlugQueryCmdAttribute("8b904afc-6b23-4bd7-ae33-3ce8a7f93cdf"),
   PlugActionAttribute("采购审批"),
   PlugDescriptionAttribute("采购审批")]
    public partial class CKPlugApproveOrder : PluginNode
    {

        public CKPlugApproveOrder()
        {
        }
        public override void Initialization()
        {
            //NodeBitmap = Resource.driver;
            //注册功能按钮
            Command cmdApprove = new Command("审批采购单", iapplication, CommandTriger.ON, (int)ImageType.ADD);
            Command cmdDetail = new Command("采购单详情表", iapplication, CommandTriger.ON, (int)ImageType.PRINT01);

            cmdApprove.Click += new EventHandler(cmdApprove_Click);
            cmdDetail.Click += new EventHandler(cmdDetail_Click);
            //建立功能按钮点击处理函数
            RegCommand(cmdApprove,cmdDetail);

            //标题,字段,宽度,是否主键,是否显示
            this.InitialCaption();
            ////颜色控制列表
            //this.RegWhere(new object[] { 
            //                            new object[]{ "F_StateName","草稿",Color.Red},
            //            new object[]{ "F_StateName","关闭",Color.Gray},
            //            new object[]{ "F_StateName","发布",Color.Green}});

            ////分组
            //this.RegGroup(new object[] { "F_EventName" });
        }

        void cmdDetail_Click(object sender, EventArgs e)
        {
            //根据采购单号  生成采购单详情表.
        }

        void cmdApprove_Click(object sender, EventArgs e)
        {
          //查看采购单明细,设置采购单属性到下个审批人或者回退到创建人,如果没有下个审批人.更新采购单状态都审批通过.
           

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
    [PlugNameAttribute("采购下单"),
    PlugQueryFormAttribute("Order_Qurey"),
    PlugWriterAttribute(""),
    PlugQueryCmdAttribute("8b904afc-6b23-4bd7-ae33-3ce8a7f93cdf"),
    PlugActionAttribute("商品类别"),
    PlugDescriptionAttribute("商品类别 ")]
    public partial class CKPlugBuyOrder : PluginNode
    {
        public CKPlugBuyOrder()
        {
        }
        public override void Initialization()
        {
            //NodeBitmap = Resource.driver;
            //注册功能按钮
            Command cmdAdd = new Command("采购下单", iapplication, CommandTriger.OFF, (int)ImageType.ADD);
            Command cmdEdit = new Command("", iapplication, CommandTriger.ON, (int)ImageType.EDIT);
            Command cmdDetail = new Command("订单详情", iapplication, CommandTriger.ON, (int)ImageType.PRINT01);
            // Command cmdPrint = new Command("人员查看", iapplication, CommandTriger.ON, (int)ImageType.PRINT02);
            cmdAdd.Click += new EventHandler(cmdAdd_Click);
            cmdEdit.Click += new EventHandler(cmdEdit_Click);
            cmdDetail.Click += new EventHandler(cmdDetail_Click);
            //建立功能按钮点击处理函数
            RegCommand(cmdAdd, cmdEdit, cmdDetail);

            //标题,字段,宽度,是否主键,是否显示
            this.InitialCaption();
            ////颜色控制列表
            //this.RegWhere(new object[] { 
            //                            new object[]{ "F_StateName","草稿",Color.Red},
            //            new object[]{ "F_StateName","关闭",Color.Gray},
            //            new object[]{ "F_StateName","发布",Color.Green}});

            ////分组
            //this.RegGroup(new object[] { "F_EventName" });
        }

        void cmdDetail_Click(object sender, EventArgs e)
        {
            //            throw new NotImplementedException();
        }
        void cmdPrint_Click(object sender, EventArgs e)
        {

            //displayReport("f292a161-04fd-416a-8275-d4e4b6f35ffb", "71e05c88-7210-4a99-91a8-8e6247fe8baa");
        }
        void cmdSetting_Click(object sender, EventArgs e)
        {

        }
        void cmdEdit_Click(object sender, EventArgs e)
        {

        }
        void cmdAdd_Click(object sender, EventArgs e)
        {
            FormCreateOrder FCO = new FormCreateOrder(iapplication, idataservice);
            IRight ir = (IRight)iapplication.GetService(typeof(IRight));
            FCO.RegStatickElement("F_CREATEUSER", System.Data.SqlDbType.Int, ir.UserId);
            // FCO.RegStatickElement("F_CREATENAME", System.Data.SqlDbType.VarChar, ir.UserName);
            // FCO.RegStatickElement("F_CREATEAGENCY", System.Data.SqlDbType.VarChar, ir.AgencyName);
            FCO.ShowForm(FormType.Insert);
        }
    }

    [PlugNameAttribute("采购处理"),
    PlugQueryFormAttribute("Order_Qurey"),
    PlugWriterAttribute(""),
    PlugQueryCmdAttribute("8b904afc-6b23-4bd7-ae33-3ce8a7f93cdf"),
    PlugActionAttribute("商品类别"),
    PlugDescriptionAttribute("商品类别 ")]
    public partial class CKPlugOrderDeal : PluginNode
    {
        public CKPlugOrderDeal()
        {
        }
        public override void Initialization()
        {
            //NodeBitmap = Resource.driver;
            //注册功能按钮
            Command cmdAdd = new Command("到货验收", iapplication, CommandTriger.OFF, (int)ImageType.ADD);
            Command cmdEdit = new Command("采购付款", iapplication, CommandTriger.ON, (int)ImageType.EDIT);
            Command cmdDetail = new Command("采购入库", iapplication, CommandTriger.ON, (int)ImageType.PRINT01);
            // Command cmdPrint = new Command("人员查看", iapplication, CommandTriger.ON, (int)ImageType.PRINT02);
            cmdAdd.Click += new EventHandler(cmdAdd_Click);
            cmdEdit.Click += new EventHandler(cmdEdit_Click);
            cmdDetail.Click += new EventHandler(cmdDetail_Click);
            //建立功能按钮点击处理函数
            RegCommand(cmdAdd, cmdEdit, cmdDetail);

            //标题,字段,宽度,是否主键,是否显示
            this.InitialCaption();
            ////颜色控制列表
            //this.RegWhere(new object[] { 
            //                            new object[]{ "F_StateName","草稿",Color.Red},
            //            new object[]{ "F_StateName","关闭",Color.Gray},
            //            new object[]{ "F_StateName","发布",Color.Green}});

            ////分组
            //this.RegGroup(new object[] { "F_EventName" });
        }

        void cmdDetail_Click(object sender, EventArgs e)
        {
            //            throw new NotImplementedException();
        }
        void cmdPrint_Click(object sender, EventArgs e)
        {

            //displayReport("f292a161-04fd-416a-8275-d4e4b6f35ffb", "71e05c88-7210-4a99-91a8-8e6247fe8baa");
        }
        void cmdSetting_Click(object sender, EventArgs e)
        {

        }
        void cmdEdit_Click(object sender, EventArgs e)
        {

        }
        void cmdAdd_Click(object sender, EventArgs e)
        {
            FormCreateOrder FCO = new FormCreateOrder(iapplication, idataservice);
            IRight ir = (IRight)iapplication.GetService(typeof(IRight));
            FCO.RegStatickElement("F_CREATEUSER", System.Data.SqlDbType.Int, ir.UserId);
            // FCO.RegStatickElement("F_CREATENAME", System.Data.SqlDbType.VarChar, ir.UserName);
            // FCO.RegStatickElement("F_CREATEAGENCY", System.Data.SqlDbType.VarChar, ir.AgencyName);
            FCO.ShowForm(FormType.Insert);
        }
    }
}
