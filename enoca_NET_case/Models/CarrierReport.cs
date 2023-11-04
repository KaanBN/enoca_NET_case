using System.ComponentModel.DataAnnotations.Schema;

namespace enoca_NET_case.Models
{
    [Table("carrier_reports")]
    public class CarrierReport
    {
        public int CarrierReportId { get; set; }
        public int CarrierId { get; set; }
        public decimal CarrierCost { get; set; }
        public DateTime CarrierReportDate { get; set; }

        [ForeignKey("CarrierId")]
        public Carrier Carrier { get; set; }
    }
}
