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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PersonIdLE = new System.Windows.Forms.Label();
            this.userCart1 = new DVLD.People.Controlls.UserCart();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(334, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add New Person";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Person ID :";
            // 
            // PersonIdLE
            // 
            this.PersonIdLE.AutoSize = true;
            this.PersonIdLE.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonIdLE.Location = new System.Drawing.Point(131, 103);
            this.PersonIdLE.Name = "PersonIdLE";
            this.PersonIdLE.Size = new System.Drawing.Size(46, 22);
            this.PersonIdLE.TabIndex = 3;
            this.PersonIdLE.Text = "N/A";
            // 
            // userCart1
            // 
            this.userCart1.Location = new System.Drawing.Point(12, 137);
            this.userCart1.Name = "userCart1";
            this.userCart1.Size = new System.Drawing.Size(923, 427);
            this.userCart1.TabIndex = 4;
            this.userCart1.Load += new System.EventHandler(this.userCart1_Load);
            // 
            // AddEditPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 597);
            this.Controls.Add(this.userCart1);
            this.Controls.Add(this.PersonIdLE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEditPeople";
            this.Text = "AddEditPeople";
            this.Load += new System.EventHandler(this.AddEditPeople_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PersonIdLE;
        private Controlls.UserCart userCart1;
    }
}