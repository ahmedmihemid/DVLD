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

namespace DVLD.People
{
    public partial class frManagePeople : Form
    {
        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();



        //only select the columns that you want to show in the grid
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                         "FirstName", "SecondName", "ThirdName", "LastName",
                                                         "GenderString", "DateOfBirth", "CountryName",
                                                         "Phone", "Email");


        public frManagePeople()
        {
            InitializeComponent();
        }

        private void _RefreshPeoplList()
        {
               _dtAllPeople = clsPerson.GetAllPeople();

             _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                         "FirstName", "SecondName", "ThirdName", "LastName",
                                                         "GenderString", "DateOfBirth", "CountryName",
                                                         "Phone", "Email");

            PeopleDGV.DataSource = _dtPeople;
            RecordsLEB.Text = _dtPeople.Rows.Count.ToString();
        }


        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)PeopleDGV.CurrentRow.Cells[0].Value;
            frPersonDetails fr = new frPersonDetails(personID);
            fr.ShowDialog();
            _RefreshPeoplList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frAddEditPeople fr = new frAddEditPeople();
            fr.ShowDialog();

            _RefreshPeoplList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)PeopleDGV.CurrentRow.Cells[0].Value;
            frAddEditPeople fr = new frAddEditPeople(personID);
            fr.ShowDialog();

            _RefreshPeoplList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete Person [" + PeopleDGV.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {


                //Perform Delele and refresh
                if (clsPerson.DeletePersonByID((int)PeopleDGV.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshPeoplList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frAddEditPeople fr = new frAddEditPeople();
            fr.ShowDialog();

            _RefreshPeoplList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            PeopleDGV.DataSource = _dtPeople;
            comboBox1.SelectedIndex = 0;
            RecordsLEB.Text = PeopleDGV.Rows.Count.ToString();
            if (PeopleDGV.Rows.Count > 0)
            {

                PeopleDGV.Columns[0].HeaderText = "Person ID";
                PeopleDGV.Columns[0].Width = 90;

                PeopleDGV.Columns[1].HeaderText = "National No";
                PeopleDGV.Columns[1].Width = 90;


                PeopleDGV.Columns[2].HeaderText = "First Name";
                PeopleDGV.Columns[2].Width = 100;

                PeopleDGV.Columns[3].HeaderText = "Second Name";
                PeopleDGV.Columns[3].Width = 120;


                PeopleDGV.Columns[4].HeaderText = "Third Name";
                PeopleDGV.Columns[4].Width = 100;

                PeopleDGV.Columns[5].HeaderText = "Last Name";
                PeopleDGV.Columns[5].Width = 100;

                PeopleDGV.Columns[6].HeaderText = "Gendor";
                PeopleDGV.Columns[6].Width = 80;

                PeopleDGV.Columns[7].HeaderText = "Date Of Birth";
                PeopleDGV.Columns[7].Width = 130;

                PeopleDGV.Columns[8].HeaderText = "Nationality";
                PeopleDGV.Columns[8].Width = 100;


                PeopleDGV.Columns[9].HeaderText = "Phone";
                PeopleDGV.Columns[9].Width = 110;


                PeopleDGV.Columns[10].HeaderText = "Email";
                PeopleDGV.Columns[10].Width = 160;
            }
        }

        private void FilterValueTB_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (comboBox1.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (FilterValueTB.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                RecordsLEB.Text = PeopleDGV.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
            { 
                //in this case we deal with integer not string.
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValueTB.Text.Trim());
            }
            else
            { 
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, FilterValueTB.Text.Trim());
            }

            RecordsLEB.Text = PeopleDGV.Rows.Count.ToString();



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterValueTB.Visible = (comboBox1.Text != "None");

            if (FilterValueTB.Visible)
            {
                FilterValueTB.Text = "";
                FilterValueTB.Focus();
            }
        }

     
        private void PeopleDGV_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new frPersonDetails((int)PeopleDGV.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeoplList();
        }

        private void FilterValueTB_KeyPress(object sender, KeyPressEventArgs e)
        {
        
            //we allow number incase person id is selected.
            if (comboBox1.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        
        }
    }
}
