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
using System.IO;

namespace DVLD
{
    public partial class frLogin : Form
    {
        public frLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string userName = "";
            string password = "";
            if (DVLD.Classes.clsGlobal.GetStoredCredential(ref userName,ref password))
            {
                UserNameTB.Text = userName;
                PasswordTB.Text = password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            clsUser user = clsUser.GetUserInfoByUsernameAndPassword(UserNameTB.Text.Trim(), PasswordTB.Text.Trim());
          if(user!=null)
            {
                if (chkRememberMe.Checked )
                {
                    DVLD.Classes.clsGlobal.RememberUsernameAndPassword(UserNameTB.Text.Trim(), PasswordTB.Text.Trim());
                }
                else
                {
                    DVLD.Classes.clsGlobal.RememberUsernameAndPassword("", "");
                }

                if (!user.IsActive)
                {
                    MessageBox.Show("User is Inactive, Please contact the system administrator");
                    return;
                }

                DVLD.Classes.clsGlobal.CurrentUser = user;
                this.Hide();
                frMain main = new frMain(this);
                main.ShowDialog();


            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
                return;
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
