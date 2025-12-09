namespace PassFort_Upload
{
    partial class Upload_Audit_Data
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.excelsheetname = new System.Windows.Forms.TextBox();
            this.excelfilepath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.upload_final = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.main_page = new System.Windows.Forms.Button();
            this.txt_Firm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Firm_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Submitted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Batch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Inquiry_PM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_InquiryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Type_P_O = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Inquiry_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_EntityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Match_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Match_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Match_Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_TrackingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_ReportingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Postal_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Global_Search = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Risk_Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Event_Codes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Most_Recent_Event_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_PEP_Type_Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_PEP_Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Entity_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Entity_Date_Of_Birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_AI_Alert_Confidence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Inquiry_Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(267, 39);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 32);
            this.button4.TabIndex = 30;
            this.button4.Text = "Select File";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(929, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Excel Sheet Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(599, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Excel File Path";
            // 
            // excelsheetname
            // 
            this.excelsheetname.Location = new System.Drawing.Point(1102, 39);
            this.excelsheetname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.excelsheetname.Name = "excelsheetname";
            this.excelsheetname.Size = new System.Drawing.Size(224, 26);
            this.excelsheetname.TabIndex = 33;
            // 
            // excelfilepath
            // 
            this.excelfilepath.Location = new System.Drawing.Point(447, 39);
            this.excelfilepath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.excelfilepath.Name = "excelfilepath";
            this.excelfilepath.Size = new System.Drawing.Size(414, 26);
            this.excelfilepath.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.upload_final);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.reset);
            this.groupBox1.Location = new System.Drawing.Point(447, 91);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(648, 112);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // upload_final
            // 
            this.upload_final.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upload_final.Location = new System.Drawing.Point(222, 25);
            this.upload_final.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.upload_final.Name = "upload_final";
            this.upload_final.Size = new System.Drawing.Size(179, 58);
            this.upload_final.TabIndex = 134;
            this.upload_final.Text = "Upload Final";
            this.upload_final.UseVisualStyleBackColor = true;
            this.upload_final.Click += new System.EventHandler(this.upload_final_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(7, 25);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 58);
            this.button2.TabIndex = 0;
            this.button2.Text = "Load the records below";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.Location = new System.Drawing.Point(431, 25);
            this.reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(179, 58);
            this.reset.TabIndex = 2;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txt_Firm,
            this.txt_Firm_Name,
            this.txt_Submitted,
            this.txt_Batch,
            this.txt_Inquiry_PM,
            this.txt_InquiryID,
            this.txt_Type_P_O,
            this.txt_Inquiry_Name,
            this.txt_EntityID,
            this.txt_Match_Name,
            this.txt_Match_Status,
            this.txt_Match_Score,
            this.txt_TrackingID,
            this.txt_ReportingID,
            this.txt_Address,
            this.txt_City,
            this.txt_State,
            this.txt_Country,
            this.txt_Postal_Code,
            this.txt_Age,
            this.txt_DOB,
            this.txt_Global_Search,
            this.txt_Risk_Priority,
            this.txt_Event_Codes,
            this.txt_Most_Recent_Event_Date,
            this.txt_PEP_Type_Level,
            this.txt_PEP_Rating,
            this.txt_Entity_Address,
            this.txt_Entity_Date_Of_Birth,
            this.txt_AI_Alert_Confidence,
            this.txt_Inquiry_Notes});
            this.dataGridView1.Location = new System.Drawing.Point(33, 247);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1732, 707);
            this.dataGridView1.TabIndex = 136;
            // 
            // main_page
            // 
            this.main_page.Location = new System.Drawing.Point(26, 14);
            this.main_page.Name = "main_page";
            this.main_page.Size = new System.Drawing.Size(96, 45);
            this.main_page.TabIndex = 137;
            this.main_page.Text = "Main Page";
            this.main_page.UseVisualStyleBackColor = true;
            this.main_page.Click += new System.EventHandler(this.main_page_Click);
            // 
            // txt_Firm
            // 
            this.txt_Firm.DataPropertyName = "Firm #";
            this.txt_Firm.HeaderText = "Firm #";
            this.txt_Firm.MinimumWidth = 8;
            this.txt_Firm.Name = "txt_Firm";
            this.txt_Firm.ReadOnly = true;
            this.txt_Firm.Width = 150;
            // 
            // txt_Firm_Name
            // 
            this.txt_Firm_Name.DataPropertyName = "Firm Name";
            this.txt_Firm_Name.HeaderText = "Firm Name";
            this.txt_Firm_Name.MinimumWidth = 8;
            this.txt_Firm_Name.Name = "txt_Firm_Name";
            this.txt_Firm_Name.ReadOnly = true;
            this.txt_Firm_Name.Width = 150;
            // 
            // txt_Submitted
            // 
            this.txt_Submitted.DataPropertyName = "Submitted";
            this.txt_Submitted.HeaderText = "Submitted";
            this.txt_Submitted.MinimumWidth = 8;
            this.txt_Submitted.Name = "txt_Submitted";
            this.txt_Submitted.ReadOnly = true;
            this.txt_Submitted.Width = 150;
            // 
            // txt_Batch
            // 
            this.txt_Batch.DataPropertyName = "Batch #";
            this.txt_Batch.HeaderText = "Batch #";
            this.txt_Batch.MinimumWidth = 8;
            this.txt_Batch.Name = "txt_Batch";
            this.txt_Batch.ReadOnly = true;
            this.txt_Batch.Width = 150;
            // 
            // txt_Inquiry_PM
            // 
            this.txt_Inquiry_PM.DataPropertyName = "Inquiry/PM";
            this.txt_Inquiry_PM.HeaderText = "Inquiry/PM";
            this.txt_Inquiry_PM.MinimumWidth = 8;
            this.txt_Inquiry_PM.Name = "txt_Inquiry_PM";
            this.txt_Inquiry_PM.ReadOnly = true;
            this.txt_Inquiry_PM.Width = 150;
            // 
            // txt_InquiryID
            // 
            this.txt_InquiryID.DataPropertyName = "Inquiry ID";
            this.txt_InquiryID.HeaderText = "Inquiry ID";
            this.txt_InquiryID.MinimumWidth = 8;
            this.txt_InquiryID.Name = "txt_InquiryID";
            this.txt_InquiryID.ReadOnly = true;
            this.txt_InquiryID.Width = 150;
            // 
            // txt_Type_P_O
            // 
            this.txt_Type_P_O.DataPropertyName = "Type (P/O)";
            this.txt_Type_P_O.HeaderText = "Type (P/O)";
            this.txt_Type_P_O.MinimumWidth = 8;
            this.txt_Type_P_O.Name = "txt_Type_P_O";
            this.txt_Type_P_O.ReadOnly = true;
            this.txt_Type_P_O.Width = 150;
            // 
            // txt_Inquiry_Name
            // 
            this.txt_Inquiry_Name.DataPropertyName = "Inquiry Name";
            this.txt_Inquiry_Name.HeaderText = "Inquiry Name";
            this.txt_Inquiry_Name.MinimumWidth = 8;
            this.txt_Inquiry_Name.Name = "txt_Inquiry_Name";
            this.txt_Inquiry_Name.ReadOnly = true;
            this.txt_Inquiry_Name.Width = 150;
            // 
            // txt_EntityID
            // 
            this.txt_EntityID.DataPropertyName = "Entity ID";
            this.txt_EntityID.HeaderText = "Entity ID";
            this.txt_EntityID.MinimumWidth = 8;
            this.txt_EntityID.Name = "txt_EntityID";
            this.txt_EntityID.ReadOnly = true;
            this.txt_EntityID.Width = 150;
            // 
            // txt_Match_Name
            // 
            this.txt_Match_Name.DataPropertyName = "Match Name";
            this.txt_Match_Name.HeaderText = "Match Name";
            this.txt_Match_Name.MinimumWidth = 8;
            this.txt_Match_Name.Name = "txt_Match_Name";
            this.txt_Match_Name.ReadOnly = true;
            this.txt_Match_Name.Width = 150;
            // 
            // txt_Match_Status
            // 
            this.txt_Match_Status.DataPropertyName = "Match Status";
            this.txt_Match_Status.HeaderText = "Match_Status";
            this.txt_Match_Status.MinimumWidth = 8;
            this.txt_Match_Status.Name = "txt_Match_Status";
            this.txt_Match_Status.ReadOnly = true;
            this.txt_Match_Status.Width = 150;
            // 
            // txt_Match_Score
            // 
            this.txt_Match_Score.DataPropertyName = "Match Score";
            this.txt_Match_Score.HeaderText = "Match Score";
            this.txt_Match_Score.MinimumWidth = 8;
            this.txt_Match_Score.Name = "txt_Match_Score";
            this.txt_Match_Score.ReadOnly = true;
            this.txt_Match_Score.Width = 150;
            // 
            // txt_TrackingID
            // 
            this.txt_TrackingID.DataPropertyName = "Tracking ID";
            this.txt_TrackingID.HeaderText = "Tracking ID";
            this.txt_TrackingID.MinimumWidth = 8;
            this.txt_TrackingID.Name = "txt_TrackingID";
            this.txt_TrackingID.ReadOnly = true;
            this.txt_TrackingID.Width = 150;
            // 
            // txt_ReportingID
            // 
            this.txt_ReportingID.DataPropertyName = "Reporting ID";
            this.txt_ReportingID.HeaderText = "Reporting ID";
            this.txt_ReportingID.MinimumWidth = 8;
            this.txt_ReportingID.Name = "txt_ReportingID";
            this.txt_ReportingID.ReadOnly = true;
            this.txt_ReportingID.Width = 150;
            // 
            // txt_Address
            // 
            this.txt_Address.DataPropertyName = "Address";
            this.txt_Address.HeaderText = "Address";
            this.txt_Address.MinimumWidth = 8;
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.ReadOnly = true;
            this.txt_Address.Width = 150;
            // 
            // txt_City
            // 
            this.txt_City.DataPropertyName = "City";
            this.txt_City.HeaderText = "City";
            this.txt_City.MinimumWidth = 8;
            this.txt_City.Name = "txt_City";
            this.txt_City.ReadOnly = true;
            this.txt_City.Width = 150;
            // 
            // txt_State
            // 
            this.txt_State.DataPropertyName = "State";
            this.txt_State.HeaderText = "State";
            this.txt_State.MinimumWidth = 8;
            this.txt_State.Name = "txt_State";
            this.txt_State.ReadOnly = true;
            this.txt_State.Width = 150;
            // 
            // txt_Country
            // 
            this.txt_Country.DataPropertyName = "Country";
            this.txt_Country.HeaderText = "Country";
            this.txt_Country.MinimumWidth = 8;
            this.txt_Country.Name = "txt_Country";
            this.txt_Country.ReadOnly = true;
            this.txt_Country.Width = 150;
            // 
            // txt_Postal_Code
            // 
            this.txt_Postal_Code.DataPropertyName = "Postal Code";
            this.txt_Postal_Code.HeaderText = "Postal Code";
            this.txt_Postal_Code.MinimumWidth = 8;
            this.txt_Postal_Code.Name = "txt_Postal_Code";
            this.txt_Postal_Code.ReadOnly = true;
            this.txt_Postal_Code.Width = 150;
            // 
            // txt_Age
            // 
            this.txt_Age.DataPropertyName = "Age";
            this.txt_Age.HeaderText = "Age";
            this.txt_Age.MinimumWidth = 8;
            this.txt_Age.Name = "txt_Age";
            this.txt_Age.ReadOnly = true;
            this.txt_Age.Width = 150;
            // 
            // txt_DOB
            // 
            this.txt_DOB.DataPropertyName = "DOB";
            this.txt_DOB.HeaderText = "DOB";
            this.txt_DOB.MinimumWidth = 8;
            this.txt_DOB.Name = "txt_DOB";
            this.txt_DOB.ReadOnly = true;
            this.txt_DOB.Width = 150;
            // 
            // txt_Global_Search
            // 
            this.txt_Global_Search.DataPropertyName = "Global Search";
            this.txt_Global_Search.HeaderText = "Global Search";
            this.txt_Global_Search.MinimumWidth = 8;
            this.txt_Global_Search.Name = "txt_Global_Search";
            this.txt_Global_Search.ReadOnly = true;
            this.txt_Global_Search.Width = 150;
            // 
            // txt_Risk_Priority
            // 
            this.txt_Risk_Priority.DataPropertyName = "Risk Priority";
            this.txt_Risk_Priority.HeaderText = "Risk Priority";
            this.txt_Risk_Priority.MinimumWidth = 8;
            this.txt_Risk_Priority.Name = "txt_Risk_Priority";
            this.txt_Risk_Priority.ReadOnly = true;
            this.txt_Risk_Priority.Width = 150;
            // 
            // txt_Event_Codes
            // 
            this.txt_Event_Codes.DataPropertyName = "Event Code(s)";
            this.txt_Event_Codes.HeaderText = "Event Code(s)";
            this.txt_Event_Codes.MinimumWidth = 8;
            this.txt_Event_Codes.Name = "txt_Event_Codes";
            this.txt_Event_Codes.ReadOnly = true;
            this.txt_Event_Codes.Width = 150;
            // 
            // txt_Most_Recent_Event_Date
            // 
            this.txt_Most_Recent_Event_Date.DataPropertyName = "Most Recent Event Date";
            this.txt_Most_Recent_Event_Date.HeaderText = "Most Recent Event Date";
            this.txt_Most_Recent_Event_Date.MinimumWidth = 8;
            this.txt_Most_Recent_Event_Date.Name = "txt_Most_Recent_Event_Date";
            this.txt_Most_Recent_Event_Date.ReadOnly = true;
            this.txt_Most_Recent_Event_Date.Width = 150;
            // 
            // txt_PEP_Type_Level
            // 
            this.txt_PEP_Type_Level.DataPropertyName = "PEP Type: Lvl";
            this.txt_PEP_Type_Level.HeaderText = "PEP Type: Lvl";
            this.txt_PEP_Type_Level.MinimumWidth = 8;
            this.txt_PEP_Type_Level.Name = "txt_PEP_Type_Level";
            this.txt_PEP_Type_Level.ReadOnly = true;
            this.txt_PEP_Type_Level.Width = 150;
            // 
            // txt_PEP_Rating
            // 
            this.txt_PEP_Rating.DataPropertyName = "PEP Rating";
            this.txt_PEP_Rating.HeaderText = "PEP Rating";
            this.txt_PEP_Rating.MinimumWidth = 8;
            this.txt_PEP_Rating.Name = "txt_PEP_Rating";
            this.txt_PEP_Rating.ReadOnly = true;
            this.txt_PEP_Rating.Width = 150;
            // 
            // txt_Entity_Address
            // 
            this.txt_Entity_Address.DataPropertyName = "Entity Address(es)";
            this.txt_Entity_Address.HeaderText = "Entity Address(es)";
            this.txt_Entity_Address.MinimumWidth = 8;
            this.txt_Entity_Address.Name = "txt_Entity_Address";
            this.txt_Entity_Address.ReadOnly = true;
            this.txt_Entity_Address.Width = 150;
            // 
            // txt_Entity_Date_Of_Birth
            // 
            this.txt_Entity_Date_Of_Birth.DataPropertyName = "Entity Date(s) of Birth";
            this.txt_Entity_Date_Of_Birth.HeaderText = "Entity Date(s) of Birth";
            this.txt_Entity_Date_Of_Birth.MinimumWidth = 8;
            this.txt_Entity_Date_Of_Birth.Name = "txt_Entity_Date_Of_Birth";
            this.txt_Entity_Date_Of_Birth.ReadOnly = true;
            this.txt_Entity_Date_Of_Birth.Width = 150;
            // 
            // txt_AI_Alert_Confidence
            // 
            this.txt_AI_Alert_Confidence.DataPropertyName = "AI Alert Confidence";
            this.txt_AI_Alert_Confidence.HeaderText = "AI Alert Confidence";
            this.txt_AI_Alert_Confidence.MinimumWidth = 8;
            this.txt_AI_Alert_Confidence.Name = "txt_AI_Alert_Confidence";
            this.txt_AI_Alert_Confidence.ReadOnly = true;
            this.txt_AI_Alert_Confidence.Width = 150;
            // 
            // txt_Inquiry_Notes
            // 
            this.txt_Inquiry_Notes.DataPropertyName = "Inquiry Notes";
            this.txt_Inquiry_Notes.HeaderText = "Inquiry Notes";
            this.txt_Inquiry_Notes.MinimumWidth = 8;
            this.txt_Inquiry_Notes.Name = "txt_Inquiry_Notes";
            this.txt_Inquiry_Notes.ReadOnly = true;
            this.txt_Inquiry_Notes.Width = 150;
            // 
            // Upload_Audit_Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1837, 1050);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.main_page);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.excelsheetname);
            this.Controls.Add(this.excelfilepath);
            this.Name = "Upload_Audit_Data";
            this.Text = "Upload_Audit_Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Upload_Audit_Data_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox excelsheetname;
        private System.Windows.Forms.TextBox excelfilepath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button upload_final;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button main_page;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Firm;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Firm_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Submitted;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Batch;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Inquiry_PM;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_InquiryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Type_P_O;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Inquiry_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_EntityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Match_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Match_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Match_Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_TrackingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_ReportingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_City;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Postal_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_DOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Global_Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Risk_Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Event_Codes;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Most_Recent_Event_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_PEP_Type_Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_PEP_Rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Entity_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Entity_Date_Of_Birth;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_AI_Alert_Confidence;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Inquiry_Notes;
    }
}