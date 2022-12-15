using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CartRepo : DatabaseRepo, ICrud<Cart, int, bool>
    {
        public bool Add(Cart data)
        {
            database.Carts.Add(data);
            return database.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            database.Carts.Remove(Get(id));
            return database.SaveChanges() > 0;
        }

        public Cart Get(int id)
        {
            return database.Carts.Find(id);
        }

        public List<Cart> GetAll()
        {
            return database.Carts.ToList();
        }

        public bool Update(Cart data)
        {
            var record = Get(data.cart_id);
            database.Entry(record).CurrentValues.SetValues(data);
            return database.SaveChanges() > 0;
        }
    }
}
