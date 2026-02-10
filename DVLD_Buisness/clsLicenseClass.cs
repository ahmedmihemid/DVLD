using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DVLD_Buisness
{
    public class clsLicenseClass
    {
        public int LicenseClassID { set; get; }
        public string ClassName { set; get; }
        public string ClassDescription { set; get; }
        public int MinimumAllowedAge { set; get; }
        public int DefaultValidityLength { set; get; }
        public float ClassFees { set; get; }


        public clsLicenseClass()
        {
            LicenseClassID = 0;
            ClassName = string.Empty;
            ClassDescription = string.Empty;
            MinimumAllowedAge = 0;
            DefaultValidityLength = 0;
            ClassFees = 0.0f;
        }

        public clsLicenseClass(string className, int licenseClassID, string classDescription, int minimumAllowedAge, int defaultValidityLength, float classFees)
        {
            LicenseClassID = licenseClassID;
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return DVLD_DataAccess.clsLicenseClassData.GetAllLicenseClasses();
        }

        public static clsLicenseClass Find(string licenseClassName)
        {
            int licenseClassID = -1;
            string classDescription = string.Empty;
            int minimumAllowedAge = 0;
            int defaultValidityLength = 0;
            float classFees = 0.0f;
            bool isFound = DVLD_DataAccess.clsLicenseClassData.Find(licenseClassName, ref licenseClassID, ref classDescription, ref minimumAllowedAge, ref defaultValidityLength, ref classFees);
            if (isFound)
            {
                return new clsLicenseClass(licenseClassName, licenseClassID, classDescription, minimumAllowedAge, defaultValidityLength, classFees);
            }
            return null;

        }



    }
}
