using DVLD.Classes;
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

namespace DVLD.Licenses
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {

       
        private clsDriverscs _Driver;
        private clsLicenses _License;
        private clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;

        public frmIssueDriverLicenseFirstTime(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _License = new clsLicenses();
            _localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(localDrivingLicenseApplicationID);
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_localDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
        }


        private void btnIssueLicense_Click(object sender, EventArgs e)
        {


            int LicenseID = _localDrivingLicenseApplication.IssueLicenseForTheFirtTime(NotTB.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlDrivingLicenseApplicationInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
