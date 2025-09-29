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
    public partial class frUpdateTestTypes : Form
    {
        private int _TestTypeID;
        private clsTestTypes _testTypes;
        public frUpdateTestTypes(int testTypeID)
        {
            InitializeComponent();
            _TestTypeID = testTypeID;
        }

        private void frUpdateTestTypes_Load(object sender, EventArgs e)
        {
            _LoudApplicationTypeData();
        }

        private void _LoudApplicationTypeData()
        {
            _testTypes = clsTestTypes.Find(_TestTypeID);
            if (_testTypes != null)
            {
                IdLEB.Text = (_testTypes.TestTypeID).ToString();
                TitleTB.Text = _testTypes.TestTypeTitle;
                TestTypeDescriptionTB.Text = _testTypes.TestTypeDescription;
                FeesTB.Text = (_testTypes.TestTypeFees).ToString();
            }
            else
            {
                MessageBox.Show("Test Type not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_testTypes != null)
            {   
                _testTypes.TestTypeTitle = TitleTB.Text;
                _testTypes.TestTypeDescription = TestTypeDescriptionTB.Text;
                _testTypes.TestTypeFees = Convert.ToDecimal(FeesTB.Text);

                if (_testTypes.save())
                {
                    MessageBox.Show("Test Type updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update Test Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Test Type data is not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}