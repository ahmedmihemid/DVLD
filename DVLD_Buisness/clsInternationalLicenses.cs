using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        enum enMode { AddNew = 1, Edit = 2 }
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
            _Mode = enMode.Edit;
        }







    }
}
