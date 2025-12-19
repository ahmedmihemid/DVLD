using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.Local_Licenses
{
    public partial class frShowPersonLicenseHistory : Form
    {
        public frShowPersonLicenseHistory(int DriverID)
        {
            InitializeComponent();

            ctrlPersonCardWithFilter1.LoadPersonInfo(clsDriverscs.FindByDriverID(DriverID).PersonID);
            //ctrlDriverLicensesHstory1.LoadDriverLicenseHistory(DriverID);
        }

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }


     


    }
}
