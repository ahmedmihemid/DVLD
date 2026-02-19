using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
using System.Data;

namespace DVLD_Buisness
{
    public class clsDriverscs
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public clsPerson PersonInfo;

        public int DriverID { set; get; }
        public int PersonID { set; get; }
        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate { set; get; }

        public clsDriverscs()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;
        }

        public clsDriverscs(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
            PersonInfo = clsPerson.Find(personID);
            Mode = enMode.Update;
        }



        private bool _AddNewDriver()
        {
            //call DataAccess Layer 

            this.DriverID = clsDriversData.AddNewDriver(PersonID, CreatedByUserID);


            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            //call DataAccess Layer 

            return clsDriversData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID);
        }

        public static clsDriverscs FindByDriverID(int DriverID)
        {

            int PersonID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (clsDriversData.GetDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))

                return new clsDriverscs(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;

        }

        public static clsDriverscs FindByPersonID(int PersonID)
        {

            int DriverID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (clsDriversData.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))

                return new clsDriverscs(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;

        }

        public static DataTable GetAllDrivers()
        {
            return clsDriversData.GetAllDrivers();

        }


        public bool save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                  if(_AddNewDriver())
                    {
                       Mode = enMode.Update;
                        return true;
                    }
                  else
                   { return false; }

                case enMode.Update:
                    return _UpdateDriver();
            }
            return false;
        }




        //public static DataTable GetLicenses(int DriverID)
        //{
        //    return clsLicenses.GetDriverLicenses(DriverID);
        //}

        //public static DataTable GetInternationalLicenses(int DriverID)
        //{
        //    return clsInternationalLicenses.GetDriverInternationalLicenses(DriverID);
        //}

    }
}
