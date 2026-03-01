using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Buisness
{
    public class clsLocalDrivingLicenseApplication : clsApplications
    {

        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo;
        public string PersonFullName
        {
            get
            {
                return clsPerson.Find(ApplicantPersonID).FirstName;
            }
        }




        public clsLocalDrivingLicenseApplication()
        {
            Mode = enMode.AddNew;

            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;
        }

        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
           DateTime ApplicationDate, int ApplicationTypeID,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
            float PaidFees, int CreatedByUserID, int LicenseClassID)

        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID; ;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            Mode = enMode.Update;
        }




        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(ApplicationID, LicenseClassID);
            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
        }

        public static clsLocalDrivingLicenseApplication FindByApplicationID(int applicationID)
        {
            int localDrivingLicenseApplicationID = -1;
            int licenseClassID = -1;
            bool isFound = DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID(applicationID, ref localDrivingLicenseApplicationID, ref licenseClassID);
            if (isFound)
            {
                clsApplications Application = clsApplications.Find(applicationID);

                return new clsLocalDrivingLicenseApplication(
                     localDrivingLicenseApplicationID, Application.ApplicationID,
                     Application.ApplicantPersonID,
                                      Application.ApplicationDate, Application.ApplicationTypeID,
                                     (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                      Application.PaidFees, Application.CreatedByUserID, licenseClassID);
            }
            else
            {
                return null;
            }
        }

        public static clsLocalDrivingLicenseApplication FindByLocalDrivingAppLicenseID(int localDrivingLicenseApplicationID)
        {
            int applicationID = -1;
            int licenseClassID = -1;
            bool isFound = DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(localDrivingLicenseApplicationID, ref applicationID, ref licenseClassID);
            if (isFound)
            {
                clsApplications Application = clsApplications.Find(applicationID);

                return new clsLocalDrivingLicenseApplication(
                   localDrivingLicenseApplicationID, Application.ApplicationID,
                   Application.ApplicantPersonID,
                                    Application.ApplicationDate, Application.ApplicationTypeID,
                                   (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                    Application.PaidFees, Application.CreatedByUserID, licenseClassID);
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

            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            base.Mode = (clsApplications.enMode)Mode;
            if (!base.Save())
            {
                return false;
            }

            //After we save the main application now we save the sub application.
            switch (Mode)
            {
                case enMode.AddNew:
                    if (!_AddNewLocalDrivingLicenseApplication())
                    {
                        return false;
                    }
                    else
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                case enMode.Update:
                    return _UpdateLocalDrivingLicenseApplication();
            }
            return false;

        }

        public bool Delete()
        {
            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;
            //First we delete the Local Driving License Application

            IsLocalDrivingApplicationDeleted = DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);

            if (!IsLocalDrivingApplicationDeleted)
                return false;

            IsBaseApplicationDeleted = base.Delete();
            return IsBaseApplicationDeleted;
        }


        public int GetActiveLicenseID()
        {
            return clsLicenses.GetLicenseIDByPersonID(ApplicantPersonID, LicenseClassID);
        }

        public bool IsLicenseIssued()
        {
            int licenseID = GetActiveLicenseID();
            return (licenseID != -1);
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType testTypeID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)testTypeID);
        }

        public bool DoesPassTestType(clsTestTypes.enTestType testTypeID)
        {
            return DoesPassTestType(this.LocalDrivingLicenseApplicationID, testTypeID);
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType testTypeID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)testTypeID);
        }

        public bool DoesAttendTestType(clsTestTypes.enTestType testTypeID)
        {
            return DoesAttendTestType(this.LocalDrivingLicenseApplicationID, testTypeID);

        }


        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType testTypeID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)testTypeID);
        }
        public bool IsThereAnActiveScheduledTest(clsTestTypes.enTestType testTypeID)
        {
            return IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, testTypeID);
        }


        public static int TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType testTypeID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)testTypeID);
        }

        public int TotalTrialsPerTest(clsTestTypes.enTestType testTypeID)
        {
            return DVLD_DataAccess.clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)testTypeID);

        }


        public clsTests GetLastTestPerTestType(clsTestTypes.enTestType testTypeID)
        {
          return clsTests.FindLastTestPerPersonAndLicenseClass(ApplicantPersonID, LicenseClassID, testTypeID);
          
        }

        public int IssueLicenseForTheFirtTime(string Notes, int UserID)
        {
            int DriverID = -1;

            clsDriverscs Driver = clsDriverscs.FindByPersonID(this.ApplicantPersonID);

            if (Driver == null)
            {
                //we check if the driver already there for this person.
                Driver = new clsDriverscs();

                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                if (Driver.save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }
            //now we diver is there, so we add new licesnse

            clsLicenses License = new clsLicenses();
            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClass = this.LicenseClassInfo;
            License.IssueDate = DateTime.Now;
            License.ExpiryDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            License.Note = Notes;
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = clsLicenses.enReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if (License.save())
            {
                //now we should set the application status to complete.
                this.SetComplete();

                return License.LicenseID;
            }

            else
                return -1;
        }





    }

}
