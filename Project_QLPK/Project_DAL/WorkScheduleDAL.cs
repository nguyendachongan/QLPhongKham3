using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public class WorkScheduleDAL
    {
        DataBaseDataContext db;
        public WorkScheduleDAL()
        {
            db = new DataBaseDataContext();
        }
        public List<WorkSchedule> getAllWorkSchedule()
        {
            return db.WorkSchedules.ToList();
        }
        public WorkSchedule getOneWorkSchedule(int Id)
        {
            return db.WorkSchedules.Where(x => x.WorkScheduleID == Id).FirstOrDefault();
        }
        public void insertWorkSchedule(WorkSchedule WorkSchedule)
        {
            db.WorkSchedules.InsertOnSubmit(WorkSchedule);
            db.SubmitChanges();
        }
        public void updateWorkSchedule(WorkSchedule WorkSchedule)
        {
            var record = db.WorkSchedules.Where(x => x.WorkScheduleID == WorkSchedule.WorkScheduleID).FirstOrDefault();
            record.RoomID = WorkSchedule.DoctorID;
            record.DoctorID = WorkSchedule.DoctorID;
            record.StartTime = WorkSchedule.StartTime;
            record.EndTime = WorkSchedule.EndTime;
            db.SubmitChanges();
        }
    }
}
