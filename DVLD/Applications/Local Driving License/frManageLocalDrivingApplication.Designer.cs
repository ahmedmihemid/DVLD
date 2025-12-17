namespace DVLD.Licenses
{
    partial class frManageLocalDrivingApplication
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
            this.components = new System.ComponentModel.Container();
            this.RecordsLEB = new System.Windows.Forms.Label();
            this.label223 = new System.Windows.Forms.Label();
            this.FilterValueTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LocalDrivingLicenseApplicationDGV = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.EditeApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.shechduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechsuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechsuleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sechsuleToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.issueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LocalDrivingLicenseApplicationDGV)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RecordsLEB
            // 
            this.RecordsLEB.AutoSize = true;
            this.RecordsLEB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordsLEB.Location = new System.Drawing.Point(151, 606);
            this.RecordsLEB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RecordsLEB.Name = "RecordsLEB";
            this.RecordsLEB.Size = new System.Drawing.Size(23, 24);
            this.RecordsLEB.TabIndex = 20;
            this.RecordsLEB.Text = "0";
            // 
            // label223
            // 
            this.label223.AutoSize = true;
            this.label223.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label223.Location = new System.Drawing.Point(22, 607);
            this.label223.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label223.Name = "label223";
            this.label223.Size = new System.Drawing.Size(121, 24);
            this.label223.TabIndex = 19;
            this.label223.Text = "#Records :";
            // 
            // FilterValueTB
            // 
            this.FilterValueTB.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterValueTB.Location = new System.Drawing.Point(472, 206);
            this.FilterValueTB.Margin = new System.Windows.Forms.Padding(4);
            this.FilterValueTB.Name = "FilterValueTB";
            this.FilterValueTB.Size = new System.Drawing.Size(180, 29);
            this.FilterValueTB.TabIndex = 18;
            this.FilterValueTB.Visible = false;
            this.FilterValueTB.TextChanged += new System.EventHandler(this.FilterValueTB_TextChanged);
            this.FilterValueTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FilterValueTB_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(470, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(343, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Local Driving License Application";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 207);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Filter By";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No",
            "Full Name",
            "Status"});
            this.comboBox1.Location = new System.Drawing.Point(135, 207);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(316, 30);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // LocalDrivingLicenseApplicationDGV
            // 
            this.LocalDrivingLicenseApplicationDGV.AllowUserToAddRows = false;
            this.LocalDrivingLicenseApplicationDGV.BackgroundColor = System.Drawing.Color.White;
            this.LocalDrivingLicenseApplicationDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LocalDrivingLicenseApplicationDGV.ContextMenuStrip = this.contextMenuStrip1;
            this.LocalDrivingLicenseApplicationDGV.Location = new System.Drawing.Point(13, 243);
            this.LocalDrivingLicenseApplicationDGV.Margin = new System.Windows.Forms.Padding(4);
            this.LocalDrivingLicenseApplicationDGV.Name = "LocalDrivingLicenseApplicationDGV";
            this.LocalDrivingLicenseApplicationDGV.RowHeadersWidth = 51;
            this.LocalDrivingLicenseApplicationDGV.RowTemplate.Height = 26;
            this.LocalDrivingLicenseApplicationDGV.Size = new System.Drawing.Size(1152, 355);
            this.LocalDrivingLicenseApplicationDGV.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.EditeApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.cancelApplicationToolStripMenuItem,
            this.toolStripMenuItem2,
            this.shechduleTestsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.issueToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showLicenseToolStripMenuItem1,
            this.toolStripMenuItem4,
            this.showPersonLicenseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(297, 276);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showApplicationDToolStripMenuItem
            // 
            this.showApplicationDToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonDetails_323;
            this.showApplicationDToolStripMenuItem.Name = "showApplicationDToolStripMenuItem";
            this.showApplicationDToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.showApplicationDToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDToolStripMenuItem_Click);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(293, 6);
            // 
            // EditeApplicationToolStripMenuItem
            // 
            this.EditeApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_326;
            this.EditeApplicationToolStripMenuItem.Name = "EditeApplicationToolStripMenuItem";
            this.EditeApplicationToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.EditeApplicationToolStripMenuItem.Text = "Edit Application";
            this.EditeApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem1
            // 
            this.deleteApplicationToolStripMenuItem1.Image = global::DVLD.Properties.Resources.Delete_32_21;
            this.deleteApplicationToolStripMenuItem1.Name = "deleteApplicationToolStripMenuItem1";
            this.deleteApplicationToolStripMenuItem1.Size = new System.Drawing.Size(296, 26);
            this.deleteApplicationToolStripMenuItem1.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem1.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(293, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.Delete_322;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(293, 6);
            // 
            // shechduleTestsToolStripMenuItem
            // 
            this.shechduleTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sechsuleToolStripMenuItem,
            this.sechsuleToolStripMenuItem1,
            this.sechsuleToolStripMenuItem2});
            this.shechduleTestsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Schedule_Test_32;
            this.shechduleTestsToolStripMenuItem.Name = "shechduleTestsToolStripMenuItem";
            this.shechduleTestsToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.shechduleTestsToolStripMenuItem.Text = "Sechdule Tests";
            // 
            // sechsuleToolStripMenuItem
            // 
            this.sechsuleToolStripMenuItem.Image = global::DVLD.Properties.Resources.Vision_Test_32;
            this.sechsuleToolStripMenuItem.Name = "sechsuleToolStripMenuItem";
            this.sechsuleToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.sechsuleToolStripMenuItem.Text = "Sechsule Vision Test";
            this.sechsuleToolStripMenuItem.Click += new System.EventHandler(this.sechsuleToolStripMenuItem_Click);
            // 
            // sechsuleToolStripMenuItem1
            // 
            this.sechsuleToolStripMenuItem1.Image = global::DVLD.Properties.Resources.Written_Test_32;
            this.sechsuleToolStripMenuItem1.Name = "sechsuleToolStripMenuItem1";
            this.sechsuleToolStripMenuItem1.Size = new System.Drawing.Size(232, 26);
            this.sechsuleToolStripMenuItem1.Text = "Sechsule Written Test";
            this.sechsuleToolStripMenuItem1.Click += new System.EventHandler(this.sechsuleToolStripMenuItem1_Click);
            // 
            // sechsuleToolStripMenuItem2
            // 
            this.sechsuleToolStripMenuItem2.Image = global::DVLD.Properties.Resources.Street_Test_32;
            this.sechsuleToolStripMenuItem2.Name = "sechsuleToolStripMenuItem2";
            this.sechsuleToolStripMenuItem2.Size = new System.Drawing.Size(232, 26);
            this.sechsuleToolStripMenuItem2.Text = "Sechsule Street Test";
            this.sechsuleToolStripMenuItem2.Click += new System.EventHandler(this.sechsuleToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(293, 6);
            // 
            // issueToolStripMenuItem
            // 
            this.issueToolStripMenuItem.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_32;
            this.issueToolStripMenuItem.Name = "issueToolStripMenuItem";
            this.issueToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.issueToolStripMenuItem.Text = "Issue Driving License (First Time)";
            this.issueToolStripMenuItem.Click += new System.EventHandler(this.issueToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(293, 6);
            // 
            // showLicenseToolStripMenuItem1
            // 
            this.showLicenseToolStripMenuItem1.Image = global::DVLD.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem1.Name = "showLicenseToolStripMenuItem1";
            this.showLicenseToolStripMenuItem1.Size = new System.Drawing.Size(296, 26);
            this.showLicenseToolStripMenuItem1.Text = "Show License";
            this.showLicenseToolStripMenuItem1.Click += new System.EventHandler(this.showLicenseToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(293, 6);
            // 
            // showPersonLicenseToolStripMenuItem
            // 
            this.showPersonLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseToolStripMenuItem.Name = "showPersonLicenseToolStripMenuItem";
            this.showPersonLicenseToolStripMenuItem.Size = new System.Drawing.Size(296, 26);
            this.showPersonLicenseToolStripMenuItem.Text = "Show Person License History";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Local_32;
            this.pictureBox2.Location = new System.Drawing.Point(647, 36);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Applications2;
            this.pictureBox1.Location = new System.Drawing.Point(541, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::DVLD.Properties.Resources.Close_32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1052, 606);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 43);
            this.button2.TabIndex = 13;
            this.button2.Text = "  Close";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::DVLD.Properties.Resources.New_Application_64;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1092, 176);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 61);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frManageLocalDrivingApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 654);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.RecordsLEB);
            this.Controls.Add(this.label223);
            this.Controls.Add(this.FilterValueTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LocalDrivingLicenseApplicationDGV);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frManageLocalDrivingApplication";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frManageLocalDrivingApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LocalDrivingLicenseApplicationDGV)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RecordsLEB;
        private System.Windows.Forms.Label label223;
        private System.Windows.Forms.TextBox FilterValueTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView LocalDrivingLicenseApplicationDGV;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditeApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem shechduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem issueToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechsuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechsuleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sechsuleToolStripMenuItem2;
    }
}