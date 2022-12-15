using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class SaleDTO
    {
        public int sales_id { get; set; }
        public int expense { get; set; }
        public int revenue { get; set; }
        public DateTime date { get; set; }
    }
}
