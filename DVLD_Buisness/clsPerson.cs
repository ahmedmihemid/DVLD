using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess; 

namespace DVLD_Buisness
{
    public class clsPerson
    {

        public enum enMode { EmptyMode = 0, UpdateMode = 1, AddNewMode = 2 }

        private enMode Mode;
        private int PersonID { get; set; }

        private string NationalNo { get; set; }

        private string FirstName { get; set; }

        private string SecondName { get; set; }

        private string ThirdName { get; set; }  // nullable

        private string LastName { get; set; }

        private DateTime DateOfBirth { get; set; }

        private string Gender { get; set; }  // tinyint → byte

        private string Address { get; set; }

        private string Phone { get; set; }

        private string Email { get; set; }  // nullable

        private int NationalityCountryID { get; set; }

        private string ImagePath { get; set; }


        private clsPerson()
        {
            Mode = enMode.EmptyMode;
            //PersonID = 0;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gender = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationalityCountryID= 0;
            ImagePath = string.Empty;

        }

        public clsPerson(enMode mode , string nationalNo, string firstName, string secondName, string thirdName,
            string lastName, DateTime dateofBirth, string gender, string address, string phone, string email,
            int narionalityCountryID, string imagePath)
        {
            Mode = mode;
            //PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateofBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = narionalityCountryID;
            ImagePath = imagePath;
        }





        private static byte GetGenderAsByte(string strGender)
        {
            if(strGender=="Male")
                return 0;
            else 
                return 1;
        }


        public static DataTable GetAllPeople()
        {
            return  DVLD_DataAccess.clsPeopleData.GetAllPeople();
        }


        public static DataTable GetFilteredPeople(string columnName, string filterValue)
        {
            return DVLD_DataAccess.clsPeopleData.GetFilteredPeople(columnName, filterValue);
        }
      
        public static bool IdIsExist(string nationalNo)
        {
            return DVLD_DataAccess.clsPeopleData.IdIsExist(nationalNo);
        }


        public static int  AddNewPerson(clsPerson newPerson)
        {
            return DVLD_DataAccess.clsPeopleData.AddNewPerson(newPerson.NationalNo, newPerson.FirstName,
                newPerson.SecondName, newPerson.ThirdName, newPerson.LastName, newPerson.DateOfBirth,
                GetGenderAsByte(newPerson.Gender), newPerson.Address, newPerson.Phone,
                newPerson.Email, newPerson.NationalityCountryID, newPerson.ImagePath);

        }
    }
}
