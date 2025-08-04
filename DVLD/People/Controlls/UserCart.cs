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
using DVLD_Buisness;

namespace DVLD.People.Controlls
{
    public partial class UserCart : UserControl
    {
        public UserCart()
        {
            InitializeComponent();
        }

        private clsPerson FillData()
        {
          return new clsPerson(clsPerson.enMode.AddNewMode,NationalNoTB.Text,FirstNameTB.Text,
              SecondNameTB.Text, ThirdNameTB.Text,LastNameTB.Text, DateOfBirthDTP.Value, GetGenderAsString(),
              AddressTB.Text,PhoneTB.Text,EmailTB.Text,N);
        }
         
        private string GetGenderAsString()
        {
            if (MaleRB.Checked)
                return "Male";
            else if (FmaleRB.Checked)
                return "Female";
         else
                return string.Empty;
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
