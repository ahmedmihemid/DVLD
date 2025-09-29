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
               IdLEB.Text = (_applicationType.ApplicationTypeID).ToString();
               TitleTB.Text = _applicationType.ApplicationTypeTitle;
               FeesTB.Text = (_applicationType.ApplicationFees).ToString();
            }
            else
            {
                MessageBox.Show("Application Type not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _applicationType.ApplicationTypeID = Convert.ToInt32(IdLEB.Text);
            _applicationType.ApplicationTypeTitle = TitleTB.Text;
            _applicationType.ApplicationFees = Convert.ToDecimal(FeesTB.Text);

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
    }
}
