using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CartRepo : DatabaseRepo, ICrud<Cart, int, bool>, IDeleteCart
    {
        Random random = new Random();
        public bool Add(Cart data)
        {
            database.Carts.Add(data);
            return database.SaveChanges() > 0;
        }

        public bool Confirm()
        {
            var data = GetAll();
            int total = 0;
            //var order = new Order();
            //int[] items = new int[data.Count];
            foreach(var item in data)
            {
                total += item.total_price;
            }
            foreach(var cart in data)
            {
                var order = new Order();
                order.total_price = total;
                order.customer_id = cart.customer_id;
                order.item_id = cart.item_id;
                order.status = 0;
                order.delivered_by = random.Next(2, 11);
                //items.Append(cart.item_id);
                //order.status = "Pending"; 
                database.Orders.Add(order);
                database.Carts.Remove(cart);
                database.SaveChanges();
            }
            var sale = new Sale();
            sale.revenue = total;
            sale.expense = (int)(0.4 * total);
            sale.date = DateTime.Now;
            database.Sales.Add(sale);
            database.SaveChanges();
            //order.status = 0;
            //order.delivered_by = random.Next(2, 11);
            //order.item_id = items;
            //database.Orders.Add(order);
            //database.SaveChanges();
            return true;
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
