using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enoca_NET_case.Models
{
    [Table("carrier_configurations")]
    public class CarrierConfiguration
    {
        public int CarrierConfigurationId { get; set; }
        public int CarrierId { get; set; }
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public decimal CarrierCost { get; set; }

        public Carrier Carrier { get; set; }
    }
}
