using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsLocalDrivingLicenseApplication
    {

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }



        public static bool IsExist(int ApplicationID, int LicenseClassID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.IsExist(ApplicationID, LicenseClassID);
        }


        private bool _AddNew()
        {
            int newID = DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.AddNew(ApplicationID, LicenseClassID);
            if (newID > 0)
            {
                this.LocalDrivingLicenseApplicationID = newID;
                return true;
            }
            else
            {
                return false;
            }

        }



        public static bool HasApplicationForLicenseClass(int applicationID, int licenseClassID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.HasApplicationForLicenseClass(applicationID, licenseClassID);
        
        }

        public static clsLocalDrivingLicenseApplication FindByApplicationID(int applicationID)
        {
            int localDrivingLicenseApplicationID = 0;
            int licenseClassID = 0;
            bool isFound = DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.FindByApplicationID(applicationID, ref localDrivingLicenseApplicationID, ref licenseClassID);
            if (isFound)
            {
                clsLocalDrivingLicenseApplication obj = new clsLocalDrivingLicenseApplication();
                obj.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
                obj.ApplicationID = applicationID;
                obj.LicenseClassID = licenseClassID;
                return obj;
            }
            else
            {
                return null;
            }
        }




        public bool Save()
        {

            return _AddNew();

        }
    }
}
