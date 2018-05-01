using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public class EmployeeDAL
    {
        
        DataBaseDataContext db;
        public EmployeeDAL()
        {
            db = new DataBaseDataContext();
        }
        public List<Employee> getAllEmployee()
        {
            return db.Employees.ToList();
        }
        public List<Employee> getAllNewEmployee()
        {
            List<int> accounts = db.Accounts.Select(a => a.EmployeeID).ToList();
            var query = from e in db.Employees where !(accounts).Contains(e.EmployeeID) select e;
            return query.ToList();
        }
        public Employee getOneEmployee(int Id)
        {
            return db.Employees.Where(x => x.EmployeeID == Id).FirstOrDefault();
        }
        public void insertEmployee(Employee Employee)
        {
            db.Employees.InsertOnSubmit(Employee);
            db.SubmitChanges();
        }
        public void updateEmployee(Employee Employee)
        {
            var record = db.Employees.Where(x => x.EmployeeID == Employee.EmployeeID).FirstOrDefault();
            record.FirstName = Employee.FirstName;
            record.LastName = Employee.LastName;
            record.MiddleName = Employee.MiddleName;
            record.Phone = Employee.Phone;
            record.Position = Employee.Position;
            record.BirthDay = Employee.BirthDay;
            record.IdentifyCard = Employee.IdentifyCard;
            record.Address = Employee.Address;
            record.Gender = Employee.Gender;
            record.Active = Employee.Active;
            db.SubmitChanges();
        }
    }
}
