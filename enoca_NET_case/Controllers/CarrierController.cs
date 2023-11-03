using enoca_NET_case.DTOs;
using enoca_NET_case.Exceptions;
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

        [HttpPost]
        public ActionResult CreateCarrier([FromBody] CarrierDto carrierDto)
        {
            try
            {
                _carrierService.CreateCarrier(carrierDto);
                return Ok("Kurye başarıyla oluşturuldu!");
            }
            catch (ValidationNotValidException ex)
            {
                return BadRequest(ex);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateCarrier([FromRoute] int id, [FromBody] CarrierDto carrierDto)
        {
            try
            {
                _carrierService.UpdateCarrier(id,carrierDto);
                return Ok(String.Format("{0} idli Kurye başarıyla güncellendi!", id));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound($"{id} idli kurye bulunamadı.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCarrier([FromRoute] int id)
        {
            try
            {
                _carrierService.DeleteCarrier(id);
                return Ok(String.Format("{0} idli Kurye başarıyla silindi!", id));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound($"{id} idli kurye bulunamadı.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
