using enoca_NET_case.Models;
using System.ComponentModel.DataAnnotations;

namespace enoca_NET_case.DTOs
{
    public class CarrierConfigurationDto
    {
        public int CarrierConfigurationId { get; set; }
        [Required]
        public int? CarrierId { get; set; }
        public int? CarrierMaxDesi { get; set; }
        public int? CarrierMinDesi { get; set; }
        public decimal? CarrierCost { get; set; }
    }
}
