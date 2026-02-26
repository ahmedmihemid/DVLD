using DVLD.Properties;
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
using System.IO;

namespace DVLD.Licenses.Local_Licenses.Controlls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        private clsDriverscs _Driverscs;
        private clsLicenses _license;
        private int _licenseID;

        public int licenseID
        {
            get { return _licenseID; }
        }

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
            _Driverscs = new clsDriverscs();
            _license = new clsLicenses();
        }

        public void LoadLicenseInfo(int licenseID)
        {
            _licenseID=licenseID;
            _license = clsLicenses.Find(_licenseID);
            if(_license == null)
            {
                MessageBox.Show("No License with LicenseID = " + licenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }

            _Driverscs = clsDriverscs.FindByDriverID(_license.DriverID);
            _FillLicenseInfo();
        }

        private void _FillLicenseInfo()
        {
            lblLicenseID.Text = _license.LicenseID.ToString();
            lblNationalNo.Text = _Driverscs.PersonInfo.NationalNo;
            lblGendor.Text = _Driverscs.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = _Driverscs.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _license.DriverID.ToString();
            lblFullName.Text = _Driverscs.PersonInfo.FullName;
            lblClass.Text = _license.LicenseClass.ClassName;
            lblIssueDate.Text = _license.IssueDate.ToShortDateString();
            lblExpirationDate.Text = _license.ExpiryDate.ToShortDateString();
            lblNotes.Text = _license.Note;
            lblIsActive.Text = _license.IsActive ? "Yes" : "No";
            lblIssueReason.Text = _license.IssueReason.ToString();
            lblIsDetained.Text = (clsDetainedLicens.LicenseIsExist(_license.LicenseID)) ? "Yes" : "No";// To be implemented
            _LoadPersonImage();
        }

        private void _LoadPersonImage()
        {
            if (_Driverscs.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _Driverscs.PersonInfo.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        public void clear()
        {
            lblLicenseID.Text = "[???]";
            lblNationalNo.Text = "[???]"; 
            lblGendor.Text = "[???]"; 
            lblDateOfBirth.Text = "[??/??/????]";
            lblDriverID.Text = "[???]"; 
            lblFullName.Text = "[???]";
            lblClass.Text = "[???]";
            lblIssueDate.Text = "[??/??/????]";
            lblExpirationDate.Text = "[??/??/????]";
            lblNotes.Text = "[???]";
            lblIsActive.Text ="[???]";
            lblIssueReason.Text = "[??/??/????]";
            lblIsDetained.Text = "[???]";
        }



    }
}
