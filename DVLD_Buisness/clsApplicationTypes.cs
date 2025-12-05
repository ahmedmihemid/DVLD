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
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        public int ID { set; get; }
        public string Title { set; get; }
        public float Fees { set; get; }


        public clsApplicationTypes()
        {
            this.ID = -1;
            this.Title = "";
            this.Fees = 0;
            _Mode = enMode.AddNew;
        }

        public clsApplicationTypes(int ID, string title, float fees)
        {
            this.ID = ID;
            this.Title = title;
            this.Fees = fees;
            _Mode = enMode.Update;
        }

        public static DataTable GetAllApplicationTypes()
        {
          return  clsApplicationTypesData.GetAllApplicationTypes();
        }


        public static clsApplicationTypes Find(int applicationTypeID)
        {
            string applicationTypeTitle = "";
            float applicationFees = 0;

            bool isFound= clsApplicationTypesData.Find(applicationTypeID,ref applicationTypeTitle , ref applicationFees);



            if (isFound)
                return  new clsApplicationTypes(applicationTypeID, applicationTypeTitle, applicationFees);
            else
                return null;

        }
        public static clsApplicationTypes FindByTitle( string applicationTypeTitle)
        {
            int applicationTypeID = -1;
            float applicationFees = 0;

            if( clsApplicationTypesData.FindByTitle(applicationTypeTitle, ref applicationTypeID, ref applicationFees))
                return new clsApplicationTypes(applicationTypeID, applicationTypeTitle, applicationFees);
            else
                return null;

        }


        private bool _AddNew()
        {
            this.ID= clsApplicationTypesData.AddNew(this.Title,this.Fees);
            return(this.ID != -1);
        }


        private  bool _Update()
        {
            return clsApplicationTypesData.Update(this.ID,this.Title,this.Fees);
        }

        public bool save()
        {
           switch(_Mode)
           {
              case enMode.Update:
                    return _Update();
                    break;

              case enMode.AddNew:
                    if(_AddNew())
                    {
                        return true;
                        _Mode = enMode.Update;
                    }
                    else
                    {
                        return false;
                    }
                    break;

           }
              return false;
        }

    }
}
