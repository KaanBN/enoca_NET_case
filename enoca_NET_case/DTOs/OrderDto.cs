﻿using System.ComponentModel.DataAnnotations;

namespace enoca_NET_case.DTOs
{
    public class OrderDto
    {
        public int? CarrierId { get; set; }
        public int? OrderDesi { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? OrderCarrierCost { get; set; }
    }
}
