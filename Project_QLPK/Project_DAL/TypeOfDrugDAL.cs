using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public class TypeOfDrugDAL
    {
        DataBaseDataContext db;
        public TypeOfDrugDAL()
        {
            db = new DataBaseDataContext();
        }
        public List<TypeOfDrug> getAllTypeOfDrug()
        {
            return db.TypeOfDrugs.ToList();
        }
        public TypeOfDrug getOneTypeOfDrug(int Id)
        {
            return db.TypeOfDrugs.Where(x => x.TypeOfDrugID == Id).FirstOrDefault();
        }
        public void insertTypeOfDrug(TypeOfDrug TypeOfDrug)
        {
            db.TypeOfDrugs.InsertOnSubmit(TypeOfDrug);
            db.SubmitChanges();
        }
        public void updateTypeOfDrug(TypeOfDrug typeDrug)
        {
            //db.TypeOfDrugs.Attach(typeDrug);
            //db.Entry(typeDrug).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
        }
    }
}
