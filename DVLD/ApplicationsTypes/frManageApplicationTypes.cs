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

namespace DVLD.ApplicationsTypes
{
    public partial class frManageApplicationTypes : Form
    {
       private DataTable _dt = new DataTable();


        public frManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void ManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _dt = clsApplicationTypes.GetAllApplicationTypes();
            RecordsLEB.Text = _dt.Rows.Count.ToString();
            if (_dt.Rows.Count > 0)
            {
                ApplicationTypesTGV.DataSource = _dt;

                ApplicationTypesTGV.Columns[0].HeaderText = "ID";
                ApplicationTypesTGV.Columns[0].Width = 80;

                ApplicationTypesTGV.Columns[1].HeaderText = "Title";
                ApplicationTypesTGV.Columns[1].Width = 310;

                ApplicationTypesTGV.Columns[2].HeaderText = "Fees";
                ApplicationTypesTGV.Columns[2].Width = 110;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationType= Convert.ToInt32( ApplicationTypesTGV.CurrentRow.Cells[0].Value);
            frUpdateApplicationType fr = new frUpdateApplicationType(ApplicationType);
            fr.ShowDialog();
            ManageApplicationTypes_Load(null, null);//refresh data
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
