using enoca_NET_case.Models;
using enoca_NET_case.Services;
using Microsoft.AspNetCore.Mvc;

namespace enoca_NET_case.Controllers
{
    [Route("api/carrier")]
    [ApiController]
    public class CarrierController: Controller
    {
        private readonly ICarrierService _carrierService;

        public CarrierController(ICarrierService carrierService)
        {
            this._carrierService = carrierService;
        }

        [HttpGet]
        public ActionResult<List<Carrier>> GetAllCarriers()
        {
            var carriers = _carrierService.GetAllCarriers();
            return Ok(carriers);
        }
    }
}
