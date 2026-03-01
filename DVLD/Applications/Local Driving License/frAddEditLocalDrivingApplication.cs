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
using DVLD.Classes;

namespace DVLD.Licenses
{
    public partial class frAddEditLocalDrivingApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        private int oldLicenseClassID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frAddEditLocalDrivingApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }

        public frAddEditLocalDrivingApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frAddEditLocalDrivingApplication_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if(_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void _FillLicenseClassesInComoboBox()
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in dt.Rows)
            {
                LicensesClassCB.Items.Add(row["ClassName"]);
            }
        }

        private void _ResetDefualtValues()
        {

            //this will initialize the reset the defaule values
            _FillLicenseClassesInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                TitleLEB.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                ctrlPersonCardWithFilter1.FilterFocus();
                tabPage2.Enabled = false;

                LicensesClassCB.SelectedIndex = 2;
                LicensesFeesLEB.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewDrivingLicense).Fees.ToString();
                ApplicationDateLEB.Text = DateTime.Now.ToShortDateString();
                CreateByLEB.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {

                TitleLEB.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                
                tabPage2.Enabled = true;
                btnSave.Enabled = true;

            }


        }

        private void _LoadData()
        {
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if(_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            oldLicenseClassID = _LocalDrivingLicenseApplication.LicenseClassID;

            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            ApplicationIdLEB.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            ApplicationDateLEB.Text = clsFormat.DateToShort(_LocalDrivingLicenseApplication.ApplicationDate);
            LicensesClassCB.SelectedIndex = LicensesClassCB.FindString(clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            LicensesFeesLEB.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            CreateByLEB.Text = clsUser.Find(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if(_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tabPage2.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
                return;
            }

            if(ctrlPersonCardWithFilter1.PersonID != -1)
            {
                btnSave.Enabled = true;
                tabPage2.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
            }
            else
            {
               
                MessageBox.Show("Please select the applicant person", "Applicant Person Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

         

            int lecenseClassID = clsLicenseClass.Find(LicensesClassCB.Text).LicenseClassID;

            int ActiveApplicationID = clsApplications.GetActiveApplicationIDForLicenseClass(ctrlPersonCardWithFilter1.PersonID, clsApplications.enApplicationType.NewDrivingLicense, lecenseClassID);

            if(ActiveApplicationID != -1 && oldLicenseClassID != lecenseClassID)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.Focus();
                return;
            }


            if(clsLicenses.IsLicenseExistByPersonID(ctrlPersonCardWithFilter1.PersonID, lecenseClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID ;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplications.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(LicensesFeesLEB.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = lecenseClassID;

            if (_LocalDrivingLicenseApplication.Save())
            {
                ApplicationIdLEB.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                TitleLEB.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void frAddEditLocalDrivingApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();

        }

        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received
            _SelectedPersonID = PersonID;
            ctrlPersonCardWithFilter1.LoadPersonInfo(PersonID);


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
