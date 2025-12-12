

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
using static DVLD.Tests.crlScheduleTest;
using static DVLD.Tests.frManageTestAppointments;
using static DVLD_Buisness.clsApplications;
using static System.Net.Mime.MediaTypeNames;


namespace DVLD.Tests
{
    public partial class crlScheduleTest : UserControl
    {
        public enum enMode { AddNew = 1, Edit = 2 }
        private enMode _Mode = enMode.AddNew;

        public enum enGreationType { FirstTime=1,Retake=2}
        private enGreationType _GreationType = enGreationType.FirstTime;

        private enTest _Test;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsApplications _Application = null;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = null;

        private clsTestAppointments _TestAppointment = null;
        private int _TestAppointmentID = -1;

        //private int _RetakeApplicationID = -1;
        private clsApplications _RetakeApplication = null;

        public crlScheduleTest()
        {
            InitializeComponent();
        }




        public void LoadData(int LocalDrivingLicenseApplicationID, enTest test)
        {
            _TestAppointment=new clsTestAppointments();
            //_RetakeApplication= new clsApplications();


            _Mode = enMode.AddNew;
            gbRetakeTestInfo.Enabled = false;
            _Test = test;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);
            _Application = clsApplications.Find(_LocalDrivingLicenseApplication.ApplicationID);
           
            

            _chooseGreationType();
            if(_GreationType == enGreationType.Retake)
                _RetakeApplication = new clsApplications();

            _FillData();
        }

        public void LoadData(int LocalDrivingLicenseApplicationID, enTest test , int testAppointmentID)
        {
            _Mode = enMode.Edit;
            gbRetakeTestInfo.Enabled = false;
            _Test = test;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = testAppointmentID;

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);
            _Application = clsApplications.Find(_LocalDrivingLicenseApplication.ApplicationID);
            _TestAppointment = clsTestAppointments.FindIfTestAppointment(_TestAppointmentID);

            _chooseGreationType(_TestAppointment.TestAppointmentID);
            _FillData();
        }


        private void _chooseGreationType(int testAppointmentID=-1)
        {
            if(_Mode == enMode.AddNew)
            { if (IsItFallTests())
                    _GreationType = enGreationType.Retake;
                else
                    _GreationType = enGreationType.FirstTime;
            }

            else
            {
                _RetakeApplication = clsApplications.Find(_TestAppointment.RetakeTestApplicationID);
                if (_RetakeApplication != null)
                {
                    _GreationType = enGreationType.Retake;
                }
                else
                {
                    _GreationType = enGreationType.FirstTime;
                }
            }

        }



        private void _FillRetakeData()
        {
            gbRetakeTestInfo.Enabled = true;


            if (_Mode == enMode.Edit)
            {
                lblRetakeAppFees.Text = _RetakeApplication.PaidFees.ToString();
                lblTotalFees.Text = (_Application.PaidFees + _RetakeApplication.PaidFees).ToString();
                lblRetakeTestAppID.Text = _RetakeApplication.ApplicationID.ToString();
            }
            else
            {
                lblRetakeAppFees.Text= clsApplicationTypes.FindByTitle("Retake Test").Fees.ToString();
                lblTotalFees.Text = (_Application.PaidFees + clsApplicationTypes.FindByTitle("Retake Test").Fees).ToString();
                lblRetakeTestAppID.Text = "N/A";
            }


        }


        private void _FillData()
        {
            //dtpTestDate.MaxDate = DateTimePicker.MaximumDateTime;
            //dtpTestDate.MinDate = DateTimePicker.MaximumDateTime;

            switch (_Test)
            {
                case enTest.VisionTest:
                    {
                        pbTestTypeImage.Image = Properties.Resources.Vision_512;
                        lblTitle.Text = "Vison Test Appointments";
                        break;
                    }
                case enTest.WrittenTest:
                    {
                        pbTestTypeImage.Image = Properties.Resources.Written_Test_512;
                        lblTitle.Text = "Written Test Appointments";
                        break;
                    }
                case enTest.StreetTest:
                    {
                        pbTestTypeImage.Image = Properties.Resources.Street_Test_322;
                        lblTitle.Text = "Street Test Appointments";
                        break;
                    }
            }

                    if(_Application == null)
                    {
                        MessageBox.Show("Application not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                    lblDrivingClass.Text= _LocalDrivingLicenseApplication.LicenseClassID.ToString();
                    lblFullName.Text = clsPerson.Find(_Application.ApplicantPersonID).FullName;
                    //lblTrial.Text = "";
                       
             
                    if (_Mode == enMode.Edit)
                    {  
                        dtpTestDate.Value= _TestAppointment.AppointmentDate;
                        if(_TestAppointment.IsLocked)
                         {
                            dtpTestDate.Enabled = false;
                            btnSave.Enabled = false;
                         }

                    }
                    else
                    {
                        dtpTestDate.Value = DateTime.Now;
                    }
                    lblFees.Text = _Application.PaidFees.ToString();

                    if(_GreationType == enGreationType.Retake)
                    {
                        _FillRetakeData();
                    }


        }


        private bool IsItFallTests()
        {
            return clsTests.IsItFallTests(_LocalDrivingLicenseApplicationID,(int)_Test);
        }



        private void btnSave_Click(object sender, EventArgs e)
        {   
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Please correct the errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            _TestAppointment.TestTypeID = (int)_Test;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.CreatedByUserID = DVLD.Classes.clsGlobal.CurrentUser.UserID;
            

            if (_GreationType == enGreationType.Retake)
            {
                _RetakeApplication.ApplicantPersonID= _Application.ApplicantPersonID;
                _RetakeApplication.ApplicationTypeID = clsApplicationTypes.FindByTitle("Retake Test").ID;
                _RetakeApplication.PaidFees = clsApplicationTypes.FindByTitle("Retake Test").Fees;
                _RetakeApplication.CreatedByUserID = DVLD.Classes.clsGlobal.CurrentUser.UserID;
                _RetakeApplication.ApplicationDate = DateTime.Now;
                _RetakeApplication.ApplicationStatus= DVLD_Buisness.clsApplications.enStatus.New;
                _RetakeApplication.LastStatusDate = DateTime.Now;



                if (_RetakeApplication.Save())
                {
                    _TestAppointment.PaidFees = (_Application.PaidFees + _RetakeApplication.PaidFees);
                    _TestAppointment.RetakeTestApplicationID = _RetakeApplication.ApplicationID;
                }
                else
                {
                    MessageBox.Show("Failed to save Retake Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                _TestAppointment.PaidFees = _Application.PaidFees;
            }

            _TestAppointment.IsLocked = false;

            if (_TestAppointment.Save())
            {
                MessageBox.Show("Test Appointment saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save Test Appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }

        private void dtpTestDate_Validating(object sender, CancelEventArgs e)
        {
            if(_Mode == enMode.AddNew)
            {
                if (dtpTestDate.Value < DateTime.Now)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(dtpTestDate, "Test date cannot be in the past.");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(dtpTestDate, "");

                }
            }
            else
            { 
                if (dtpTestDate.Value >= DateTime.Now || dtpTestDate.Value == _TestAppointment.AppointmentDate)
                 {
                     e.Cancel = false;
                     errorProvider1.SetError(dtpTestDate, "");
                 }
           
                 else
                 {
                     e.Cancel = true;
                     errorProvider1.SetError(dtpTestDate, "Test date cannot be in the past.");
                 }
            }

        }
      


    }
}
