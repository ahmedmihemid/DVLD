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
using DVLD_Buisness;

namespace DVLD.ApplicationsTypes
{
    public partial class frUpdateApplicationType : Form
    {

        private int _ApplicationTypeID;
        private clsApplicationTypes _applicationType;


        public frUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        }

        private void frUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _LoudApplicationTypeData();
        }


        private void _LoudApplicationTypeData()
        {
            _applicationType = clsApplicationTypes.Find(_ApplicationTypeID);
            if (_applicationType != null)
            {
               IdLEB.Text = (_applicationType.ID).ToString();
               TitleTB.Text = _applicationType.Title;
               FeesTB.Text = (_applicationType.Fees).ToString();
            }
            else
            {
                MessageBox.Show("Application Type not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            _applicationType.ID = Convert.ToInt32(IdLEB.Text);
            _applicationType.Title = TitleTB.Text;
            _applicationType.Fees = Convert.ToSingle(FeesTB.Text);

            if (_applicationType.save())
            {
                MessageBox.Show("Application Type updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update Application Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TitleTB_Validating(object sender, CancelEventArgs e)
      {
            if(string.IsNullOrWhiteSpace(TitleTB.Text.Trim()))
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
