namespace DVLD.Tests
{
    partial class frManageTestAppointments
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RecordsLEB = new System.Windows.Forms.Label();
            this.label223 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TitleLEB = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TestImagePB = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlDrivingLicenseApplicationInfo1 = new DVLD.Licenses.ctrlDrivingLicenseApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestImagePB)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 610);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.Size = new System.Drawing.Size(902, 167);
            this.dataGridView1.TabIndex = 1;
            // 
            // RecordsLEB
            // 
            this.RecordsLEB.AutoSize = true;
            this.RecordsLEB.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordsLEB.Location = new System.Drawing.Point(147, 784);
            this.RecordsLEB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RecordsLEB.Name = "RecordsLEB";
            this.RecordsLEB.Size = new System.Drawing.Size(21, 21);
            this.RecordsLEB.TabIndex = 33;
            this.RecordsLEB.Text = "0";
            // 
            // label223
            // 
            this.label223.AutoSize = true;
            this.label223.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label223.Location = new System.Drawing.Point(33, 784);
            this.label223.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label223.Name = "label223";
            this.label223.Size = new System.Drawing.Size(104, 21);
            this.label223.TabIndex = 32;
            this.label223.Text = "#Records :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 572);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 21);
            this.label1.TabIndex = 34;
            this.label1.Text = "Appointments";
            // 
            // TitleLEB
            // 
            this.TitleLEB.AutoSize = true;
            this.TitleLEB.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLEB.ForeColor = System.Drawing.Color.Red;
            this.TitleLEB.Location = new System.Drawing.Point(364, 117);
            this.TitleLEB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TitleLEB.Name = "TitleLEB";
            this.TitleLEB.Size = new System.Drawing.Size(253, 28);
            this.TitleLEB.TabIndex = 35;
            this.TitleLEB.Text = "[?????????????????]";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Image = global::DVLD.Properties.Resources.AddAppointment_32;
            this.button1.Location = new System.Drawing.Point(870, 560);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 44);
            this.button1.TabIndex = 37;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestImagePB
            // 
            this.TestImagePB.Image = global::DVLD.Properties.Resources.Street_Test_322;
            this.TestImagePB.Location = new System.Drawing.Point(443, 12);
            this.TestImagePB.Name = "TestImagePB";
            this.TestImagePB.Size = new System.Drawing.Size(107, 92);
            this.TestImagePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TestImagePB.TabIndex = 36;
            this.TestImagePB.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Window;
            this.btnClose.CausesValidation = false;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_321;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(819, 784);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 46);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // ctrlDrivingLicenseApplicationInfo1
            // 
            this.ctrlDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(20, 158);
            this.ctrlDrivingLicenseApplicationInfo1.Name = "ctrlDrivingLicenseApplicationInfo1";
            this.ctrlDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(932, 411);
            this.ctrlDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // frManageTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 843);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TestImagePB);
            this.Controls.Add(this.TitleLEB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RecordsLEB);
            this.Controls.Add(this.label223);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfo1);
            this.Name = "frManageTestAppointments";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestImagePB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Licenses.ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label RecordsLEB;
        private System.Windows.Forms.Label label223;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TitleLEB;
        private System.Windows.Forms.PictureBox TestImagePB;
        private System.Windows.Forms.Button button1;
    }
}