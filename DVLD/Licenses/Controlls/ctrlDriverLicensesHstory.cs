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
            dtInternationalLicenses = clsInternationalLicenses.GetAllInternationalLicenses(_driverID);


            _FillLocalDriverLicenseHistory();
            _FillInternationalDriverLicenseHistory();

        }


        







        private void _FillLocalDriverLicenseHistory()
        {
            _dtLocalDriverLicenseHistory = dtLocalLicenses.DefaultView.ToTable(false, "LicenseID", "ApplicationID",
                                                         "LicenseClass", "IssueDate", "ExpirationDate", "IsActive");
            dgvLocalLicensesHistory.DataSource = _dtLocalDriverLicenseHistory;
            lblLocalLicensesRecords.Text= _dtLocalDriverLicenseHistory.Rows.Count.ToString();
            if (_dtLocalDriverLicenseHistory.Rows.Count > 0)
            {
                dgvLocalLicensesHistory.Columns["LicenseID"].HeaderText = "License ID";
                dgvLocalLicensesHistory.Columns["ApplicationID"].HeaderText = "Application ID";
                dgvLocalLicensesHistory.Columns["LicenseClass"].HeaderText = "License Class";
                dgvLocalLicensesHistory.Columns["IssueDate"].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns["IssueDate"].Width = 150;
                dgvLocalLicensesHistory.Columns["ExpirationDate"].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns["ExpirationDate"].Width = 150;
                dgvLocalLicensesHistory.Columns["IsActive"].HeaderText = "Is Active";
            }


        }


        private void _FillInternationalDriverLicenseHistory()
        {
            _dtInternationalDriverLicenseHistory =  dtInternationalLicenses.DefaultView.ToTable(false, "InternationalLicenseID", "ApplicationID",
                                                         "IssuedUsingLocalLicenseID", "IssueDate", "ExpirationDate", "IsActive");

            dgvInternationalLicensesHistory.DataSource = _dtInternationalDriverLicenseHistory;
            lblInternationalLicensesRecords.Text = _dtInternationalDriverLicenseHistory.Rows.Count.ToString();

            if (_dtInternationalDriverLicenseHistory.Rows.Count > 0)
            {
                dgvInternationalLicensesHistory.Columns["InternationalLicenseID"].HeaderText = "Int.License ID";
                dgvInternationalLicensesHistory.Columns["ApplicationID"].HeaderText = "Application ID";
                dgvInternationalLicensesHistory.Columns["IssuedUsingLocalLicenseID"].HeaderText = "L.License ID";
                dgvInternationalLicensesHistory.Columns["IssueDate"].HeaderText = "Issue Date";
                dgvInternationalLicensesHistory.Columns["IssueDate"].Width = 150;
                dgvInternationalLicensesHistory.Columns["ExpirationDate"].HeaderText = "Expiration Date";
                dgvInternationalLicensesHistory.Columns["ExpirationDate"].Width = 150;

                dgvInternationalLicensesHistory.Columns["IsActive"].HeaderText = "Is Active";
            }
        }
    }
}
