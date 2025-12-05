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
        public enum enTest {  VisionTest=1, WrittenTest = 2,  StreetTest = 3 }
        private enTest _Test;

        

        private int _LocalDrivingLicenseApplicationID = -1;


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
                        TestImagePB.Image= Resources.Vision_512;
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




        }

        private void button1_Click(object sender, EventArgs e)
       {
            Form1 fr = new Form1(_LocalDrivingLicenseApplicationID, _Test);
            fr.ShowDialog();

        }


    }
}
