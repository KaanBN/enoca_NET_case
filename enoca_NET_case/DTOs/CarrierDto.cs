using System.ComponentModel.DataAnnotations;

namespace enoca_NET_case.DTOs
{
    public class CarrierDto
    {
        public int CarrierId { get; set; }
        public string? CarrierName { get; set; }
        public bool? CarrierIsActive { get; set; }
        public int? CarrierPlusDesiCost { get; set; }
    }
}
