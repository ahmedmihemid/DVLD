using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DVLD_Buisness
{
    public class clsTestAppointments
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode;
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public bool IsLocked { get; set; }



        public clsTestAppointments()
        {
            TestAppointmentID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = -1;
            CreatedByUserID = -1;
            IsLocked = false;
            Mode = enMode.AddNew;
        }

        public clsTestAppointments(int testAppointmentID, int testTypeID, int localDrivingLicenseApplicationID, DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
            Mode = enMode.Update;
        }



        public static DataTable GetAllTestAppointmentsBylocalDrivingLicenseApplicationID(int localDrivingLicenseApplicationID,int TestType)
        {
            return DVLD_DataAccess.clsTestAppointmentsData.GetAllTestAppointmentsBylocalDrivingLicenseApplicationID(localDrivingLicenseApplicationID, TestType);
        }

        public static clsTestAppointments FindIfTestAppointment(int testAppointmentID)
        {

            int testTypeID = 0;
            int localDrivingLicenseApplicationID = 0;
            DateTime appointmentDate = DateTime.Now;
            float paidFees = 0;
            int createdByUserID = 0;
            bool isLocked = false;

            if (DVLD_DataAccess.clsTestAppointmentsData.FindIfTestAppointment(testAppointmentID, ref testTypeID, ref localDrivingLicenseApplicationID, ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked))
            {
                return new clsTestAppointments(testAppointmentID, testTypeID, localDrivingLicenseApplicationID, appointmentDate, paidFees, createdByUserID, isLocked);
            }
            else
            {
                return null;
            }


        }


        private bool _add(clsTestAppointments testAppointment)
        {
            this.TestAppointmentID = DVLD_DataAccess.clsTestAppointmentsData.addTestAppointment(testAppointment.TestTypeID, testAppointment.LocalDrivingLicenseApplicationID,
            testAppointment.AppointmentDate, testAppointment.PaidFees, testAppointment.CreatedByUserID, testAppointment.RetakeTestApplicationID, testAppointment.IsLocked);

            return this.TestAppointmentID > -1;
        }


        private bool _update(clsTestAppointments testAppointment)
        {
            return false;//just to be implemented in future

        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_add(this))
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }


                case enMode.Update:
                    return _update(this);

            }
            return false;

        }
    }
}
