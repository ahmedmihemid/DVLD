using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsApplicationTypes
    {

        public int ApplicationTypeID { set; get; }
        public string ApplicationTypeTitle { set; get; }
        public decimal ApplicationFees { set; get; }


        public clsApplicationTypes()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = "";
            this.ApplicationFees = 0;
        }

        public static DataTable GetAllApplicationTypes()
        {
          return  clsApplicationTypesData.GetAllApplicationTypes();
        }

        public static clsApplicationTypes Find(int applicationTypeID)
        {
            string applicationTypeTitle = "";
            decimal applicationFees = 0;

            bool isFound= clsApplicationTypesData.Find(applicationTypeID,ref applicationTypeTitle , ref applicationFees);
            
            clsApplicationTypes applicationType = new clsApplicationTypes();
            applicationType.ApplicationTypeID = applicationTypeID;
            applicationType.ApplicationTypeTitle = applicationTypeTitle;
            applicationType.ApplicationFees = applicationFees;

            if (isFound ) 
                return applicationType;
            else
                return null;

        }


        private  bool _Update()
        {
            return clsApplicationTypesData.Update(this.ApplicationTypeID,this.ApplicationTypeTitle,this.ApplicationFees);
        }

        public bool save()
        {
            return _Update();
        }

    }
}
