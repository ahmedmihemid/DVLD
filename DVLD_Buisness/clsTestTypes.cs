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
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }


        public clsTestTypes()
        {
            TestTypeID = 0;
            TestTypeTitle = string.Empty;
            TestTypeDescription = string.Empty;
            TestTypeFees = 0.0m;
        }


        public DataTable GetAllTestTypes()
        {
            return DVLD_DataAccess.clsTestTypesData.GetAllTestTypes();
        }

        public static clsTestTypes Find(int TestTypeID)
        {
            string title = string.Empty;
            string description = string.Empty;
            decimal fees = 0.0m;
            bool found = DVLD_DataAccess.clsTestTypesData.Find(TestTypeID, ref title, ref description, ref fees);
           
            clsTestTypes testType = new clsTestTypes();
            if (found)
            {
                testType.TestTypeID = TestTypeID;
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

        private bool _update()
        {
            return DVLD_DataAccess.clsTestTypesData.Update(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }

        public bool save()
        {
                return _update();
        }

    }
}
