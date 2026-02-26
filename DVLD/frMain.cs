using DVLD.Applications.NewFolder1;
using DVLD.Applications.ReplaceLostOrDamagedLicense;
using DVLD.Applications.Rlease_Detained_License;
using DVLD.ApplicationsTypes;
using DVLD.Licenses;
using DVLD.Licenses.Detain_License;
using DVLD.NewFolder1;
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

        private void driveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers fr = new frmListDrivers();
            fr.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication fr = new frmNewInternationalLicenseApplication();
            fr.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicesnseApplications fr = new frmListInternationalLicesnseApplications();
            fr.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicenseApplication fr = new frmRenewLocalDrivingLicenseApplication();
            fr.ShowDialog();
        }

        private void ReplacementLostOrDamagedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicenseApplication fr = new frmReplaceLostOrDamagedLicenseApplication();
            fr.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication fr = new frmDetainLicenseApplication();
            fr.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication fr = new frmReleaseDetainedLicenseApplication();
            fr.ShowDialog();
        }
    }
}
