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
            if (chkRememberMe.Checked)
            {
                ReadLoginInfor();
            }
        }

        private void WriteLoginInfor()
        {
            if (chkRememberMe.Checked)
            {
                using (StreamWriter sw = new StreamWriter("RememberMe.txt", false))
                {
                    sw.WriteLine(UserNameTB.Text.Trim());
                    sw.WriteLine(PasswordTB.Text.Trim());
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter("RememberMe.txt", false))
                {
                    sw.WriteLine("");
                }
            }

        }

        private void ReadLoginInfor()
        {
            using (StreamReader sr = new StreamReader("RememberMe.txt"))
            {
                UserNameTB.Text= sr.ReadLine();
                PasswordTB.Text= sr.ReadLine();
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool isFound=false; 
            clsUser user = clsUser.Login(UserNameTB.Text.Trim(), PasswordTB.Text.Trim(),ref isFound);
            if(!isFound)
            {
               MessageBox.Show("Invalid username or password.");
                return;
            }
            if (!user.IsActive)
            {

                MessageBox.Show("This user is not active.");
                return;
            }


            DVLD.Classes.clsGlobal.CurrentUser = user;

            WriteLoginInfor();

            DVLD.Classes.clsGlobal.CurrentUser = user;
            this.Hide();
            frMain fr = new frMain(this);
            fr.ShowDialog();
       
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
