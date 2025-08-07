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
using System.IO;
using DVLD_Buisness;

namespace DVLD.People.Controlls
{
    public partial class UserCart : UserControl
    {
        public UserCart()
        {
            InitializeComponent();
        }

        //private clsPerson FillData()
        //{
        //    return new clsPerson(clsPerson.enMode.AddNewMode, NationalNoTB.Text, FirstNameTB.Text,
        //        SecondNameTB.Text, ThirdNameTB.Text, LastNameTB.Text, DateOfBirthDTP.Value, GetGenderAsString(),
        //        AddressTB.Text, PhoneTB.Text, EmailTB.Text, CountryCB.SelectedIndex+1,"ImagePath");
        //}

        private string GetGenderAsString()
        {
            if (MaleRB.Checked)
                return "Male";
            else if (FmaleRB.Checked)
                return "Female";
         else
                return string.Empty;
        }

        private void loadCountries()
        {
            List<clsCountry> countries = clsCountry.GetAllCountries();
            foreach (clsCountry country in countries)
            {
                CountryCB.Items.Add(country.CountryName);
                
            }
            CountryCB.SelectedIndex = 168;
        }


        private void test()
        {
           
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UserCart_Load(object sender, EventArgs e)
        {
            loadCountries();
        }
    }
}
