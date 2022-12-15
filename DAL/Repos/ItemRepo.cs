using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ItemRepo : DatabaseRepo, ICrud<Item, int, bool>
    {
        public bool Add(Item data)
        {
            database.Items.Add(data);
            return database.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            database.Items.Remove(Get(id));
            return database.SaveChanges() > 0;
        }

        public Item Get(int id)
        {
            return database.Items.Find(id);
        }

        public List<Item> GetAll()
        {
            return database.Items.ToList();
        }

        public bool Update(Item data)
        {
            var record = Get(data.item_id);
            database.Entry(record).CurrentValues.SetValues(data);
            return database.SaveChanges() > 0;
        }
    }
}
