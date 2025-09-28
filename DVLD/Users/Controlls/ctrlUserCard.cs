using DVLD.Controls;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users.Controlls
{
    public partial class ctrlUserCard : UserControl
    {
        private clsUser _User ;
        private int _UserID = -1;
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public int UserID
        {
            get { return _UserID; }
          
        }

        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.Find(UserID);
            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }


        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            UserIdLEB.Text = _User.UserID.ToString();
            UserIdLEB.Text = _User.UserName;
            IsActiveLEB.Text = (_User.IsActive) ? "YES" :"NO";
        }

        private void _ResetPersonInfo()
        {
            ctrlPersonCard1.ResetPersonInfo();
            UserIdLEB.Text = "[???]";
            UserIdLEB.Text = "[???]";
            IsActiveLEB.Text = "[???]";
        }

       
    }


}
