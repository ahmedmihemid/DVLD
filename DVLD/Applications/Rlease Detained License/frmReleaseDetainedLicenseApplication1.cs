using DVLD.Licenses.Controlls;
using DVLD.Licenses.Local_Licenses;
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

namespace DVLD.Applications.Rlease_Detained_License
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {

        private int _selectedLicensId = -1;
        private clsDetainedLicens _DetainedLicens;
        private clsApplications _RleaseDetainedApplication;



        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _Restvalues();

            if (obj< 0) 
               return;

            _selectedLicensId = obj;
            _DetainedLicens = clsDetainedLicens.GetDetainedLicenseInfoByLicenseID(_selectedLicensId);

            _LoadInfo();

        }


        private void _Restvalues()
        {
            lblDetainID.Text = "[???]";
            lblLicenseID.Text = "[???]";
            lblCreatedByUser.Text = "[???]";
            lblApplicationID.Text = "[???]";
            lblDetainDate.Text = "[??/??/????]";
            lblApplicationFees.Text = "[$$$$]";
            lblFineFees.Text = "[$$$$]";
            lblTotalFees.Text = "[$$$$]";

            llShowLicenseHistory.Enabled = false;
            btnRelease.Enabled = false;
            llShowLicenseInfo.Enabled = false;
        }


        private void _LoadInfo()
        {
            if (_DetainedLicens == null)
              { 
                MessageBox.Show("Selected License with ID = " + _selectedLicensId.ToString() + " is not found in the detained licenses list.",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return; 
             }

            llShowLicenseHistory.Enabled = true;

            btnRelease.Enabled = true;

            lblDetainID.Text = _DetainedLicens.DetainID.ToString();
            lblLicenseID.Text = _DetainedLicens.LicenseID.ToString();
            lblCreatedByUser.Text = clsUser.Find(_DetainedLicens.CreatedByUserID).UserName;
            lblApplicationID.Text = "[???]";
            lblDetainDate.Text = _DetainedLicens.DetainDate.ToShortDateString();
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
            lblFineFees.Text = _DetainedLicens.FineFees.ToString();
           
            int fineFees = 0;
            int appFees = 0;
            int.TryParse(lblFineFees.Text, out fineFees);
            int.TryParse(lblApplicationFees.Text, out appFees);
            lblTotalFees.Text = (fineFees + appFees).ToString();

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {

            _RleaseDetainedApplication = new clsApplications();
            _RleaseDetainedApplication.ApplicantPersonID = clsDriverscs.FindByDriverID(clsLicenses.Find(_DetainedLicens.LicenseID).DriverID).PersonID;
            _RleaseDetainedApplication.ApplicationDate = DateTime.Now;
            _RleaseDetainedApplication.ApplicationTypeID = (int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicsense;
            _RleaseDetainedApplication.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            _RleaseDetainedApplication.LastStatusDate = DateTime.Now;
            _RleaseDetainedApplication.PaidFees = Convert.ToInt32(lblApplicationFees.Text);
            _RleaseDetainedApplication.CreatedByUserID = DVLD.Classes.clsGlobal.CurrentUser.UserID;

            if(_RleaseDetainedApplication.Save())
            {
                lblApplicationID.Text = _RleaseDetainedApplication.ApplicationID.ToString();

                _DetainedLicens.ReleaseApplicationID = _RleaseDetainedApplication.ApplicationID;
                _DetainedLicens.ReleaseDate = DateTime.Now;
                _DetainedLicens.ReleasedByUserID = _RleaseDetainedApplication.CreatedByUserID;

                if(_DetainedLicens.Release())
                {
                    llShowLicenseInfo.Enabled = true;
                    ctrlDriverLicenseInfoWithFilter1.FilterEnabled=false;
                    btnRelease.Enabled = false;

                    MessageBox.Show("Selected Detained License has been released successfully.", "License Released",
                                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error: Could not release the detained license.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error: Could not create the release application.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo fr = new frmShowLicenseInfo(_DetainedLicens.LicenseID);
            fr.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frShowPersonLicenseHistory fr = new frShowPersonLicenseHistory(clsLicenses.Find(_DetainedLicens.LicenseID).DriverID);
            fr.ShowDialog();
        }
    }
}
