using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Sale
    {
        [Key]
        public int sales_id { get; set; }

        [Required]
        public int expense { get; set; }

        [Required]
        public int revenue { get; set; }

        [Required]
        public DateTime date { get; set; }
    }
}
