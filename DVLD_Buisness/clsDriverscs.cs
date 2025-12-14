using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsDriverscs
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }


        enum enMode { New = 1, Edit = 2 }
        private enMode _Mode;

        public clsDriverscs()
        {
            _Mode = enMode.New;
        }

        public clsDriverscs(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
            _Mode = enMode.Edit;
        }






        public static bool IsExist(int personID)
        {
            return DVLD_DataAccess.clsDriversData.IsExist(personID);
        }

        public static clsDriverscs FindByPersonID(int personID)
        {
            int driverID = 0;
            DateTime createdDate = DateTime.MinValue;
            int createdByUserID = 0;
            bool isFound = DVLD_DataAccess.clsDriversData.FindByPersonID(personID, ref driverID, ref createdByUserID, ref createdDate);
            if (isFound)
            {
                return new clsDriverscs(driverID, personID, createdByUserID, createdDate);
            }
            return null;


        }



        private bool _AddNew()
        {
            int newDriverID = DVLD_DataAccess.clsDriversData.AddNew(PersonID, CreatedByUserID, CreatedDate);
            if (newDriverID > 0)
            {
                DriverID = newDriverID;
                return true;
            }
            return false;

        }


        private bool _Update()
        {
            // Update logic to be implemented
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
                  else
                   { return false; }

                case enMode.Edit:
                    return _Update();
            }
            return false;
        }






    }
}
