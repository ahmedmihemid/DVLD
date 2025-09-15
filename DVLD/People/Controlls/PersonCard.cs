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

namespace DVLD.People.Controlls
{
    public partial class PersonCard : UserControl
    {
        
        public PersonCard()
        {
            InitializeComponent();
            
        }

        private  void PersonCard_Load(object sender, EventArgs e)
        {
            
        }


        public void LoadPersonData(int id)
        {
            DVLD_Buisness.clsPerson person = DVLD_Buisness.clsPerson.GetPersonByID(id);

            PersonIdLEB.Text = person.Id.ToString();
            NameLEB.Text = person.FullName;
            NationalNoLEB.Text = person.NationalNo;
            DateOfBirhtLEB.Text = person.DateOfBirth.ToShortDateString();
            GendorLEB.Text = person.Gender;
            PhoneLEB.Text = person.Phone;
            EmailLEb.Text = person.Email;
            CountryLEB.Text = clsCountry.getCountryName(person.NationalityCountryID);
            AddressLEB.Text = person.Address;

            if (person.ImagePath != null && person.ImagePath != "")
            {
                try
                {
                    PersonPB.Image = Image.FromFile(person.ImagePath);
                    PersonPB.Tag = person.ImagePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            
            }


            else
            {
                if (person.Gender == "Male")
                { PersonPB.Image = Properties.Resources.Male_512; }
                else
                { PersonPB.Image = Properties.Resources.Female_512; }
            }

        }



    }
}
