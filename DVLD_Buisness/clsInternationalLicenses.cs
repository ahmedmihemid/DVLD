using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DVLD_Buisness
{
    public class clsInternationalLicenses
    {


        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode;


        public clsInternationalLicenses()
        {
            InternationalLicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            IssuedUsingLocalLicenseID = 0;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = true;
            CreatedByUserID = 0;
            _Mode = enMode.AddNew;
        }

        public clsInternationalLicenses(int pInternationalLicenseID, int pApplicationID, int pDriverID,
            int pIssuedUsingLocalLicenseID, DateTime pIssueDate, DateTime pExpirationDate,
            bool pIsActive, int pCreatedByUserID)
        {
            InternationalLicenseID = pInternationalLicenseID;
            ApplicationID = pApplicationID;
            DriverID = pDriverID;
            IssuedUsingLocalLicenseID = pIssuedUsingLocalLicenseID;
            IssueDate = pIssueDate;
            ExpirationDate = pExpirationDate;
            IsActive = pIsActive;
            CreatedByUserID = pCreatedByUserID;
            _Mode = enMode.Update;
        }


        public static DataTable GetAllInternationalLicenses()
        {
            return DVLD_DataAccess.clsInternationalLicensesData.GetAllInternationalLicenses();
        }

        public static DataTable GetAllInternationalLicensesForDriver(int driverID)
        {
            return DVLD_DataAccess.clsInternationalLicensesData.GetAllInternationalLicensesForDriver(driverID);
        }

        public static clsInternationalLicenses GetInternationalLicenseByID(int internationalLicenseID)
        {
            int applicationID = -1;
            int driverID = -1;
            int issuedUsingLocalLicenseID = -1;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            bool isActive = false;
            int createdByUserID = -1;

            if (DVLD_DataAccess.clsInternationalLicensesData.GetInternationalLicenseByID(internationalLicenseID, ref applicationID,
                  ref driverID, ref issuedUsingLocalLicenseID, ref issueDate, ref expirationDate, ref isActive, ref createdByUserID))
            {
                return new clsInternationalLicenses(internationalLicenseID, applicationID, driverID, issuedUsingLocalLicenseID, issueDate, expirationDate, isActive, createdByUserID);
            }
            else
            {
                return null;
            }


        }


        public static clsInternationalLicenses GetInternationalLicenseByLocalLicenseIDint(int localLicenseID)
        {
            int internationalLicenseID = -1;
            int applicationID = -1;
            int driverID = -1;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            bool isActive = false;
            int createdByUserID = -1;
            if (DVLD_DataAccess.clsInternationalLicensesData.GetInternationalLicenseByLocalLicenseIDint(localLicenseID, ref internationalLicenseID, ref applicationID,
                  ref driverID, ref issueDate, ref expirationDate, ref isActive, ref createdByUserID))
            {
                return new clsInternationalLicenses(internationalLicenseID, applicationID, driverID, localLicenseID, issueDate, expirationDate, isActive, createdByUserID);
            }
            else
            {
                return null;
            }


        }

        private bool AddNew()
        {
            int newID = DVLD_DataAccess.clsInternationalLicensesData.AddNewInternationalLicense(ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            if (newID > 0)
            {
                InternationalLicenseID = newID;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Update()
        {
            return DVLD_DataAccess.clsInternationalLicensesData.UpdateInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (AddNew())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    return Update();
                default:
                    return false;
            }
        }

    }
}
