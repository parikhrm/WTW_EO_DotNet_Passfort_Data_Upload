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
    public partial class Upload_Audit_Data : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public Upload_Audit_Data()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.excelfilepath.Text = openFileDialog1.FileName;
            }
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
                        

                        //string pathconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelfilepath.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
                        //OleDbConnection conne = new OleDbConnection(pathconn);
                        //OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + excelsheetname.Text + "$]", conne);
                        //DataTable dt = new DataTable();
                        //da.Fill(dt);
                        //dataGridView1.DataSource = dt;

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


                        string pathconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                                        excelfilepath.Text +
                                        ";Extended Properties=\"Excel 8.0;HDR=Yes;';";

                        OleDbConnection conne = new OleDbConnection(pathconn);
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + excelsheetname.Text + "$]", conne);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        //foreach (DataGridViewRow row in dataGridView1.Rows)
                        //{
                        //    cmd.CommandType = CommandType.Text;
                        //    cmd.CommandText = "insert into dbo.tbl_passfort_data_upload_daily_dotnet([Application date],[Application week],[Application first decision date],[Application first decision week],[Profile creation date],[Profile ID],[Application ID],[Display name],[First name(s)],Surname,[Date of birth],Gender,[Ultimate parent profile ID],[Ultimate parent display name],Tags,[Date of incorporation],[Customer reference],[Email address],[Phone number],Website,[Company number],[Application status (current)],[Application status (at first decision)],[Application flag (current)],Product,[Profile type],[Assignee type],[Assignee user],[Assignee ID],[Country of incorporation],[Country of current address],[Country of nationality],[Risk level (current)],[Risk level (at first decision)],[Risk score (current)],[Associate role],[Application decided with STP],[Screening events: PEP count (ignored)],[Screening events: PEP count (confirmed)],[Screening events: PEP count (potential)],[Screening events: Sanction count (ignored)],[Screening events: Sanction count (confirmed)],[Screening events: Sanction count (potential)],[Screening events: Adverse media count (ignored)],[Screening events: Adverse media count (confirmed)],[Screening events: Adverse media count (potential)],[Screening events: Referral count (ignored)],[Screening events: Referral count (confirmed)],[Screening events: Referral count (potential)],[National identity number],[Individual address (current)],[Company registered address],[Company branch address],[Company head office address],[Company contact address],[Company trading address],[Associate shareholdings],[Entity type],Shares,Liability,[Legal Entity Identifier (LEI)],[Application comment (at first decision)],[Application comment (current)],[Last decision made: User type],[Last decision made: User name],[Last decision made: User auditee ID],[ID type: Passport],[ID type: Passport card],[ID type: Driving licence],[ID type: State],[ID type: Voter],[ID type: Biometric state],[ID type: Healthcare],[ID type: Tax],[ID type: Residence],[ID type: Residence other],[ID type: Visa],[BvD ID],[Screening events: Watchlist count (ignored)],[Screening events: Watchlist count (confirmed)],[Screening events: Watchlist count (potential)],[Screening events: Internal Watchlist count (ignored)],[Screening events: Internal Watchlist count (confirmed)],[Screening events: Internal Watchlist count (potential)],[Is Sanction Only Check?]) values('" + row.Cells["txt_Application_date"].Value + "','" + row.Cells["txt_Application_week"].Value + "','" + row.Cells["txt_Application_first_decision_date"].Value + "','" + row.Cells["txt_Application_first_decision_week"].Value + "','" + row.Cells["txt_Profile_creation_date"].Value + "','" + row.Cells["txt_Profile_ID"].Value + "','" + row.Cells["txt_Application_ID"].Value + "','" + row.Cells["txt_Display_name"].Value + "','" + row.Cells["txt_First_name"].Value + "','" + row.Cells["txt_Surname"].Value + "','" + row.Cells["txt_Date_of_birth"].Value + "','" + row.Cells["txt_Gender"].Value + "','" + row.Cells["txt_Ultimate_parent_profile_ID"].Value + "','" + row.Cells["txt_Ultimate_parent_display_name"].Value + "','" + row.Cells["txt_Tags"].Value + "','" + row.Cells["txt_Date_of_incorporation"].Value + "','" + row.Cells["txt_Customer_reference"].Value + "','" + row.Cells["txt_Email_address"].Value + "','" + row.Cells["txt_Phone_number"].Value + "','" + row.Cells["txt_Website"].Value + "','" + row.Cells["txt_Company_number"].Value + "','" + row.Cells["txt_Application_status_current"].Value + "','" + row.Cells["txt_Application_status_at_first_decision"].Value + "','" + row.Cells["txt_Application_flag_current"].Value + "','" + row.Cells["txt_Product"].Value + "','" + row.Cells["txt_Profile_type"].Value + "','" + row.Cells["txt_Assignee_type"].Value + "','" + row.Cells["txt_Assignee_user"].Value + "','" + row.Cells["txt_Assignee_ID"].Value + "','" + row.Cells["txt_Country_of_incorporation"].Value + "','" + row.Cells["txt_Country_of_current_address"].Value + "','" + row.Cells["txt_Country_of_nationality"].Value + "','" + row.Cells["txt_Risk_level_current"].Value + "','" + row.Cells["txt_Risk_level_at_first_decision"].Value + "','" + row.Cells["txt_Risk_score_current"].Value + "','" + row.Cells["txt_Associate_role"].Value + "','" + row.Cells["txt_Application_decided_with_STP"].Value + "','" + row.Cells["txt_Screening_events_PEP_count_ignored"].Value + "','" + row.Cells["txt_Screening_events_PEP_count_confirmed"].Value + "','" + row.Cells["txt_Screening_events_PEP_count_potential"].Value + "','" + row.Cells["txt_Screening_events_Sanction_count_ignored"].Value + "','" + row.Cells["txt_Screening_events_Sanction_count_confirmed"].Value + "','" + row.Cells["txt_Screening_events_Sanction_count_potential"].Value + "','" + row.Cells["txt_Screening_events_Adverse_media_count_ignored"].Value + "','" + row.Cells["txt_Screening_events_Adverse_media_count_confirmed"].Value + "','" + row.Cells["txt_Screening_events_Adverse_media_count_potential"].Value + "','" + row.Cells["txt_Screening_events_Referral_count_ignored"].Value + "','" + row.Cells["txt_Screening_events_Referral_count_confirmed"].Value + "','" + row.Cells["txt_Screening_events_Referral_count_potential"].Value + "','" + row.Cells["txt_National_identity_number"].Value + "','" + row.Cells["txt_Individual_address_current"].Value + "','" + row.Cells["txt_Company_registered_address"].Value + "','" + row.Cells["txt_Company_branch_address"].Value + "','" + row.Cells["txt_Company_head_office_address"].Value + "','" + row.Cells["txt_Company_contact_address"].Value + "','" + row.Cells["txt_Company_trading_address"].Value + "','" + row.Cells["txt_Associate_shareholdings"].Value + "','" + row.Cells["txt_Entity_type"].Value + "','" + row.Cells["txt_Shares"].Value + "','" + row.Cells["txt_Liability"].Value + "','" + row.Cells["txt_Legal_Entity_Identifier_LEI"].Value + "','" + row.Cells["txt_Application_comment_at_first_decision"].Value + "','" + row.Cells["txt_Application_comment_current"].Value + "','" + row.Cells["txt_Last_decision_made_User_type"].Value + "','" + row.Cells["txt_Last_decision_made_User_name"].Value + "','" + row.Cells["txt_Last_decision_made_User_auditee_ID"].Value + "','" + row.Cells["txt_ID_type_Passport"].Value + "','" + row.Cells["txt_ID_type_Passport_card"].Value + "','" + row.Cells["txt_ID_type_Driving_licence"].Value + "','" + row.Cells["txt_ID_type_State"].Value + "','" + row.Cells["txt_ID_type_Voter"].Value + "','" + row.Cells["txt_ID_type_Biometric_state"].Value + "','" + row.Cells["txt_ID_type_Healthcare"].Value + "','" + row.Cells["txt_ID_type_Tax"].Value + "','" + row.Cells["txt_ID_type_Residence"].Value + "','" + row.Cells["txt_ID_type_Residence_other"].Value + "','" + row.Cells["txt_ID_type_Visa"].Value + "','" + row.Cells["txt_BvD_ID"].Value + "','" + row.Cells["txt_Screening_events_Watchlist_count_ignored"].Value + "','" + row.Cells["txt_Screening_events_Watchlist_count_confirmed"].Value + "','" + row.Cells["txt_Screening_events_Watchlist_count_potential"].Value + "','" + row.Cells["txt_Screening_events_Internal_Watchlist_count_ignored"].Value + "','" + row.Cells["txt_Screening_events_Internal_Watchlist_count_confirmed"].Value + "','" + row.Cells["txt_Screening_events_Internal_Watchlist_count_potential"].Value + "','" + row.Cells["txt_Is_Sanction_Only_Check"].Value + "')";
                        //    cmd.ExecuteNonQuery();
                        //}

                        //string pathconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelfilepath.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
                        //OleDbConnection conne = new OleDbConnection(pathconn);
                        //OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + excelsheetname.Text + "$]", conne);
                        //DataTable dt = new DataTable();
                        //da.Fill(dt);

                        using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(conn))
                        {
                            sqlbulkcopy.BulkCopyTimeout = 1000;
                            sqlbulkcopy.DestinationTableName = "dbo.tbl_passfort_data_upload_daily_dotnet_audit";
                            sqlbulkcopy.ColumnMappings.Add("Firm", "Firm");
                            sqlbulkcopy.ColumnMappings.Add("Firm_Name", "Firm_Name");
                            sqlbulkcopy.ColumnMappings.Add("Submitted", "Submitted");
                            sqlbulkcopy.ColumnMappings.Add("Batch", "Batch");
                            sqlbulkcopy.ColumnMappings.Add("Inquiry_PM", "Inquiry_PM");
                            sqlbulkcopy.ColumnMappings.Add("InquiryID", "InquiryID");
                            sqlbulkcopy.ColumnMappings.Add("Type_P_O", "Type_P_O");
                            sqlbulkcopy.ColumnMappings.Add("Inquiry_Name", "Inquiry_Name");
                            sqlbulkcopy.ColumnMappings.Add("EntityID", "EntityID");
                            sqlbulkcopy.ColumnMappings.Add("Match_Name", "Match_Name");
                            sqlbulkcopy.ColumnMappings.Add("Match_Status", "Match_Status");
                            sqlbulkcopy.ColumnMappings.Add("Match_Score", "Match_Score");
                            sqlbulkcopy.ColumnMappings.Add("TrackingID", "TrackingID");
                            sqlbulkcopy.ColumnMappings.Add("ReportingID", "ReportingID");
                            sqlbulkcopy.ColumnMappings.Add("Address", "Address");
                            sqlbulkcopy.ColumnMappings.Add("City", "City");
                            sqlbulkcopy.ColumnMappings.Add("State", "State");
                            sqlbulkcopy.ColumnMappings.Add("Country", "Country");
                            sqlbulkcopy.ColumnMappings.Add("Postal_Code", "Postal_Code");
                            sqlbulkcopy.ColumnMappings.Add("Age", "Age");
                            sqlbulkcopy.ColumnMappings.Add("DOB", "DOB");
                            sqlbulkcopy.ColumnMappings.Add("Global_Search", "Global_Search");
                            sqlbulkcopy.ColumnMappings.Add("Risk_Priority", "Risk_Priority");
                            sqlbulkcopy.ColumnMappings.Add("Event_Codes", "Event_Codes");
                            sqlbulkcopy.ColumnMappings.Add("Most_Recent_Event_Date", "Most_Recent_Event_Date");
                            sqlbulkcopy.ColumnMappings.Add("PEP_Type_Level", "PEP_Type_Level");
                            sqlbulkcopy.ColumnMappings.Add("PEP_Rating", "PEP_Rating");
                            sqlbulkcopy.ColumnMappings.Add("Entity_Address", "Entity_Address");
                            sqlbulkcopy.ColumnMappings.Add("Entity_Date_Of_Birth", "Entity_Date_Of_Birth");
                            sqlbulkcopy.ColumnMappings.Add("AI_Alert_Confidence", "AI_Alert_Confidence");
                            sqlbulkcopy.ColumnMappings.Add("Inquiry_Notes", "Inquiry_Notes");
                            
                            conn.Open();
                            sqlbulkcopy.WriteToServer(dt);
                            conn.Close();
                        }

                        //conn.Open();
                        //cmd.Parameters.Clear();
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.CommandTimeout = 1000;
                        //cmd.CommandText = "dbo.usp_passfort_data_upload_daily_dotnet";
                        //cmd.Parameters.AddWithValue("@UploadedBy", Environment.UserName.ToString());
                        //cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 2000);
                        //cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                        //cmd.ExecuteNonQuery();
                        //conn.Close();
                        //string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                        //MessageBox.Show("" + uploadmessage.ToString());
                        //reset_overall();
                        //cmd.Parameters.Clear();
                        //conn.Close();
                    }

                    catch (Exception ab)
                    {
                        MessageBox.Show("Rows uploaded unsuccessfully into final table");
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        MessageBox.Show("Error Generated Details :" + ab.ToString());
                        //datagridview_display_overall();
                    }
                }
                else
                {
                    excelfilepath.Focus();
                }
            }
        }
    }
}
