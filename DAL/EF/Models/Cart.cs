using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Cart
    {
        [Key]
        public int cart_id { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int customer_id { get; set; }

        [Required]
        [ForeignKey("Item")]
        public int item_id { get; set; }

        [Required]
        public int total_price { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Item Item { get; set; }
    }
}
