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

        private int _UserID;

        private clsUser _User = null;

        private int _PersonID ;
        public frAddEditUsers()
        {
            InitializeComponent();
            _mode = enMode.AddMode;
            _PersonID = 0;
        }

        public frAddEditUsers(int UserID)
        {
            InitializeComponent();
           
            _UserID = UserID;
            _mode = enMode.UpdateMode;
            _PersonID = DVLD_Buisness.clsUser.Find(UserID).PersonID;
        }

        private void _ResetDefualtValues()
        {
            if(_mode == enMode.UpdateMode)
            {
                TitleLEB.Text = "Edit User";
                ctrlPersonCardWithFilter1.FilterEnabled = false;
            }
            else
            {
                TitleLEB.Text = "Add New User";
                _User = new clsUser();
                tabControl1.TabPages[1].Enabled = false;
            }
            UserIdLEB.Text = "???";
            IsActiveCHB.Checked = false;

        }

        private void _LoadData()
        {
            _User = DVLD_Buisness.clsUser.Find(_UserID);
            if(_User == null)
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
            if (_mode == enMode.AddMode)
            {
      
            if (_PersonID == 0)
                {
                    MessageBox.Show("Please select a person first.");
                    return;
                }

                if (DVLD_Buisness.clsUser.IsExistByPersonID(_PersonID))
                {
                    MessageBox.Show("This person is already assigned to a user, please select another person.");
                    return;
                }
            }

        
            _User.Person.PersonID = _PersonID;

            tabControl1.TabPages[1].Enabled = true;

            tabControl1.SelectedTab = tabPage2;
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;
        }

        private void AddEditUsers_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_mode == enMode.UpdateMode)
                _LoadData();
        }

        private void UsreNameTB_Validating(object sender, CancelEventArgs e)
        {
            if(UserNameTB.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(UserNameTB, "User Name is required.");

            }
            else if (DVLD_Buisness.clsUser.IsExistByUserName(UserNameTB.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(UserNameTB, "This User Name is already exist, please choose another one.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(UserNameTB, "");
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


            _User.PersonID = _PersonID;
            _User.UserName = UserNameTB.Text;
            _User.Password = PasswordTB.Text;
            _User.IsActive = IsActiveCHB.Checked;

            if(_User.Save())
            {
                UserIdLEB.Text = _User.UserID.ToString();
                TitleLEB.Text = "Edit User";
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
    }



}
