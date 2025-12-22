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

namespace DVLD.Licenses
{
    public partial class frAddEditLocalDrivingApplication : Form
    {
        public enum enMode { AddNew=1, Edit=2 }
        public enMode Mode = enMode.AddNew;

        private int _ApplicationTypeId = 1;

        clsApplications applications;
        clsLocalDrivingLicenseApplication localDrivingLicenseApplication;
        public frAddEditLocalDrivingApplication()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
            applications = new clsApplications();
            localDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
        }

        public frAddEditLocalDrivingApplication(int applicationsID)
        {
            InitializeComponent();
            Mode = enMode.Edit;
            applications = clsApplications.Find(applicationsID);
            localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(applicationsID);
        }



        private void _FillLicenseClasses()
        {   
            DataTable dt = DVLD_Buisness.LicenseClass.GetAllLicenseClasses();
            foreach (DataRow dr in dt.Rows)
            {
                LicensesClassCB.Items.Add(dr["ClassName"].ToString());
            }
            LicensesClassCB.SelectedIndex = 2;
        }



        private void _ResetDefualtValues()
        {
            if (Mode == enMode.Edit)
            {
                TitleLEB.Text = "Edit Local Driving Application";
                this.Text = "Edit Local Driving Application";
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                btnSave.Enabled = true;
                _ResetDefualtValuesOfApplicationInfo();
                return;
            }
            else
            {
                TitleLEB.Text = "Add New Local Driving Application";
                this.Text = "Add New Local Driving Application";
                tabControl1.TabPages[1].Enabled = false;
                btnSave.Enabled = false;
                ApplicationIdLEB.Text = "???";
                ApplicationDateLEB.Text = "???";
                LicensesFeesLEB.Text = "???";
                CreateByLEB.Text = "???";
            }
           
           

        }


        private void _ResetDefualtValuesOfApplicationInfo()
        {
            ApplicationIdLEB.Text = "???";
            ApplicationDateLEB.Text = DateTime.Now.ToShortDateString();
            LicensesFeesLEB.Text = (DVLD_Buisness.clsApplicationTypes.Find(_ApplicationTypeId).Fees).ToString();
            CreateByLEB.Text = Classes.clsGlobal.CurrentUser.UserName;
            _FillLicenseClasses();
        }


        private void _LoadApplicationData()
        {
            if(applications != null)
            {
                ctrlPersonCardWithFilter1.LoadPersonInfo(applications.ApplicantPersonID);
                ApplicationIdLEB.Text = applications.ApplicationID.ToString();
                ApplicationDateLEB.Text = applications.ApplicationDate.ToShortDateString();
                if(localDrivingLicenseApplication !=null)
                LicensesClassCB.SelectedIndex = localDrivingLicenseApplication.LicenseClassID - 1;
                LicensesFeesLEB.Text= applications.PaidFees.ToString();
                CreateByLEB.Text = clsUser.Find(applications.CreatedByUserID).UserName;

            }
            else
            {
                MessageBox.Show("The specified application could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (Mode == enMode.Edit)
                _LoadApplicationData();

        }



        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Edit)
            {
                btnSave.Enabled = true;
                tabControl1.TabPages[1].Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages[1];
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                //if (DVLD_Buisness.clsUser.IsExistByPersonID(ctrlPersonCardWithFilter1.PersonID))
                //{
                //    MessageBox.Show("This person already has a user account, please choose another person.", "Person Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //}
                //else
                //{
                    btnSave.Enabled = true;
                    tabControl1.TabPages[1].Enabled = true;
                    tabControl1.SelectedTab = tabControl1.TabPages[1];
                    _ResetDefualtValuesOfApplicationInfo();
                //}
            }
            else
            {
                MessageBox.Show("Please select a person to continue.", "No Person Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(DVLD_Buisness.clsLocalDrivingLicenseApplication.HasApplicationForLicenseClass(ctrlPersonCardWithFilter1.PersonID, LicensesClassCB.SelectedIndex+1, (int)applications.ApplicationStatus))
            {  
                if(Mode == enMode.Edit && localDrivingLicenseApplication != null && localDrivingLicenseApplication.LicenseClassID == LicensesClassCB.SelectedIndex + 1)
                {
                    // Allow saving if in edit mode and the license class hasn't changed
                }
                else
                {
                    MessageBox.Show("This person already has an application for the selected license class.", "Duplicate Application", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //MessageBox.Show("This person already has an application for the selected license class.", "Duplicate Application", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
            }

           
            applications.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
            applications.ApplicationDate = DateTime.Now;
            applications.ApplicationTypeID = _ApplicationTypeId;
            applications.ApplicationStatus = clsApplications.enStatus.New;
            applications.LastStatusDate = DateTime.Now;
            applications.PaidFees = DVLD_Buisness.clsApplicationTypes.Find(_ApplicationTypeId).Fees;
            applications.CreatedByUserID = Classes.clsGlobal.CurrentUser.UserID;

            if(applications.Save())
            {
               
                localDrivingLicenseApplication.ApplicationID = applications.ApplicationID;
                localDrivingLicenseApplication.LicenseClassID = LicensesClassCB.SelectedIndex + 1;
                if (localDrivingLicenseApplication.Save())
                {
                    MessageBox.Show("The local driving license application has been saved successfully.", "Local Driving License Application Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TitleLEB.Text = "Edit Local Driving Application";
                    this.Text = "Edit Local Driving Application";
                    ApplicationIdLEB.Text = applications.ApplicationID.ToString();

                }
                else
                {
                    MessageBox.Show("An error occurred while saving the local driving license application. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("An error occurred while saving the application. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
