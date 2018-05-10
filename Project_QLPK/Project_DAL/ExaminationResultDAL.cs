using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public class ExaminationResultDAL
    {
        
        DataBaseDataContext db;
        public ExaminationResultDAL()
        {
            db = new DataBaseDataContext();
        }
        public List<ExaminationResult> getAllExaminationResult()
        {
            return db.ExaminationResults.ToList();
        }
        public List<ExaminationResult> getAllExaminationResultByPatient(int PatientID)
        {
            return db.ExaminationResults.Where(x => x.PatientID == PatientID && x.Time.Date != DateTime.Now).OrderByDescending(x => x.Time).Take(5).ToList();
        }
        public List<ExaminationResult> getAllExaminationResultByDispenser()
        {
            return db.ExaminationResults.Where(x => x.DispenserID == null).OrderBy(x => x.Time).ToList();
        }
        public ExaminationResult getOneExaminationResult(int Id)
        {
            return db.ExaminationResults.Where(x => x.ExaminationResultID == Id).FirstOrDefault();
        }
        public int insertExaminationResult(ExaminationResult ExaminationResult)
        {
            db.ExaminationResults.InsertOnSubmit(ExaminationResult);
            db.SubmitChanges();
            return ExaminationResult.ExaminationResultID;
        }
        public void updateExaminationResult(ExaminationResult ExaminationResult)
        {
            var record = db.ExaminationResults.Where(x => x.ExaminationResultID == ExaminationResult.ExaminationResultID).FirstOrDefault();
           // record.DoctorID = ExaminationResult.DoctorID;
            record.DispenserID = ExaminationResult.DispenserID;
          //  record.Time = ExaminationResult.Time;
          //  record.Result = ExaminationResult.Result;
          //  record.PatientID = ExaminationResult.PatientID;
          //  record.Description = ExaminationResult.Description;
            db.SubmitChanges();
        }
    }
}
