using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PassFort_Upload
{
    public partial class Main_Page : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

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

        private void Main_Page_Load(object sender, EventArgs e)
        {
            accesslevel.Visible = false;
            check_access();
        }

        public void check_access()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                DropDown_References obj_empdetails = new DropDown_References();
                DataTable dtaa = new DataTable();
                obj_empdetails.emp_details_list(dtaa,Environment.UserName.ToString());
                accesslevel.DataSource = dtaa;
                accesslevel.DisplayMember = "PF_Data_Upload_Access";
                conn.Close();

                if(accesslevel.Text == "Admin")
                {
                    pf_data.Enabled = true;
                    pf_audit_data.Enabled = true;
                }
                else
                {
                    pf_data.Enabled = false;
                    pf_audit_data.Enabled = false;
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }
    }
}
