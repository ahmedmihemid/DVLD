using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DVLD_Shared;


namespace DVLD_Buisness
{
    public class clsUtil
    {



        public static string HashPassword(string password)
        {
            // Hash the password using SHA256
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();

            }

        }



    }
}
