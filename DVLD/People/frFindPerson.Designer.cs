namespace DVLD.People
{
    partial class frFindPerson
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
            this.ctrlPersonCardWithFilter1 = new DVLD.People.Controlls.ctrlPersonCardWithFilter();
            this.button2 = new System.Windows.Forms.Button();
            this.TitleLEB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(-3, 78);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(876, 447);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::DVLD.Properties.Resources.Close_32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(735, 497);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 50);
            this.button2.TabIndex = 5;
            this.button2.Text = "  Close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TitleLEB
            // 
            this.TitleLEB.AutoSize = true;
            this.TitleLEB.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLEB.ForeColor = System.Drawing.Color.Red;
            this.TitleLEB.Location = new System.Drawing.Point(340, 30);
            this.TitleLEB.Name = "TitleLEB";
            this.TitleLEB.Size = new System.Drawing.Size(192, 36);
            this.TitleLEB.TabIndex = 6;
            this.TitleLEB.Text = "Find Person";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 588);
            this.Controls.Add(this.TitleLEB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controlls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label TitleLEB;
    }
}