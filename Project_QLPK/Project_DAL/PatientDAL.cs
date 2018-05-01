using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public class PatientDAL
    {
        DataBaseDataContext db;
        public PatientDAL()
        {
            db = new DataBaseDataContext();
        }
        public List<Patient> getAllPatient()
        {
            var ls = db.Patients.ToList();
            return db.Patients.ToList();
        }
        public Patient getOnePatient(int Id)
        {
            return db.Patients.Where(x => x.PatientID == Id).FirstOrDefault();
        }
        public void insertPatient(Patient Patient)
        {
            db.Patients.InsertOnSubmit(Patient);
            db.SubmitChanges();
        }
        public void updatePatient(Patient Patient)
        {
            //db.Patients.     
            //db.SubmitChanges();
        } 

    }
}
