using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrderRepo : DatabaseRepo, ICrud<Order, int, bool>
    {
        public bool Add(Order data)
        {
            database.Orders.Add(data);
            return database.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            database.Orders.Remove(Get(id));
            return database.SaveChanges() > 0;
        }

        public Order Get(int id)
        {
            return database.Orders.Find(id);
        }

        public List<Order> GetAll()
        {
            return database.Orders.ToList();
        }

        public bool Update(Order data)
        {
            var record = Get(data.order_id);
            database.Entry(record).CurrentValues.SetValues(data);
            return database.SaveChanges() > 0;
        }
    }
}
