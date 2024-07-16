using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TenantDAO
    {
        public static ObservableCollection<Tenant> GetListTenant()
        {
            ObservableCollection<Tenant> tenants;
            using (QLPTDataContext db = new QLPTDataContext())
            {
                List<Tenant> tenantList = db.Tenants.Select(r => r).ToList();
                tenants = new ObservableCollection<Tenant>(tenantList);
            }
            return tenants;
        }

        public static Tenant GetTenantByRoomID(int roomID)
        {
            using (QLPTDataContext db = new QLPTDataContext())
            {
                // Lấy người thuê dựa trên RoomID từ bảng Tenants
                Tenant tenant = db.Tenants.FirstOrDefault(t => t.RoomID == roomID);
                return tenant;
            }
        }

        public static ObservableCollection<Tenant> GetListTenantByRoomID(int roomID)
        {
            ObservableCollection<Tenant> tenants;
            using (QLPTDataContext db = new QLPTDataContext())
            {
                List<Tenant> tenantList = db.Tenants.Where(t => t.RoomID == roomID).ToList();
                tenants = new ObservableCollection<Tenant>(tenantList);
                return tenants;
            }
        }

        public static void DeleteTenant(Tenant tenant)
        {
            using (var db = new QLPTDataContext())
            {
                Tenant existingTenant = db.Tenants.SingleOrDefault(t => t.TenantID == tenant.TenantID);
                if (existingTenant != null)
                {
                    db.Tenants.DeleteOnSubmit(existingTenant);
                    db.SubmitChanges();
                }
            }
        }

        public static void AddTenant(Tenant tenant)
        {
            using (var db = new QLPTDataContext()) 
            {
                db.Tenants.InsertOnSubmit(tenant);
                db.SubmitChanges();
            }
        }

        

    }
}
