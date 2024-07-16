using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TenantBUS
    {
        public static Tenant GetTenantByRoomID(int roomID) 
        {
            return DAO.TenantDAO.GetTenantByRoomID(roomID);
        }

        public static ObservableCollection<Tenant> GetListTenantByRoomID(int roomID)
        {
            return DAO.TenantDAO.GetListTenantByRoomID(roomID);
        }

        public static void DeleteTenant(Tenant tenant)
        {
            DAO.TenantDAO.DeleteTenant(tenant);
        }

        public static ObservableCollection<Tenant> GetListTenant()
        {
            return DAO.TenantDAO.GetListTenant();
        }

        public static void AddTenant(Tenant tenant)
        {
            DAO.TenantDAO.AddTenant(tenant);
        }
    }
}
