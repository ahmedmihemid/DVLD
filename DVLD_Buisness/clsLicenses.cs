using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DVLD_Buisness
{
    public class clsLicenses
    {

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public clsLicenseClass LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Note { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }


        public enum enMode { New = 1, Edit = 2}
        private enMode _Mode ;

        public enum enReason { FirstTime=1, Renew=2, ReplacementForDamaged=3, ReplacementForLost=4 }



        public clsLicenses()
        {
            _Mode = enMode.New;
        }

        public clsLicenses(int licenseID, int applicationID, int driverID, clsLicenseClass licenseClass, DateTime issueDate, DateTime expiryDate, string note, float paidFees, bool isActive, enReason issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClass = licenseClass;
            IssueDate = issueDate;
            ExpiryDate = expiryDate;
            Note = note;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
            _Mode =enMode.Edit;
        }







        //public static bool IsFirstTimeIssue(int applicationID, int localDrivingLicenseApplicationID, int licenseClassID)
        //{
        //    return DVLD_DataAccess.clsLicensesData.IsFirstTimeIssue(applicationID, localDrivingLicenseApplicationID, licenseClassID);
        //}


        public static DataTable GetAllLocalLicenses(int driverID)
        {
            return DVLD_DataAccess.clsLicensesData.GetAllLocalLicenses(driverID);
        }

        public static DataTable GetAllInternationalLicenses(int driverID)
        {
            return DVLD_DataAccess.clsLicensesData.GetAllInternationalLicenses(driverID);
        }

        public static clsLicenses Find(int licenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int licenseClassID = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpiryDate = DateTime.MinValue;
            string Note = string.Empty;
            float PaidFees = -1; 
            bool IsActive = false;
            int IssueReasonID = -1;
            int CreatedByUserID = -1;


             bool isFound= DVLD_DataAccess.clsLicensesData.Find(licenseID,ref ApplicationID,ref DriverID,ref licenseClassID,
                ref IssueDate,ref ExpiryDate,ref Note ,ref PaidFees, ref IsActive , ref IssueReasonID, ref CreatedByUserID);

            if (isFound)
                {
                return new clsLicenses(licenseID, ApplicationID, DriverID, clsLicenseClass.Find(licenseClassID), IssueDate, ExpiryDate, Note, PaidFees, IsActive,
                    (enReason)IssueReasonID, CreatedByUserID);
            }
            return null;
        }

        public static int GetLicenseIDByApplicationID(int applicationID)
        {
            return DVLD_DataAccess.clsLicensesData.GetLicenseIDByApplicationID(applicationID);
        }

        private bool _AddNew()
        {
           int newLicenseID = DVLD_DataAccess.clsLicensesData.AddNew(ApplicationID, DriverID, LicenseClass.LicenseClassID, IssueDate, ExpiryDate, Note, PaidFees, IsActive,(int)IssueReason, CreatedByUserID);
           if(newLicenseID > 0)
            {
                LicenseID = newLicenseID;
                return true;
            }
              return false;
        }
        private bool _Update()
        {
            // Update license logic to be implemented
            return false;
        }

        public bool save()
        {
            switch (_Mode)
            {
                case enMode.New:
                   if(_AddNew())
                    {
                        _Mode = enMode.Edit;
                        return true;
                    }
                    return false;
                case enMode.Edit:
                    return _Update();
                default:
                    return false;
            }
        }





    }
}
