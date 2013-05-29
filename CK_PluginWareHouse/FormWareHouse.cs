using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rock.Container;
using Rock.Interface;

namespace CK_PluginWareHouse
{
    public partial class FormWareHouse : FormBase
    {
        public FormWareHouse(IApplication iapp, IDataService _ids)
        {
            InitializeComponent();
            _iapplication = iapp;
            ids = _ids;
        }
        public override void AfterShowForm()
        {
            myEditTreeView1.MyItemCheck += new EventHandler(myEditTreeView1_MyItemCheck);
            base.AfterShowForm();
        }

        void myEditTreeView1_MyItemCheck(object sender, EventArgs e)
        {
            lblType.Text = (string)sender;
            myEditTextBox5.FieldValue = lblType.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Commit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
