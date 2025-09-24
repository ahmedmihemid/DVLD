using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;

namespace DVLD.Users
{
    public partial class frChanagePassword : Form
    {

        private int _UserID;
        private clsUser _User;
        public frChanagePassword(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }

        private void ctrlUserCard1_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_UserID);
            _User = clsUser.Find(_UserID); 
            
        }

        private void CurrentPasswordTB_Validating(object sender, CancelEventArgs e)
        {
            if (CurrentPasswordTB.Text == "" || CurrentPasswordTB.Text != _User.Password) 
            {
                e.Cancel = true;
                errorProvider1.SetError(CurrentPasswordTB, "Current Password is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(CurrentPasswordTB, null);
            }
        }

        private void NewPasswordTB_Validating(object sender, CancelEventArgs e)
        {
            if (NewPasswordTB.Text == "")
            {
                e.Cancel = true;
               errorProvider1.SetError(NewPasswordTB, "new Password is required.");
            }
            else if (ConfirmPasswordTB.Text != NewPasswordTB.Text && ConfirmPasswordTB.Text !="")
            {
                e.Cancel = true;
               errorProvider1.SetError(NewPasswordTB, "new Password and Confirm Password must be the same.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(CurrentPasswordTB, null);
            }

        }

        private void ConfirmPasswordTB_Validating(object sender, CancelEventArgs e)
        {
            if (ConfirmPasswordTB.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(ConfirmPasswordTB, "Confirm Password is required.");
            }
            else if(ConfirmPasswordTB.Text != NewPasswordTB.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(ConfirmPasswordTB, "Confirm Password is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(ConfirmPasswordTB, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (this.ValidateChildren())
            {
                _User.Password = NewPasswordTB.Text;
                _User.Save();
                MessageBox.Show("Password changed successfully.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
            this.Close();
        }
    }
}
