using DVLD.Licenses.Local_Licenses;
using DVLD.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.NewFolder1
{
    public partial class frmListDrivers : Form
    {

        private DataTable dtDrivers;
        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            LoadDrivers();
        }

        private void LoadDrivers()
        {
            cbFilterBy.SelectedIndex = 0;
            dtDrivers = DVLD_Buisness.clsDriverscs.GetAllDrivers();
            dgvDrivers.DataSource = dtDrivers;
            lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();

            if(dtDrivers!=null)
            {
                dgvDrivers.Columns[0].HeaderText="Driver ID";
                dgvDrivers.Columns[0].Width = 85;
                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[1].Width = 85;
                dgvDrivers.Columns[2].HeaderText = "National No";
                dgvDrivers.Columns[2].Width = 85;
                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].Width = 250;
                dgvDrivers.Columns[4].HeaderText = "Date";
                dgvDrivers.Columns[4].Width = 190;
                dgvDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvDrivers.Columns[5].Width = 85;

            }


        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible=(cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }


        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string filterExpression = "";

            switch (cbFilterBy.Text)
            {

                case "Driver ID":
                    filterExpression = "DriverID";
                    break;
                case "Person ID":
                    filterExpression = "PersonID";
                    break;
                case "National No.":
                    filterExpression = "NationalNo";
                    break;
                case "Full Name":
                    filterExpression = "FullName";
                    break;
                default:
                    filterExpression = "None";
                    break;

            }

            if (filterExpression == "None" || txtFilterValue.Text.Trim()=="")
            {
                dtDrivers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
                return;
            }

            if (filterExpression == "DriverID" || filterExpression == "PersonID")
            {
                dtDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterExpression, txtFilterValue.Text.Trim());
            }
            else
            {
                dtDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterExpression, txtFilterValue.Text.Trim());
            }

            lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
            {
                //allow only numbers and control characters (like backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // ignore the input
                }
            }
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)dgvDrivers.CurrentRow.Cells[1].Value;
            frPersonDetails fr = new frPersonDetails(personID);
            fr.ShowDialog();
            LoadDrivers();
        }

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is under development.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvDrivers.CurrentRow.Cells[0].Value;
            frShowPersonLicenseHistory fr = new frShowPersonLicenseHistory(DriverID);
            fr.ShowDialog();
            LoadDrivers();
        }
    }
}
