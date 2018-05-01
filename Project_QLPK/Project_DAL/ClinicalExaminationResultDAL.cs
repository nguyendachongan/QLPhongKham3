using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public class ClinicalExaminationResultDAL
    {
        
        DataBaseDataContext db;
        public ClinicalExaminationResultDAL()
        {
            db = new DataBaseDataContext();
        }
        public List<ClinicalExaminationResult> getAllClinicalExaminationResult()
        {
            return db.ClinicalExaminationResults.ToList();
        }
        public ClinicalExaminationResult getOneClinicalExaminationResult(int Id)
        {
            return db.ClinicalExaminationResults.Where(x => x.ClinicalExaminationResultID == Id).FirstOrDefault();
        }
        public void insertClinicalExaminationResult(ClinicalExaminationResult ClinicalExaminationResult)
        {
            db.ClinicalExaminationResults.InsertOnSubmit(ClinicalExaminationResult);
            db.SubmitChanges();
        }
        public void updateClinicalExaminationResult(ClinicalExaminationResult ClinicalExaminationResult)
        {
            var record = db.ClinicalExaminationResults.Where(x => x.ClinicalExaminationResultID == ClinicalExaminationResult.ClinicalExaminationResultID).FirstOrDefault();
            record.ClinicalExaminationID = ClinicalExaminationResult.ClinicalExaminationID;
            record.DoctorID = ClinicalExaminationResult.DoctorID;
            record.ExaminationResultID = ClinicalExaminationResult.ExaminationResultID;
            record.Result = ClinicalExaminationResult.Result;
            db.SubmitChanges();
        }
    }
}
