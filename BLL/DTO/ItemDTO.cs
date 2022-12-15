using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ItemDTO
    {
        public int item_id { get; set; }
        public string item_name { get; set; }
        public int stock { get; set; }
        public int unit_price { get; set; }
        public DateTime man_date { get; set; }
        public DateTime exp_date { get; set; }
    }
}
