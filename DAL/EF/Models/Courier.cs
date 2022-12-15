using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Courier
    {
        [Key]
        public int courier_id { get; set; }

        [Required]
        [StringLength(100)]
        public string courier_name { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string contact { get; set; }

        [Required]
        public string location { get; set; }

        [Required]
        public int income { get; set; }
        public string token { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public Courier()
        {
            Orders = new List<Order>();
        }
    }
}
