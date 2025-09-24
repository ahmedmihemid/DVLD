using DVLD.People;
using DVLD.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frMain : Form
    {

        private frLogin _frLogin;

        public frMain()
        {
            InitializeComponent();
        }

        public frMain(frLogin frLogin)
        {
            InitializeComponent();
            _frLogin = frLogin;
        }

        private void managePepoleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fdsfsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frManagePeople managePeople = new frManagePeople();
            managePeople.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void singOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DVLD.Classes.clsGlobal.CurrentUser = null;
            _frLogin.Show();
            this.Close();
           
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frManageUsers fr = new frManageUsers();
            fr.ShowDialog();
        }


    }
}
