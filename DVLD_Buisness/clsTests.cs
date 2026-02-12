using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsTests
    {
        private enum enTestResult { Fail = 0, Pass = 1 }

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }


        public clsTests()
        {
            TestID = 0;
            TestAppointmentID = 0;
            TestResult = false;
            Notes = string.Empty;
            CreatedByUserID = 0;
        }

        public clsTests(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;
        }



        public static int GetNumberOfPassedTests(int localDrivingLicenseApplicationID)
        {
            return DVLD_DataAccess.clsTestsData.GetNumberOfPassedTests(localDrivingLicenseApplicationID);
        }

        public static bool IsItFallTests(int localDrivingLicenseApplicationID,int testTypeID)
        {
            return DVLD_DataAccess.clsTestsData.HasTestResult(localDrivingLicenseApplicationID, testTypeID, (int)enTestResult.Fail);
        }


        public static bool IsHasPassedTest(int localDrivingLicenseApplicationID, int testTypeID)
        {
            return DVLD_DataAccess.clsTestsData.HasTestResult(localDrivingLicenseApplicationID, testTypeID,(int)enTestResult.Pass);
        }



        private bool _AddNew()
        {
            int newID = DVLD_DataAccess.clsTestsData.AddNew(TestAppointmentID, TestResult, Notes, CreatedByUserID);
            if (newID > 0)
            {
                this.TestID = newID;
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool Save()
        {
            return _AddNew();
        }


        //public static clsTests FindLastTestPerPersonAndLicenseClass(int ApplicantPersonID, int LicenseClassID, clsTestTypes.enTestType TestTypeID)
        //{
        //    int TestID = -1;
        //    int TestAppointmentID = -1;
        //    bool TestResult = false;
        //    string Notes = string.Empty;
        //    int CreatedByUserID = -1;

        //    bool found = DVLD_DataAccess.clsTestsData.FindLastTestPerPersonAndLicenseClass(ApplicantPersonID, LicenseClassID, (int)TestTypeID, ref TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID);

        //    if (found)
        //    {
        //        return new clsTests(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

    }
}
