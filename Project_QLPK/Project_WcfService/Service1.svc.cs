using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Project_DAL;

namespace Project_WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        #region Declare
        // Declare 
        AccountDAL accdal = new AccountDAL();
        ClinicalExaminationDAL cedal = new ClinicalExaminationDAL();
        ClinicalExaminationResultDAL cerdal = new ClinicalExaminationResultDAL();
        DrugDAL drugdal = new DrugDAL();
        EmployeeDAL empdal = new EmployeeDAL();
        ExaminationResultDAL erdal = new ExaminationResultDAL();
        PatientDAL patientdal = new PatientDAL();
        PatientOfDayDAL potdal = new PatientOfDayDAL();
        PrescriptionDetailDAL presdal = new PrescriptionDetailDAL();
        RoomDAL roomdal = new RoomDAL();
        TypeOfDrugDAL typedal = new TypeOfDrugDAL();
        WorkScheduleDAL workdal = new WorkScheduleDAL();
        #endregion

        #region Account
        public List<eAccount> getAllAccount()
        {
            List<eAccount> ls = new List<eAccount>();
            foreach (Account record in accdal.getAllAccount())
            {
                eAccount temp = new eAccount();
                temp.EmployeeId = record.EmployeeID;
                temp.UserName = record.UserName;
                temp.Password = record.Password;
                Employee e = empdal.getOneEmployee(temp.EmployeeId);
                temp.FirstName = e.FirstName;
                temp.LastName = e.LastName;
                temp.MiddleName = e.MiddleName;
                temp.Position = e.Position;
                temp.Active = e.Active;
                ls.Add(temp);
            }
            return ls;
        }

        public bool insertAccount(eAccount e)
        {
            try
            {
                Account temp = new Account();
                temp.EmployeeID = e.EmployeeId;
                temp.Password = e.Password;
                temp.UserName = e.UserName;
                accdal.insertAccount(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public eAccount getOneAccount(string id)
        {
            var result = accdal.getOneAccount(id);
            eAccount e = new eAccount();
            e.UserName = result.UserName;
            e.Password = result.Password;
            e.EmployeeId = result.EmployeeID;
            return e;
        }

        public bool updateAccount(eAccount e)
        {
            try
            {
                Account temp = new Account();
                temp.EmployeeID = e.EmployeeId;
                temp.Password = e.Password;
                temp.UserName = e.UserName;
                accdal.updateAccount(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region ClinicalExamination
        public List<eClinicalExamination> getAllClinicalExamination()
        {
            List<eClinicalExamination> ls = new List<eClinicalExamination>();
            foreach (ClinicalExamination record in cedal.getAllClinicalExamination())
            {
                eClinicalExamination temp = new eClinicalExamination();
                temp.ClinicalExaminationId = record.ClinicalExaminationTypeID;
                temp.Description = record.Description;
                temp.Type = record.Type;
                ls.Add(temp);
            }
            return ls;
            
        }

        public bool insertClinicalExamination(eClinicalExamination e)
        {
            try
            {
                ClinicalExamination temp = new ClinicalExamination();
                temp.ClinicalExaminationTypeID = e.ClinicalExaminationId;
                temp.Description = e.Description;
                temp.Type = e.Type;
                cedal.insertClinicalExamination(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public eClinicalExamination getOneClinicalExamination(int id)
        {
            var result = cedal.getOneClinicalExamination(id);
            eClinicalExamination e = new eClinicalExamination();
            e.ClinicalExaminationId = result.ClinicalExaminationTypeID;
            e.Type = result.Type;
            e.Description = result.Description;
            return e;
        }

        public bool updateClinicalExamination(eClinicalExamination e)
        {
            try
            {
                ClinicalExamination temp = new ClinicalExamination();
                temp.ClinicalExaminationTypeID = e.ClinicalExaminationId;
                temp.Description = e.Description;
                temp.Type = e.Type;
                cedal.updateClinicalExamination(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region ClinicalExaminationResult
        public List<eClinicalExaminationResult> getAllClinicalExaminationResult()
        {
            List<eClinicalExaminationResult> ls = new List<eClinicalExaminationResult>();
            foreach (ClinicalExaminationResult record in cerdal.getAllClinicalExaminationResult())
            {
                eClinicalExaminationResult temp = new eClinicalExaminationResult();
                temp.ClinicalExaminationID = record.ClinicalExaminationID;
                temp.ClinicalExaminationResultID = record.ClinicalExaminationResultID;
                temp.DoctorID = record.DoctorID;
                temp.ExaminationResultID=record.ExaminationResultID;
                temp.Result = record.Result;
                ls.Add(temp);
            }
            return ls;
        }

        public bool insertClinicalExaminationResult(eClinicalExaminationResult e)
        {
            try
            {
                ClinicalExaminationResult temp = new ClinicalExaminationResult();
                temp.ClinicalExaminationID = e.ClinicalExaminationID;
                temp.ClinicalExaminationResultID = e.ClinicalExaminationResultID;
                temp.DoctorID = e.DoctorID;
                temp.ExaminationResultID = e.ExaminationResultID;
                temp.Result = e.Result;
                cerdal.insertClinicalExaminationResult(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public eClinicalExaminationResult getOneClinicalExaminationResult(int id)
        {
            var result = cerdal.getOneClinicalExaminationResult(id);
            eClinicalExaminationResult e = new eClinicalExaminationResult();
            e.ClinicalExaminationID = result.ClinicalExaminationID;
            e.ClinicalExaminationResultID = result.ClinicalExaminationResultID;
            e.DoctorID = result.DoctorID;
            e.ExaminationResultID = result.ExaminationResultID;
            e.Result = result.Result;
            return e;
        }

        public bool updateClinicalExaminationResult(eClinicalExaminationResult e)
        {
            try
            {
                ClinicalExaminationResult temp = new ClinicalExaminationResult();
                temp.ClinicalExaminationID = e.ClinicalExaminationID;
                temp.ClinicalExaminationResultID = e.ClinicalExaminationResultID;
                temp.DoctorID = e.DoctorID;
                temp.ExaminationResultID = e.ExaminationResultID;
                temp.Result = e.Result;
                cerdal.updateClinicalExaminationResult(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Drug
        List<eDrug> IService1.getAllDrugs()
        {
            List<eDrug> ls = new List<eDrug>();
            foreach (Drug dr in drugdal.getAllDrug())
            {
                eDrug edr = new eDrug();
                edr.DrugID = dr.DrugID;
                edr.Description = dr.Description;
                edr.Name = dr.Name;
                edr.Price = Convert.ToDouble(dr.Price);
                TypeOfDrug t = new TypeOfDrug();
                t = typedal.getOneTypeOfDrug(dr.TypeID);
                eTypeOfDrug et = new eTypeOfDrug();
                et.Type = t.Type;
                et.Description = t.Description;
                edr.Type = et;
                ls.Add(edr);
            }
            return ls;

        }
        public bool insertDrug(eDrug e)
        {
            try
            {
                Drug d = new Drug();
                d.Description = e.Description;
                d.DrugID = e.DrugID;
                d.Name = e.Name;
                d.Price = Convert.ToDecimal(e.Price);
                d.TypeID = e.TypeID;
                drugdal.insertDrug(d);
                return true;
            }
            catch
            {
                return false;
            }
        }




        public eDrug getOneDrug(int id)
        {
            var result = drugdal.getOneDrug(id);
            eDrug e = new eDrug();
            e.TypeID = result.TypeID;
            e.Description = result.Description;
            e.DrugID = result.DrugID;
            e.Name = result.Name;
            e.Price = Convert.ToDouble(result.Price);
            e.Type = getOneTypeDrug(result.TypeID);
            return e;
        }


        public bool updateDrug(eDrug e)
        {
            try
            {
                Drug d = new Drug();
                d.Description = e.Description;
                d.DrugID = e.DrugID;
                d.Name = e.Name;
                d.Price = Convert.ToDecimal(e.Price);
                d.TypeID = e.TypeID;
                drugdal.updateDrug(d);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Employee
        public List<eEmployee> getAllEmployee()
        {
            List<eEmployee> ls = new List<eEmployee>();
            foreach (Employee record in empdal.getAllEmployee())
            {
                eEmployee temp = new eEmployee();
                temp.Active = record.Active;
                temp.Address = record.Address;
                temp.BirthDay = record.BirthDay.ToString("yyyy-MM-dd");
                temp.FirstName = record.FirstName;
                temp.Gender = record.Gender;
                temp.IdentifyCard = record.IdentifyCard;
                temp.LastName = record.LastName;
                temp.MiddleName = record.MiddleName;
                temp.Phone = record.Phone;
                temp.Position = record.Position;             
                temp.EmployeeID = record.EmployeeID;
                ls.Add(temp);
            }
            return ls;
        }

        public List<eEmployee> getAllNewEmployee()
        {
            List<eEmployee> ls = new List<eEmployee>();
            foreach (Employee record in empdal.getAllNewEmployee())
            {
                eEmployee temp = new eEmployee();
                temp.Active = record.Active;
                temp.Address = record.Address;
                temp.BirthDay = record.BirthDay.ToString("yyyy-MM-dd");
                temp.FirstName = record.FirstName;
                temp.Gender = record.Gender;
                temp.IdentifyCard = record.IdentifyCard;
                temp.LastName = record.LastName;
                temp.MiddleName = record.MiddleName;
                temp.Phone = record.Phone;
                temp.Position = record.Position;
                temp.IdentifyCard = record.IdentifyCard;
                temp.EmployeeID = record.EmployeeID;
                ls.Add(temp);
            }
            return ls;
        }

        public bool insertEmployee(eEmployee e)
        {
            try
            {
                Employee temp = new Employee();
                temp.Active = e.Active;
                temp.Address = e.Address;
                temp.BirthDay = DateTime.ParseExact(e.BirthDay, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                temp.FirstName = e.FirstName;
                temp.Gender = e.Gender;
                temp.IdentifyCard = e.IdentifyCard;
                temp.LastName = e.LastName;
                temp.MiddleName = e.MiddleName;
                temp.Phone = e.Phone;
                temp.Position = e.Position;
                temp.IdentifyCard = e.IdentifyCard;
                temp.EmployeeID = e.EmployeeID;
                empdal.insertEmployee(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public eEmployee getOneEmployee(int id)
        {
            var result = empdal.getOneEmployee(id);
            eEmployee e = new eEmployee();
            e.Active = result.Active;
            e.Address = result.Address;
            e.BirthDay =  result.BirthDay.ToString("yyyy-MM-dd");
            e.FirstName = result.FirstName;
            e.Gender = result.Gender;
            e.IdentifyCard = result.IdentifyCard;
            e.LastName = result.LastName;
            e.MiddleName = result.MiddleName;
            e.Phone = result.Phone;
            e.Position = result.Position;
            e.EmployeeID = result.EmployeeID;
            return e;
        }

        public bool updateEmployee(eEmployee e)
        {
            try
            {
                Employee temp = new Employee();
                temp.Active = e.Active;
                temp.Address = e.Address;
                temp.BirthDay = DateTime.ParseExact(e.BirthDay, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                temp.FirstName = e.FirstName;
                temp.Gender = e.Gender;
                temp.IdentifyCard = e.IdentifyCard;
                temp.LastName = e.LastName;
                temp.MiddleName = e.MiddleName;
                temp.Phone = e.Phone;
                temp.Position = e.Position;
                temp.IdentifyCard = e.IdentifyCard;
                temp.EmployeeID = e.EmployeeID;
                empdal.updateEmployee(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region AllExaminationResult
        public List<eExaminationResult> getAllExaminationResult()
        {
            List<eExaminationResult> ls = new List<eExaminationResult>();
            foreach (ExaminationResult record in erdal.getAllExaminationResult())
            {
                eExaminationResult temp = new eExaminationResult();
                temp.Description = record.Description;
                Employee result = empdal.getOneEmployee(record.DoctorID);
                eEmployee e = new eEmployee();
                e.Active = result.Active;
                e.Address = result.Address;
                e.BirthDay = result.BirthDay.ToString("yyyy-MM-dd");
                e.FirstName = result.FirstName;
                e.Gender = result.Gender;
                e.IdentifyCard = result.IdentifyCard;
                e.LastName = result.LastName;
                e.MiddleName = result.MiddleName;
                e.Phone = result.Phone;
                e.Position = result.Position;
                e.IdentifyCard = result.IdentifyCard;
                e.EmployeeID = result.EmployeeID;
                temp.Doctor = e;
                temp.ExaminationResultID = record.ExaminationResultID;
                if (record.DispenserID.HasValue)
                {
                    result = empdal.getOneEmployee(record.DispenserID.Value);
                    e.Active = result.Active;
                    e.Address = result.Address;
                    e.BirthDay = result.BirthDay.ToString("yyyy-MM-dd");
                    e.FirstName = result.FirstName;
                    e.Gender = result.Gender;
                    e.IdentifyCard = result.IdentifyCard;
                    e.LastName = result.LastName;
                    e.MiddleName = result.MiddleName;
                    e.Phone = result.Phone;
                    e.Position = result.Position;
                    e.IdentifyCard = result.IdentifyCard;
                    e.EmployeeID = result.EmployeeID;
                    temp.Dispenser = e;
                }

                ePatient tem = new ePatient();
                Patient p = patientdal.getOnePatient(record.PatientID);
                tem.FirstName = p.FirstName;
                tem.LastName = p.LastName;
                tem.MiddleName = p.MiddleName;
                temp.Patient = tem;
                temp.Time = record.Time.ToShortDateString();
                temp.Result = record.Result;
                List<ePrescriptionDetail> lspd = new List<ePrescriptionDetail>();
                foreach (PrescriptionDetail pd in presdal.getAllPrescriptionDetail(record.ExaminationResultID))
                {
                    ePrescriptionDetail temp1 = new ePrescriptionDetail();
                    temp1.Day = pd.Day;
                    temp1.Description = pd.Description;
                    temp1.Dosage = pd.Dosage;
                    temp1.DrugID = pd.DrugID;
                    temp1.DrugName = drugdal.getOneDrug(pd.DrugID).Name;
                    temp1.ExaminationResultID = pd.ExaminationResultID;
                    temp1.PrescriptionDetailID = pd.PrescriptionDetailID;
                    temp1.Price = Convert.ToDouble(pd.Price);
                    temp1.Quantity = pd.Quantity;
                    temp1.Usage = pd.Usage;

                    lspd.Add(temp1);
                }
                temp.listpd = lspd;
                ls.Add(temp);
            }
            return ls;
        }

        public List<eExaminationResult> getAllExaminationResultByPatient(int PatientID)
        {
            List<eExaminationResult> ls = new List<eExaminationResult>();
            foreach (ExaminationResult record in erdal.getAllExaminationResultByPatient(PatientID))
            {
                eExaminationResult temp = new eExaminationResult();
                temp.Description = record.Description;
                Employee result = empdal.getOneEmployee(record.DoctorID);
                eEmployee e = new eEmployee();
                e.Active = result.Active;
                e.Address = result.Address;
                e.BirthDay = result.BirthDay.ToString("yyyy-MM-dd");
                e.FirstName = result.FirstName;
                e.Gender = result.Gender;
                e.IdentifyCard = result.IdentifyCard;
                e.LastName = result.LastName;
                e.MiddleName = result.MiddleName;
                e.Phone = result.Phone;
                e.Position = result.Position;
                e.IdentifyCard = result.IdentifyCard;
                e.EmployeeID = result.EmployeeID;
                temp.Doctor = e;
                temp.ExaminationResultID = record.ExaminationResultID;
                if (record.DispenserID.HasValue)
                {
                    result = empdal.getOneEmployee(record.DispenserID.Value);
                    e.Active = result.Active;
                    e.Address = result.Address;
                    e.BirthDay = result.BirthDay.ToString("yyyy-MM-dd");
                    e.FirstName = result.FirstName;
                    e.Gender = result.Gender;
                    e.IdentifyCard = result.IdentifyCard;
                    e.LastName = result.LastName;
                    e.MiddleName = result.MiddleName;
                    e.Phone = result.Phone;
                    e.Position = result.Position;
                    e.IdentifyCard = result.IdentifyCard;
                    e.EmployeeID = result.EmployeeID;
                    temp.Dispenser = e;
                }

                ePatient tem = new ePatient();
                Patient p = patientdal.getOnePatient(record.PatientID);
                tem.FirstName = p.FirstName;
                tem.LastName = p.LastName;
                tem.MiddleName = p.MiddleName;
                temp.Patient = tem;
                temp.Time = record.Time.ToShortDateString();
                temp.Result = record.Result;
                List<ePrescriptionDetail> lspd = new List<ePrescriptionDetail>();
                foreach (PrescriptionDetail pd in presdal.getAllPrescriptionDetail(record.ExaminationResultID))
                {
                    ePrescriptionDetail temp1 = new ePrescriptionDetail();
                    temp1.Day = pd.Day;
                    temp1.Description = pd.Description;
                    temp1.Dosage = pd.Dosage;
                    temp1.DrugID = pd.DrugID;
                    temp1.DrugName = drugdal.getOneDrug(pd.DrugID).Name;
                    temp1.ExaminationResultID = pd.ExaminationResultID;
                    temp1.PrescriptionDetailID = pd.PrescriptionDetailID;
                    temp1.Price = Convert.ToDouble(pd.Price);
                    temp1.Quantity = pd.Quantity;
                    temp1.Usage = pd.Usage;

                    lspd.Add(temp1);
                }
                temp.listpd = lspd;
                ls.Add(temp);
            }
            return ls;
        }

        public List<eExaminationResult> getAllExaminationResultByDispenser()
        {
            List<eExaminationResult> ls = new List<eExaminationResult>();
            foreach (ExaminationResult record in erdal.getAllExaminationResultByDispenser())
            {
                eExaminationResult temp = new eExaminationResult();
                temp.Description = record.Description;
                Employee result = empdal.getOneEmployee(record.DoctorID);
                eEmployee e = new eEmployee();
                e.Active = result.Active;
                e.Address = result.Address;
                e.BirthDay = result.BirthDay.ToString("yyyy-MM-dd");
                e.FirstName = result.FirstName;
                e.Gender = result.Gender;
                e.IdentifyCard = result.IdentifyCard;
                e.LastName = result.LastName;
                e.MiddleName = result.MiddleName;
                e.Phone = result.Phone;
                e.Position = result.Position;
                e.IdentifyCard = result.IdentifyCard;
                e.EmployeeID = result.EmployeeID;
                temp.Doctor = e;
                temp.ExaminationResultID = record.ExaminationResultID;
                ePatient tem = new ePatient();
                Patient p = patientdal.getOnePatient(record.PatientID);
                tem.FirstName = p.FirstName;
                tem.LastName = p.LastName;
                tem.MiddleName = p.MiddleName;
                temp.Patient = tem;
                temp.Time = record.Time.ToShortDateString();
                temp.Result = record.Result;
                List<ePrescriptionDetail> lspd = new List<ePrescriptionDetail>();
                foreach (PrescriptionDetail pd in presdal.getAllPrescriptionDetail(record.ExaminationResultID))
                {
                    ePrescriptionDetail temp1 = new ePrescriptionDetail();
                    temp1.Day = pd.Day;
                    temp1.Description = pd.Description;
                    temp1.Dosage = pd.Dosage;
                    temp1.DrugID = pd.DrugID;
                    temp1.DrugName = drugdal.getOneDrug(pd.DrugID).Name;
                    temp1.ExaminationResultID = pd.ExaminationResultID;
                    temp1.PrescriptionDetailID = pd.PrescriptionDetailID;
                    temp1.Price = Convert.ToDouble(pd.Price);
                    temp1.Quantity = pd.Quantity;
                    temp1.Usage = pd.Usage;

                    lspd.Add(temp1);
                }
                temp.listpd = lspd;
                ls.Add(temp);
            }
            return ls;
        }

        public int insertExaminationResult(eExaminationResult e)
        {
            try
            {
                ExaminationResult temp = new ExaminationResult();
                temp.Description = e.Description;
                temp.DispenserID = null;
                temp.DoctorID = e.DoctorID;
                temp.PatientID = e.PatientID;
                temp.Time = DateTime.Now;
                temp.Result = e.Result;
                int id = erdal.insertExaminationResult(temp);
                PartientOfDay pod = new PartientOfDay();
                pod.PartientID = temp.PatientID;
                pod.Status = true;
                potdal.updatePartientOfDay(pod);
                return id;
            }
            catch
            {
                return 0;
            }
        }

        public eExaminationResult getOneExaminationResult(int id)
        {
            var result = erdal.getOneExaminationResult(id);           
            eExaminationResult temp = new eExaminationResult();
            temp.Description = result.Description;
            temp.DispenserID = Convert.ToInt32(result.DispenserID);
            temp.DoctorID = result.DoctorID;
            temp.ExaminationResultID = result.ExaminationResultID;
            temp.PatientID = result.PatientID;
            temp.Time = result.Time.ToShortDateString();
            temp.Result = result.Result;
            return temp;
        }

        public bool updateExaminationResult(eExaminationResult e)
        {
            try
            {
                ExaminationResult temp = new ExaminationResult();
                temp.Description = e.Description;
                temp.DispenserID = Convert.ToInt32(e.DispenserID);
                temp.DoctorID = e.DoctorID;
                temp.ExaminationResultID = e.ExaminationResultID;
                temp.PatientID = e.PatientID;
              
                temp.Result = e.Result;
                erdal.updateExaminationResult(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Patient
        public List<ePatient> getAllPatient()
        {
            List<ePatient> ls = new List<ePatient>();
            foreach (Patient record in patientdal.getAllPatient())
            {
                ePatient temp = new ePatient();
                temp.Address = record.Address;
                temp.FirstName = record.FirstName;
                temp.Gender =Convert.ToBoolean( record.Gender);
                temp.IdentifyCard = record.IdentifyCard;
                temp.LastName = record.LastName;
                temp.MiddleName = record.MiddleName;
                temp.PatientID = record.PatientID;
                temp.Phone = record.Phone;
                PartientOfDay pod = potdal.getOnePartientOfDay(temp.PatientID);
                temp.Number = pod == null ? 0 : pod.Number;
                temp.Room = pod == null ? "" : roomdal.getOneRoom(pod.RoomID).Room1;
                ls.Add(temp);
            }
            return ls;
        }

        public ePatientOfDay insertPatient(ePatient e)
        {
            try
            {
                Patient temp = new Patient();
                temp.Address = e.Address;
                temp.FirstName = e.FirstName;
                temp.Gender = Convert.ToBoolean(e.Gender);
                temp.IdentifyCard = e.IdentifyCard;
                temp.LastName = e.LastName;
                temp.MiddleName = e.MiddleName;
                temp.PatientID = e.PatientID;
                temp.Phone = e.Phone; 
                patientdal.insertPatient(temp);
                ePatientOfDay pod = new ePatientOfDay();
                pod = insertPatientOfDay(temp.PatientID);
                return pod;
            }
            catch
            {
                return null;
            }
        }

        public ePatient getOnePatient(int id)
        {
            var result = patientdal.getOnePatient(id);
            ePatient temp = new ePatient();
            temp.Address = result.Address;
            temp.FirstName = result.FirstName;
            temp.Gender = Convert.ToBoolean(result.Gender);
            temp.IdentifyCard = result.IdentifyCard;
            temp.LastName = result.LastName;
            temp.MiddleName = result.MiddleName;
            temp.PatientID = result.PatientID;
            temp.Phone = result.Phone;
            return temp;
        }

        public bool updatePatient(ePatient e)
        {
            try
            {
                Patient temp = new Patient();
                temp.Address = e.Address;
                temp.FirstName = e.FirstName;
                temp.Gender = Convert.ToBoolean(e.Gender);
                temp.IdentifyCard = e.IdentifyCard;
                temp.LastName = e.LastName;
                temp.MiddleName = e.MiddleName;
                temp.PatientID = e.PatientID;
                temp.Phone = e.Phone;
                patientdal.updatePatient(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region PatientOfDay
        public List<ePatient> getPatientOfDaysByDoctorID(int DoctorID)
        {
            List<ePatient> ls = new List<ePatient>();
            foreach (Patient record in potdal.getPatientOfDaysByDoctorID(DoctorID))
            {
                ePatient temp = new ePatient();
                temp.Address = record.Address;
                temp.FirstName = record.FirstName;
                temp.Gender = Convert.ToBoolean(record.Gender);
                temp.IdentifyCard = record.IdentifyCard;
                temp.LastName = record.LastName;
                temp.MiddleName = record.MiddleName;
                temp.PatientID = record.PatientID;
                temp.Phone = record.Phone;
                PartientOfDay pod = potdal.getOnePartientOfDay(record.PatientID);
                temp.Status = pod.Status.Value;
                ls.Add(temp);
            }
            return ls;
        }

        public ePatientOfDay insertPatientOfDay(int id)
        {
            try
            {
                ePatientOfDay temp = new ePatientOfDay();
                PartientOfDay e = potdal.insertPartientOfDay(id);
                temp.Number = e.Number;
                temp.PatientID = e.PartientID;
                temp.RoomID = e.RoomID;
                temp.Room = getOneRoom(e.RoomID).Room;
                return temp;
            }
            catch
            {
                return null;
            }
        }

        public ePatientOfDay getOnePatientOfDay(int id)
        {
            var result = potdal.getOnePartientOfDay(id);
            ePatientOfDay temp = new ePatientOfDay();
            temp.Number = result.Number;
            temp.PatientID = result.PartientID;
            temp.RoomID = result.RoomID;
            temp.Status = result.Status.Value;
            return temp;
        }

        public bool updateParient(ePatientOfDay e)
        {
            try
            {
                PartientOfDay temp = new PartientOfDay();
                temp.Number = e.Number;
                temp.PartientID = e.PatientID;
                temp.RoomID = e.RoomID;
                temp.Status = e.Status;
                potdal.updatePartientOfDay(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region PrescriptionDetail
       /* public List<ePrescriptionDetail> getAllPrescriptionDetail()
        {
            List<ePrescriptionDetail> ls = new List<ePrescriptionDetail>();
            foreach (PrescriptionDetail record in presdal.getAllPrescriptionDetail())
            {
                ePrescriptionDetail temp = new ePrescriptionDetail();
                temp.Day = record.Day;
                temp.Description = record.Description;
                temp.Dosage = record.Dosage;
                temp.DrugID = record.DrugID;
                temp.ExaminationResultID = record.ExaminationResultID;
                temp.PrescriptionDetailID = record.PrescriptionDetailID;
                temp.Price =Convert.ToDouble( record.Price);
                temp.Quantity = record.Quantity;
                temp.Usage = record.Usage;

                ls.Add(temp);
            }
            return ls;
        }
        */
        public bool insertPrescriptionDetail(List<ePrescriptionDetail> e)
        {
            try
            {
                foreach (ePrescriptionDetail i in e)
                {
                    PrescriptionDetail temp = new PrescriptionDetail();
                    temp.Day = i.Day;
                    temp.Description = i.Description;
                    temp.Dosage = i.Dosage;
                    temp.DrugID = i.DrugID;
                    temp.ExaminationResultID = i.ExaminationResultID;
                    temp.PrescriptionDetailID = i.PrescriptionDetailID;
                    temp.Price = drugdal.getOneDrug(i.DrugID).Price;
                    temp.Quantity = i.Quantity;
                    temp.Usage = i.Usage;
                    presdal.insertPrescriptionDetail(temp);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ePrescriptionDetail getOnePrescriptionDetail(int id)
        {
            var result = presdal.getOnePrescriptionDetail(id);
            ePrescriptionDetail temp = new ePrescriptionDetail();
            temp.Day = result.Day;
            temp.Description = result.Description;
            temp.Dosage = result.Dosage;
            temp.DrugID = result.DrugID;
            temp.ExaminationResultID = result.ExaminationResultID;
            temp.PrescriptionDetailID = result.PrescriptionDetailID;
            temp.Price = Convert.ToDouble(result.Price);
            temp.Quantity = result.Quantity;
            temp.Usage = result.Usage;

            return temp;
        }

        public bool updatePrescriptionDetail(ePrescriptionDetail e)
        {
            try
            {
                PrescriptionDetail temp = new PrescriptionDetail();
                temp.Day = e.Day;
                temp.Description = e.Description;
                temp.Dosage = e.Dosage;
                temp.DrugID = e.DrugID;
                temp.ExaminationResultID = e.ExaminationResultID;
                temp.PrescriptionDetailID = e.PrescriptionDetailID;
                temp.Price = Convert.ToDecimal(e.Price);
                temp.Quantity = e.Quantity;
                temp.Usage = e.Usage;
                presdal.updatePrescriptionDetail(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Room
        public List<eRoom> getAllRoom()
        {
            List<eRoom> ls = new List<eRoom>();
            foreach (Room record in roomdal.getAllRoom())
            {
                eRoom temp = new eRoom();
                temp.Room = record.Room1;
                temp.RoomId = record.RoomID;
                
                ls.Add(temp);
            }
            return ls;
        }

        public bool insertRoom(eRoom e)
        {
            try
            {                
                Room temp = new Room();
                temp.Room1 = e.Room;
                temp.RoomID = e.RoomId;
                roomdal.insertRoom(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public eRoom getOneRoom(int id)
        {
            var result = roomdal.getOneRoom(id);
            eRoom temp = new eRoom();
            temp.Room = result.Room1;
            temp.RoomId = result.RoomID;

            return temp;
        }

        public bool updateRoom(eRoom e)
        {
            try
            {
                Room temp = new Room();
                temp.Room1 = e.Room;
                temp.RoomID = e.RoomId;
                roomdal.updateRoom(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region TypeDrugs
        public List<eTypeOfDrug> getAllTypeDrugs()
        {
            List<eTypeOfDrug> ls = new List<eTypeOfDrug>();
            foreach (TypeOfDrug record in typedal.getAllTypeOfDrug())
            {
                eTypeOfDrug temp = new eTypeOfDrug();
                temp.Description = record.Description;
                temp.Type = record.Type;
                temp.TypeOfDrugID = record.TypeOfDrugID;
              
                ls.Add(temp);
            }
            return ls;
        }

        public bool insertTypeDrug(eTypeOfDrug e)
        {
            try
            {
                TypeOfDrug temp = new TypeOfDrug();
                temp.Description = e.Description;
                temp.Type = e.Type;
                temp.TypeOfDrugID = e.TypeOfDrugID;
                typedal.insertTypeOfDrug(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public eTypeOfDrug getOneTypeDrug(int id)
        {
            var result = typedal.getOneTypeOfDrug(id);
            eTypeOfDrug temp = new eTypeOfDrug();
            temp.Description = result.Description;
            temp.Type = result.Type;
            temp.TypeOfDrugID = result.TypeOfDrugID;

            return temp;
        }

        public bool updateTypeDrug(eTypeOfDrug e)
        {
            try
            {
                TypeOfDrug temp = new TypeOfDrug();
                temp.Description = e.Description;
                temp.Type = e.Type;
                temp.TypeOfDrugID = e.TypeOfDrugID;
                typedal.updateTypeOfDrug(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region WorkSchedule
        public List<eWorkSchedule> getAllWorkSchedule()
        {
            List<eWorkSchedule> ls = new List<eWorkSchedule>();
            foreach (WorkSchedule record in workdal.getAllWorkSchedule())
            {
                eWorkSchedule temp = new eWorkSchedule();
                temp.DoctorID = record.DoctorID;
                temp.EndTime = record.EndTime;
                temp.RoomID = record.RoomID;
                temp.StartTime = record.StartTime;
                temp.WorkScheduleID = record.WorkScheduleID;
                         
                ls.Add(temp);
            }
            return ls;
        }

        public bool insertWorkSchedule(eWorkSchedule e)
        {
            try
            {
                WorkSchedule temp = new WorkSchedule();
                temp.DoctorID = e.DoctorID;
                temp.EndTime = e.EndTime;
                temp.RoomID = e.RoomID;
                temp.StartTime = e.StartTime;
                temp.WorkScheduleID = e.WorkScheduleID;
                workdal.insertWorkSchedule(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public eWorkSchedule getOneWorkSchedule(int id)
        {
            var result = workdal.getOneWorkSchedule(id);
            eWorkSchedule temp = new eWorkSchedule();
            temp.DoctorID = result.DoctorID;
            temp.EndTime = result.EndTime;
            temp.RoomID = result.RoomID;
            temp.StartTime = result.StartTime;
            temp.WorkScheduleID = result.WorkScheduleID;

            return temp;
        }

        public bool updateWorkSchedule(eWorkSchedule e)
        {
            try
            {
                WorkSchedule temp = new WorkSchedule();
                temp.DoctorID = e.DoctorID;
                temp.EndTime = e.EndTime;
                temp.RoomID = e.RoomID;
                temp.StartTime = e.StartTime;
                temp.WorkScheduleID = e.WorkScheduleID;
                workdal.updateWorkSchedule(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion


    }
}
