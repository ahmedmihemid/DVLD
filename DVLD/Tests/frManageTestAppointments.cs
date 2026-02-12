using DVLD.Properties;
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

namespace DVLD.Tests
{
    public partial class frManageTestAppointments : Form
    {

        private int _LocalDrivingLicenseApplicationID;
        private DataTable _dtTestAppointments ;
        private clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;

        public frManageTestAppointments(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;
        }

        private void frManageTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
            _dtTestAppointments = clsTestAppointments.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);
            dataGridView1.DataSource= _dtTestAppointments;
            RecordsLEB.Text = dataGridView1.Rows.Count.ToString();

            if(dataGridView1.Rows.Count >0)
            {
                dataGridView1.Columns[0].HeaderText = "Appointment ID";
                dataGridView1.Columns[0].Width = 150;

                dataGridView1.Columns[1].HeaderText = "Appointment Date";
                dataGridView1.Columns[1].Width = 200;

                dataGridView1.Columns[2].HeaderText = "Paid Fees";
                dataGridView1.Columns[2].Width = 150;

                dataGridView1.Columns[3].HeaderText = "Is Locked";
                dataGridView1.Columns[3].Width = 100;
            }



        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case clsTestTypes.enTestType.VisionTest:
                    {
                        TitleLEB.Text = "Vision Test Appointments";
                        this.Text = TitleLEB.Text;
                        TestImagePB.Image = Resources.Vision_512;
                        break;
                    }

                case clsTestTypes.enTestType.WrittenTest:
                    {
                        TitleLEB.Text = "Written Test Appointments";
                        this.Text = TitleLEB.Text;
                        TestImagePB.Image = Resources.Written_Test_512;
                        break;
                    }
                case clsTestTypes.enTestType.StreetTest:
                    {
                        TitleLEB.Text = "Street Test Appointments";
                        this.Text = TitleLEB.Text;
                        TestImagePB.Image = Resources.Street_Test_322;
                        break;
                    }
            }

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frTakeTest frm = new frTakeTest(_LocalDrivingLicenseApplicationID, _TestType);
            //frm.ShowDialog();
            //frManageTestAppointments_Load(null, null);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, TestAppointmentID);
            frm.ShowDialog();
            frManageTestAppointments_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {


            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);


            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            //---
            clsTests LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(_TestType);

            if (LastTest == null)
            {
                frmScheduleTest frm1 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
                frm1.ShowDialog();
                frManageTestAppointments_Load(null, null);
                return;
            }

            //if person already passed the test s/he cannot retak it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int TestAppointmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
            frm.ShowDialog();
            frManageTestAppointments_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
