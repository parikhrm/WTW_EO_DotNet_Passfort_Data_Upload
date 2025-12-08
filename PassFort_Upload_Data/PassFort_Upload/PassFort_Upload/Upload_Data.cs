using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;

namespace PassFort_Upload
{
    public partial class Upload_Data : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        

        public Upload_Data()
        {
            InitializeComponent();
        }

        private void Upload_Data_Load(object sender, EventArgs e)
        {
            reset_overall();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.excelfilepath.Text = openFileDialog1.FileName;
            }
        }

        public void reset_overall()
        {
            datagridview_display_overall();
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
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select [Application date],[Application week],[Application first decision date],[Application first decision week],[Profile creation date],[Profile ID],[Application ID],[Display name],[First name(s)],Surname,[Date of birth],Gender,[Ultimate parent profile ID],[Ultimate parent display name],Tags,[Date of incorporation],[Customer reference],[Email address],[Phone number],Website,[Company number],[Application status (current)],[Application status (at first decision)],[Application flag (current)],Product,[Profile type],[Assignee type],[Assignee user],[Assignee ID],[Country of incorporation],[Country of current address],[Country of nationality],[Risk level (current)],[Risk level (at first decision)],[Risk score (current)],[Associate role],[Application decided with STP],[Screening events: PEP count (ignored)],[Screening events: PEP count (confirmed)],[Screening events: PEP count (potential)],[Screening events: Sanction count (ignored)],[Screening events: Sanction count (confirmed)],[Screening events: Sanction count (potential)],[Screening events: Adverse media count (ignored)],[Screening events: Adverse media count (confirmed)],[Screening events: Adverse media count (potential)],[Screening events: Referral count (ignored)],[Screening events: Referral count (confirmed)],[Screening events: Referral count (potential)],[National identity number],[Individual address (current)],[Company registered address],[Company branch address],[Company head office address],[Company contact address],[Company trading address],[Associate shareholdings],[Entity type],Shares,Liability,[Legal Entity Identifier (LEI)],[Application comment (at first decision)],[Application comment (current)],[Last decision made: User type],[Last decision made: User name],[Last decision made: User auditee ID],[ID type: Passport],[ID type: Passport card],[ID type: Driving licence],[ID type: State],[ID type: Voter],[ID type: Biometric state],[ID type: Healthcare],[ID type: Tax],[ID type: Residence],[ID type: Residence other],[ID type: Visa],[BvD ID],[Screening events: Watchlist count (ignored)],[Screening events: Watchlist count (confirmed)],[Screening events: Watchlist count (potential)],[Screening events: Internal Watchlist count (ignored)],[Screening events: Internal Watchlist count (confirmed)],[Screening events: Internal Watchlist count (potential)],[Is Sanction Only Check?] from dbo.tbl_passfort_data_upload_daily_dotnet with(nolock)";
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

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(excelsheetname.Text))
            {
                MessageBox.Show("Please enter excel sheet name");
            }
            else
            {
                string messsage = "Do you want to upload these records?";
                string title = "Message Box";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(messsage, title, buttons);
                if (result == DialogResult.Yes)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    try
                    {
                        upload_final.Enabled = true;
                        //for uploading .xlsx file
                        /*
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        excelfilepath.Text +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + excelsheetname.Text + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;
                        */

                        string pathconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelfilepath.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
                        OleDbConnection conne = new OleDbConnection(pathconn);
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + excelsheetname.Text + "$]", conne);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        
                    }
                    catch (Exception ab)
                    {
                        MessageBox.Show("Rows Uploaded Unsuccessfully");
                        MessageBox.Show("Error Generated Details :" + ab.ToString());
                    }
                }
                else
                {
                    excelfilepath.Focus();
                }
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {

        }

        private void upload_final_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                string messsage = "Do you want to upload these records in the final table?";
                string title = "Message Box";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(messsage, title, buttons);
                if (result == DialogResult.Yes)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    try
                    {
                        conn.ConnectionString = connectionstringtxt;
                        cmd.Connection = conn;
                        //conn.Open();
                        //new code
                        //string pathconn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        //                excelfilepath.Text +
                        //                ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        //string pathconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                        //                excelfilepath.Text +
                        //                ";Extended Properties=\"Excel 8.0;HDR=Yes;';";

                        //OleDbConnection conne = new OleDbConnection(pathconn);
                        //OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + excelsheetname.Text + "$]", conne);
                        //DataTable dt = new DataTable();
                        //da.Fill(dt);

                        //foreach (DataGridViewRow row in dataGridView1.Rows)
                        //{
                        //    cmd.CommandType = CommandType.Text;
                        //    cmd.CommandText = "insert into dbo.tbl_passfort_data_upload_daily_dotnet([Application date],[Application week],[Application first decision date],[Application first decision week],[Profile creation date],[Profile ID],[Application ID],[Display name],[First name(s)],Surname,[Date of birth],Gender,[Ultimate parent profile ID],[Ultimate parent display name],Tags,[Date of incorporation],[Customer reference],[Email address],[Phone number],Website,[Company number],[Application status (current)],[Application status (at first decision)],[Application flag (current)],Product,[Profile type],[Assignee type],[Assignee user],[Assignee ID],[Country of incorporation],[Country of current address],[Country of nationality],[Risk level (current)],[Risk level (at first decision)],[Risk score (current)],[Associate role],[Application decided with STP],[Screening events: PEP count (ignored)],[Screening events: PEP count (confirmed)],[Screening events: PEP count (potential)],[Screening events: Sanction count (ignored)],[Screening events: Sanction count (confirmed)],[Screening events: Sanction count (potential)],[Screening events: Adverse media count (ignored)],[Screening events: Adverse media count (confirmed)],[Screening events: Adverse media count (potential)],[Screening events: Referral count (ignored)],[Screening events: Referral count (confirmed)],[Screening events: Referral count (potential)],[National identity number],[Individual address (current)],[Company registered address],[Company branch address],[Company head office address],[Company contact address],[Company trading address],[Associate shareholdings],[Entity type],Shares,Liability,[Legal Entity Identifier (LEI)],[Application comment (at first decision)],[Application comment (current)],[Last decision made: User type],[Last decision made: User name],[Last decision made: User auditee ID],[ID type: Passport],[ID type: Passport card],[ID type: Driving licence],[ID type: State],[ID type: Voter],[ID type: Biometric state],[ID type: Healthcare],[ID type: Tax],[ID type: Residence],[ID type: Residence other],[ID type: Visa],[BvD ID],[Screening events: Watchlist count (ignored)],[Screening events: Watchlist count (confirmed)],[Screening events: Watchlist count (potential)],[Screening events: Internal Watchlist count (ignored)],[Screening events: Internal Watchlist count (confirmed)],[Screening events: Internal Watchlist count (potential)],[Is Sanction Only Check?]) values('" + row.Cells["txt_Application_date"].Value + "','" + row.Cells["txt_Application_week"].Value + "','" + row.Cells["txt_Application_first_decision_date"].Value + "','" + row.Cells["txt_Application_first_decision_week"].Value + "','" + row.Cells["txt_Profile_creation_date"].Value + "','" + row.Cells["txt_Profile_ID"].Value + "','" + row.Cells["txt_Application_ID"].Value + "','" + row.Cells["txt_Display_name"].Value + "','" + row.Cells["txt_First_name"].Value + "','" + row.Cells["txt_Surname"].Value + "','" + row.Cells["txt_Date_of_birth"].Value + "','" + row.Cells["txt_Gender"].Value + "','" + row.Cells["txt_Ultimate_parent_profile_ID"].Value + "','" + row.Cells["txt_Ultimate_parent_display_name"].Value + "','" + row.Cells["txt_Tags"].Value + "','" + row.Cells["txt_Date_of_incorporation"].Value + "','" + row.Cells["txt_Customer_reference"].Value + "','" + row.Cells["txt_Email_address"].Value + "','" + row.Cells["txt_Phone_number"].Value + "','" + row.Cells["txt_Website"].Value + "','" + row.Cells["txt_Company_number"].Value + "','" + row.Cells["txt_Application_status_current"].Value + "','" + row.Cells["txt_Application_status_at_first_decision"].Value + "','" + row.Cells["txt_Application_flag_current"].Value + "','" + row.Cells["txt_Product"].Value + "','" + row.Cells["txt_Profile_type"].Value + "','" + row.Cells["txt_Assignee_type"].Value + "','" + row.Cells["txt_Assignee_user"].Value + "','" + row.Cells["txt_Assignee_ID"].Value + "','" + row.Cells["txt_Country_of_incorporation"].Value + "','" + row.Cells["txt_Country_of_current_address"].Value + "','" + row.Cells["txt_Country_of_nationality"].Value + "','" + row.Cells["txt_Risk_level_current"].Value + "','" + row.Cells["txt_Risk_level_at_first_decision"].Value + "','" + row.Cells["txt_Risk_score_current"].Value + "','" + row.Cells["txt_Associate_role"].Value + "','" + row.Cells["txt_Application_decided_with_STP"].Value + "','" + row.Cells["txt_Screening_events_PEP_count_ignored"].Value + "','" + row.Cells["txt_Screening_events_PEP_count_confirmed"].Value + "','" + row.Cells["txt_Screening_events_PEP_count_potential"].Value + "','" + row.Cells["txt_Screening_events_Sanction_count_ignored"].Value + "','" + row.Cells["txt_Screening_events_Sanction_count_confirmed"].Value + "','" + row.Cells["txt_Screening_events_Sanction_count_potential"].Value + "','" + row.Cells["txt_Screening_events_Adverse_media_count_ignored"].Value + "','" + row.Cells["txt_Screening_events_Adverse_media_count_confirmed"].Value + "','" + row.Cells["txt_Screening_events_Adverse_media_count_potential"].Value + "','" + row.Cells["txt_Screening_events_Referral_count_ignored"].Value + "','" + row.Cells["txt_Screening_events_Referral_count_confirmed"].Value + "','" + row.Cells["txt_Screening_events_Referral_count_potential"].Value + "','" + row.Cells["txt_National_identity_number"].Value + "','" + row.Cells["txt_Individual_address_current"].Value + "','" + row.Cells["txt_Company_registered_address"].Value + "','" + row.Cells["txt_Company_branch_address"].Value + "','" + row.Cells["txt_Company_head_office_address"].Value + "','" + row.Cells["txt_Company_contact_address"].Value + "','" + row.Cells["txt_Company_trading_address"].Value + "','" + row.Cells["txt_Associate_shareholdings"].Value + "','" + row.Cells["txt_Entity_type"].Value + "','" + row.Cells["txt_Shares"].Value + "','" + row.Cells["txt_Liability"].Value + "','" + row.Cells["txt_Legal_Entity_Identifier_LEI"].Value + "','" + row.Cells["txt_Application_comment_at_first_decision"].Value + "','" + row.Cells["txt_Application_comment_current"].Value + "','" + row.Cells["txt_Last_decision_made_User_type"].Value + "','" + row.Cells["txt_Last_decision_made_User_name"].Value + "','" + row.Cells["txt_Last_decision_made_User_auditee_ID"].Value + "','" + row.Cells["txt_ID_type_Passport"].Value + "','" + row.Cells["txt_ID_type_Passport_card"].Value + "','" + row.Cells["txt_ID_type_Driving_licence"].Value + "','" + row.Cells["txt_ID_type_State"].Value + "','" + row.Cells["txt_ID_type_Voter"].Value + "','" + row.Cells["txt_ID_type_Biometric_state"].Value + "','" + row.Cells["txt_ID_type_Healthcare"].Value + "','" + row.Cells["txt_ID_type_Tax"].Value + "','" + row.Cells["txt_ID_type_Residence"].Value + "','" + row.Cells["txt_ID_type_Residence_other"].Value + "','" + row.Cells["txt_ID_type_Visa"].Value + "','" + row.Cells["txt_BvD_ID"].Value + "','" + row.Cells["txt_Screening_events_Watchlist_count_ignored"].Value + "','" + row.Cells["txt_Screening_events_Watchlist_count_confirmed"].Value + "','" + row.Cells["txt_Screening_events_Watchlist_count_potential"].Value + "','" + row.Cells["txt_Screening_events_Internal_Watchlist_count_ignored"].Value + "','" + row.Cells["txt_Screening_events_Internal_Watchlist_count_confirmed"].Value + "','" + row.Cells["txt_Screening_events_Internal_Watchlist_count_potential"].Value + "','" + row.Cells["txt_Is_Sanction_Only_Check"].Value + "')";
                        //    cmd.ExecuteNonQuery();
                        //}

                        string pathconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelfilepath.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
                        OleDbConnection conne = new OleDbConnection(pathconn);
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + excelsheetname.Text + "$]", conne);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(conn))
                        {
                            sqlbulkcopy.BulkCopyTimeout = 1000;
                            sqlbulkcopy.DestinationTableName = "dbo.tbl_passfort_data_upload_daily_dotnet";
                            sqlbulkcopy.ColumnMappings.Add("Application date", "Application date");
                            sqlbulkcopy.ColumnMappings.Add("Application week", "Application week");
                            sqlbulkcopy.ColumnMappings.Add("Application first decision date", "Application first decision date");
                            sqlbulkcopy.ColumnMappings.Add("Application first decision week", "Application first decision week");
                            sqlbulkcopy.ColumnMappings.Add("Profile creation date", "Profile creation date");
                            sqlbulkcopy.ColumnMappings.Add("Profile ID", "Profile ID");
                            sqlbulkcopy.ColumnMappings.Add("Application ID", "Application ID");
                            sqlbulkcopy.ColumnMappings.Add("Display name", "Display name");
                            sqlbulkcopy.ColumnMappings.Add("First name(s)", "First name(s)");
                            sqlbulkcopy.ColumnMappings.Add("Surname", "Surname");
                            sqlbulkcopy.ColumnMappings.Add("Date of birth", "Date of birth");
                            sqlbulkcopy.ColumnMappings.Add("Gender", "Gender");
                            sqlbulkcopy.ColumnMappings.Add("Ultimate parent profile ID", "Ultimate parent profile ID");
                            sqlbulkcopy.ColumnMappings.Add("Ultimate parent display name", "Ultimate parent display name");
                            sqlbulkcopy.ColumnMappings.Add("Tags", "Tags");
                            sqlbulkcopy.ColumnMappings.Add("Date of incorporation", "Date of incorporation");
                            sqlbulkcopy.ColumnMappings.Add("Customer reference", "Customer reference");
                            sqlbulkcopy.ColumnMappings.Add("Email address", "Email address");
                            sqlbulkcopy.ColumnMappings.Add("Phone number", "Phone number");
                            sqlbulkcopy.ColumnMappings.Add("Website", "Website");
                            sqlbulkcopy.ColumnMappings.Add("Company number", "Company number");
                            sqlbulkcopy.ColumnMappings.Add("Application status (current)", "Application status (current)");
                            sqlbulkcopy.ColumnMappings.Add("Application status (at first decision)", "Application status (at first decision)");
                            sqlbulkcopy.ColumnMappings.Add("Application flag (current)", "Application flag (current)");
                            sqlbulkcopy.ColumnMappings.Add("Product", "Product");
                            sqlbulkcopy.ColumnMappings.Add("Profile type", "Profile type");
                            sqlbulkcopy.ColumnMappings.Add("Assignee type", "Assignee type");
                            sqlbulkcopy.ColumnMappings.Add("Assignee user", "Assignee user");
                            sqlbulkcopy.ColumnMappings.Add("Assignee ID", "Assignee ID");
                            sqlbulkcopy.ColumnMappings.Add("Country of incorporation", "Country of incorporation");
                            sqlbulkcopy.ColumnMappings.Add("Country of current address", "Country of current address");
                            sqlbulkcopy.ColumnMappings.Add("Country of nationality", "Country of nationality");
                            sqlbulkcopy.ColumnMappings.Add("Risk level (current)", "Risk level (current)");
                            sqlbulkcopy.ColumnMappings.Add("Risk level (at first decision)", "Risk level (at first decision)");
                            sqlbulkcopy.ColumnMappings.Add("Risk score (current)", "Risk score (current)");
                            sqlbulkcopy.ColumnMappings.Add("Associate role", "Associate role");
                            sqlbulkcopy.ColumnMappings.Add("Application decided with STP", "Application decided with STP");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: PEP count (ignored)", "Screening events: PEP count (ignored)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: PEP count (confirmed)", "Screening events: PEP count (confirmed)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: PEP count (potential)", "Screening events: PEP count (potential)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: Sanction count (ignored)", "Screening events: Sanction count (ignored)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: Sanction count (confirmed)", "Screening events: Sanction count (confirmed)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: Sanction count (potential)", "Screening events: Sanction count (potential)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: Adverse media count (ignored)", "Screening events: Adverse media count (ignored)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: Adverse media count (confirmed)", "Screening events: Adverse media count (confirmed)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: Adverse media count (potential)", "Screening events: Adverse media count (potential)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: Referral count (ignored)", "Screening events: Referral count (ignored)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: Referral count (confirmed)", "Screening events: Referral count (confirmed)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: Referral count (potential)", "Screening events: Referral count (potential)");
                            sqlbulkcopy.ColumnMappings.Add("National identity number", "National identity number");
                            sqlbulkcopy.ColumnMappings.Add("Individual address (current)", "Individual address (current)");
                            sqlbulkcopy.ColumnMappings.Add("Company registered address", "Company registered address");
                            sqlbulkcopy.ColumnMappings.Add("Company branch address", "Company branch address");
                            sqlbulkcopy.ColumnMappings.Add("Company head office address", "Company head office address");
                            sqlbulkcopy.ColumnMappings.Add("Company contact address", "Company contact address");
                            sqlbulkcopy.ColumnMappings.Add("Company trading address", "Company trading address");
                            sqlbulkcopy.ColumnMappings.Add("Associate shareholdings", "Associate shareholdings");
                            sqlbulkcopy.ColumnMappings.Add("Entity type", "Entity type");
                            sqlbulkcopy.ColumnMappings.Add("Shares", "Shares");
                            sqlbulkcopy.ColumnMappings.Add("Liability", "Liability");
                            sqlbulkcopy.ColumnMappings.Add("Legal Entity Identifier (LEI)", "Legal Entity Identifier (LEI)");
                            sqlbulkcopy.ColumnMappings.Add("Application comment (at first decision)", "Application comment (at first decision)");
                            sqlbulkcopy.ColumnMappings.Add("Application comment (current)", "Application comment (current)");
                            sqlbulkcopy.ColumnMappings.Add("Last decision made: User type", "Last decision made: User type");
                            sqlbulkcopy.ColumnMappings.Add("Last decision made: User name", "Last decision made: User name");
                            sqlbulkcopy.ColumnMappings.Add("Last decision made: User auditee ID", "Last decision made: User auditee ID");
                            sqlbulkcopy.ColumnMappings.Add("ID type: Passport", "ID type: Passport");
                            sqlbulkcopy.ColumnMappings.Add("ID type: Passport card", "ID type: Passport card");
                            sqlbulkcopy.ColumnMappings.Add("ID type: Driving licence", "ID type: Driving licence");
                            sqlbulkcopy.ColumnMappings.Add("ID type: State", "ID type: State");
                            sqlbulkcopy.ColumnMappings.Add("ID type: Voter", "ID type: Voter");
                            sqlbulkcopy.ColumnMappings.Add("ID type: Biometric state", "ID type: Biometric state");
                            sqlbulkcopy.ColumnMappings.Add("ID type: Healthcare", "ID type: Healthcare");
                            sqlbulkcopy.ColumnMappings.Add("ID type: Tax", "ID type: Tax");
                            sqlbulkcopy.ColumnMappings.Add("ID type: Residence", "ID type: Residence");
                            sqlbulkcopy.ColumnMappings.Add("ID type: Residence other", "ID type: Residence other");
                            sqlbulkcopy.ColumnMappings.Add("ID type: Visa", "ID type: Visa");
                            sqlbulkcopy.ColumnMappings.Add("BvD ID", "BvD ID");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: Watchlist count (ignored)", "Screening events: Watchlist count (ignored)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: Watchlist count (confirmed)", "Screening events: Watchlist count (confirmed)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: Watchlist count (potential)", "Screening events: Watchlist count (potential)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: Internal Watchlist count (ignored)", "Screening events: Internal Watchlist count (ignored)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: Internal Watchlist count (confirmed)", "Screening events: Internal Watchlist count (confirmed)");
                            sqlbulkcopy.ColumnMappings.Add("Screening events: Internal Watchlist count (potential)", "Screening events: Internal Watchlist count (potential)");
                            sqlbulkcopy.ColumnMappings.Add("Is Sanction Only Check?", "Is Sanction Only Check?");
                            sqlbulkcopy.ColumnMappings.Add("Is prospect", "Is prospect");
                            sqlbulkcopy.ColumnMappings.Add("Relationship manager", "Relationship manager");
                            conn.Open();
                            sqlbulkcopy.WriteToServer(dt);
                            conn.Close();
                        }

                        conn.Open();
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 1000;
                        cmd.CommandText = "dbo.usp_passfort_data_upload_daily_dotnet";
                        cmd.Parameters.AddWithValue("@UploadedBy", Environment.UserName.ToString());
                        cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 2000);
                        cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                        MessageBox.Show("" + uploadmessage.ToString());
                        reset_overall();
                        cmd.Parameters.Clear();
                        conn.Close();
                    }

                    catch (Exception ab)
                    {
                        MessageBox.Show("Rows uploaded unsuccessfully into final table");
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        MessageBox.Show("Error Generated Details :" + ab.ToString());
                        datagridview_display_overall();
                    }
                }
                else
                {
                    excelfilepath.Focus();
                }
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://wtwonlineap.sharepoint.com/:x:/r/sites/tctnonclient_edskycoms/_layouts/15/Doc.aspx?sourcedoc=%7B1503D5A6-2BF4-4B1C-B27F-615F18BE87C8%7D&file=Upload_Template.csv&action=default&mobileredirect=true");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }

        private void main_page_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Main_Page obj1 = new Main_Page();
            obj1.Show();
        }
    }
    
}
