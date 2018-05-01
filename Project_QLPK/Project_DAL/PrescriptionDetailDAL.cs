using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public class PrescriptionDetailDAL
    {
        
        DataBaseDataContext db;
        public PrescriptionDetailDAL()
        {
            db = new DataBaseDataContext();
        }
        public List<PrescriptionDetail> getAllPrescriptionDetail()
        {
            return db.PrescriptionDetails.ToList();
        }
        public PrescriptionDetail getOnePrescriptionDetail(int Id)
        {
            return db.PrescriptionDetails.Where(x => x.PrescriptionDetailID == Id).FirstOrDefault();
        }
        public void insertPrescriptionDetail(PrescriptionDetail PrescriptionDetail)
        {
            db.PrescriptionDetails.InsertOnSubmit(PrescriptionDetail);
            db.SubmitChanges();
        }
        public void updatePrescriptionDetail(PrescriptionDetail PrescriptionDetail)
        {
            var record = db.PrescriptionDetails.Where(x => x.PrescriptionDetailID == PrescriptionDetail.PrescriptionDetailID).FirstOrDefault();
            record.ExaminationResultID = PrescriptionDetail.ExaminationResultID;
            record.DrugID = PrescriptionDetail.DrugID;
            record.Day = PrescriptionDetail.Day;
            record.Description = PrescriptionDetail.Description;
            record.Quantity = PrescriptionDetail.Quantity;
            record.Dosage = PrescriptionDetail.Dosage;
            record.Usage = PrescriptionDetail.Usage;
            record.Price = PrescriptionDetail.Price;
            db.SubmitChanges();
        }
    }
}
