using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frUserDetails : Form
    {

        private int _userId=-1;
        public frUserDetails(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserDetails_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_userId);
        }


    }
}
