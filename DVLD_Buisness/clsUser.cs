using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DVLD_Buisness
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, UpdateMode = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsPerson Person { get; set; }



        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = true;

            Person = new clsPerson();
        }


       public clsUser(int userID, int personID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            Person = new clsPerson();
            Mode = enMode.UpdateMode;
        }

        public static clsUser Find(string UserName)
        {
            clsUser user = new clsUser();
           
            int userID = 0;
            int personID = 0;
            string password = string.Empty;
            bool isActive = false;

            DVLD_DataAccess.clsUserData.FindByUserName(user.UserName, ref userID, ref personID, ref password, ref isActive);

            return new clsUser(userID, personID, UserName, password, isActive);
        }

        public static clsUser Find(int UserID)
        {
            

            string userName = string.Empty;
            int personID = 0;
            string password = string.Empty;
            bool isActive = false;

            DVLD_DataAccess.clsUserData.FindByUserID(UserID, ref userName, ref personID, ref password, ref isActive);

           
            return new clsUser(UserID, personID, userName, password, isActive);

        }

        public static clsUser Login(string UserName,string Password, ref bool IsFound)
        {

            int userID = 0;
            int personID = 0;
            bool isActive = false;

            IsFound= DVLD_DataAccess.clsUserData.Login(UserName,  Password, ref userID, ref personID, ref isActive);

           return new clsUser(userID, personID, UserName, Password, isActive);
        }

        public static DataTable GetAllUser()
        {
            return DVLD_DataAccess.clsUserData.GetAllUsers();
        }

        public static bool IsExistByPersonID(int PersonID)
        {
            return DVLD_DataAccess.clsUserData.IsExistByPersonID(PersonID);
        }

        public static bool IsExistByUserName(string UserName)
        {
            return DVLD_DataAccess.clsUserData.IsExistByUserName(UserName);
        }

        private bool _AddNewUser()
        {
          this.UserID= DVLD_DataAccess.clsUserData.addNewUser
                (this.PersonID, this.UserName, this.Password, this.IsActive);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return DVLD_DataAccess.clsUserData.UpdateUser
                (this.UserID, this.UserName, this.Password, this.IsActive);
        }

        public static bool DeleteUser(int UserID)
        {
           return   DVLD_DataAccess.clsUserData.DeleteUser(UserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                {
                      if(  _AddNewUser())
                      {
                            Mode = enMode.UpdateMode;
                            return true;
                      }
                      else
                      {
                            return false;

                      }
                        break;
                }
                case enMode.UpdateMode:
                {
                        _UpdateUser();
                        return true;
                        break;
                }

            }
            return false;
        }


    }
}
