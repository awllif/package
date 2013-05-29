﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rock.Container;
using Rock.Interface;

namespace CK_PluginOrder
{
    public partial class FormCreateOrder : FormBase
    {
        public FormCreateOrder(IApplication iapp ,IDataService _ids)
        {
            InitializeComponent();
            _iapplication = iapp;
            ids = _ids;
        }
        public override void AfterShowForm()
        {
            IRight ir = (IRight)iapplication.GetService(typeof(IRight));
            textBox1.Text = ir.UserName;
            textBox2.Text = ir.AgencyName;
            myEditTreeView1.MyItemCheck += new EventHandler(myEditTreeView1_MyItemCheck);
            base.AfterShowForm();
        }

        /// <summary>
        /// 1选取商品
        /// 2选取供应商(一个商品多个供应商)
        /// 3显示信息
        /// 3输入数量
        /// 4加到列表
        /// 5创建同意采购号
        /// 5提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void myEditTreeView1_MyItemCheck(object sender, EventArgs e)
        {
            String id = myEditTreeView1.FieldValue.ToString();//单品ID
            String sql = "select *,(SELECT F_NAME FROM CK_COMPANY WHERE F_ID=F_COMPANYID)as F_COMPANYNAME from [CK_PRODUCT] where F_PROTYPE=" + id;//用于查询这个商品的全部信息
            IAdapter iad = (IAdapter)iapplication.GetService(typeof(IAdapter));
            DataTable ntable = (DataTable)iad.RunCmdnoCheck("AFunction2", new object[]{sql});
            if (ntable.Rows.Count > 0)
            {
                MyDataView mdv = new MyDataView();
                mdv.SetKey("f_id");
                mdv.SelectedRows.Add("f_id", ntable.Rows[0]);
                mdv.iapplication = iapplication;
                FormProductInfo fpdi = new FormProductInfo(iapplication, mdv, listView1, ntable, myEditTextBox2);
                fpdi.ShowForm(FormType.Edit);
            }
            else
            {
                MessageBox.Show("商品信息不完整, 请到商品管理进行设置!");
            }
        }


        private void butOk_Click(object sender, EventArgs e)
        {

            IAdapter Iad = (IAdapter)iapplication.GetService(typeof(IAdapter));
            int amount = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
               
                Fields2Xml f2x = new Fields2Xml("CK_ORDERPRODUCT");//定义要修改的表名
                //f2x.addField("F_IP", SqlDbType.VarChar, dr["F_IP"].ToString(), true, false);//指定主键值,没指定主键将添加
                f2x.addField("F_PurchasNo", SqlDbType.VarChar, myEditTextBox1.FieldValue.ToString(), false, false);//定义要修改的字段和值
                f2x.addField("F_PRODUCTID", SqlDbType.Int, listView1.Items[i].SubItems[0].Text.ToString(), false, false);//定义要修改的字段和值
                f2x.addField("F_COUNT", SqlDbType.Int, listView1.Items[i].SubItems[3].Text.ToString(), false, false);//定义要修改的字段和值
                f2x.addField("F_UnitPrice", SqlDbType.Int, listView1.Items[i].SubItems[5].Text.ToString(), false, false);//定义要修改的字段和值
                f2x.addField("F_Unit", SqlDbType.VarChar, listView1.Items[i].SubItems[4].Text.ToString(), false, false);//定义要修改的字段和值
                f2x.addField("F_PRODUCT", SqlDbType.VarChar, listView1.Items[i].SubItems[2].Text.ToString(), false, false);//定义要修改的字段和值
                f2x.addField("F_CODE", SqlDbType.VarChar, listView1.Items[i].SubItems[1].Text.ToString(), false, false);//定义要修改的字段和值
                String retxml = (string)Iad.RunCmdnoCheck("AFunction1", new object[] { f2x.getDataXml(FormType.Insert) });//指定执行类型,执行
                amount =amount+ Int32.Parse(listView1.Items[i].SubItems[6].Text.ToString());

            }
            this.myEditTextBox2.FieldValue = amount;
            this.myEditTextBox4.FieldValue = 0;//流程状态,审批中
            this.Commit();
            this.listView1.Clear();
            this.textBox3.Text = "";
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void myEditComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            myEditTextBox3.FieldValue +=myEditComboBox2.FieldValue.ToString()+",";
            textBox3.Text += myEditComboBox2.ShowFieldValue.ToString() + "->";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myEditTextBox3.FieldValue = "";
            textBox3.Text = "";
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            listView1.Clear();
        }
        

    }
}
