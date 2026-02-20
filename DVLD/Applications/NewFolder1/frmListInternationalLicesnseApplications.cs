using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.NewFolder1
{
    public partial class frmListInternationalLicesnseApplications : Form
    {
        public frmListInternationalLicesnseApplications()
        {
            InitializeComponent();
        }

        private DataTable _dtInternationalLicenses;

        private void frmListInternationalLicesnseApplications_Load(object sender, EventArgs e)
        {
            _dtInternationalLicenses = DVLD_Buisness.clsInternationalLicenses.GetAllInternationalLicenses();
            dgvInternationalLicenses.DataSource = _dtInternationalLicenses;
            lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();

            cbFilterBy.SelectedIndex = 0;
            cbIsReleased.SelectedIndex = 0;

            if (dgvInternationalLicenses.Rows.Count>0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "IntLicense ID";
                dgvInternationalLicenses.Columns[0].Width = 80;
                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 80;
                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 80;
                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[3].Width = 80;
                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 250;
                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 250;
                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 80;
            }

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string filterValue = "";
            switch (cbFilterBy.Text)
            {
                case "International License ID":
                    filterValue = "InternationalLicenseID";
                    break;
                case "Application ID":
                    filterValue = "ApplicationID";
                    break;
                case "Driver ID":
                    filterValue = "DriverID";
                    break;
                case "Local License ID":
                    filterValue = "IssuedUsingLocalLicenseID";
                    break;
                case "Is Active":
                    filterValue = "IsActive";
                    break;
                Default:
                    filterValue = "None";
                    break;
            }

            if (filterValue == "None" || txtFilterValue.Text.Trim() == "")
            {
                _dtInternationalLicenses.DefaultView.RowFilter = "";
                lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();
            }
            else if (filterValue == "IsActive")
            {
                cbIsReleased.Visible = true;
                txtFilterValue.Visible = false;
            }
            else
            {
                _dtInternationalLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterValue, txtFilterValue.Text.Trim());
                lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();

            }




        }


        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterValue = "";
            switch (cbIsReleased.Text)
            {
                case "Yes":
                    filterValue = "Yes";
                    break;

                case "No":
                    filterValue = "No";
                    break;

                Default:
                    filterValue = "ALL";
                    break;
            }

            if (filterValue == "Yes")
            {
                _dtInternationalLicenses.DefaultView.RowFilter = string.Format("IsActive = 'True'");
                lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();
            }
            else if (filterValue == "No")
            {
                _dtInternationalLicenses.DefaultView.RowFilter = string.Format("IsActive = 'False'");
                lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();
            }
            else
            {
                _dtInternationalLicenses.DefaultView.RowFilter = "";
                lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            cbIsReleased.SelectedIndex = 0;

            if (cbFilterBy.Text == "None")
            {
                cbIsReleased.Visible = false;
                txtFilterValue.Visible = false;
                return;
            }

            if (cbFilterBy.Text == "Is Active")
            {
                cbIsReleased.Visible = true;
                txtFilterValue.Visible = false;
                return;
            }

                cbIsReleased.Visible = false;
                txtFilterValue.Visible = true;
                txtFilterValue.Focus();
        }

        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication fr = new frmNewInternationalLicenseApplication();
            fr.ShowDialog();
            frmListInternationalLicesnseApplications_Load(null, null);
        }
    }
}
