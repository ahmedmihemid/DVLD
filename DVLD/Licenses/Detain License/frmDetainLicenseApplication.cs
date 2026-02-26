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

namespace DVLD.Licenses.Detain_License
{
    public partial class frmDetainLicenseApplication : Form
    {
        private int _selectedLicenseId = -1;
        private clsLicenses _selectedLicenseInfo;
        private clsDetainedLicens _DetainedLicens;




        public frmDetainLicenseApplication()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _Restvalues();

            if (obj < 0)
              return;

            _selectedLicenseId = obj;
            _selectedLicenseInfo= clsLicenses.Find(_selectedLicenseId);
            _DetainedLicens = new clsDetainedLicens();
            _LoadInfo();
        }

        private void _Restvalues()
        {
            lblDetainID.Text = "[???]";
            lblLicenseID.Text = "[???]";
            lblCreatedByUser.Text = "[???]";
            lblDetainDate.Text = "[??/??/????]";
            txtFineFees.Text = string.Empty;

            llShowLicenseHistory.Enabled = false;
            btnDetain.Enabled = false;
            llShowLicenseInfo.Enabled = false ;
        }

        
        private void _LoadInfo()
        {
            if (_selectedLicenseInfo == null)
                return;

            llShowLicenseHistory.Enabled = true;

            if (clsDetainedLicens.LicenseIsExist(_selectedLicenseId))
            {
                MessageBox.Show("<eofjodsjfofjsf");
                return;
            }

            btnDetain.Enabled = true;

            lblLicenseID.Text = _selectedLicenseId.ToString();
            lblCreatedByUser.Text = DVLD.Classes.clsGlobal.CurrentUser.UserName;
            lblDetainDate.Text = DateTime.Now.ToShortDateString();

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            _DetainedLicens.LicenseID = _selectedLicenseInfo.LicenseID;
            _DetainedLicens.DetainDate = DateTime.Now;
            _DetainedLicens.FineFees = Convert.ToInt32(txtFineFees.Text);
            _DetainedLicens.CreatedByUserID = DVLD.Classes.clsGlobal.CurrentUser.UserID;
            _DetainedLicens.IsReleased = false;

            if(_DetainedLicens.Detain())
            {
                lblDetainID.Text = _DetainedLicens.DetainID.ToString();
                llShowLicenseInfo.Enabled = true;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;

                btnDetain.Enabled = false;
                MessageBox.Show("License Detained Successfully with ID = " + _DetainedLicens.DetainID.ToString(),
                          "License Detained", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: License Detain Failed!", "Error",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fine Fees No is required.");
            }
            else if (!Classes.clsValidatoin.IsNumber(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fine Fees  Format!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFineFees, null);
            }

        }

        private void frmDetainLicenseApplication_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo fr = new frmShowLicenseInfo(_selectedLicenseInfo.LicenseID);
            fr.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frShowPersonLicenseHistory fr = new frShowPersonLicenseHistory(_selectedLicenseInfo.DriverID);
            fr.ShowDialog();
        }
    }
}
