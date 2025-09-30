using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DVLD_Buisness
{
    public class clsTestTypes
    {

        public enum enMode { AddNew, Update }
        public enMode Mode=enMode.AddNew;

        public enum enTestType { VisionTest=1,WrittenTest=2,StreetTest=3}

        public enTestType ID{ set; get; }

        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }


        public clsTestTypes()
        {
            ID = enTestType.VisionTest;
            TestTypeTitle = string.Empty;
            TestTypeDescription = string.Empty;
            TestTypeFees=0;
            Mode = enMode.AddNew;
        }


        public clsTestTypes(enTestType Id, string testTypeTitle, string testTypeDescription, float testTypeFees)
        {
            ID = Id;
            TestTypeTitle = testTypeTitle;
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;
            Mode = enMode.Update;
        }


        public DataTable GetAllTestTypes()
        {
            return DVLD_DataAccess.clsTestTypesData.GetAllTestTypes();
        }

        public static clsTestTypes Find(clsTestTypes.enTestType TestTypeID)
        {
            string title = string.Empty;
            string description = string.Empty;
            float fees = 0;
            bool found = DVLD_DataAccess.clsTestTypesData.Find((int)TestTypeID, ref title, ref description, ref fees);
           
            clsTestTypes testType = new clsTestTypes();
            if (found)
            {
                testType.ID = TestTypeID;
                testType.TestTypeTitle = title;
                testType.TestTypeDescription = description;
                testType.TestTypeFees = fees;
                return testType;
            }
            else
            {
                return null;
            }
        }

        private bool _AddNew()
        {
            this.ID= (enTestType)DVLD_DataAccess.clsTestTypesData.AddNew( this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
           
            return( (int)this.ID) > 0;
        }


        private bool _update()
        {
            return DVLD_DataAccess.clsTestTypesData.Update((int)this.ID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }

        public bool save()
        {
             switch (this.Mode)
            {
                case enMode.AddNew:
                {
                   if(_AddNew())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                case enMode.Update:
                {
                  return _update();
                }
              
             }
            return false;
        }

    }
}
