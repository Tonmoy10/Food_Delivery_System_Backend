using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CartDTO
    {
        public int cart_id { get; set; }
        public int customer_id { get; set; }
        public int item_id { get; set; }
        public int total_price { get; set; }
    }
}
