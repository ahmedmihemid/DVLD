using DVLD.Licenses.Local_Licenses;
using DVLD.Licenses.Local_Licenses.Controlls;
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

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private int _LocalDrivingLicenseApplicationID = -1;

        private int _LicenseID;

        private bool _showLicenceInfoEnabled;
        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }



        public bool ShowLicenceInfoEnabled
        {
            get
            {
                return _showLicenceInfoEnabled;
            }
            set
            {
                _showLicenceInfoEnabled = value;
                llShowLicenceInfo.Enabled = _showLicenceInfoEnabled;
            }

        }

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent(); 
        }


        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if(_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            llShowLicenceInfo.Enabled = (clsLicenses.GetLicenseIDByApplicationID(_LocalDrivingLicenseApplication.ApplicationID) != -1);
           

            _FillLocalDrivingLicenseApplicationInfo();
        }

        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            llShowLicenceInfo.Enabled = (clsLicenses.GetLicenseIDByApplicationID(_LocalDrivingLicenseApplication.ApplicationID) != -1);


            _FillLocalDrivingLicenseApplicationInfo();
        }


        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            lblLocalDrivingLicenseApplicationID.Text = "[???]";
            lblAppliedFor.Text = "[???]";
            lblPassedTests.Text = "[???]";
            ctlApplicationBasicInfo1.ReastDefaultsData();


        }

        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedFor.Text = clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName;
            lblPassedTests.Text = clsTests.GetPassedTestCount(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID).ToString();
            ctlApplicationBasicInfo1.LoadData(_LocalDrivingLicenseApplication.ApplicationID);
        }

        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LicenseID);
            frm.ShowDialog();


        }
    }
}
