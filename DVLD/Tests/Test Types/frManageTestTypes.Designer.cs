namespace DVLD.Test_Types
{
    partial class frManageTestTypes
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
            this.TitleLEB = new System.Windows.Forms.Label();
            this.TestTypesTGV = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TestTypesTGV)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RecordsLEB
            // 
            this.RecordsLEB.AutoSize = true;
            this.RecordsLEB.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordsLEB.Location = new System.Drawing.Point(128, 519);
            this.RecordsLEB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RecordsLEB.Name = "RecordsLEB";
            this.RecordsLEB.Size = new System.Drawing.Size(21, 21);
            this.RecordsLEB.TabIndex = 31;
            this.RecordsLEB.Text = "0";
            // 
            // label223
            // 
            this.label223.AutoSize = true;
            this.label223.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label223.Location = new System.Drawing.Point(14, 519);
            this.label223.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label223.Name = "label223";
            this.label223.Size = new System.Drawing.Size(104, 21);
            this.label223.TabIndex = 30;
            this.label223.Text = "#Records :";
            // 
            // TitleLEB
            // 
            this.TitleLEB.AutoSize = true;
            this.TitleLEB.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLEB.ForeColor = System.Drawing.Color.Red;
            this.TitleLEB.Location = new System.Drawing.Point(278, 157);
            this.TitleLEB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TitleLEB.Name = "TitleLEB";
            this.TitleLEB.Size = new System.Drawing.Size(285, 34);
            this.TitleLEB.TabIndex = 28;
            this.TitleLEB.Text = "Manage Test Types";
            // 
            // TestTypesTGV
            // 
            this.TestTypesTGV.AllowUserToAddRows = false;
            this.TestTypesTGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestTypesTGV.ContextMenuStrip = this.contextMenuStrip1;
            this.TestTypesTGV.Location = new System.Drawing.Point(13, 195);
            this.TestTypesTGV.Margin = new System.Windows.Forms.Padding(4);
            this.TestTypesTGV.Name = "TestTypesTGV";
            this.TestTypesTGV.RowHeadersWidth = 51;
            this.TestTypesTGV.RowTemplate.Height = 26;
            this.TestTypesTGV.Size = new System.Drawing.Size(742, 303);
            this.TestTypesTGV.TabIndex = 26;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 30);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_324;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Schedule_Test_5121;
            this.pictureBox1.Location = new System.Drawing.Point(302, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Window;
            this.btnClose.CausesValidation = false;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_321;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(650, 506);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 46);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frManageTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 578);
            this.Controls.Add(this.RecordsLEB);
            this.Controls.Add(this.label223);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TitleLEB);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.TestTypesTGV);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frManageTestTypes";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TestTypesTGV)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RecordsLEB;
        private System.Windows.Forms.Label label223;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label TitleLEB;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView TestTypesTGV;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}