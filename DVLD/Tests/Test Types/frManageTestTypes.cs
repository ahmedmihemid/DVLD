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

namespace DVLD.Test_Types
{
    public partial class frManageTestTypes : Form
    {

        private DataTable _dtTestTypes;

        public frManageTestTypes()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _LoadTestTypes();
        }


        private void _LoadTestTypes()
        {
            DVLD_Buisness.clsTestTypes testTypes = new DVLD_Buisness.clsTestTypes();
            _dtTestTypes = testTypes.GetAllTestTypes();
            TestTypesTGV.DataSource = _dtTestTypes;
            RecordsLEB.Text=_dtTestTypes.Rows.Count.ToString();

            if (_dtTestTypes.Rows.Count > 0)
            {
                TestTypesTGV.Columns["TestTypeID"].HeaderText = "ID";
                TestTypesTGV.Columns["TestTypeID"].Width = 60;
                TestTypesTGV.Columns["TestTypeTitle"].HeaderText = "Title";
                TestTypesTGV.Columns["TestTypeTitle"].Width = 180; 
                TestTypesTGV.Columns["TestTypeDescription"].HeaderText = "Description";
                TestTypesTGV.Columns["TestTypeDescription"].Width =350;
                TestTypesTGV.Columns["TestTypeFees"].HeaderText = "Fees";
                TestTypesTGV.Columns["TestTypeFees"].Width = 100;
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frUpdateTestTypes fr = new frUpdateTestTypes((clsTestTypes.enTestType)Convert.ToInt32(TestTypesTGV.CurrentRow.Cells[0].Value));
            fr.ShowDialog();
            _LoadTestTypes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
