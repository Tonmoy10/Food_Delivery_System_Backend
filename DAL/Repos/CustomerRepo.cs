using DAL.EF.Models;
using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CustomerRepo : DatabaseRepo, ICrud<Customer, int, bool>
    {
        public bool Add(Customer data)
        {
            database.Customers.Add(data);
            return database.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            database.Customers.Remove(database.Customers.Find(id));
            return database.SaveChanges() > 0;
        }

        public Customer Get(int id)
        {
            return database.Customers.Find(id);
        }

        public List<Customer> GetAll()
        {
            return database.Customers.ToList();
        }

        public bool Update(Customer data)
        {
            var record = database.Customers.Find(data.customer_id);
            database.Entry(record).CurrentValues.SetValues(data);
            return database.SaveChanges() > 0;
        }
    }
}
