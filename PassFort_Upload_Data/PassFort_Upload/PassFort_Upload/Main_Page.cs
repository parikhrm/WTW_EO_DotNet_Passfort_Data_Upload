using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassFort_Upload
{
    public partial class Main_Page : Form
    {
        public Main_Page()
        {
            InitializeComponent();
        }

        private void pf_data_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Upload_Data obj1 = new Upload_Data();
            obj1.Show();
        }

        private void pf_audit_data_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Upload_Audit_Data obj1 = new Upload_Audit_Data();
            obj1.Show();
        }

        private void pf_audit_data_workflow_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Workflow_PF_Audit_Data obj1 = new Workflow_PF_Audit_Data();
            obj1.Show();
        }
    }
}
