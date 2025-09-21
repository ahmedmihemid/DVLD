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

namespace DVLD.Users.Controlls
{
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }


        public void LoadUserInfo(int UserID)
        {
            DVLD_Buisness.clsUser _User = DVLD_Buisness.clsUser.Find(UserID);
            if (_User == null)
            {
                //ResetUserInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            UserNameLEB.Text = _User.UserName;
            UserIdLEB.Text = _User.UserID.ToString();
            IsActiveLEB.Text = _User.IsActive ? "Yes" : "No";

        }


    }


}
