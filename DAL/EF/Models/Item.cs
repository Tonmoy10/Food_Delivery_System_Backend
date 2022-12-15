using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Item
    {
        [Key]
        public int item_id { get; set; }

        [Required]
        public string item_name { get; set; }

        [Required]
        public int stock { get; set; }

        [Required]
        public int unit_price { get; set; }

        [Required]
        public DateTime man_date { get; set; }

        [Required]
        public DateTime exp_date { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Item()
        {
            Carts = new List<Cart>();
            Orders = new List<Order>();
        }
    }
}
