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
    public partial class frAddEditUsers : Form
    {

        private enum enMode {AddMode=0,UpdateMode=1};
        private enMode _mode;

        private int _UserID=-1;

        private clsUser _User;

   
        public frAddEditUsers()
        {
            InitializeComponent();
            _mode = enMode.AddMode;
     
        }

        public frAddEditUsers(int UserID)
        {
            InitializeComponent();
           
            _UserID = UserID;
            _mode = enMode.UpdateMode;

        }

        private void _ResetDefualtValues()
        {
            if(_mode == enMode.UpdateMode)
            {
                TitleLEB.Text = "Edit User";
                this.Text = "Edit User";
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                btnSave.Enabled = true;
            }
            else
            {
                TitleLEB.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUser();
                tabControl1.TabPages[1].Enabled = false;
            }
            UserIdLEB.Text = "???";
            UserNameTB.Text = "";
            PasswordTB.Text = "";
            IsActiveCHB.Checked = true;

        }

        private void _LoadData()
        {
            _User = DVLD_Buisness.clsUser.Find(_UserID);
            //ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_User == null)
            {
                 MessageBox.Show("Failed to load user information, please try again.");
                return;
            }
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
            UserIdLEB.Text = _User.UserID.ToString();
            UserNameTB.Text = _User.UserName;
            PasswordTB.Text = _User.Password;
            ConfirmPasswordTB.Text = _User.Password;
            IsActiveCHB.Checked = _User.IsActive;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_mode == enMode.UpdateMode)
            {
                btnSave.Enabled = true;
                tabControl1.TabPages[1].Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages[1];
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                if(DVLD_Buisness.clsUser.IsExistByPersonID(ctrlPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("This person already has a user account, please choose another person.", "Person Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                }
                else
                {
                    btnSave.Enabled = true;
                    tabControl1.TabPages[1].Enabled = true;
                    tabControl1.SelectedTab = tabControl1.TabPages[1];
                }
            }
            else
            {
                MessageBox.Show("Please select a person to continue.", "No Person Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

      

        private void AddEditUsers_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_mode == enMode.UpdateMode)
                _LoadData();
        }

        private void UsreNameTB_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(UserNameTB.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(UserNameTB, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(UserNameTB, null);
            }

            if (_mode == enMode.AddMode)
            {

                if (clsUser.IsExistByUserName(UserNameTB.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(UserNameTB, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(UserNameTB, null);
                }
                ;
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.UserName != UserNameTB.Text.Trim())
                {
                    if (clsUser.IsExistByUserName(UserNameTB.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(UserNameTB, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(UserNameTB, null);
                    }
                    ;
                }
            }


        }

        private void PasswordTB_Validating(object sender, CancelEventArgs e)
        {
            if (PasswordTB.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(PasswordTB, "Password is required.");

            }

            else if (ConfirmPasswordTB.Text != PasswordTB.Text && ConfirmPasswordTB.Text!="")
            {
                e.Cancel = true;
                errorProvider1.SetError(ConfirmPasswordTB, "Password and Confirm Password must be the same.");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(PasswordTB, "");
            }
        }

        private void ConfirmPasswordTB_Validating(object sender, CancelEventArgs e)
        {
            if (ConfirmPasswordTB.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(ConfirmPasswordTB, "User Name is required.");

            }

            else if (ConfirmPasswordTB.Text != PasswordTB.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(ConfirmPasswordTB, "Password and Confirm Password must be the same.");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(ConfirmPasswordTB, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.UserName = UserNameTB.Text;
            _User.Password = PasswordTB.Text;
            _User.IsActive = IsActiveCHB.Checked;

            if(_User.Save())
            {
                UserIdLEB.Text = _User.UserID.ToString();
                TitleLEB.Text = "Edit User";
                this.Text = "Edit User";
                _mode = enMode.UpdateMode;
                MessageBox.Show("User information saved successfully.");

            }
            else
            {
                MessageBox.Show("Failed to save user information, please try again.");
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frAddEditUsers_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();

        }
    }



}
