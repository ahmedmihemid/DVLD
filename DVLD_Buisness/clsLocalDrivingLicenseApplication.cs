using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DVLD_Buisness
{
    public class clsLocalDrivingLicenseApplication
    {

        public enum enMode { AddNew = 1, Edit = 2 }
        public enMode Mode = enMode.AddNew;
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
      

        public clsLocalDrivingLicenseApplication()
        {
            Mode = enMode.AddNew;
            LocalDrivingLicenseApplicationID = 0;
            ApplicationID = 0;
            LicenseClassID = 0;
        }

        public clsLocalDrivingLicenseApplication(int localDrivingLicenseApplicationID, int applicationID, int licenseClassID)
        {
            Mode = enMode.Edit;
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.ApplicationID = applicationID;
            this.LicenseClassID = licenseClassID;
        }

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

        private bool _Update()
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.Update(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
        }

        public static bool HasApplicationForLicenseClass(int applicationID, int licenseClassID ,int ApplicationStatus)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.HasApplicationForLicenseClass(applicationID, licenseClassID, ApplicationStatus);
        
        }

        public static clsLocalDrivingLicenseApplication FindByApplicationID(int applicationID)
        {
            int localDrivingLicenseApplicationID = 0;
            int licenseClassID = 0;
            bool isFound = DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.FindByApplicationID(applicationID, ref localDrivingLicenseApplicationID, ref licenseClassID);
            if (isFound)
            {
                return new clsLocalDrivingLicenseApplication(localDrivingLicenseApplicationID, applicationID, licenseClassID);
            }
            else
            {
                return null;
            }
        }

        public static clsLocalDrivingLicenseApplication Find(int localDrivingLicenseApplicationID)
        {
            int applicationID = 0;
            int licenseClassID = 0;
            bool isFound = DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.Find(localDrivingLicenseApplicationID, ref applicationID, ref licenseClassID);
            if (isFound)
            {
                return new clsLocalDrivingLicenseApplication(localDrivingLicenseApplicationID, applicationID, licenseClassID);
            }
            else
            {
                return null;
            }
        }



        public static DataTable GetAllLocalDrivingLicenseApplicationInfo()
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplicationInfo();
        }



        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (!_AddNew())
                    {
                        return false;
                    }
                    else
                    {
                        Mode = enMode.Edit;
                        return true;
                    }
                case enMode.Edit:
                    return _Update();
            }
            return false;

        }









    }
}
