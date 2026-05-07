using DVLD.Properties;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD.People
{
    public partial class frAddEditPeople : Form
    {


        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGendor { Male = 0, Female = 1 };

        private enMode _Mode = enMode.AddNew;
        private int _PersonID = 1;
        private clsPerson _Person;
        private string imageFolderPath = "C:\\Users\\MBM\\My_apps_ahmed\\DVLD_People_images";


        public frAddEditPeople()
        {
            InitializeComponent();
        }

        public frAddEditPeople(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PersonID = PersonID;
        }


        private void _ResetDefualtValues()
        {
            _FillCountriesInComoboBox();
            _Person = new clsPerson();

            if (_Mode == enMode.AddNew)
            {
                TitleLEB.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                TitleLEB.Text = "Edit Person";

            }

            MaleRB.Checked = true;

            if (MaleRB.Checked)
                PersonImagePB.Image = Resources.Male_512;
            else
                PersonImagePB.Image = Resources.Female_512;

            RemoveLL.Visible = (_Person.ImagePath != "");

            DateOfBirthDTP.MaxDate = DateTime.Now.AddYears(-18);
            DateOfBirthDTP.Value = DateOfBirthDTP.MaxDate;

            DateOfBirthDTP.MinDate = DateTime.Now.AddYears(-100);

            CountryCB.SelectedIndex = CountryCB.FindString("Syria");



            FirstNameTB.Text = "";
            SecondNameTB.Text = "";
            ThirdNameTB.Text = "";
            LastNameTB.Text = "";
            NationalNoTB.Text = "";
            AddressTB.Text = "";
            PhoneTB.Text = "";
            EmailTB.Text = "";

        }


        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("Error: Person not found");
                this.Close();
                return;
            }
            _FillCountriesInComoboBox();
            this.Text = "Edit Person";
            FirstNameTB.Text = _Person.FirstName;
            SecondNameTB.Text = _Person.SecondName;
            ThirdNameTB.Text = _Person.ThirdName;
            LastNameTB.Text = _Person.LastName;
            NationalNoTB.Text = _Person.NationalNo;
            DateOfBirthDTP.Value = _Person.DateOfBirth;

            if (_Person.Gendor == 0)
                MaleRB.Checked = true;
            else
                FamaleRB.Checked = true;

            AddressTB.Text = _Person.Address;
            PhoneTB.Text = _Person.Phone;
            EmailTB.Text = _Person.Email;
            CountryCB.SelectedIndex = CountryCB.FindString(_Person.CountryInfo.CountryName);

            if (_Person.ImagePath != "")
            {
                PersonImagePB.ImageLocation = _Person.ImagePath;
            } else
            {
               if (MaleRB.Checked)
                    PersonImagePB.Image = Resources.Male_512;
                else
                    PersonImagePB.Image = Resources.Female_512;
            }



        }

        private void _FillCountriesInComoboBox()
        {
            DataTable countries = clsCountry.GetAllCountries();

            foreach (DataRow row in countries.Rows)
            {
                CountryCB.Items.Add(row["CountryName"]);
            }

        }

        private bool _HandlePersonImage()
        {
            if(PersonImagePB.ImageLocation!= _Person.ImagePath)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {

                    }
                }

                if(PersonImagePB.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = PersonImagePB.ImageLocation.ToString();

                    if(Classes.clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        PersonImagePB.ImageLocation = SourceImageFile;
                        return true;

                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }

            }

            return true;
        }

        private void AddEditPeople_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(tb, "This field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tb, null);
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            //no need to validate the email incase it's empty.
            if (EmailTB.Text.Trim() == "")
                return;

            //validate email format
            if (!Classes.clsValidatoin.ValidateEmail(EmailTB.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(EmailTB, "Invalid Email Address Format!");
            }
           else
            { 
                errorProvider1.SetError(EmailTB, null); 
            };
        }

        private void PhoneTB_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Trim() == "")
                return;
            if (!Classes.clsValidatoin.IsNumber(tb.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tb, "Invalid Phone Number Format!");
            }
            else
            {
                errorProvider1.SetError(tb, null);
            } ;

        }

        private void NationalNoTB_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NationalNoTB.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(NationalNoTB, "National No is required.");
            }
            else if(clsPerson.IsExist(NationalNoTB.Text.Trim())  && NationalNoTB.Text.Trim() != _Person.NationalNo)
            {
                e.Cancel = true;
                errorProvider1.SetError(NationalNoTB, "National No is Exist ");
            }
            else
            {
                errorProvider1.SetError(NationalNoTB, null);
            }


        }

        private void MaleRB_Click(object sender, EventArgs e)
        {

            if (PersonImagePB.ImageLocation == null)
                PersonImagePB.Image = Resources.Male_512;
        }

        private void FamaleRB_Click(object sender, EventArgs e)
        {
            if (PersonImagePB.ImageLocation == null)
                PersonImagePB.Image = Resources.Female_512;
        }

        private void SetImageLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                PersonImagePB.Load(selectedFilePath);
                RemoveLL.Visible = true;
                // ...
            }
        }

        private void RemoveLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonImagePB.ImageLocation = null;

            if (MaleRB.Checked)
                PersonImagePB.Image = Resources.Male_512;
            else
                PersonImagePB.Image = Resources.Female_512;

            RemoveLL.Visible = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandlePersonImage())
                return;

            _Person.FirstName = FirstNameTB.Text.Trim();
            _Person.SecondName = SecondNameTB.Text.Trim();
            _Person.ThirdName = ThirdNameTB.Text.Trim();
            _Person.LastName = LastNameTB.Text.Trim();
            _Person.NationalNo = NationalNoTB.Text.Trim();
            _Person.DateOfBirth = DateOfBirthDTP.Value;
            _Person.Gendor = (short)(MaleRB.Checked ? 0 : 1);   
            _Person.Address = AddressTB.Text.Trim();
            _Person.Phone = PhoneTB.Text.Trim();
            _Person.Email = EmailTB.Text.Trim();
            _Person.NationalityCountryID = clsCountry.Find(CountryCB.SelectedItem.ToString()).ID;

            if(PersonImagePB.ImageLocation != null)
                _Person.ImagePath = PersonImagePB.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                PersonIdLE.Text = _Person.PersonID.ToString();
                TitleLEB.Text = "Edite Person";
                _Mode = enMode.Update;

                MessageBox.Show("Person Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Person.PersonID);

            }
            else
            {
                MessageBox.Show("Error: Saving Person Data Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }



        }

     
        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
