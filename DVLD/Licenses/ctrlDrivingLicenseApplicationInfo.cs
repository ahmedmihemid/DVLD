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
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {

         private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication ;

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void _Reset()
        {
    ;       lblLocalDrivingLicenseApplicationID.Text = "[???]";
            lblAppliedFor.Text = "[???]";
            lblPassedTests.Text = "0";
        }

        private void _FillDate()
        {
            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedFor.Text = LicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName;
            lblPassedTests.Text = clsTests.GetNumberOfPassedTests(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID) +"/3";
            ctlApplicationBasicInfo1.LoadData(_LocalDrivingLicenseApplication.ApplicationID);
        }

        public void LoadData(int  localDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(localDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Invalid Local Driving License Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
               _FillDate();       
        }

        private void ctrlDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            _Reset();
        }



    }
}
