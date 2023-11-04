using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enoca_NET_case.Models
{
    [Table("carrier_configurations")]
    public class CarrierConfiguration
    {
        public int CarrierConfigurationId { get; set; }
        [Required]
        public int CarrierId { get; set; }
        [Required]
        public int CarrierMaxDesi { get; set; }
        [Required]
        public int CarrierMinDesi { get; set; }
        [Required]
        public decimal CarrierCost { get; set; }
        [ForeignKey("CarrierId")]
        public Carrier Carrier { get; set; }
    }
}
