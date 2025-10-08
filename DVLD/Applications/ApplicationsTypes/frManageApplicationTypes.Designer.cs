namespace DVLD.ApplicationsTypes
{
    partial class frManageApplicationTypes
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
            this.ApplicationTypesTGV = new System.Windows.Forms.DataGridView();
            this.ApplicationTypesCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TitleLEB = new System.Windows.Forms.Label();
            this.RecordsLEB = new System.Windows.Forms.Label();
            this.label223 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationTypesTGV)).BeginInit();
            this.ApplicationTypesCMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ApplicationTypesTGV
            // 
            this.ApplicationTypesTGV.AllowUserToAddRows = false;
            this.ApplicationTypesTGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ApplicationTypesTGV.ContextMenuStrip = this.ApplicationTypesCMS;
            this.ApplicationTypesTGV.Location = new System.Drawing.Point(18, 213);
            this.ApplicationTypesTGV.Margin = new System.Windows.Forms.Padding(4);
            this.ApplicationTypesTGV.Name = "ApplicationTypesTGV";
            this.ApplicationTypesTGV.RowHeadersWidth = 51;
            this.ApplicationTypesTGV.RowTemplate.Height = 26;
            this.ApplicationTypesTGV.Size = new System.Drawing.Size(552, 272);
            this.ApplicationTypesTGV.TabIndex = 0;
            // 
            // ApplicationTypesCMS
            // 
            this.ApplicationTypesCMS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ApplicationTypesCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.ApplicationTypesCMS.Name = "ApplicationTypesCMS";
            this.ApplicationTypesCMS.Size = new System.Drawing.Size(109, 30);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_323;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // TitleLEB
            // 
            this.TitleLEB.AutoSize = true;
            this.TitleLEB.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLEB.ForeColor = System.Drawing.Color.Red;
            this.TitleLEB.Location = new System.Drawing.Point(126, 157);
            this.TitleLEB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TitleLEB.Name = "TitleLEB";
            this.TitleLEB.Size = new System.Drawing.Size(383, 34);
            this.TitleLEB.TabIndex = 22;
            this.TitleLEB.Text = "Manage Application Types";
            // 
            // RecordsLEB
            // 
            this.RecordsLEB.AutoSize = true;
            this.RecordsLEB.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordsLEB.Location = new System.Drawing.Point(128, 493);
            this.RecordsLEB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RecordsLEB.Name = "RecordsLEB";
            this.RecordsLEB.Size = new System.Drawing.Size(21, 21);
            this.RecordsLEB.TabIndex = 25;
            this.RecordsLEB.Text = "0";
            // 
            // label223
            // 
            this.label223.AutoSize = true;
            this.label223.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label223.Location = new System.Drawing.Point(14, 493);
            this.label223.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label223.Name = "label223";
            this.label223.Size = new System.Drawing.Size(104, 21);
            this.label223.TabIndex = 24;
            this.label223.Text = "#Records :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Application_Types_5121;
            this.pictureBox1.Location = new System.Drawing.Point(213, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Window;
            this.btnClose.CausesValidation = false;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_321;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(465, 493);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 46);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frManageApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 564);
            this.Controls.Add(this.RecordsLEB);
            this.Controls.Add(this.label223);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TitleLEB);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ApplicationTypesTGV);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frManageApplicationTypes";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ManageApplicationTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationTypesTGV)).EndInit();
            this.ApplicationTypesCMS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ApplicationTypesTGV;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label TitleLEB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label RecordsLEB;
        private System.Windows.Forms.Label label223;
        private System.Windows.Forms.ContextMenuStrip ApplicationTypesCMS;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}