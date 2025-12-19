namespace PassFort_Upload
{
    partial class Main_Page
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
            this.pf_data = new System.Windows.Forms.Button();
            this.pf_audit_data = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pf_data
            // 
            this.pf_data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pf_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pf_data.Location = new System.Drawing.Point(408, 95);
            this.pf_data.Name = "pf_data";
            this.pf_data.Size = new System.Drawing.Size(249, 139);
            this.pf_data.TabIndex = 0;
            this.pf_data.Text = "Upload PF Data";
            this.pf_data.UseVisualStyleBackColor = false;
            this.pf_data.Click += new System.EventHandler(this.pf_data_Click);
            // 
            // pf_audit_data
            // 
            this.pf_audit_data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pf_audit_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pf_audit_data.Location = new System.Drawing.Point(799, 95);
            this.pf_audit_data.Name = "pf_audit_data";
            this.pf_audit_data.Size = new System.Drawing.Size(265, 139);
            this.pf_audit_data.TabIndex = 1;
            this.pf_audit_data.Text = "Upload PF Audit Data";
            this.pf_audit_data.UseVisualStyleBackColor = false;
            this.pf_audit_data.Click += new System.EventHandler(this.pf_audit_data_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(408, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(265, 139);
            this.button1.TabIndex = 2;
            this.button1.Text = "Upload PF Audit Data";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Main_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1711, 651);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pf_audit_data);
            this.Controls.Add(this.pf_data);
            this.Name = "Main_Page";
            this.Text = "Main_Page";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pf_data;
        private System.Windows.Forms.Button pf_audit_data;
        private System.Windows.Forms.Button button1;
    }
}