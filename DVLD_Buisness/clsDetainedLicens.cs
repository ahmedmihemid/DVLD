using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DVLD_Buisness
{
    public class clsDetainedLicens
    {

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public int FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }

        public enum enMode { AddNew = 0, Update = 1 };
        enMode mode;

        public clsDetainedLicens()
        {
           
            DetainID = -1;
                LicenseID = -1;
                DetainDate = DateTime.Now;
                FineFees = -1;
                CreatedByUserID = -1;
                IsReleased = false;
                ReleaseDate = DateTime.MinValue;
                ReleasedByUserID = -1;
                ReleaseApplicationID = -1;
                mode = enMode.AddNew;
        }

        public clsDetainedLicens(int detainID, int licenseID, DateTime detainDate, int fineFees, int createdByUserID, bool isReleased, DateTime releaseDate, int releasedByUserID, int releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;
            mode = enMode.Update;

        }


        public static DataTable GetAllDetainedLicenses()
        {
            return DVLD_DataAccess.clsDetainedLicensesData.GetAllDetainedLicenses();
        }

        public bool Detain()
        {
            int newID = DVLD_DataAccess.clsDetainedLicensesData.AddDetainedLicense(LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased);
            if (newID != 0)
            {
                DetainID = newID;
                return true;
            }
            return false;
        }

        public bool Release()
        {
          if (!IsReleased)      
          return DVLD_DataAccess.clsDetainedLicensesData.ReleaseDetainedLicense(DetainID, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);

          else
           return false;

        }

        public static clsDetainedLicens GetDetainedLicenseInfoByLicenseID(int LicenseID)
        {
            DateTime DetainDate = DateTime.MinValue;
            int detainID = -1;
            int FineFees = -1;
            int CreatedByUserID = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.MinValue;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;


            bool isSuccess = DVLD_DataAccess.clsDetainedLicensesData.GetDetainedLicenseInfoByLicenseID(LicenseID, ref detainID, ref DetainDate, ref FineFees,
            ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID);


            if (isSuccess)
            {
                return new clsDetainedLicens(detainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
            {
                return null;

            }
        }

        public static clsDetainedLicens GetDetainedLicenseInfoByDetainID(int detainID)
        {
            DateTime DetainDate = DateTime.MinValue;
            int LicenseID = -1;
            int FineFees = -1;
            int CreatedByUserID = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.MinValue;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;


            bool isSuccess = DVLD_DataAccess.clsDetainedLicensesData.FineByDetainedID(detainID, ref LicenseID, ref DetainDate, ref FineFees,
            ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID);


            if (isSuccess)
            {
                return new clsDetainedLicens(detainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
            {
                return null;

            }
        }


        public static bool IsLicenseDetained(int detainID)
        {
            return DVLD_DataAccess.clsDetainedLicensesData.IsLicenseDetained(detainID);
        }

        public static bool LicenseIsExist(int licenseID)
        {
            return DVLD_DataAccess.clsDetainedLicensesData.LicenseIsExist(licenseID);
        }





    }
}
