using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frApplicationDetails : Form
    {
        private int LocalDrivingAppID = -1;
        public frApplicationDetails(int localDrivingAppID)
        {
            InitializeComponent();
            LocalDrivingAppID = localDrivingAppID;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(LocalDrivingAppID);
        }


    }
}
