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

namespace DVLD.Licenses.Controlls
{
    public partial class ctrlDriverLicensesHstory : UserControl
    {
        private int _driverID;
        DataTable dtLicenses;

        private DataTable _dtLocalDriverLicenseHistory;

        public ctrlDriverLicensesHstory()
        {
            InitializeComponent();
        }

        public void LoadDriverLicenseHistory(int driverID)
        {
            _driverID= driverID;
            dtLicenses = clsLicenses.GetAllLocalLicenses(_driverID);
            _FillLocalDriverLicenseHistory();



        }

        private void _FillLocalDriverLicenseHistory()
        {
            _dtLocalDriverLicenseHistory = dtLicenses.DefaultView.ToTable(false, "LicenseID", "ApplicationID",
                                                         "LicenseClass", "IssueDate", "ExpirationDate", "IsActive");
            dgvLocalLicensesHistory.DataSource = _dtLocalDriverLicenseHistory;




        }
    }
}
