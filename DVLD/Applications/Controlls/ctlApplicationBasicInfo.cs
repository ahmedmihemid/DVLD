using DVLD.People;
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
using static System.Net.Mime.MediaTypeNames;


namespace DVLD.Applications.Controlls
{
    public partial class ctlApplicationBasicInfo : UserControl
    {


        private clsApplications _Applications;
        private int _ApplicationID = -1;

        public ctlApplicationBasicInfo()
        {
            InitializeComponent();

        }


        public void LoadData(int ApplicationID)
        {
            _ApplicationID = ApplicationID;
            _Applications = clsApplications.Find(_ApplicationID);

            if (_Applications == null)
            {
                MessageBox.Show("Application Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ReastDefaultsData();
            }
            else
            {
                _FillData();
            }
        }

        private void _FillData()
        {

            lblApplicationID.Text = _Applications.ApplicationID.ToString();
            lblStatus.Text = _Applications.ApplicationStatus.ToString();
            lblFees.Text = _Applications.PaidFees.ToString();
            lblType.Text = clsApplicationTypes.Find(_Applications.ApplicationTypeID).Title;
            lblApplicant.Text = clsPerson.Find(_Applications.ApplicantPersonID).FullName;
            lblDate.Text = _Applications.ApplicationDate.ToString();
            lblStatusDate.Text = _Applications.LastStatusDate.ToString();
            lblCreatedByUser.Text = clsUser.Find(_Applications.CreatedByUserID).UserName;

        }

        private void _ReastDefaultsData()
        {
            lblApplicationID.Text = "[???]";
            lblStatus.Text = "[???]";
            lblFees.Text = "[???]";
            lblType.Text = "[???]";
            lblApplicant.Text = "[???]";
            lblDate.Text = "[???]";
            lblStatusDate.Text = "[???]";
            lblCreatedByUser.Text = "[???]";
        }

        private void ctlApplicationBasicInfo_Load(object sender, EventArgs e)
        {
            _ReastDefaultsData();
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frPersonDetails fr = new frPersonDetails(_Applications.ApplicantPersonID);
            fr.ShowDialog();
            LoadData(_ApplicationID);
        }




    }
}
