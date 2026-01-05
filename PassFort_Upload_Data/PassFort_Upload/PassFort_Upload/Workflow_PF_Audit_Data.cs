using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
namespace PassFort_Upload
{
    public partial class Workflow_PF_Audit_Data : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public Workflow_PF_Audit_Data()
        {
            InitializeComponent();
        }

        private void Workflow_PF_Audit_Data_Load(object sender, EventArgs e)
        {
            match_criteria_list();
            empname_list();
            reset_overall();
        }

        public void reset_overall()
        {
            current_datetime.Visible = false;
            current_datetime.Text = DateTime.Now.ToLongDateString();
            id.Enabled = false;
            id.Text = string.Empty;
            match_criteria.SelectedIndex = -1;
            orgid.Text = string.Empty;
            requestor_email_address.Text = string.Empty;
            sanction_raised_date.CustomFormat = " ";
            sanction_resolved_date.CustomFormat = " ";
            completion_date.CustomFormat = " ";
            checkBox1.Checked = false;
            allocation_associate_name.SelectedIndex = -1;
            allocation_from.Value = 0;
            allocation_to.Value = 0;
            allocation_entityid.Text = string.Empty;
            datagridview_display_overall();
        }

        private void sanction_raised_date_ValueChanged(object sender, EventArgs e)
        {
            sanction_raised_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void sanction_raised_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                sanction_raised_date.CustomFormat = " ";
            }
        }

        private void sanction_resolved_date_ValueChanged(object sender, EventArgs e)
        {
            sanction_resolved_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void sanction_resolved_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                sanction_resolved_date.CustomFormat = " ";
            }
        }

        private void completion_date_ValueChanged(object sender, EventArgs e)
        {
            completion_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void completion_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                completion_date.CustomFormat = " ";
            }
        }

        public void match_criteria_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                DropDown_References obj_match_criteria = new DropDown_References();
                DataTable dtaa = new DataTable();
                obj_match_criteria.match_criteria_list (dtaa);
                match_criteria.DataSource = dtaa;
                match_criteria.DisplayMember = "Match_Criteria";
                conn.Close();
                match_criteria.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void empname_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                DropDown_References obj_empname = new DropDown_References();

                DataTable dtaa = new DataTable();
                DataTable dtaa1 = new DataTable();

                obj_empname.emp_details_list_overall (dtaa);
                obj_empname.emp_details_list_overall(dtaa1);

                allocation_associate_name.DataSource = dtaa;
                searchby_associate_name.DataSource = dtaa1;

                allocation_associate_name.DisplayMember = "EmpName";
                searchby_associate_name.DisplayMember = "EmpName";

                conn.Close();
                allocation_associate_name.SelectedIndex = -1;
                searchby_associate_name.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }
        public void datagridview_display_overall()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();

                if (string.IsNullOrEmpty(searchby_inquiry_name.Text) && string.IsNullOrEmpty(searchby_match_name.Text) && string.IsNullOrEmpty(search_entityid.Text) && string.IsNullOrEmpty(searchby_associate_name.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select top 100 Firm,Firm_Name,Submitted,BatchID,Inquiry_PM,InquiryID,Type_P_O,Inquiry_Name,EntityID,Match_Name,Match_Status,Match_Score,TrackingID,ReportingID,Address,City,State,Country,Postal_Code,Age,DOB,Global_Search,Risk_Priority,Event_Codes,Most_Recent_Event_Date,PEP_Type_Level,PEP_Rating,Entity_Addresses,Entity_Date_of_Birth,AI_Alert_Confidence,Inquiry_Notes,Match_Criteria,ID,LastUpdatedBy,LastUpdatedDateTime,Completion_Date,Sanction_Raised_Date,Sanction_Resolved_Date,Business_Confirmed_Client_Inactive,OrgID,Requestor_Email_Address,AssociateName,AllocatedBy,Allocation_Date from dbo.tbl_passfort_data_upload_daily_dotnet_audit_archive with(nolock) where (Event_Codes like '%WLT%' or Inquiry_Notes like '%SNX%' or Inquiry_Notes like '%SAN%') order by ID,BatchID, EntityID";
                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_passfort_data_audit_datagridview_search_dotnet";
                    if (string.IsNullOrEmpty(search_entityid.Text))
                    {
                        cmd.Parameters.AddWithValue("@entityid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@entityid", search_entityid.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_inquiry_name.Text))
                    {
                        cmd.Parameters.AddWithValue("@inquiry_name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@inquiry_name", searchby_inquiry_name.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_match_name.Text))
                    {
                        cmd.Parameters.AddWithValue("@match_name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@match_name", searchby_match_name.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_associate_name.Text))
                    {
                        cmd.Parameters.AddWithValue("@associate_name",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@associate_name", searchby_associate_name.Text);
                    }
                }
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }

        }

        private void searchby_inquiry_name_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void search_entityid_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void searchby_match_name_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.usp_passfort_data_audit_update_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@ID", id.Text);
                if (string.IsNullOrEmpty(match_criteria.Text))
                {
                    cmd.Parameters.AddWithValue("@Match_Criteria", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Match_Criteria", match_criteria.Text);
                }
                if (string.IsNullOrEmpty(orgid.Text))
                {
                    cmd.Parameters.AddWithValue("@OrgID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@OrgID", orgid.Text);
                }
                if (string.IsNullOrEmpty(requestor_email_address.Text))
                {
                    cmd.Parameters.AddWithValue("@Requestor_Email_Address", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Requestor_Email_Address", requestor_email_address.Text);
                }
                if (sanction_raised_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Sanction_Raised_Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Sanction_Raised_Date", sanction_raised_date.Value.Date);
                }
                if (sanction_resolved_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Sanction_Resolved_Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Sanction_Resolved_Date", sanction_resolved_date.Text);
                }
                if (completion_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Completion_Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Completion_Date", completion_date.Value.Date);
                }
                if(checkBox1.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Business_Confirmed_Client_InActive", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Business_Confirmed_Client_InActive", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@LastUpdatedBy",Environment.UserName.ToString());

                //if conditions
                if (match_criteria.Text == "Exact" && string.IsNullOrEmpty(orgid.Text))
                {
                    MessageBox.Show("Please update OrgID");
                }
                else if (match_criteria.Text == "Potential" && string.IsNullOrEmpty(orgid.Text))
                {
                    MessageBox.Show("Please update OrgID");
                }
                if (match_criteria.Text == "Exact" && string.IsNullOrEmpty(requestor_email_address.Text))
                {
                    MessageBox.Show("Please update Requestor Email Address");
                }
                else if (match_criteria.Text == "Potential" && string.IsNullOrEmpty(requestor_email_address.Text))
                {
                    MessageBox.Show("Please update Requestor Email Address");
                }
                else if(sanction_raised_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Sanction Raised Date cannot be more than Today's date");
                }
                else if (sanction_resolved_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Sanction Resolved Date cannot be more than Today's date");
                }
                else if (completion_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Completion Date cannot be more than Today's date");
                }
                else
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                    MessageBox.Show("" + uploadmessage.ToString());
                    cmd.Parameters.Clear();
                    reset_overall();
                    conn.Close();
                }
                
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string messsage = "Do you want to update the record?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    id.Text = row.Cells["txt_ID"].Value.ToString();
                    if(string.IsNullOrEmpty(row.Cells["txt_Match_Criteria"].Value.ToString()))
                    {
                        match_criteria.SelectedIndex = -1;
                    }
                    else
                    {
                        match_criteria.Text = row.Cells["txt_Match_Criteria"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_OrgID"].Value.ToString()))
                    {
                        orgid.Text = string.Empty;
                    }
                    else
                    {
                        orgid.Text = row.Cells["txt_OrgID"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Requestor_Email_Address"].Value.ToString()))
                    {
                        requestor_email_address.Text = string.Empty;
                    }
                    else
                    {
                        requestor_email_address.Text = row.Cells["Requestor_Email_Address"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Sanction_Raised_Date"].Value.ToString()))
                    {
                        sanction_raised_date.CustomFormat = " ";
                    }
                    else
                    {
                        sanction_raised_date.Text = row.Cells["txt_Sanction_Raised_Date"].Value.ToString();
                        sanction_raised_date.CustomFormat = "dd-MMMM-yyyy";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Sanction_Resolved_Date"].Value.ToString()))
                    {
                        sanction_resolved_date.CustomFormat = " ";
                    }
                    else
                    {
                        sanction_resolved_date.Text = row.Cells["txt_Sanction_Resolved_Date"].Value.ToString();
                        sanction_resolved_date.CustomFormat = "dd-MMMM-yyyy";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Completion_Date"].Value.ToString()))
                    {
                        completion_date.CustomFormat = " ";
                    }
                    else
                    {
                        completion_date.Text = row.Cells["txt_Completion_Date"].Value.ToString();
                        completion_date.CustomFormat = "dd-MMMM-yyyy";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Business_Confirmed_Client_Inactive"].Value.ToString()))
                    {
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        checkBox1.Checked= true;
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_EntityID"].Value.ToString()))
                    {
                        entityid.Text = string.Empty;
                    }
                    else
                    {
                        entityid.Text = row.Cells["txt_EntityID"].Value.ToString();
                    }
                    

                }
            }
            else
            {

            }
        }

        private void main_page_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Main_Page obj1 = new Main_Page();
            obj1.Show();
        }

        private void bulk_update_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.usp_passfort_data_audit_update_completion_datedotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@EntityID", entityid.Text);
                cmd.Parameters.AddWithValue("@Completion_Date", completion_date.Value.Date);
                cmd.Parameters.AddWithValue("@LastUpdatedBy",Environment.UserName.ToString());

                //if conditions
                if(completion_date.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Completion Date");
                }
                else if(string.IsNullOrEmpty(orgid.Text))
                {
                    MessageBox.Show("Please update OrgID");
                }
                else if(completion_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Completion Date cannot be more than Today's date");
                }
                else
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                    MessageBox.Show("" + uploadmessage.ToString());
                    cmd.Parameters.Clear();
                    reset_overall();
                    conn.Close();
                }

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        private void rawdata_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://app.powerbi.com/groups/81c3ab7d-0a2a-46f2-b54f-38eb239011a1/reports/930a495d-9c0b-4039-a7b8-b0a12fe94dc8/8a3ef574d346ac4b6c16?experience=power-bi");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void allocation_update_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.usp_passfort_data_audit_allocation_datedotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                if (string.IsNullOrEmpty(entityid.Text))
                {
                    cmd.Parameters.AddWithValue("@EntityID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@EntityID", allocation_entityid.Text);
                }
                cmd.Parameters.AddWithValue("@AssociateName", allocation_associate_name.Text);
                cmd.Parameters.AddWithValue("@AllocatedBy",Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@From",Convert.ToInt32(allocation_from.Value));
                cmd.Parameters.AddWithValue("@To",Convert.ToInt32(allocation_to.Value));

                //if conditions
                if (string.IsNullOrEmpty(allocation_associate_name.Text))
                {
                    MessageBox.Show("Please select Associate Name");
                }
                else if (allocation_from.Value > allocation_to.Value)
                {
                    MessageBox.Show("Page number From value cannot be less the Page number to value");
                }
                else if(allocation_from.Value <= 0)
                {
                    MessageBox.Show("Page number from value cannot less than or equal to 0");
                }
                else if(allocation_to.Value <= 0)
                {
                    MessageBox.Show("Page number To value cannot be less than or equal to 0");
                }
                else
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                    MessageBox.Show("" + uploadmessage.ToString());
                    cmd.Parameters.Clear();
                    reset_overall();
                    conn.Close();
                }

            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        private void searchby_associate_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void searchby_associate_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                searchby_associate_name.SelectedIndex = -1;
            }
        }
    }
}
