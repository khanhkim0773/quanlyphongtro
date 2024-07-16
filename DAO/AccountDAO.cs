using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public  class AccountDAO
    {   
        public static List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();

            using (QLPTDataContext db = new QLPTDataContext())
            {
                accounts = db.Accounts.Select(a => a).ToList();
            }
            return accounts;
        }

        public static void AddAccount(Account account)
        {
            using (var db = new QLPTDataContext())
            {
                db.Accounts.InsertOnSubmit(account);
                db.SubmitChanges();
            }
        }

    }


}
