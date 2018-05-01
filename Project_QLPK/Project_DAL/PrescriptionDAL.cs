using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public class PrescriptionDAL
    {
        DataBaseDataContext db;
        public PrescriptionDAL()
        {
            db = new DataBaseDataContext();
        }      
        public List<PrescriptionDetail> getAllPrescription()
        {
            var ls = db.PrescriptionDetails.ToList();
            return db.PrescriptionDetails.ToList();
        }
        public PrescriptionDetail getOnePrescription(int Id)
        {
            return db.PrescriptionDetails.Where(x => x.PrescriptionDetailID == Id).FirstOrDefault();
        }
        public void insertPrescription(PrescriptionDetail Prescription)
        {
            db.PrescriptionDetails.InsertOnSubmit(Prescription);
            db.SubmitChanges();
        }
        public void updatePrescription(PrescriptionDetail Prescription)
        {
            //db.PrescriptionDetails.     
            //db.SubmitChanges();
        }   
    }
}
