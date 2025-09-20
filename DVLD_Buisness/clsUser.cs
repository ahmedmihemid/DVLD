using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsUser
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsPerson Person { get; set; }



        public clsUser()
        {

        }


        public clsUser(int UserID)
        {

        }


        public static clsUser Find(string UserName)
        {
            clsUser user = new clsUser();
           
            int userID = 0;
            int personID = 0;
            string password = string.Empty;
            bool isActive = false;

            DVLD_DataAccess.clsUserData.FindByUserName(user.UserName, ref userID, ref personID, ref password, ref isActive);

            user.UserName = UserName;
            user.UserID = userID;
            user.PersonID = personID;
            user.Password = password;
            user.IsActive = isActive;

            return user;
        }


        public static clsUser Login(string UserName,string Password, ref bool IsFound)
        {

            int userID = 0;
            int personID = 0;
            bool isActive = false;

            IsFound= DVLD_DataAccess.clsUserData.Login(UserName,  Password, ref userID, ref personID, ref isActive);

            clsUser user = new clsUser();
            user.UserName = UserName;
            user.UserID = userID;
            user.PersonID = personID;
            user.Password = Password;
            user.IsActive = isActive;

            return user;
        }




   

}
}
