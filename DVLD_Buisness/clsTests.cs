using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsTests
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }

        clsTestAppointments TestAppointment ;
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }


        public clsTests()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = "";
            CreatedByUserID = -1;
            TestAppointment = new clsTestAppointments();
            Mode = enMode.AddNew;
        }

        public clsTests(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestAppointment = clsTestAppointments.Find(testAppointmentID);
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;
            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.TestID = clsTestsData.AddNewTest(this.TestAppointmentID,
                 this.TestResult, this.Notes, this.CreatedByUserID);


            return (this.TestID != -1);
        }

        private bool _Update()
        {
            return DVLD_DataAccess.clsTestsData.UpdateTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
        }

        public static clsTests Find(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsTestsData.GetTestInfoByID(TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsTests(TestID,
                        TestAppointmentID, TestResult,
                        Notes, CreatedByUserID);
            else
                return null;

        }

        public static clsTests FindLastTestPerPersonAndLicenseClass
            (int PersonID, int LicenseClassID, clsTestTypes.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsTestsData.GetLastTestByPersonAndTestTypeAndLicenseClass
                (PersonID, LicenseClassID, (int)TestTypeID, ref TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsTests(TestID,
                        TestAppointmentID, TestResult,
                        Notes, CreatedByUserID);
            else
                return null;

        }

        public static DataTable GetAllTests()
        {
            return clsTestsData.GetAllTests();

        }


        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNew())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                case enMode.Update:
                    {
                        return _Update();
                    }

            }
            return false;

        }


        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }


    }
}
