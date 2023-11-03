using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enoca_NET_case.Models
{
    [Table("carriers")]
    public class Carrier
    {
        public int CarrierId { get; set; }
        [Required]
        public string CarrierName { get; set; }
        [Required]

        public bool CarrierIsActive { get; set; }
        [Required]

        public int CarrierPlusDesiCost { get; set; }

        public List<Order> Orders { get; set; }
        public List<CarrierConfiguration> CarrierConfigurations { get; set; }

    }
}
