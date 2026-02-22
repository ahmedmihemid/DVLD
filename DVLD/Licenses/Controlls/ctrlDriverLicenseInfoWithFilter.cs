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

namespace DVLD.Licenses.Controlls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {

        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }


        private int _LicensesID;
        private clsLicenses _LicenseInfo;

        public int LicensesID { get => _LicensesID;  }

        public ctrlDriverLicenseInfoWithFilter()
        {

            InitializeComponent();
            
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            _LicensesID= Convert.ToInt32(txtLicenseID.Text);
            _LicenseInfo = clsLicenses.Find(_LicensesID);

            if(_LicenseInfo == null)
            {
                MessageBox.Show("License Not Found");
                return;
            }

            //if(!_LicenseInfo.IsActive)
            //{
            //   MessageBox.Show("License Not Active");
            //    return;
            //}


            ctrlDriverLicenseInfo1.LoadLicenseInfo(_LicenseInfo);
            if(OnLicenseSelected != null)
            {
                PersonSelected(_LicensesID);
            }

        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
