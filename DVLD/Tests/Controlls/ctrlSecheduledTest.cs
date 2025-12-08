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

namespace DVLD.Tests.Controlls
{
    public partial class ctrlSecheduledTest : UserControl
    {
        
        private int _TestType;
        private int _TestAppointmentID;
        private int _TestID;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = null;
        private clsTestAppointments _TestAppointment = null;
        private clsTests _Test = null;

        public ctrlSecheduledTest()
        {
            InitializeComponent();
        }

        public void LoadData(int testAppointmentID,int testType)
        {
            _TestAppointmentID = testAppointmentID;
            _TestType = testType;
            _TestAppointment = clsTestAppointments.FindIfTestAppointment(_TestAppointmentID);
            _LocalDrivingLicenseApplication= clsLocalDrivingLicenseApplication.Find(_TestAppointment.LocalDrivingLicenseApplicationID);
            _FillData();
        }

        private void _FillData()
        {

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error loading test appointment data.");
                return;
            }

            switch (_TestType)
            {
                case 1:
                    {
                        pbTestTypeImage.Image = Properties.Resources.Vision_512;
                        break;
                    }
                case 2:
                    {
                        pbTestTypeImage.Image = Properties.Resources.Written_Test_512;
                        break;
                    }
                case 3:
                    {
                        pbTestTypeImage.Image = Properties.Resources.Street_Test_322;
                        break;
                    }
            }


            lblLocalDrivingLicenseAppID.Text = _TestAppointment.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClassID.ToString();
            lblFullName.Text = clsPerson.Find(clsApplications.Find(_LocalDrivingLicenseApplication.ApplicationID).ApplicantPersonID).FullName;
            //lblTrial.Text=
            lblDate.Text = _TestAppointment.AppointmentDate.ToString("yyyy-MM-dd");
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            //lblTestID.Text

        }




    }
}
