using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourierRepo : DatabaseRepo, ICrud<Courier, int, bool>
    {
        public bool Add(Courier data)
        {
            database.Couriers.Add(data);
            return database.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            database.Couriers.Remove(database.Couriers.Find(id));
            return database.SaveChanges() > 0;
        }

        public Courier Get(int id)
        {
            return database.Couriers.Find(id);
        }

        public List<Courier> GetAll()
        {
            return database.Couriers.ToList();
        }

        public bool Update(Courier data)
        {
            var record = database.Couriers.Find(data.courier_id);
            database.Entry(record).CurrentValues.SetValues(data);
            return database.SaveChanges() > 0;
        }
    }
}
