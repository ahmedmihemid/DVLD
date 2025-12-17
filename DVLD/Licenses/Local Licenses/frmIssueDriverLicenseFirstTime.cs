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
            _localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(localDrivingLicenseApplicationID);
            ctrlDrivingLicenseApplicationInfo1.LoadData(_localDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
        }







        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            _Driver = clsDriverscs.FindByPersonID(_localDrivingLicenseApplication.application.ApplicantPersonID);
            if (_Driver == null)
            {
                _Driver = new clsDriverscs();
                _Driver.PersonID = _localDrivingLicenseApplication.application.ApplicantPersonID;
                _Driver.CreatedByUserID = Classes.clsGlobal.CurrentUser.UserID;
                _Driver.CreatedDate = DateTime.Now;
                if (!_Driver.save())
                {
                    MessageBox.Show("Error in saving Driver information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            _License.ApplicationID = _localDrivingLicenseApplication.application.ApplicationID;
            _License.DriverID = _Driver.DriverID;   
            _License.LicenseClass = LicenseClass.Find(_localDrivingLicenseApplication.LicenseClassID);
            _License.IssueDate = DateTime.Now;
            _License.ExpiryDate = DateTime.Now.AddYears(_License.LicenseClass.DefaultValidityLength);
            if (!string.IsNullOrWhiteSpace(NotTB.Text))
            {
                _License.Note = NotTB.Text.Trim();
            }
            _License.PaidFees = _localDrivingLicenseApplication.application.PaidFees;
            _License.IsActive = true;
            _License.IssueReason = clsLicenses.enReason.FirstTime;
            _License.CreatedByUserID = Classes.clsGlobal.CurrentUser.UserID;

            if(_License.save())
            {
                 _localDrivingLicenseApplication.application.ApplicationStatus = clsApplications.enStatus.Completed;
                  if (!_localDrivingLicenseApplication.application.Save())
                  {
                      MessageBox.Show("Error updating application status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      return;
                  }

               
                MessageBox.Show("Driver License issued successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error in issuing Driver License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}
