using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SaleRepo : DatabaseRepo, ICrud<Sale, int, bool>, ICount
    {
        public int Count() 
        {
            int total = 0;
            var data = GetAll();
            foreach (var item in data)
            {
                total += item.revenue;
            }
            return total;
        }

        
            
        

        public bool Add(Sale data)
        {
            database.Sales.Add(data);
            return database.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            database.Sales.Remove(Get(id));
            return database.SaveChanges() > 0;
        }

        public Sale Get(int id)
        {
            return database.Sales.Find(id);
        }

        public List<Sale> GetAll()
        {
            return database.Sales.ToList();
        }

        public bool Update(Sale data)
        {
            var record = Get(data.sales_id);
            database.Entry(record).CurrentValues.SetValues(data);
            return database.SaveChanges() > 0;
        }
    }
}
