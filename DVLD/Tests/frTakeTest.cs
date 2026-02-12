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
using DVLD_Buisness;
using DVLD.Classes;

namespace DVLD.Tests
{
    public partial class frTakeTest : Form
    {
        enTest _TestType;
        private int _TestID;
        private int _TestAppointmentID;
        private clsTests _Test = null;
        private clsTestAppointments _TestAppointment = null;
        private clsLocalDrivingLicenseApplication _LocalDLApplication = null;

        public frTakeTest(int testAppointmentID, clsTestTypes.enTestType test)
        {
            InitializeComponent();
            _Test = new clsTests();
            _TestAppointmentID = testAppointmentID;
            _TestType = test;
            ctrlSecheduledTest1.LoadData(_TestAppointmentID, (int)_TestType);
        }

        public frTakeTest(int testAppointmentID, enTest test, int TestID)
        {
            InitializeComponent();
            _TestAppointmentID = testAppointmentID;
            _TestID = TestID;
            _TestType = test;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _Test.TestID = _TestID;
            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = PassRB.Checked ? true : false;
            _Test.Notes = NotTB.Text.Trim();

            if(_Test.Save())
            {
                MessageBox.Show("Test results saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _TestAppointment= clsTestAppointments.FindIfTestAppointment(_TestAppointmentID);
                _TestAppointment.IsLocked = true;
                if(!_TestAppointment.Save())
                {
                    MessageBox.Show("Error locking the test appointment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

             

                this.Close();
            }
            else
            {
                MessageBox.Show("Error saving test results.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
