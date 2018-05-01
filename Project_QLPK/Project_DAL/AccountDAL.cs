using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public class AccountDAL
    {
        DataBaseDataContext db;
        public AccountDAL()
        {
            db = new DataBaseDataContext();
        }
        public List<Account> getAllAccount()
        {
            return db.Accounts.ToList();
        }
        public Account getOneAccount(string Id)
        {
            return db.Accounts.Where(x => x.UserName == Id).FirstOrDefault();
        }
        public Account getOneAccountByEmployeeID(int Id)
        {
            return db.Accounts.Where(x => x.EmployeeID == Id).FirstOrDefault();
        }
        public void insertAccount(Account account)
        {
            db.Accounts.InsertOnSubmit(account);
            db.SubmitChanges();
        }
        public void updateAccount(Account account)
        {
            var record = db.Accounts.Where(x => x.UserName == account.UserName).FirstOrDefault();
            record.Password = account.Password;
            db.SubmitChanges();
        }
    }
}
