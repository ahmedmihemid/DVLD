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

        public enum enMode { EmptyMode = 0, UpdateMode = 1, AddNewMode = 2, ViewMode=3 }

        private enMode _Mode;
        private int PersonID;

        private string _NationalNo;

        private string _FirstName;

        private string _SecondName;

        private string _ThirdName;

        private string _LastName;

        private DateTime _DateOfBirth;

        private string _Gender;

        private string _Address;

        private string _Phone;

        private string _Email;

        private int _NationalityCountryID;

        private string _ImagePath;




        private clsPerson()
        {
            _Mode = enMode.EmptyMode;
            //PersonID = 0;
            _NationalNo = string.Empty;
            _FirstName = string.Empty;
            _SecondName = string.Empty;
            _ThirdName = string.Empty;
            _LastName = string.Empty;
            _DateOfBirth = DateTime.MinValue;
            _Gender = string.Empty;
            _Address = string.Empty;
            _Phone = string.Empty;
            _Email = string.Empty;
            _NationalityCountryID = 0;
            _ImagePath = string.Empty;

        }

        public clsPerson(enMode mode , string nationalNo, string firstName, string secondName, string thirdName,
            string lastName, DateTime dateofBirth, string gender, string address, string phone, string email,
            int narionalityCountryID, string imagePath)
        {
            _Mode = mode;
            //PersonID = personID;
            _NationalNo = nationalNo;
            _FirstName = firstName;
            _SecondName = secondName;
            _ThirdName = thirdName;
            _LastName = lastName;
            _DateOfBirth = dateofBirth;
            _Gender = gender;
            _Address = address;
            _Phone = phone;
            _Email = email;
            _NationalityCountryID = narionalityCountryID;
            _ImagePath = imagePath;
        }







        // Properties (getters/setters)
        public enMode ModeProp
        {
            get => _Mode;
            set => _Mode = value;
        }

        public int Id
        {
            get => PersonID;
            //set => PersonID = value;
        }

        public string NationalNo
        {
            get => _NationalNo;
            set => _NationalNo = value;
        }

        public string FirstName
        {
            get => _FirstName;
            set => _FirstName = value;
        }

        public string SecondName
        {
            get => _SecondName;
            set => _SecondName = value;
        }

        public string ThirdName
        {
            get => _ThirdName;
            set => _ThirdName = value;
        }

        public string LastName
        {
            get => _LastName;
            set => _LastName = value;
        }

        public DateTime DateOfBirth
        {
            get => _DateOfBirth;
            set => _DateOfBirth = value;
        }

        public string Gender
        {
            get => _Gender;
            set => _Gender = value;
        }

        public string Address
        {
            get => _Address;
            set => _Address = value;
        }

        public string Phone
        {
            get => _Phone;
            set => _Phone = value;
        }

        public string Email
        {
            get => _Email;
            set => _Email = value;
        }

        public int NationalityCountryID
        {
            get => _NationalityCountryID;
            set => _NationalityCountryID = value;
        }

        public string ImagePath
        {
            get => _ImagePath;
            set => _ImagePath = value;
        }

        public string FullName
        {
            get => $"{_FirstName} {_SecondName} {_ThirdName} {_LastName}";
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
            return DVLD_DataAccess.clsPeopleData.AddNewPerson(newPerson._NationalNo, newPerson._FirstName,
                newPerson._SecondName, newPerson._ThirdName, newPerson._LastName, newPerson._DateOfBirth,
                GetGenderAsByte(newPerson.Gender), newPerson._Address, newPerson._Phone,
                newPerson._Email, newPerson._NationalityCountryID, newPerson._ImagePath);

        }

        public static clsPerson GetPersonByID(int personID)
        {

            DataTable dt = DVLD_DataAccess.clsPeopleData.GetPersonByID(personID);
            DataRow dr = dt.Rows[0];
            clsPerson person = new clsPerson();

            person._Mode = enMode.ViewMode;
            person.PersonID = Convert.ToInt32(dr["PersonID"]);
            person._NationalNo = dr["NationalNo"].ToString();
            person._FirstName = dr["FirstName"].ToString();
            person._SecondName = dr["SecondName"].ToString();
            person._ThirdName = dr["ThirdName"].ToString();
            person._LastName = dr["LastName"].ToString();
            person._DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
            person._Gender = dr["GenderString"].ToString();
            person._Address = dr["Address"].ToString();
            person._Phone = dr["Phone"].ToString();
            person._Email = dr["Email"].ToString();
            person._NationalityCountryID = Convert.ToInt32(dr["NationalityCountryID"]);
            person._ImagePath = dr["ImagePath"].ToString();

            return person;

        }
    }
}




