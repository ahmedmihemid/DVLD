using DVLD.Applications;
using DVLD.Licenses.Local_Licenses;
using DVLD.Tests;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace DVLD.Licenses
{
    public partial class frManageLocalDrivingApplication : Form
    {

        private DataTable dtLocalDrivingApplications = null;


        public frManageLocalDrivingApplication()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frAddEditLocalDrivingApplication fr = new frAddEditLocalDrivingApplication();
            fr.ShowDialog();
            frManageLocalDrivingApplication_Load(null, null);
        }


        private void frManageLocalDrivingApplication_Load(object sender, EventArgs e)
        {
            dtLocalDrivingApplications = DVLD_Buisness.clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplicationInfo();
            LocalDrivingLicenseApplicationDGV.DataSource = dtLocalDrivingApplications;
            RecordsLEB.Text = LocalDrivingLicenseApplicationDGV.Rows.Count.ToString();
            if (dtLocalDrivingApplications != null)
            {
                comboBox1.SelectedIndex = 0;

                LocalDrivingLicenseApplicationDGV.Columns[0].HeaderText = "L.D.L.AppID";
                LocalDrivingLicenseApplicationDGV.Columns[0].Width=85;
                LocalDrivingLicenseApplicationDGV.Columns[1].HeaderText = "Calss Name";
                LocalDrivingLicenseApplicationDGV.Columns[1].Width = 230;
                LocalDrivingLicenseApplicationDGV.Columns[2].HeaderText = "National No";
                LocalDrivingLicenseApplicationDGV.Columns[2].Width = 100;
                LocalDrivingLicenseApplicationDGV.Columns[3].HeaderText = "Full Name";
                LocalDrivingLicenseApplicationDGV.Columns[3].Width = 310;
                LocalDrivingLicenseApplicationDGV.Columns[4].HeaderText = "Application Date";
                LocalDrivingLicenseApplicationDGV.Columns[4].Width = 170;
                LocalDrivingLicenseApplicationDGV.Columns[5].HeaderText = "Passed Tests";
                LocalDrivingLicenseApplicationDGV.Columns[5].Width = 120;
                LocalDrivingLicenseApplicationDGV.Columns[6].HeaderText = "Status";
                LocalDrivingLicenseApplicationDGV.Columns[6].Width = 80;
            }


        }

        private void FilterValueTB_TextChanged(object sender, EventArgs e)
        {
            string filterExpression = "";
            
             switch (comboBox1.Text)
             {

                    case "L.D.L.AppID":
                         filterExpression = "LocalDrivingLicenseApplicationID";
                         break;
                    case "National No":
                         filterExpression = "NationalNo";
                        break;
                    case "Full Name":
                            filterExpression = "FullName";
                            break;
                    case "Status":
                             filterExpression = "Status";
                            break;
                    Default:
                        filterExpression = "None";
                        break;
             }

            if(filterExpression=="None" || FilterValueTB.Text.Trim() == "")
            {
                dtLocalDrivingApplications.DefaultView.RowFilter = "";
                RecordsLEB.Text = LocalDrivingLicenseApplicationDGV.Rows.Count.ToString();
                return;
            }

            if(filterExpression == "LocalDrivingLicenseApplicationID")
            {
               
                dtLocalDrivingApplications.DefaultView.RowFilter= string.Format("[{0}] = {1}", filterExpression, FilterValueTB.Text.Trim());
            }
            else
            {
                dtLocalDrivingApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterExpression, FilterValueTB.Text.Trim());
            }
            RecordsLEB.Text = LocalDrivingLicenseApplicationDGV.Rows.Count.ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          FilterValueTB.Visible = (comboBox1.Text!="None");

            if(FilterValueTB.Visible)
            {
                FilterValueTB.Text = "";
                FilterValueTB.Focus();
            }
            dtLocalDrivingApplications.DefaultView.RowFilter = "";
            RecordsLEB.Text = LocalDrivingLicenseApplicationDGV.Rows.Count.ToString();
        }

        private void FilterValueTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // it is the update option but i forget to change the name of the menu item
            int ApplicationID = clsLocalDrivingLicenseApplication.Find((int)(LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value)).ApplicationID;
            frAddEditLocalDrivingApplication fr = new frAddEditLocalDrivingApplication(ApplicationID);
             fr.ShowDialog();
            frManageLocalDrivingApplication_Load(null, null);
        }

        private void deleteApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this user?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            if(clsApplications.Delete(clsLocalDrivingLicenseApplication.Find((int)(LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value)).ApplicationID))
            {
                MessageBox.Show("Applications deleted successfully.", "Delete Applications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frManageLocalDrivingApplication_Load(null, null);
            }
            else
            {
                MessageBox.Show("Error deleting Applications.", "Delete Applications", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this applicaation ?", "cancel applicaation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }



            int LocalDrivingLicenseApplicationID = (int)(LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value);
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if(LocalDrivingLicenseApplicationID != null)
            { 
                if (localDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("The application has been cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frManageLocalDrivingApplication_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to cancel the application. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                    MessageBox.Show("Application not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showApplicationDToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frApplicationDetails fr = new frApplicationDetails((int)LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value);
            fr.ShowDialog();
            frManageLocalDrivingApplication_Load(null, null);
        }


        private void sechsuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frManageTestAppointments fr = new frManageTestAppointments((int)LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.VisionTest);
            fr.ShowDialog();
            frManageLocalDrivingApplication_Load(null, null);
        }

        private void sechsuleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frManageTestAppointments fr = new frManageTestAppointments((int)LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.WrittenTest);
            fr.ShowDialog();
            frManageLocalDrivingApplication_Load(null, null);
        }

        private void sechsuleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frManageTestAppointments fr = new frManageTestAppointments((int)LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.StreetTest);
            fr.ShowDialog();
            frManageLocalDrivingApplication_Load(null, null);
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int localDrivingLicenseApplicationID = (int)(LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value);
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(localDrivingLicenseApplicationID);

            int TotalPassedTests = (int)LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[5].Value;

            bool LicenseExists = localDrivingLicenseApplication.IsLicenseIssued();



            //Enabled only if person passed all tests and Does not have license. 
            issueToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            showLicenseToolStripMenuItem.Enabled = LicenseExists;
            EditeApplicationToolStripMenuItem.Enabled = !LicenseExists && (localDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New);
            shechduleTestsToolStripMenuItem.Enabled = !LicenseExists;

            //Enable/Disable Cancel Menue Item
            //We only canel the applications with status=new.
            cancelApplicationToolStripMenuItem.Enabled = (localDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New);

            //Enable/Disable Delete Menue Item
            //We only allow delete incase the application status is new not complete or Cancelled.
            deleteApplicationToolStripMenuItem1.Enabled =
                (localDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New);


            //Enable Disable Schedule menue and it's sub menue
            bool PassedVisionTest = localDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.VisionTest);
            bool PassedWrittenTest = localDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.WrittenTest);
            bool PassedStreetTest = localDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.StreetTest);


            shechduleTestsToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (localDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New);

            if (shechduleTestsToolStripMenuItem.Enabled)
            {
                //To Allow Schdule vision test, Person must not passed the same test before.
                sechsuleToolStripMenuItem.Enabled = !PassedVisionTest;

                //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
                sechsuleToolStripMenuItem1.Enabled = PassedVisionTest && !PassedWrittenTest;

                //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
                sechsuleToolStripMenuItem2.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            }

        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int localDrivingLicenseApplicationID = (int)(LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value);
            frmIssueDriverLicenseFirstTime fr = new frmIssueDriverLicenseFirstTime(localDrivingLicenseApplicationID);
            fr.ShowDialog();
            frManageLocalDrivingApplication_Load(null, null);
        }

        private void showLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int localDrivingLicenseApplicationID = (int)(LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value);
            var L_D_application = clsLocalDrivingLicenseApplication.Find(localDrivingLicenseApplicationID);
            frmShowLicenseInfo fr = new frmShowLicenseInfo(clsLicenses.GetLicenseIDByApplicationID(L_D_application.ApplicationID));
            fr.ShowDialog();
            frManageLocalDrivingApplication_Load(null, null);
        }

        private void showPersonLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localDrivingLicenseApplicationID = (int)(LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value);
            frShowPersonLicenseHistory fr = new frShowPersonLicenseHistory(clsDriverscs.FindByPersonID(clsLocalDrivingLicenseApplication.Find(localDrivingLicenseApplicationID).ApplicantPersonID).DriverID);
            fr.ShowDialog();
            frManageLocalDrivingApplication_Load(null, null);


        }

        private void button2_Click(object sender, EventArgs e)
        {
           this.Close();
        }





    }
}
