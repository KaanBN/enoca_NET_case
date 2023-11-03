using enoca_NET_case.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enoca_NET_case.Models
{
    [Table("orders")]
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public int CarrierId { get; set; }
        [Required]
        public int OrderDesi { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal OrderCarrierCost { get; set; }

        public Carrier Carrier { get; set; }
    }
}
