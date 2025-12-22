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
            comboBox1.SelectedIndex = 0;
            dtLocalDrivingApplications = DVLD_Buisness.clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplicationInfo();
            LocalDrivingLicenseApplicationDGV.DataSource = dtLocalDrivingApplications;
            RecordsLEB.Text = LocalDrivingLicenseApplicationDGV.Rows.Count.ToString();
            if (dtLocalDrivingApplications != null)
            {
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
           
        }



        private void FilterValueTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

            int ApplicationID = clsLocalDrivingLicenseApplication.Find((int)(LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value)).ApplicationID;
            if (clsApplications.ChangeStatus(ApplicationID, clsApplications.enStatus.Cancelled))
            {
                MessageBox.Show("The application has been cancelled successfully.","Success", MessageBoxButtons.OK,MessageBoxIcon.Information);
                frManageLocalDrivingApplication_Load(null, null);
            }
            else
            {
                MessageBox.Show("Failed to cancel the application. Please try again.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

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
            frManageTestAppointments fr = new frManageTestAppointments((int)LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value, frManageTestAppointments.enTest.VisionTest);
            fr.ShowDialog();
            frManageLocalDrivingApplication_Load(null, null);
        }



        private void sechsuleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frManageTestAppointments fr = new frManageTestAppointments((int)LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value, frManageTestAppointments.enTest.WrittenTest);
            fr.ShowDialog();
            frManageLocalDrivingApplication_Load(null, null);
        }



        private void sechsuleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frManageTestAppointments fr = new frManageTestAppointments((int)LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value, frManageTestAppointments.enTest.StreetTest);
            fr.ShowDialog();
            frManageLocalDrivingApplication_Load(null, null);
        }



        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            // إعادة ضبط كل العناصر مهم جداً
            shechduleTestsToolStripMenuItem.Enabled = true;
            issueToolStripMenuItem.Enabled = true;
            EditeApplicationToolStripMenuItem.Enabled = true;
            deleteApplicationToolStripMenuItem1.Enabled = true;
            cancelApplicationToolStripMenuItem.Enabled = true;

            showLicenseToolStripMenuItem1.Enabled = true;
            showPersonLicenseToolStripMenuItem.Enabled = true;

            sechsuleToolStripMenuItem.Enabled = true;
            sechsuleToolStripMenuItem1.Enabled = true;
            sechsuleToolStripMenuItem2.Enabled = true;

            //  جلب الطلب
            var L_D_application = clsLocalDrivingLicenseApplication.Find((int)LocalDrivingLicenseApplicationDGV.CurrentRow.Cells[0].Value);

            //  إذا الطلب ملغي أو مكتمل
            if (L_D_application.application.ApplicationStatus == clsApplications.enStatus.Cancelled ||
                L_D_application.application.ApplicationStatus == clsApplications.enStatus.Completed)
            {
                shechduleTestsToolStripMenuItem.Enabled = false;
                issueToolStripMenuItem.Enabled = false;
                EditeApplicationToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem1.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;

                // لا تُظهر الرخصة إلا إذا مكتمل
                if (L_D_application.application.ApplicationStatus == clsApplications.enStatus.Cancelled)
                {
                    showLicenseToolStripMenuItem1.Enabled = false;
                    showPersonLicenseToolStripMenuItem.Enabled = false;
                }

                return; // ⛔ خروج مبكر (مهم)
            }

            // الطلب نشط → فحص عدد الاختبارات
            showLicenseToolStripMenuItem1.Enabled = false;
            showPersonLicenseToolStripMenuItem.Enabled = false;

            int testsPassed =clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationPassedTestsCount(L_D_application.LocalDrivingLicenseApplicationID);

            if (testsPassed == 3)
            {
                shechduleTestsToolStripMenuItem.Enabled = false;
                issueToolStripMenuItem.Enabled = true;
            }
            else
            {
                issueToolStripMenuItem.Enabled = false;

                sechsuleToolStripMenuItem.Enabled = (testsPassed == 0);
                sechsuleToolStripMenuItem1.Enabled = (testsPassed == 1);
                sechsuleToolStripMenuItem2.Enabled = (testsPassed == 2);
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
            frShowPersonLicenseHistory fr = new frShowPersonLicenseHistory(clsDriverscs.GetDriverIDByApplicationID(clsLocalDrivingLicenseApplication.Find(localDrivingLicenseApplicationID).ApplicationID));
            fr.ShowDialog();
            frManageLocalDrivingApplication_Load(null, null);


        }

        private void button2_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
