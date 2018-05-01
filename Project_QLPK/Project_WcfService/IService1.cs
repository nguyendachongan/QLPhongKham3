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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1

    {
        #region OperationContract
        // Account

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getAllAccounts/")]
        List<eAccount> getAllAccount();

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "Accounts/new")]
        bool insertAccount(eAccount e);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getOneAccount?id={id}")]
        eAccount getOneAccount(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "Accounts/edit")]
        bool updateAccount(eAccount e);

        // ClinicalExamination
        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getAllClinicalExaminations/")]
        List<eClinicalExamination> getAllClinicalExamination();

        [OperationContract]
        bool insertClinicalExamination(eClinicalExamination e);

        [OperationContract]
        eClinicalExamination getOneClinicalExamination(int id);

        [OperationContract]
        bool updateClinicalExamination(eClinicalExamination e);

        // ClinicalExaminationResult

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getAllClinicalExaminationResults/")]
        List<eClinicalExaminationResult> getAllClinicalExaminationResult();

        [OperationContract]
        bool insertClinicalExaminationResult(eClinicalExaminationResult e);

        [OperationContract]
        eClinicalExaminationResult getOneClinicalExaminationResult(int id);

        [OperationContract]
        bool updateClinicalExaminationResult(eClinicalExaminationResult e);

        // Drug
        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getAllDrugs/")]
        List<eDrug> getAllDrugs();


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json, UriTemplate = "Drugs/new")]
        bool insertDrug(eDrug e);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "/getOneDrug?id={id}")]
        eDrug getOneDrug(int id);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json, UriTemplate = "Drugs/edit")]
        bool updateDrug(eDrug e);

        // Employee
        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getAllEmployees/")]
        List<eEmployee> getAllEmployee();


        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "getAllNewEmployees/")]
        List<eEmployee> getAllNewEmployee();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json, UriTemplate = "Employees/new")]
        bool insertEmployee(eEmployee e);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "/getEmployee?id={id}")]
        eEmployee getOneEmployee(int id);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json, UriTemplate = "Employees/edit")]
        bool updateEmployee(eEmployee e);

        // ExaminationResult
        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getAllExaminationResults/")]
        List<eExaminationResult> getAllExaminationResult();

        [OperationContract]
        bool insertExaminationResult(eExaminationResult e);

        [OperationContract]
        eExaminationResult getOneExaminationResult(int id);

        [OperationContract]
        bool updateExaminationResult(eExaminationResult e);

        // Patient

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getAllPatients/")]
        List<ePatient> getAllPatient();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json, UriTemplate = "Patients/new")]
        ePatientOfDay insertPatient(ePatient e);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getPatient?id={id}")]
        ePatient getOnePatient(int id);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json, UriTemplate = "Patients/edit")]
        bool updatePatient(ePatient e);

        // PatientOfDay

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getAllPatientOfDays/")]
        List<ePatientOfDay> getAllPatientOfDay();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json, UriTemplate = "PatientOfDays/new")]
       ePatientOfDay insertPatientOfDay(int id);

        [OperationContract]
        ePatientOfDay getOnePatientOfDay(int id);

        [OperationContract]
        bool updateParient(ePatientOfDay e);

        // PrescriptionDetail

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getAllPrescriptionDetail/")]
        List<ePrescriptionDetail> getAllPrescriptionDetail();

        [OperationContract]
        bool insertPrescriptionDetail(ePrescriptionDetail e);

        [OperationContract]
        ePrescriptionDetail getOnePrescriptionDetail(int id);

        [OperationContract]
        bool updatePrescriptionDetail(ePrescriptionDetail e);


        // Room

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getAllRooms/")]
        List<eRoom> getAllRoom();

        [OperationContract]
        bool insertRoom(eRoom e);

        [OperationContract]
        eRoom getOneRoom(int id);

        [OperationContract]
        bool updateRoom(eRoom e);

        // Type of Drug

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getAllTypeDrugs/")]
        List<eTypeOfDrug> getAllTypeDrugs();

        [OperationContract]
        bool insertTypeDrug(eTypeOfDrug e);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getType/?id={id}")]
        eTypeOfDrug getOneTypeDrug(int id);

        [OperationContract]
        bool updateTypeDrug(eTypeOfDrug e);


        // WorkSchedule

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getAllWorkSchedules/")]
        List<eWorkSchedule> getAllWorkSchedule();

        [OperationContract]
        bool insertWorkSchedule(eWorkSchedule e);

        [OperationContract]
        eWorkSchedule getOneWorkSchedule(int id);

        [OperationContract]
        bool updateWorkSchedule(eWorkSchedule e);

    }
    #endregion
    #region DataContract
    [DataContract]
    public class eDrug
    {
        [DataMember]
        public int DrugID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public int TypeID { get; set; }
        [DataMember]
        public eTypeOfDrug Type { get; set; }

    }
    public class eAccount
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public int Position { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
    public class eClinicalExamination
    {
        [DataMember]
        public int ClinicalExaminationId { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
    public class eClinicalExaminationResult
    {
        [DataMember]
        public int ClinicalExaminationResultID { get; set; }
        [DataMember]
        public int ClinicalExaminationID { get; set; }
        [DataMember]
        public int ExaminationResultID { get; set; }
        [DataMember]
        public int DoctorID { get; set; }
        [DataMember]
        public string Result { get; set; }
    }
    public class eEmployee
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public DateTime BirthDay { get; set; }
        [DataMember]
        public string IdentifyCard { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public int Position { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public bool Gender { get; set; }
        [DataMember]
        public bool Active { get; set; }

    }
    public class eExaminationResult
    {
        [DataMember]
        public int ExaminationResultID { get; set; }
        [DataMember]
        public int PatientID { get; set; }
        [DataMember]
        public ePatient Patient { get; set; }
        [DataMember]
        public int DoctorID { get; set; }
        [DataMember]
        public eEmployee Doctor { get; set; }
        [DataMember]
        public int DispenserID { get; set; }
        [DataMember]
        public eEmployee Dispenser { get; set; }
        [DataMember]
        public DateTime Time { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Result { get; set; }
    }
    public class ePatient
    {
        [DataMember]
        public int PatientID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string IdentifyCard { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public bool Gender { get; set; }
    }
    public class ePatientOfDay
    {
        [DataMember]
        public int PatientID { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public int RoomID { get; set; }
        [DataMember]
        public string Room { get; set; }

    }
    public class ePrescriptionDetail
    {
        [DataMember]
        public int PrescriptionDetailID { get; set; }
        [DataMember]
        public int ExaminationResultID { get; set; }
        [DataMember]
        public int DrugID { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public int Day { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public string Dosage { get; set; }
        [DataMember]
        public string Usage { get; set; }
    }

    public class eRoom
    {
        [DataMember]
        public int RoomId { get; set; }
        [DataMember]
        public string Room { get; set; }
    }

    public class eTypeOfDrug
    {
        [DataMember]
        public int TypeOfDrugID { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Description { get; set; }

    }

    public class eWorkSchedule
    {
        [DataMember]
        public int WorkScheduleID { get; set; }
        [DataMember]
        public int DoctorID { get; set; }
        [DataMember]
        public int RoomID { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public DateTime EndTime { get; set; }
    }
    #endregion
}
