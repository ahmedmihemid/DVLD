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
        private clsTestTypes.enTestType _TestTypeID;
        private clsTestTypes _testTypes;
        public frUpdateTestTypes(clsTestTypes.enTestType testTypeID)
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
                IdLEB.Text = ((_testTypes.ID)).ToString();
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
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Please correct the validation errors.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (_testTypes != null)
            {   
                _testTypes.TestTypeTitle = TitleTB.Text;
                _testTypes.TestTypeDescription = TestTypeDescriptionTB.Text;
                _testTypes.TestTypeFees = Convert.ToSingle(FeesTB.Text);

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

        private void TitleTB_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TitleTB.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(TitleTB, "Title cannot be empty.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TitleTB, "");
            }
        }

        private void TestTypeDescriptionTB_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TestTypeDescriptionTB.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(TestTypeDescriptionTB, "Description cannot be empty.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TestTypeDescriptionTB, "");
            }
        }

        private void FeesTB_Validating(object sender, CancelEventArgs e)
        {
            string input = FeesTB.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                e.Cancel = true;
                errorProvider1.SetError(FeesTB, "Fees is required.");
            }
            else if (!Classes.clsValidatoin.IsNumber(input))
            {
                e.Cancel = true;
                errorProvider1.SetError(FeesTB, "Fees must be a valid number.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(FeesTB, "");
            }

        }
    }
}