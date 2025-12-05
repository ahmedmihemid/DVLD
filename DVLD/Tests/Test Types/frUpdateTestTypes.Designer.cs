namespace DVLD.Test_Types
{
    partial class frUpdateTestTypes
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
            this.IdLEB = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FeesTB = new System.Windows.Forms.TextBox();
            this.TitleTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TitleLEB = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.TestTypeDescriptionTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // IdLEB
            // 
            this.IdLEB.AutoSize = true;
            this.IdLEB.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdLEB.Location = new System.Drawing.Point(148, 77);
            this.IdLEB.Name = "IdLEB";
            this.IdLEB.Size = new System.Drawing.Size(40, 21);
            this.IdLEB.TabIndex = 38;
            this.IdLEB.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(100, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 37;
            this.label3.Text = "ID :";
            // 
            // FeesTB
            // 
            this.FeesTB.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeesTB.Location = new System.Drawing.Point(152, 324);
            this.FeesTB.Name = "FeesTB";
            this.FeesTB.Size = new System.Drawing.Size(347, 28);
            this.FeesTB.TabIndex = 36;
            this.FeesTB.Validating += new System.ComponentModel.CancelEventHandler(this.FeesTB_Validating);
            // 
            // TitleTB
            // 
            this.TitleTB.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleTB.Location = new System.Drawing.Point(152, 116);
            this.TitleTB.Name = "TitleTB";
            this.TitleTB.Size = new System.Drawing.Size(347, 28);
            this.TitleTB.TabIndex = 35;
            this.TitleTB.Validating += new System.ComponentModel.CancelEventHandler(this.TitleTB_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 21);
            this.label2.TabIndex = 34;
            this.label2.Text = "Fees :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 33;
            this.label1.Text = "Title :";
            // 
            // TitleLEB
            // 
            this.TitleLEB.AutoSize = true;
            this.TitleLEB.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLEB.ForeColor = System.Drawing.Color.Red;
            this.TitleLEB.Location = new System.Drawing.Point(159, 24);
            this.TitleLEB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TitleLEB.Name = "TitleLEB";
            this.TitleLEB.Size = new System.Drawing.Size(226, 28);
            this.TitleLEB.TabIndex = 32;
            this.TitleLEB.Text = "Update Test Types";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Window;
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(384, 386);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 38);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Window;
            this.btnClose.CausesValidation = false;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_321;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(246, 386);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 38);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TestTypeDescriptionTB
            // 
            this.TestTypeDescriptionTB.AcceptsTab = true;
            this.TestTypeDescriptionTB.Location = new System.Drawing.Point(152, 164);
            this.TestTypeDescriptionTB.Multiline = true;
            this.TestTypeDescriptionTB.Name = "TestTypeDescriptionTB";
            this.TestTypeDescriptionTB.Size = new System.Drawing.Size(347, 145);
            this.TestTypeDescriptionTB.TabIndex = 50;
            this.TestTypeDescriptionTB.TabStop = false;
            this.TestTypeDescriptionTB.Text = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
            this.TestTypeDescriptionTB.Validating += new System.ComponentModel.CancelEventHandler(this.TestTypeDescriptionTB_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 21);
            this.label4.TabIndex = 51;
            this.label4.Text = "Description :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frUpdateTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 447);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TestTypeDescriptionTB);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.IdLEB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FeesTB);
            this.Controls.Add(this.TitleTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TitleLEB);
            this.Name = "frUpdateTestTypes";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frUpdateTestTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label IdLEB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FeesTB;
        private System.Windows.Forms.TextBox TitleTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TitleLEB;
        private System.Windows.Forms.TextBox TestTypeDescriptionTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}