using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsCountry
    {
        private string _countryName;
        private int _countryID;
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








        public static List<clsCountry> GetAllCountries()
        {
            List<clsCountry> countries = new List<clsCountry>();

            DataTable dtCountries = clsCountryData.GetAllCountries();

            if (dtCountries != null && dtCountries.Rows.Count > 0)
            {
              foreach(DataRow row in dtCountries.Rows)
                {
                    clsCountry country = new clsCountry
                    {
                        _countryID = Convert.ToInt32(row["CountryID"]),
                        _countryName = row["CountryName"].ToString()
                    };
                    countries.Add(country);
                }
            }

            return countries;
        }
           














    }
}
