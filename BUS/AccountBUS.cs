using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class AccountBUS
    {
        public static List<Account> GetAccounts() 
        {
            return AccountDAO.GetAccounts();
        }

        public static void AddAccount(Account account)
        {
            DAO.AccountDAO.AddAccount(account);
        }
    }

    
}
