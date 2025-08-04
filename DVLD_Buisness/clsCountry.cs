using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    internal class clsCountry
    {
        private string _countryName;
        private int _countryID;

       public clsCountry()
        {
            _countryName = string.Empty;
            _countryID = 0;
        }
        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }
        public int CountryID
        {
            get { return _countryID; }
            set { _countryID = value; }
        }
        public override string ToString()
        {
            return _countryName;
        }

    }
}
