using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsApplications
    {

        public enum enMode
        {
            AddNew = 1,
            Edit = 2
        }
        public enum enStatus
        {
            New =1,
            InProcess =2,
            cancelled =3,
        }

        public enMode Mode = enMode.AddNew;


        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public enStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }




        public clsApplications()
        {
            ApplicationID = 0;
            ApplicantPersonID = 0;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = 0;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = 0;
            ApplicationStatus = enStatus.New;
            Mode = enMode.AddNew;
        }


      public clsApplications(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, enStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            Mode = enMode.Edit;
        }




        public static clsApplications Find(int ApplicationID )
        {
            int ApplicantPersonID =0;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID =0;     
            int ApplicationStatus =0;
            DateTime LastStatusDate = DateTime.Now;
            float PaidFees =0;
            int CreatedByUserID =0;
                     
            bool isFound=DVLD_DataAccess.ApplicationsData.Find(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID);
            
            if(isFound)
            {
                return new clsApplications(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, (enStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
            {
                return null;
            }


        }



        private bool _AddNew()
        {
         this.ApplicationID = DVLD_DataAccess.ApplicationsData.AddNew(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, (int)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
         return this.ApplicationID > 0;
        }

        private bool _Update()
        {
           return true;
        }

        public bool Save()
        {
            switch (Mode)
            {
               case enMode.AddNew:
                  if(_AddNew())
                  {
                       Mode = enMode.Edit;
                        return true;
                  }
                  else
                  {
                        return false;
                  }
                  break;

               case enMode.Edit:
               { 
                  return _Update(); 
               }


            }
            return false;
        }



    }
}
