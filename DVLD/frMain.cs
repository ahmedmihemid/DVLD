using DVLD.ApplicationsTypes;
using DVLD.Licenses;
using DVLD.People;
using DVLD.Test_Types;
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

        public frMain(frLogin frLogin)
        {
            InitializeComponent();
            _frLogin = frLogin;
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

        private void curentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frUserDetails fr = new frUserDetails(Classes.clsGlobal.CurrentUser.UserID);
            fr.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frChanagePassword fr = new frChanagePassword(Classes.clsGlobal.CurrentUser.UserID);
            fr.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frManageApplicationTypes fr = new frManageApplicationTypes();
            fr.ShowDialog();

        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frManageTestTypes fr = new frManageTestTypes();
            fr.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frAddEditLocalDrivingApplication fr = new frAddEditLocalDrivingApplication();
            fr.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frManageLocalDrivingApplication fr = new frManageLocalDrivingApplication();
            fr.ShowDialog();
        }



    }
}
