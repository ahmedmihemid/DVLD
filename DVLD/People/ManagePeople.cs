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
    public partial class ManagePeople : Form
    {
        public ManagePeople()
        {
            InitializeComponent();
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
           
            PeopleDGV.DataSource = DVLD_Buisness.clsPerson.GetAllPeople();
            RecordsLEB.Text = (PeopleDGV.Rows.Count - 1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditPeople addEditPeople = new AddEditPeople();
            addEditPeople.ShowDialog();
        }
 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterValueTB.Text = string.Empty;

            if (comboBox1.SelectedIndex == 0)
            {
                FilterValueTB.Visible = false;
                PeopleDGV.DataSource = DVLD_Buisness.clsPerson.GetAllPeople();
                return;
            }

            FilterValueTB.Visible = true;
        }

        private void FilterValueTB_TextChanged(object sender, EventArgs e)
        {
            string columnName = comboBox1.SelectedItem.ToString();
            string filterValue = FilterValueTB.Text.Trim();

            PeopleDGV.DataSource = DVLD_Buisness.clsPerson.GetFilteredPeople(columnName, filterValue);
            if (PeopleDGV.DataSource == null || ((DataTable)PeopleDGV.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("No records found for the given filter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PeopleDGV.DataSource = DVLD_Buisness.clsPerson.GetAllPeople();
                FilterValueTB.Text = string.Empty;
            }

            RecordsLEB.Text =( PeopleDGV.Rows.Count-1).ToString();

        }

        private void FilterValueTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 9)
            {
                if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; 
                }
            }

        }

       

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PeopleDGV.CurrentRow != null)
            {
                int personId = Convert.ToInt32(PeopleDGV.CurrentRow.Cells["PersonID"].Value);
                PersonDetails personDetails = new PersonDetails(personId);
                personDetails.ShowDialog();

            }


        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditPeople addEditPeople = new AddEditPeople();
            addEditPeople.ShowDialog();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPerson person = clsPerson.GetPersonByID(Convert.ToInt32(PeopleDGV.CurrentRow.Cells["PersonID"].Value));

            if (person != null) 
            {
                AddEditPeople addEditPeople = new AddEditPeople(person);
                addEditPeople.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error retrieving person data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personId = Convert.ToInt32(PeopleDGV.CurrentRow.Cells["PersonID"].Value);

            if(DVLD_Buisness.clsPerson.DeletePersonByID(personId))
            {
                MessageBox.Show("Person deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PeopleDGV.DataSource = DVLD_Buisness.clsPerson.GetAllPeople();
                RecordsLEB.Text = (PeopleDGV.Rows.Count - 1).ToString();
            }
            else
            {
                MessageBox.Show("Error deleting person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




    }
}
