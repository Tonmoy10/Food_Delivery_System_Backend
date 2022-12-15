using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : DatabaseRepo, ICrud<Admin, int, bool>, IEmployee<Courier, int, bool>
    {
        public bool Add(Admin data)
        {
            database.Admins.Add(data);
            return database.SaveChanges() > 0 ;
        }

        public bool AddEmployee(Courier employee)
        {
            database.Couriers.Add(employee);
            return database.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            database.Admins.Remove(database.Admins.Find(id));
            return database.SaveChanges() > 0;
        }

        public bool DeleteEmployee(int id)
        {
            database.Couriers.Remove(database.Couriers.Find(id));
            return database.SaveChanges() > 0;
        }

        public Admin Get(int id)
        {
            return database.Admins.Find(id);
        }

        public List<Admin> GetAll()
        {
            return database.Admins.ToList();
        }

        public List<Courier> GetAllEmployees()
        {
            return database.Couriers.ToList();
        }

        public Courier GetEmployee(int id)
        {
            return database.Couriers.Find(id);
        }

        public bool Update(Admin data)
        {
            var record = database.Admins.Find(data.admin_id);
            database.Entry(record).CurrentValues.SetValues(data);
            return database.SaveChanges() > 0;
        }
    }
}
