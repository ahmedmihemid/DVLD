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

namespace DVLD.Tests
{
    public partial class frManageTestAppointments : Form
    {
        public enum enTest { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }
        private enTest _Test;

        private int _LocalDrivingLicenseApplicationID = -1;

        
        private DataTable _dtTestAppointments = null;

        public frManageTestAppointments(int LocalDrivingLicenseApplicationID, enTest test)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _Test = test;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.LoadData(_LocalDrivingLicenseApplicationID);
            _FillData();
        }

        private void _FillData()
        {
            switch (_Test)
            {
                case enTest.VisionTest:
                    {
                        TestImagePB.Image = Resources.Vision_512;
                        TitleLEB.Text = "Vison Test Appointments";
                        break;
                    }
                case enTest.WrittenTest:
                    {

                        TestImagePB.Image = Resources.Written_Test_512;
                        TitleLEB.Text = "Written Test Appointments";
                        break;
                    }
                case enTest.StreetTest:
                    {

                        TestImagePB.Image = Resources.Street_Test_322;
                        TitleLEB.Text = "Street Test Appointments";
                        break;
                    }

            }


            _dtTestAppointments = DVLD_Buisness.clsTestAppointments.GetAllTestAppointmentsBylocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID, (int)_Test);
            dataGridView1.DataSource = _dtTestAppointments;
            RecordsLEB.Text = dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Appointment ID";
                dataGridView1.Columns[0].Width = 150;

                dataGridView1.Columns[1].HeaderText = "Appointment Data";
                dataGridView1.Columns[1].Width = 280;


                dataGridView1.Columns[2].HeaderText = "Paid Fees";
                dataGridView1.Columns[2].Width = 130;


                dataGridView1.Columns[3].HeaderText = "Is Locked";
                dataGridView1.Columns[3].Width = 110;
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            if(DVLD_Buisness.clsTestAppointments.IsHasNotLockedTestAppointment(_LocalDrivingLicenseApplicationID))
            {
                MessageBox.Show("Cannot add new test appointment because there is a Not locked test appointment existing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form1 fr = new Form1(_LocalDrivingLicenseApplicationID, _Test);
            fr.ShowDialog();
            Form1_Load(null, null);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int testAppointmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Form1 fr = new Form1(_LocalDrivingLicenseApplicationID, _Test, testAppointmentID);
            fr.ShowDialog();
            Form1_Load(null, null);
        }




    }
}
