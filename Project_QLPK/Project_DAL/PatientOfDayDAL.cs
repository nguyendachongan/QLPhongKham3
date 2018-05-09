using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public class PatientOfDayDAL
    {       
        DataBaseDataContext db;
        public PatientOfDayDAL()
        {
            db = new DataBaseDataContext();
        }
        public List<Patient> getPatientOfDaysByDoctorID(int DoctorID)
        {
            return (from p in db.Patients
                    join pod in db.PartientOfDays on p.PatientID equals pod.PartientID
                    join ws in db.WorkSchedules on pod.RoomID equals ws.RoomID
                    where ws.DoctorID == DoctorID && ws.StartTime <= DateTime.Now && ws.EndTime >= DateTime.Now
                    select p).ToList(); 
        }

        public PartientOfDay getOnePartientOfDay(int Id)
        {
            return db.PartientOfDays.Where(x => x.PartientID == Id).FirstOrDefault();
        }
        public PartientOfDay insertPartientOfDay(int PID)
        {
            var roomids = db.Rooms.Select(r => r.RoomID);
            var f = roomids.FirstOrDefault();
            var min = new { Key = f, Count = db.PartientOfDays.Where(x => x.RoomID == f).Count() };
            foreach (var q in roomids)
            {
                var patients = db.PartientOfDays.Where(x => x.RoomID == q).Count();
                if (patients < min.Count) min = new { Key = q, Count =  patients} ;
            }
            PartientOfDay pod = new PartientOfDay();
            pod.PartientID = PID;
            pod.RoomID = min.Key;
            pod.Number = min.Count + 1;
            pod.Status = false;
            db.PartientOfDays.InsertOnSubmit(pod);
            db.SubmitChanges();
            return pod;
        }
        public void updatePartientOfDay(PartientOfDay PartientOfDay)
        {
            var record = db.PartientOfDays.Where(x => x.PartientID == PartientOfDay.PartientID).FirstOrDefault();
          //  record.Number = PartientOfDay.Number;
          //  record.RoomID=PartientOfDay.RoomID;
            record.Status = PartientOfDay.Status;
            db.SubmitChanges();
        }
    }
}
