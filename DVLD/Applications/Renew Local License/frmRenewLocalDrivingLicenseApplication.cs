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

namespace DVLD.Applications.NewFolder1
{
    public partial class frmRenewLocalDrivingLicenseApplication : Form
    {

        private int _LicenseID;
        private clsLicenses _CurrentLicenses;
        private clsLicenses _RenewalLicenses;
        private clsApplications _ReNewApplication;





        public frmRenewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            if (obj < 0)
                return;

            _LicenseID= obj;
            _CurrentLicenses = clsLicenses.Find(_LicenseID);
            _RenewalLicenses = new clsLicenses();
            LoadLicenseInfo();
        }

        private void LoadLicenseInfo()
        {
            _Restvalues();

            if (_CurrentLicenses == null)
                return;

            llShowLicenseHistory.Enabled = true;


            if (!_CurrentLicenses.IsActive)
            {
              MessageBox.Show("The selected license is not active. Please select an active license to proceed with the renewal application.", "Inactive License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (_CurrentLicenses.ExpiryDate < DateTime.Now)
            {
                lblApplicationID.Text = "[???]";
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblIssueDate.Text = DateTime.Now.ToShortDateString();
                lblExpirationDate.Text = DateTime.Now.AddYears(clsLicenseClass.Find(3).DefaultValidityLength).ToShortDateString();
                lblApplicationFees.Text = clsApplicationTypes.Find(2).Fees.ToString();
                lblLicenseFees.Text = clsApplicationTypes.Find(1).Fees.ToString(); ;
                lblRenewedLicenseID.Text = "[???]";
                lblOldLicenseID.Text = _CurrentLicenses.LicenseID.ToString();
                lblCreatedByUser.Text = DVLD.Classes.clsGlobal.CurrentUser.UserName;
                lblTotalFees.Text = (Convert.ToInt32(lblApplicationFees.Text) + Convert.ToInt32(lblLicenseFees.Text)).ToString();
                txtNotes.Text = string.Empty;

                btnRenewLicense.Enabled = true;
            }
            else
            {
                 MessageBox.Show("The selected license is not yet expired. Please select an expired license to proceed with the renewal application.", "License Not Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
            }


        }

        private void _Restvalues()
        {
            lblApplicationID.Text = "[???]";
            lblApplicationDate.Text = "[??/??/????]";
            lblIssueDate.Text = "[??/??/????]";
            lblExpirationDate.Text = "[??/??/????]";
            lblApplicationFees.Text = "[$$$]";
            lblLicenseFees.Text = "[$$$]";
            lblRenewedLicenseID.Text = "[???]";
            lblOldLicenseID.Text = "[???]";
            lblCreatedByUser.Text = "[???]";
            lblTotalFees.Text = "[$$$]";
            txtNotes.Text = string.Empty;


        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            _ReNewApplication = new clsApplications();
            _ReNewApplication.ApplicantPersonID = clsDriverscs.FindByDriverID(_CurrentLicenses.DriverID).PersonID;
            _ReNewApplication.ApplicationDate = DateTime.Now;
            _ReNewApplication.ApplicationTypeID = (int)clsApplications.enApplicationType.RenewDrivingLicense;
            _ReNewApplication.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            _ReNewApplication.LastStatusDate = DateTime.Now;
            _ReNewApplication.PaidFees = Convert.ToInt32(lblTotalFees.Text);
            _ReNewApplication.CreatedByUserID = DVLD.Classes.clsGlobal.CurrentUser.UserID;

            if (_ReNewApplication.Save())
            {
               
                _RenewalLicenses.ApplicationID= _ReNewApplication.ApplicationID;
                _RenewalLicenses.DriverID = _CurrentLicenses.DriverID;
                _RenewalLicenses.LicenseClass = _CurrentLicenses.LicenseClass;
                _RenewalLicenses.IssueDate = DateTime.Now;
                _RenewalLicenses.ExpiryDate = DateTime.Now.AddYears(clsLicenseClass.Find(3).DefaultValidityLength);
                _RenewalLicenses.IsActive = true;
                if (!string.IsNullOrWhiteSpace(txtNotes.Text))
                {
                    _RenewalLicenses.Note = txtNotes.Text.Trim();
                }
                _RenewalLicenses.PaidFees = Convert.ToInt32(lblLicenseFees.Text);
                _RenewalLicenses.IssueReason = clsLicenses.enReason.Renew;
                _RenewalLicenses.CreatedByUserID = DVLD.Classes.clsGlobal.CurrentUser.UserID;


                if (_RenewalLicenses.save())
                {
                    _CurrentLicenses.IsActive = false;

                    if (!_CurrentLicenses.save())
                    {
                       MessageBox.Show("An error occurred while deactivating the old license. Please check the license status and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       return;
                    }

                    llShowLicenseInfo.Enabled = true;
                    btnRenewLicense.Enabled = false;

                    lblApplicationID.Text = _ReNewApplication.ApplicationID.ToString();
                    lblRenewedLicenseID.Text = _RenewalLicenses.LicenseID.ToString();

                    MessageBox.Show("License renewal successful! The renewed license has been issued and the old license has been deactivated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("An error occurred while saving the renewed license. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                } 

            }
            else
            {
                MessageBox.Show("An error occurred while saving the renewal application. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frShowPersonLicenseHistory fr = new frShowPersonLicenseHistory(_CurrentLicenses.DriverID);
            fr.ShowDialog();

            //LoadLicenseInfo();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo fr = new frmShowLicenseInfo(_RenewalLicenses.LicenseID);
            fr.ShowDialog();

            //LoadLicenseInfo();

        }
    }
}
