namespace DVLD
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fdfdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fdsfsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accoountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(60, 60);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.fdsfsToolStripMenuItem,
            this.driveToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accoountSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1470, 68);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fdfdfToolStripMenuItem});
            this.applicationsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Applications_64;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(204, 64);
            this.applicationsToolStripMenuItem.Text = "Applications";
            // 
            // fdfdfToolStripMenuItem
            // 
            this.fdfdfToolStripMenuItem.Name = "fdfdfToolStripMenuItem";
            this.fdfdfToolStripMenuItem.Size = new System.Drawing.Size(146, 32);
            this.fdfdfToolStripMenuItem.Text = "fdfdf";
            // 
            // fdsfsToolStripMenuItem
            // 
            this.fdsfsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdsfsToolStripMenuItem.Image = global::DVLD.Properties.Resources.People_64;
            this.fdsfsToolStripMenuItem.Name = "fdsfsToolStripMenuItem";
            this.fdsfsToolStripMenuItem.Size = new System.Drawing.Size(149, 64);
            this.fdsfsToolStripMenuItem.Text = "People";
            this.fdsfsToolStripMenuItem.Click += new System.EventHandler(this.fdsfsToolStripMenuItem_Click);
            // 
            // driveToolStripMenuItem
            // 
            this.driveToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driveToolStripMenuItem.Image = global::DVLD.Properties.Resources.Drivers_64;
            this.driveToolStripMenuItem.Name = "driveToolStripMenuItem";
            this.driveToolStripMenuItem.Size = new System.Drawing.Size(154, 64);
            this.driveToolStripMenuItem.Text = "Drivers";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersToolStripMenuItem.Image = global::DVLD.Properties.Resources.Add_New_User_72;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(137, 64);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // accoountSettingsToolStripMenuItem
            // 
            this.accoountSettingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accoountSettingsToolStripMenuItem.Image = global::DVLD.Properties.Resources.account_settings_64;
            this.accoountSettingsToolStripMenuItem.Name = "accoountSettingsToolStripMenuItem";
            this.accoountSettingsToolStripMenuItem.Size = new System.Drawing.Size(257, 64);
            this.accoountSettingsToolStripMenuItem.Text = "Accoount settings";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DVLD.Properties.Resources.Logo_Final;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1470, 841);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Main";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fdfdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fdsfsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accoountSettingsToolStripMenuItem;
    }
}

