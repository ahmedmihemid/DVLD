using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
namespace DVLD.Licenses.Local_Licenses
{
    public partial class frmShowLicenseInfo : Form
    {
        private clsLicenses _License;
        public frmShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _License = clsLicenses.Find(LicenseID);
            ctrlDriverLicenseInfo1.LoadLicenseInfo(_License);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
