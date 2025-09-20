namespace DVLD.People
{
    partial class AddEditPeople
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
            this.TitleLEB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PersonIdLE = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RemoveLL = new System.Windows.Forms.LinkLabel();
            this.SetImageLL = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.AddressTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.FamaleRB = new System.Windows.Forms.RadioButton();
            this.MaleRB = new System.Windows.Forms.RadioButton();
            this.DateOfBirthDTP = new System.Windows.Forms.DateTimePicker();
            this.CountryCB = new System.Windows.Forms.ComboBox();
            this.PhoneTB = new System.Windows.Forms.TextBox();
            this.NationalNoTB = new System.Windows.Forms.TextBox();
            this.EmailTB = new System.Windows.Forms.TextBox();
            this.ThirdNameTB = new System.Windows.Forms.TextBox();
            this.SecondNameTB = new System.Windows.Forms.TextBox();
            this.FirstNameTB = new System.Windows.Forms.TextBox();
            this.PersonImagePB = new System.Windows.Forms.PictureBox();
            this.LastNameTB = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PersonImagePB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLEB
            // 
            this.TitleLEB.AutoSize = true;
            this.TitleLEB.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLEB.ForeColor = System.Drawing.Color.Red;
            this.TitleLEB.Location = new System.Drawing.Point(331, 9);
            this.TitleLEB.Name = "TitleLEB";
            this.TitleLEB.Size = new System.Drawing.Size(264, 36);
            this.TitleLEB.TabIndex = 1;
            this.TitleLEB.Text = "Add New Person";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Person ID :";
            // 
            // PersonIdLE
            // 
            this.PersonIdLE.AutoSize = true;
            this.PersonIdLE.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonIdLE.Location = new System.Drawing.Point(128, 58);
            this.PersonIdLE.Name = "PersonIdLE";
            this.PersonIdLE.Size = new System.Drawing.Size(46, 22);
            this.PersonIdLE.TabIndex = 3;
            this.PersonIdLE.Text = "N/A";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RemoveLL);
            this.groupBox1.Controls.Add(this.SetImageLL);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.AddressTB);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.FamaleRB);
            this.groupBox1.Controls.Add(this.MaleRB);
            this.groupBox1.Controls.Add(this.DateOfBirthDTP);
            this.groupBox1.Controls.Add(this.CountryCB);
            this.groupBox1.Controls.Add(this.PhoneTB);
            this.groupBox1.Controls.Add(this.NationalNoTB);
            this.groupBox1.Controls.Add(this.EmailTB);
            this.groupBox1.Controls.Add(this.ThirdNameTB);
            this.groupBox1.Controls.Add(this.SecondNameTB);
            this.groupBox1.Controls.Add(this.FirstNameTB);
            this.groupBox1.Controls.Add(this.PersonImagePB);
            this.groupBox1.Controls.Add(this.LastNameTB);
            this.groupBox1.Location = new System.Drawing.Point(13, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(921, 418);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // RemoveLL
            // 
            this.RemoveLL.AutoSize = true;
            this.RemoveLL.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveLL.Location = new System.Drawing.Point(783, 297);
            this.RemoveLL.Name = "RemoveLL";
            this.RemoveLL.Size = new System.Drawing.Size(70, 21);
            this.RemoveLL.TabIndex = 67;
            this.RemoveLL.TabStop = true;
            this.RemoveLL.Text = "Remove";
            this.RemoveLL.Visible = false;
            this.RemoveLL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RemoveLL_LinkClicked);
            // 
            // SetImageLL
            // 
            this.SetImageLL.AutoSize = true;
            this.SetImageLL.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetImageLL.Location = new System.Drawing.Point(774, 261);
            this.SetImageLL.Name = "SetImageLL";
            this.SetImageLL.Size = new System.Drawing.Size(98, 21);
            this.SetImageLL.TabIndex = 66;
            this.SetImageLL.TabStop = true;
            this.SetImageLL.Text = "Set Image";
            this.SetImageLL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SetImageLL_LinkClicked);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(727, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 22);
            this.label12.TabIndex = 65;
            this.label12.Text = "Last Name :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(527, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 22);
            this.label11.TabIndex = 64;
            this.label11.Text = "Third Name :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(153, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 22);
            this.label10.TabIndex = 63;
            this.label10.Text = "First Name :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(341, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 22);
            this.label9.TabIndex = 62;
            this.label9.Text = "Second Name :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(373, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 22);
            this.label8.TabIndex = 61;
            this.label8.Text = "Country:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(373, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 22);
            this.label7.TabIndex = 60;
            this.label7.Text = "Date of Birth:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(373, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 22);
            this.label6.TabIndex = 59;
            this.label6.Text = "Phone:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(486, 350);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 36);
            this.btnClose.TabIndex = 58;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(600, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 36);
            this.btnSave.TabIndex = 57;
            this.btnSave.Text = "Sava";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddressTB
            // 
            this.AddressTB.AcceptsTab = true;
            this.AddressTB.Location = new System.Drawing.Point(157, 225);
            this.AddressTB.Multiline = true;
            this.AddressTB.Name = "AddressTB";
            this.AddressTB.Size = new System.Drawing.Size(536, 110);
            this.AddressTB.TabIndex = 49;
            this.AddressTB.TabStop = false;
            this.AddressTB.Text = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
            this.AddressTB.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 22);
            this.label5.TabIndex = 56;
            this.label5.Text = "Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 22);
            this.label4.TabIndex = 55;
            this.label4.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 22);
            this.label3.TabIndex = 54;
            this.label3.Text = "Gendor:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(5, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 22);
            this.label13.TabIndex = 53;
            this.label13.Text = "National NO :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(5, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 22);
            this.label14.TabIndex = 52;
            this.label14.Text = "Name:";
            // 
            // FamaleRB
            // 
            this.FamaleRB.AutoSize = true;
            this.FamaleRB.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FamaleRB.Location = new System.Drawing.Point(228, 129);
            this.FamaleRB.Name = "FamaleRB";
            this.FamaleRB.Size = new System.Drawing.Size(64, 20);
            this.FamaleRB.TabIndex = 51;
            this.FamaleRB.TabStop = true;
            this.FamaleRB.Text = "Fmale";
            this.FamaleRB.UseVisualStyleBackColor = true;
            this.FamaleRB.Click += new System.EventHandler(this.FamaleRB_Click);
            // 
            // MaleRB
            // 
            this.MaleRB.AutoSize = true;
            this.MaleRB.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaleRB.Location = new System.Drawing.Point(157, 129);
            this.MaleRB.Name = "MaleRB";
            this.MaleRB.Size = new System.Drawing.Size(58, 20);
            this.MaleRB.TabIndex = 46;
            this.MaleRB.TabStop = true;
            this.MaleRB.Text = "Male";
            this.MaleRB.UseVisualStyleBackColor = true;
            this.MaleRB.Click += new System.EventHandler(this.MaleRB_Click);
            // 
            // DateOfBirthDTP
            // 
            this.DateOfBirthDTP.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateOfBirthDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateOfBirthDTP.Location = new System.Drawing.Point(531, 89);
            this.DateOfBirthDTP.Name = "DateOfBirthDTP";
            this.DateOfBirthDTP.Size = new System.Drawing.Size(162, 28);
            this.DateOfBirthDTP.TabIndex = 45;
            // 
            // CountryCB
            // 
            this.CountryCB.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountryCB.FormattingEnabled = true;
            this.CountryCB.ItemHeight = 22;
            this.CountryCB.Location = new System.Drawing.Point(531, 164);
            this.CountryCB.Name = "CountryCB";
            this.CountryCB.Size = new System.Drawing.Size(162, 30);
            this.CountryCB.TabIndex = 50;
            // 
            // PhoneTB
            // 
            this.PhoneTB.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneTB.Location = new System.Drawing.Point(531, 123);
            this.PhoneTB.Name = "PhoneTB";
            this.PhoneTB.Size = new System.Drawing.Size(162, 29);
            this.PhoneTB.TabIndex = 47;
            this.PhoneTB.Validating += new System.ComponentModel.CancelEventHandler(this.PhoneTB_Validating);
            // 
            // NationalNoTB
            // 
            this.NationalNoTB.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NationalNoTB.Location = new System.Drawing.Point(157, 89);
            this.NationalNoTB.Name = "NationalNoTB";
            this.NationalNoTB.Size = new System.Drawing.Size(162, 29);
            this.NationalNoTB.TabIndex = 44;
            this.NationalNoTB.Validating += new System.ComponentModel.CancelEventHandler(this.NationalNoTB_Validating);
            // 
            // EmailTB
            // 
            this.EmailTB.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTB.Location = new System.Drawing.Point(157, 164);
            this.EmailTB.Name = "EmailTB";
            this.EmailTB.Size = new System.Drawing.Size(162, 29);
            this.EmailTB.TabIndex = 48;
            this.EmailTB.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // ThirdNameTB
            // 
            this.ThirdNameTB.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThirdNameTB.Location = new System.Drawing.Point(531, 45);
            this.ThirdNameTB.Name = "ThirdNameTB";
            this.ThirdNameTB.Size = new System.Drawing.Size(162, 29);
            this.ThirdNameTB.TabIndex = 41;
            // 
            // SecondNameTB
            // 
            this.SecondNameTB.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondNameTB.Location = new System.Drawing.Point(345, 45);
            this.SecondNameTB.Name = "SecondNameTB";
            this.SecondNameTB.Size = new System.Drawing.Size(162, 29);
            this.SecondNameTB.TabIndex = 40;
            this.SecondNameTB.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // FirstNameTB
            // 
            this.FirstNameTB.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameTB.Location = new System.Drawing.Point(157, 45);
            this.FirstNameTB.Name = "FirstNameTB";
            this.FirstNameTB.Size = new System.Drawing.Size(162, 29);
            this.FirstNameTB.TabIndex = 39;
            this.FirstNameTB.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // PersonImagePB
            // 
            this.PersonImagePB.Image = global::DVLD.Properties.Resources.Male_512;
            this.PersonImagePB.Location = new System.Drawing.Point(731, 89);
            this.PersonImagePB.Name = "PersonImagePB";
            this.PersonImagePB.Size = new System.Drawing.Size(162, 158);
            this.PersonImagePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PersonImagePB.TabIndex = 43;
            this.PersonImagePB.TabStop = false;
            // 
            // LastNameTB
            // 
            this.LastNameTB.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameTB.Location = new System.Drawing.Point(731, 45);
            this.LastNameTB.Name = "LastNameTB";
            this.LastNameTB.Size = new System.Drawing.Size(162, 29);
            this.LastNameTB.TabIndex = 42;
            this.LastNameTB.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddEditPeople
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(949, 533);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PersonIdLE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TitleLEB);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddEditPeople";
            this.Text = "AddEditPeople";
            this.Load += new System.EventHandler(this.AddEditPeople_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PersonImagePB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TitleLEB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PersonIdLE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel SetImageLL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox AddressTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton FamaleRB;
        private System.Windows.Forms.RadioButton MaleRB;
        private System.Windows.Forms.DateTimePicker DateOfBirthDTP;
        private System.Windows.Forms.ComboBox CountryCB;
        private System.Windows.Forms.TextBox PhoneTB;
        private System.Windows.Forms.TextBox NationalNoTB;
        private System.Windows.Forms.TextBox EmailTB;
        private System.Windows.Forms.TextBox ThirdNameTB;
        private System.Windows.Forms.TextBox SecondNameTB;
        private System.Windows.Forms.TextBox FirstNameTB;
        private System.Windows.Forms.PictureBox PersonImagePB;
        private System.Windows.Forms.TextBox LastNameTB;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.LinkLabel RemoveLL;
    }
}