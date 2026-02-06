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
            DataTable dtDrivers = DVLD_Buisness.clsDriverscs.GetAllDrivers();
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

    }
}
