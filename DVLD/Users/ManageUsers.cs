using DVLD.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class ManageUsers : Form
    {

        private static  DataTable _dtAllUsers = DVLD_Buisness.clsUser.GetAllUser();
        private DataTable _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "IsActive");


        public ManageUsers()
        {
            InitializeComponent();
        }

        private void _ReafreshData()
        {
            _dtAllUsers = DVLD_Buisness.clsUser.GetAllUser();
            _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "IsActive");
            UsersDGV.DataSource = _dtUsers;
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {

            UsersDGV.DataSource = _dtUsers;
            comboBox1.SelectedIndex = 0;
            RecordsLEB.Text = UsersDGV.Rows.Count.ToString();

            if (UsersDGV.Rows.Count>0)
            {
                UsersDGV.Columns[0].HeaderText = "User ID";
                UsersDGV.Columns[0].Width=100;

                UsersDGV.Columns[1].HeaderText = "Person ID";
                UsersDGV.Columns[1].Width = 100;


                UsersDGV.Columns[2].HeaderText = "Full Name";
                UsersDGV.Columns[2].Width = 330;


                UsersDGV.Columns[3].HeaderText = "User Name";
                UsersDGV.Columns[3].Width = 130;


                UsersDGV.Columns[4].HeaderText = "Is Active";
                UsersDGV.Columns[4].Width = 70;

            }
        }

        private void FilterValueTB_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = "";

            switch(comboBox1.Text)
            {

              
                case "User ID":
                    FilterValue= "UserID";
                    break;

                case "Person ID":
                    FilterValue = "PersonID";
                    break;

                case "Full Name":
                    FilterValue = "FullName";
                    break;


                case "User Name":
                    FilterValue = "UserName";
                    break;


                case "Is Active":
                    FilterValue = "IsActive";
                    break;


                default:
                    FilterValue = "None";
                    break;

            }

            if(FilterValueTB.Text.Trim() =="" || FilterValue == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                RecordsLEB.Text = UsersDGV.Rows.Count.ToString();
                return;
            }

            else if (FilterValue == "UserID" || FilterValue == "PersonID")
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterValue, FilterValueTB.Text.Trim());
                RecordsLEB.Text = UsersDGV.Rows.Count.ToString();
            }
 
            else if(FilterValue == "IsActive")
            {
                comboBox2.Visible = true;
            }
            else
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterValue, FilterValueTB.Text.Trim());
            }

        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterValue = "";

            switch (comboBox2.Text)
            {


                case "Is Not Active":
                    FilterValue = "IsNotActive";
                    break;

  
                case "Is Active":
                    FilterValue = "IsActive";
                    break;


                default:
                    FilterValue = "All";
                    break;

            }

            if(FilterValue == "All")
            {
                _dtUsers.DefaultView.RowFilter = "";
                RecordsLEB.Text = UsersDGV.Rows.Count.ToString();
                
            }
            else if(FilterValue == "IsActive")
            {
                _dtUsers.DefaultView.RowFilter= "[IsActive] = true";
                RecordsLEB.Text = UsersDGV.Rows.Count.ToString();

            }
            else if(FilterValue == "IsNotActive")
            {
                _dtUsers.DefaultView.RowFilter = "[IsActive] = false";
                RecordsLEB.Text = UsersDGV.Rows.Count.ToString();
            }

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="None" )
            {
                FilterValueTB.Visible = false;
                comboBox2.Visible = false;

                return;
            }

            if (comboBox1.Text == "Is Active")
            {
                FilterValueTB.Visible = false;
                comboBox2.Visible = true;
                return;
            }

            FilterValueTB.Visible = true;
            comboBox2.Visible = false;
            FilterValueTB.Text = "";
            FilterValueTB.Focus();
          

        }


        private void FilterValueTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(comboBox1.Text=="Person ID" || comboBox1.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            AddEditUsers fr = new AddEditUsers();
            fr.ShowDialog();
            _ReafreshData();
        }



        private void showDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(UsersDGV.CurrentRow.Cells["UserID"].Value);
            UserDetails fr = new UserDetails(userId);
            fr.ShowDialog();
        }


        private void UsersDGV_DoubleClick(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(UsersDGV.CurrentRow.Cells["UserID"].Value);
            UserDetails fr = new UserDetails(userId);
            fr.ShowDialog();
            _ReafreshData();
        }


        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditUsers fr = new AddEditUsers();
            fr.ShowDialog();
            _ReafreshData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(UsersDGV.CurrentRow.Cells["UserID"].Value);
            AddEditUsers fr = new AddEditUsers(userId);
            fr.ShowDialog();
            _ReafreshData();
        }
    }
}
