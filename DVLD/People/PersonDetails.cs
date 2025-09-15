using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;

namespace DVLD.People
{
    public partial class PersonDetails : Form
    {
        private int _personID;
        public PersonDetails(int personID)
        {
            InitializeComponent();
            _personID = personID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PersonDetails_Load(object sender, EventArgs e)
        {
            personCard1.LoadPersonData(_personID);

        }
    }
}
