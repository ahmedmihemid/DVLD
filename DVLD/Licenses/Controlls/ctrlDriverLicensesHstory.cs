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
        DataTable dtLocalLicenses;
        DataTable dtInternationalLicenses;

        private DataTable _dtLocalDriverLicenseHistory;
        private DataTable _dtInternationalDriverLicenseHistory;

        public ctrlDriverLicensesHstory()
        {
            InitializeComponent();
        }

        public void LoadDriverLicenseHistory(int driverID)
        {
            _driverID = driverID;
            dtLocalLicenses = clsLicenses.GetAllLocalLicenses(_driverID);
            dtInternationalLicenses = clsLicenses.GetAllInternationalLicenses(_driverID);
            _FillLocalDriverLicenseHistory();
            _FillInternationalDriverLicenseHistory();

        }

        private void _FillLocalDriverLicenseHistory()
        {
            _dtLocalDriverLicenseHistory = dtLocalLicenses.DefaultView.ToTable(false, "LicenseID", "ApplicationID",
                                                         "LicenseClass", "IssueDate", "ExpirationDate", "IsActive");
            dgvLocalLicensesHistory.DataSource = _dtLocalDriverLicenseHistory;
            lblLocalLicensesRecords.Text= _dtLocalDriverLicenseHistory.Rows.Count.ToString();
        }


        private void _FillInternationalDriverLicenseHistory()
        {
            _dtInternationalDriverLicenseHistory =  dtInternationalLicenses.DefaultView.ToTable(false, "LicenseID", "ApplicationID",
                                                         "LicenseClass", "IssueDate", "ExpirationDate", "IsActive");

            dgvInternationalLicensesHistory.DataSource = _dtInternationalDriverLicenseHistory;
        }
    }
}
