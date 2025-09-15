using DVLD.Properties;
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


namespace DVLD.People
{
    public partial class AddEditPeople : Form
    {
        public AddEditPeople()
        {
            InitializeComponent();
        }


        private string imageFolderPath = "C:\\Users\\MBM\\My_apps_ahmed\\DVLD_People_images";


        private clsPerson FillData()
        {
            int countryID = CountryCB.SelectedIndex + 1;
            string imagePath = PersonImagePB.Tag == null ? "" : PersonImagePB.Tag.ToString();
            return new clsPerson(clsPerson.enMode.AddNewMode, NationalNoTB.Text, FirstNameTB.Text,
                SecondNameTB.Text, ThirdNameTB.Text, LastNameTB.Text, DateOfBirthDTP.Value, GetGenderAsString(),
                AddressTB?.Text?? "", PhoneTB.Text, EmailTB.Text, countryID, imagePath);
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


        private void loadCountries()
        {
            List<clsCountry> countries = clsCountry.GetAllCountries();
            foreach (clsCountry country in countries)
            {
                CountryCB.Items.Add(country.CountryName);

            }
            CountryCB.SelectedIndex = 168;
        }

        private void UserCart_Load(object sender, EventArgs e)
        {
            MaleRB.Checked = true;
            loadCountries();
            DateOfBirthValidating();
        }


        private string saveImageInFolder(string sourceImagePath)
        {
            if (PersonImagePB.Tag != null)
            {
                File.Delete(PersonImagePB.Tag.ToString());
            }
            string CopyImagePath = imageFolderPath + "\\" + Guid.NewGuid().ToString() + ".jpg";
            File.Copy(sourceImagePath, CopyImagePath);

            return CopyImagePath;

        }


        private void DateOfBirthValidating()
        {
            DateOfBirthDTP.MaxDate = DateTime.Now.AddYears(-18);
            DateOfBirthDTP.MinDate = DateTime.Now.AddYears(-100);

        }

        private void SetImageLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                PersonImagePB.Image = Image.FromFile(filePath);
                PersonImagePB.Tag = saveImageInFolder(filePath);

                RemoveLL.Visible = true;

                MessageBox.Show(PersonImagePB.Tag.ToString());
            }
            else
            {
                MessageBox.Show("No image selected.");
            }
        }

        private void RemoveLL_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonImagePB.Image = Resources.Male_512;
            if (PersonImagePB.Tag != null)
            {
                File.Delete(PersonImagePB.Tag.ToString());
                PersonImagePB.Tag = null;
            }
            RemoveLL.Visible = false;
        }

        private void FirstNameTB_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameTB.Text))
            {
                e.Cancel = true;
                FirstNameTB.Focus();
                errorProvider1.SetError(FirstNameTB, "First Name is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(FirstNameTB, null);
            }
        }

        private void SecondNameTB_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SecondNameTB.Text))
            {
                e.Cancel = true;
                SecondNameTB.Focus();
                errorProvider1.SetError(SecondNameTB, "Second Name is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(SecondNameTB, null);
            }
        }

        private void ThirdNameTB_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ThirdNameTB.Text))
            {
                e.Cancel = true;
                ThirdNameTB.Focus();
                errorProvider1.SetError(ThirdNameTB, "Third Name is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(ThirdNameTB, null);
            }
        }

        private void LastNameTB_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastNameTB.Text))
            {
                e.Cancel = true;
                LastNameTB.Focus();
                errorProvider1.SetError(LastNameTB, "Last Name is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(LastNameTB, null);
            }
        }

        private void NationalNoTB_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NationalNoTB.Text))
            {
                e.Cancel = true;
                NationalNoTB.Focus();
                errorProvider1.SetError(NationalNoTB, "National No is required.");

            }
            else if (clsPerson.IdIsExist(NationalNoTB.Text))
            {
                e.Cancel = true;
                NationalNoTB.Focus();
                errorProvider1.SetError(NationalNoTB, "National NO Is Exist.");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(NationalNoTB, null);
            }
        }

        private void PhoneTB_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(PhoneTB.Text))
            {
                e.Cancel = true;
                PhoneTB.Focus();
                errorProvider1.SetError(PhoneTB, "Phone is required.");
            }
            else if (PhoneTB.Text.Length > 11)
            {
                e.Cancel = true;
                PhoneTB.Focus();
                errorProvider1.SetError(PhoneTB, "Phone must be at least 11 digits.");
            }
            else if (!PhoneTB.Text.All(Char.IsDigit))
            {
                e.Cancel = true;
                PhoneTB.Focus();
                errorProvider1.SetError(PhoneTB, "Phone must contain only digits.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(PhoneTB, null);
            }
        }

        private void EmailTB_Validating_1(object sender, CancelEventArgs e)
        {
          if (!EmailTB.Text.Contains("@"))
            {
                e.Cancel = true;
                EmailTB.Focus();
                errorProvider1.SetError(EmailTB, "Email is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(EmailTB, null);
            }

        }

        private void AddressTB_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(AddressTB.Text))
            {
                e.Cancel = true;
                AddressTB.Focus();
                errorProvider1.SetError(AddressTB, "Address is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(AddressTB, null);
            }
        }

        private void AddEditPeople_Load(object sender, EventArgs e)
        {
            MaleRB.Checked = true;  
            loadCountries();
            DateOfBirthValidating();

        }

        private void MaleRB_CheckedChanged_1(object sender, EventArgs e)
        {
            if (MaleRB.Checked && PersonImagePB.Tag == null)
            {
                PersonImagePB.Image = Resources.Male_512;
            }
        }

        private void FmaleRB_CheckedChanged_1(object sender, EventArgs e)
        {
            if (FmaleRB.Checked && PersonImagePB.Tag == null)
            {
                PersonImagePB.Image = Resources.Female_512;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
           int newPersonID= DVLD_Buisness.clsPerson.AddNewPerson(FillData());
            if(newPersonID == -1)
            {
                MessageBox.Show("Error adding new person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PersonIdLE.Text = newPersonID.ToString();
            MessageBox.Show("New person added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




    }
}
