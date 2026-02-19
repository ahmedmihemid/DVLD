using DVLD.Licenses.International_Licenses;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Applications.NewFolder1
{
    public partial class frmNewInternationalLicenseApplication : Form
    {

        private int _LicenseID;
        private clsInternationalLicenses _InternationalLicenses;
      


        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            if (obj < 0) 
                return;
            _LicenseID = obj;
            _InternationalLicenses = new clsInternationalLicenses();
            _InternationalLicenses = clsInternationalLicenses.GetInternationalLicenseByLocalLicenseIDint(_LicenseID);

          
            LoadLicenseInfo();

        }

        private void LoadLicenseInfo()
        {

            _Restvalues();

            if (_InternationalLicenses == null )
            {
                _setDefaultValues();
            }
            else
            {
                lblApplicationID.Text = _InternationalLicenses.ApplicationID.ToString();
                lblInternationalLicenseID.Text = _InternationalLicenses.InternationalLicenseID.ToString();
                lblApplicationDate.Text =clsApplications.Find(_InternationalLicenses.ApplicationID).ApplicationDate.ToShortDateString();
                lblLocalLicenseID.Text = _InternationalLicenses.IssuedUsingLocalLicenseID.ToString();
                lblIssueDate.Text = _InternationalLicenses.IssueDate.ToShortDateString();
                lblExpirationDate.Text = _InternationalLicenses.ExpirationDate.ToShortDateString();
                lblFees.Text = clsApplications.Find(_InternationalLicenses.ApplicationID).PaidFees.ToString();
                lblCreatedByUser.Text = clsUser.Find(_InternationalLicenses.CreatedByUserID).UserName;

                btnIssueLicense.Enabled = false;
                llShowLicenseInfo.Enabled = true;
                llShowLicenseHistory.Enabled = true;

                MessageBox.Show("An international license has already been issued using this local license.");
            }
    
        }

        private void _setDefaultValues()
        {   

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblLocalLicenseID.Text = _LicenseID.ToString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblExpirationDate.Text = DateTime.Now.AddYears(clsLicenseClass.Find(3).DefaultValidityLength).ToShortDateString();
            lblFees.Text = clsApplicationTypes.Find(6).Fees.ToString();
            lblCreatedByUser.Text = DVLD.Classes.clsGlobal.CurrentUser.UserName;

            if(!clsLicenses.Find(_LicenseID).IsActive)
            { 
                btnIssueLicense.Enabled = false;
                //MessageBox.Show("The selected local license is not active. Please select an active local license to issue an international license.");
            }
            else
                btnIssueLicense.Enabled = false;

            llShowLicenseInfo.Enabled = false;
            llShowLicenseHistory.Enabled = true;

        }


        private void _Restvalues()
        {
            lblApplicationID.Text = "[???]";
            lblInternationalLicenseID.Text = "[???]";
            lblApplicationDate.Text = "[??/??/????]";
            lblLocalLicenseID.Text = "[???]";
            lblIssueDate.Text = "[??/??/????]";
            lblExpirationDate.Text = "[??/??/????]";
            lblFees.Text = "[$$$]";
            lblCreatedByUser.Text = "[???]";
            btnIssueLicense.Enabled = false;
            llShowLicenseInfo.Enabled = false;
            llShowLicenseHistory.Enabled = false;
        }


        private void btnIssueLicense_Click(object sender, EventArgs e)
        {

            clsApplications InternationalLicensApplications = new clsApplications();

            InternationalLicensApplications.ApplicantPersonID = clsApplications.Find(clsLicenses.Find(_LicenseID).ApplicationID).ApplicantPersonID;
            InternationalLicensApplications.ApplicationDate = DateTime.Now;
            InternationalLicensApplications.ApplicationTypeID = (int)clsApplications.enApplicationType.NewInternationalLicense;
            InternationalLicensApplications.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            InternationalLicensApplications.LastStatusDate= DateTime.Now;
            InternationalLicensApplications.PaidFees = Convert.ToInt32(lblFees.Text);
            InternationalLicensApplications.CreatedByUserID = DVLD.Classes.clsGlobal.CurrentUser.UserID;

            if(InternationalLicensApplications.Save())
            {
                _InternationalLicenses= new clsInternationalLicenses();
                _InternationalLicenses.ApplicationID = InternationalLicensApplications.ApplicationID;
                _InternationalLicenses.DriverID = clsLicenses.Find(_LicenseID).DriverID;
                _InternationalLicenses.IssuedUsingLocalLicenseID = Convert.ToInt32(lblLocalLicenseID.Text);
                _InternationalLicenses.IssueDate = DateTime.Now;
                _InternationalLicenses.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.Find(3).DefaultValidityLength);
                _InternationalLicenses.IsActive = true;
                _InternationalLicenses.CreatedByUserID = DVLD.Classes.clsGlobal.CurrentUser.UserID;

                if (_InternationalLicenses.Save())
                {
                    lblApplicationID.Text = _InternationalLicenses.ApplicationID.ToString();
                    lblInternationalLicenseID.Text = _InternationalLicenses.InternationalLicenseID.ToString();
                    llShowLicenseInfo.Enabled = true;


                    MessageBox.Show("International License Issued Successfully");
                    return;
                }
                else
                    MessageBox.Show("Failed to issue international license");
            }
                else
                    MessageBox.Show("Failed to save application");



        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frShowPersonLicenseHistory fr = new frShowPersonLicenseHistory(clsLicenses.Find(_LicenseID).DriverID);
            fr.ShowDialog();

            LoadLicenseInfo();

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo fr = new frmShowInternationalLicenseInfo(_InternationalLicenses.InternationalLicenseID);
            fr.ShowDialog();
            LoadLicenseInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
