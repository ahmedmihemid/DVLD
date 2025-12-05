using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD.Tests.frManageTestAppointments;

namespace DVLD.Tests
{
    public partial class Form1 : Form
    {
        private enTest _Test;
        private int _LocalDrivingLicenseApplicationID;
        private int _TestAppointmentID;
        public Form1( int LocalDrivingLicenseApplicationID, enTest test)
        {
            InitializeComponent();
            _Test = test;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            crlScheduleTest1.LoadData(_LocalDrivingLicenseApplicationID, _Test);

        }


        public Form1(int LocalDrivingLicenseApplicationID, enTest test , int testAppointmentID)
        {
            InitializeComponent();
            _Test = test;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = testAppointmentID;
            crlScheduleTest1.LoadData(_LocalDrivingLicenseApplicationID, _Test, _TestAppointmentID);

        }


        private void _FillData()
        {
          crlScheduleTest1.LoadData(_LocalDrivingLicenseApplicationID, _Test);
            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            _FillData();
        }

       
    }
}