using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public class ClinicalExaminationDAL
    {
        DataBaseDataContext db;
        public ClinicalExaminationDAL()
        {
            db = new DataBaseDataContext();
        }
        public List<ClinicalExamination> getAllClinicalExamination()
        {
            return db.ClinicalExaminations.ToList();
        }
        public ClinicalExamination getOneClinicalExamination(int Id)
        {
            return db.ClinicalExaminations.Where(x => x.ClinicalExaminationTypeID == Id).FirstOrDefault();
        }
        public void insertClinicalExamination(ClinicalExamination ClinicalExamination)
        {
            db.ClinicalExaminations.InsertOnSubmit(ClinicalExamination);
            db.SubmitChanges();
        }
        public void updateClinicalExamination(ClinicalExamination ClinicalExamination)
        {
            var record = db.ClinicalExaminations.Where(x => x.ClinicalExaminationTypeID == ClinicalExamination.ClinicalExaminationTypeID).FirstOrDefault();
            record.Description = ClinicalExamination.Description;
            record.Type = ClinicalExamination.Type;
            db.SubmitChanges();
        }
    }
}
