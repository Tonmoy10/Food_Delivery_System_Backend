using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int customer_id { get; set; }

        [Required]
        [ForeignKey("Item")]
        public int item_id { get; set; }

        [Required]
        public int total_price { get; set; }

        [Required]
        public int status { get; set; }

        [Required(AllowEmptyStrings = true)]
        [ForeignKey("Courier")]
        public int? delivered_by { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Item Item { get; set; }
        public virtual Courier Courier { get; set; }
    }
}
