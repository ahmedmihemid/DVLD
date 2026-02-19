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

namespace DVLD.Licenses.NewFolder1.NewFolder1
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private int _InternationalLicenseID;
        private clsInternationalLicenses _InternationalLicense;
        private clsPerson _Person;


        public void LoadLicenseInfo(int internationalLicenseID)
        {
            if (internationalLicenseID < 0)
                return;
            DVLD_Buisness.clsInternationalLicenses _InternationalLicenseID = new DVLD_Buisness.clsInternationalLicenses();
            _InternationalLicenseID = DVLD_Buisness.clsInternationalLicenses.GetInternationalLicenseByID(internationalLicenseID);
            DVLD_Buisness.clsPerson _Person = DVLD_Buisness.clsPerson.Find(clsDriverscs.FindByDriverID(_InternationalLicenseID.DriverID).PersonID);
            if (_InternationalLicenseID != null && _Person != null)
            {
                lblFullName.Text = _Person.FullName;
                lblIssueDate.Text = _InternationalLicenseID.IssueDate.ToShortDateString();
                lblExpirationDate.Text = _InternationalLicenseID.ExpirationDate.ToShortDateString();
                lblInternationalLicenseID.Text = _InternationalLicenseID.InternationalLicenseID.ToString();
                lblLocalLicenseID.Text = _InternationalLicenseID.IssuedUsingLocalLicenseID.ToString();
                lblNationalNo.Text = _Person.NationalNo;
                lblGendor.Text = (_Person.Gendor==0) ? "Male" : "Female";
                lblApplicationID.Text = _InternationalLicenseID.ApplicationID.ToString();
                lblIsActive.Text = (_InternationalLicenseID.IsActive) ? "Yes" : "No";
                lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
                lblDriverID.Text = _InternationalLicenseID.DriverID.ToString();


                if (_Person.Gendor == 0)
                    pbPersonImage.Image = Resources.Male_512;
                else
                    pbPersonImage.Image = Resources.Female_512;

                string ImagePath = _Person.ImagePath;
                if (ImagePath != "")
                {
                    if (File.Exists(ImagePath))
                        pbPersonImage.ImageLocation = ImagePath;
                }





            }
        }



       
          
        

    }
}
