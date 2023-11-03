using System.ComponentModel.DataAnnotations.Schema;

namespace enoca_NET_case.Models
{
    [Table("carriers")]
    public class Carrier
    {
        public int CarrierId { get; set; }
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
        public int CarrierConfigurationId { get; set; }

        public List<Order> Orders { get; set; }
        public List<CarrierConfiguration> CarrierConfigurations { get; set; }

    }
}
