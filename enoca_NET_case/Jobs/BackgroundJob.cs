using enoca_NET_case.Data;
using enoca_NET_case.Models;

namespace enoca_NET_case.Jobs
{
    public class BackgroundJob
    {
        private readonly AppDbContext _context;

        public BackgroundJob(AppDbContext context)
        {
            _context = context;
        }
        public void Execute()
        {
            var groupedOrders = _context.Orders
                .GroupBy(order => new { order.CarrierId, order.OrderDate.Date })
                .Select(group => new
                {
                    CarrierId = group.Key.CarrierId,
                    OrderDate = group.Key.Date,
                    TotalCarrierCost = group.Sum(order => order.OrderCarrierCost)
                })
                .ToList();

            foreach (var groupedOrder in groupedOrders)
            {
                var carrier = _context.Carriers.Find(groupedOrder.CarrierId);
                var carrierName = carrier.CarrierName;
                var orderDate = groupedOrder.OrderDate.ToString("dd.MM.yyyy");
                var totalCarrierCost = groupedOrder.TotalCarrierCost;

                System.Diagnostics.Debug.WriteLine($"{carrierName} kargo firmasına {orderDate} tarihinde {totalCarrierCost}₺ kargo ücreti ödendi.");

                var carrierReport = new CarrierReport
                {
                    CarrierId = groupedOrder.CarrierId,
                    CarrierCost = totalCarrierCost,
                    CarrierReportDate = DateTime.Now
                };

                // CarrierReport nesnesini kaydet.
                _context.CarrierReports.Add(carrierReport);
            }

            // Tüm CarrierReport nesnelerini veritabanına kaydet.
            _context.SaveChanges();
        }
    }
}
