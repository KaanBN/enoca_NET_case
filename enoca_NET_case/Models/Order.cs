using enoca_NET_case.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enoca_NET_case.Models
{
    [Table("orders")]
    public class Order
    {
        public int OrderId { get; set; }
        public int CarrierId { get; set; }
        public int OrderDesi { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderCarrierCost { get; set; }
    }
}
