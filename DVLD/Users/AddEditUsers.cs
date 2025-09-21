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
    public partial class AddEditUsers : Form
    {

        private enum enMode {AddMode=0,UpdateMode=1};
        private enMode _mode;

        private int _UserID;

        private clsUser _User = null;

        private int _PersonID =0;
        public AddEditUsers()
        {
            InitializeComponent();
            _User = new clsUser();
            _mode = enMode.AddMode;
        }

        public AddEditUsers(int UserID)
        {
            InitializeComponent();
            _User = new clsUser();
            _UserID = UserID;
            _mode = enMode.UpdateMode;
        }



        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_PersonID==0)
            {
                MessageBox.Show("Please select a person first.");
                return;
            }

            if(  DVLD_Buisness.clsUser.IsExistByPersonID(_PersonID))
            {
              MessageBox.Show("This person is already assigned to a user, please select another person.");
              return;
            }

            _User = new clsUser();
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
            tabControl1.TabPages[1].Enabled = false;
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
                errorProvider1.SetError(PasswordTB, "User Name is required.");

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
            if(_PersonID == 0)
            {
                MessageBox.Show("Please select a person first.");
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
