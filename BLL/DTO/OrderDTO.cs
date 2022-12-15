using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class OrderDTO
    {
        public int order_id { get; set; }
        public int total_price { get; set; }
        public int status { get; set; }
    }
}
