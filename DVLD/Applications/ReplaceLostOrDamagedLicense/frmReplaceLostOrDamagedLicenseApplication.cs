using DVLD.Licenses;
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

namespace DVLD.Applications.ReplaceLostOrDamagedLicense
{
    public partial class frmReplaceLostOrDamagedLicenseApplication : Form
    {
        private int _selectedLicenseId = -1;
        private clsLicenses _selectedLicense;
        private clsLicenses _replacementLicense;
        private clsApplications _replacementApplication;





        public frmReplaceLostOrDamagedLicenseApplication()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _Restvalues();

            if (obj < 1)
                return;
            _selectedLicenseId = obj;
            _selectedLicense = clsLicenses.Find(_selectedLicenseId);
            _replacementLicense = new clsLicenses();

            LoadLicenseInfo();
        }


        private void LoadLicenseInfo()
        {
           

            if (_selectedLicense == null)
                return;

            if (!_selectedLicense.IsActive)
            {
                MessageBox.Show("License Not Active. please select an active license ");
                return;
            }

            llShowLicenseHistory.Enabled = true;
            btnIssueReplacement.Enabled = true;

            lblOldLicenseID.Text = _selectedLicense.LicenseID.ToString();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = DVLD.Classes.clsGlobal.CurrentUser.UserName;
            lblApplicationFees.Text = _GetApplicationFees().ToString();



        }

        private void _Restvalues()
        {
            lblApplicationID.Text = "[???]";
            lblRreplacedLicenseID.Text = "[???]";
            lblApplicationDate.Text = "[??/??/????]";
            //lblApplicationFees.Text = "[$$$]";
            lblOldLicenseID.Text = "[???]";
            lblCreatedByUser.Text = DVLD.Classes.clsGlobal.CurrentUser.UserName;

            rbDamagedLicense.Checked = true;

            llShowLicenseHistory.Enabled = false;
            btnIssueReplacement.Enabled = false;
            llShowLicenseInfo.Enabled = false;
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblApplicationFees.Text = (_GetApplicationFees() == -1) ? "[$$$]" : _GetApplicationFees().ToString();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {

            lblApplicationFees.Text = (_GetApplicationFees() == -1) ? "[$$$]" : _GetApplicationFees().ToString();
        }

        private void frmReplaceLostOrDamagedLicenseApplication_Load(object sender, EventArgs e)
        {
            _Restvalues();
        }

        private float _GetApplicationFees()
        {
            if (rbDamagedLicense.Checked)
                return clsApplicationTypes.Find((int)clsApplications.enApplicationType.ReplaceDamagedDrivingLicense).Fees;

            else if (rbLostLicense.Checked)
                return clsApplicationTypes.Find((int)clsApplications.enApplicationType.ReplaceLostDrivingLicense).Fees;
            else
                return -1;
        }


        private int _GetApplicationTypeID()
        {
            if (rbDamagedLicense.Checked)
                return (int)clsApplications.enApplicationType.ReplaceDamagedDrivingLicense;
            else if (rbLostLicense.Checked)
                return (int)clsApplications.enApplicationType.ReplaceLostDrivingLicense;
            else
                return -1;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            _replacementApplication = new clsApplications();
            _replacementApplication.ApplicantPersonID = clsDriverscs.FindByDriverID(_selectedLicense.DriverID).PersonID;
            _replacementApplication.ApplicationDate = DateTime.Now;
            _replacementApplication.ApplicationTypeID = _GetApplicationTypeID();
            _replacementApplication.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            _replacementApplication.LastStatusDate = DateTime.Now;
            _replacementApplication.PaidFees = Convert.ToInt32(lblApplicationFees.Text);
            _replacementApplication.CreatedByUserID = DVLD.Classes.clsGlobal.CurrentUser.UserID;

            if (_replacementApplication.Save())
            {
                _replacementLicense.ApplicationID = _replacementApplication.ApplicationID;
                _replacementLicense.DriverID = _selectedLicense.DriverID;
                _replacementLicense.LicenseClass = _selectedLicense.LicenseClass;
                _replacementLicense.IssueDate = DateTime.Now;
                _replacementLicense.ExpiryDate = DateTime.Now.AddYears(clsLicenseClass.Find(3).DefaultValidityLength);
                _replacementLicense.IsActive = true;
                _replacementLicense.Note = null;
                _replacementLicense.PaidFees = 0;
                _replacementLicense.IssueReason = (_GetApplicationTypeID() == (int)clsApplications.enApplicationType.ReplaceLostDrivingLicense) ? clsLicenses.enReason.ReplacementForLost : clsLicenses.enReason.ReplacementForDamaged;
                _replacementLicense.CreatedByUserID = DVLD.Classes.clsGlobal.CurrentUser.UserID;

                if (_replacementLicense.save())
                {
                    _selectedLicense.IsActive = false;
                    if (!_selectedLicense.save())
                    {
                        MessageBox.Show("Failed to deactivate old license. Please check the license status and try again.");
                        return;
                    }

                    lblApplicationID.Text = _replacementApplication.ApplicationID.ToString();
                    lblRreplacedLicenseID.Text = _replacementLicense.LicenseID.ToString();
                    ctrlDriverLicenseInfoWithFilter1.EnableFilter(false);
                    gbReplacementFor.Enabled = false;
                    llShowLicenseInfo.Enabled = true;
                    MessageBox.Show("Replacement License Issued Successfully. New License ID: " + _replacementLicense.LicenseID.ToString());

                }
                else
                {
                    MessageBox.Show("Failed to issue replacement license. Please try again.");
                }

            }
            else
            {
                MessageBox.Show("Failed to create replacement application. Please try again.");
            }


        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frShowPersonLicenseHistory fr = new frShowPersonLicenseHistory(_selectedLicense.DriverID);
            fr.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo fr = new frmShowLicenseInfo(_replacementLicense.LicenseID);
            fr.ShowDialog();
        }





    }
}
