using DVLD_Buisness;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD.Classes
{
    public class clsGlobal
    {

        public static clsUser CurrentUser;



        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            string valueName1 = "UserName";
            string valueName2 = "Password";
            string valueData1 = Username;
            string valueData2 = Password;

            try
            {
                // Set the registry value
                Registry.SetValue(keyPath, valueName1, valueData1, RegistryValueKind.String);
                Registry.SetValue(keyPath, valueName2, valueData2, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error setting registry value: " + ex.Message);
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {

            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            string valueName1 = "UserName";
            string valueName2 = "Password";
      
            try
            {
                string valueData1 = Registry.GetValue(keyPath, valueName1, null) as string;
                string valueData2 = Registry.GetValue(keyPath, valueName2, null) as string;
                if (valueData1 != null && valueData2 != null)
                {
                    Username = valueData1;
                    Password = valueData2;
                    return true;
                }
                else
                {
                    Console.WriteLine("Registry value not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading registry value: " + ex.Message);
                return false;
            }

        }

    }
}
