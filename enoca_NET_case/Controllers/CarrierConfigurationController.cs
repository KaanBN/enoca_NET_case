using enoca_NET_case.DTOs;
using enoca_NET_case.Exceptions;
using enoca_NET_case.Models;
using enoca_NET_case.Services;
using Microsoft.AspNetCore.Mvc;

namespace enoca_NET_case.Controllers
{
    [Route("api/carrierConfigurations")]
    [ApiController]
    public class CarrierConfigurationController : Controller
    {
        private readonly ICarrierConfigurationService _carrierConfigurationService;

        public CarrierConfigurationController(ICarrierConfigurationService carrierConfigurationService)
        {
            this._carrierConfigurationService = carrierConfigurationService;
        }

        [HttpGet]
        public ActionResult<List<CarrierConfiguration>> GetAllCarrierConfigurations()
        {
            var carrierConfigurations = _carrierConfigurationService.GetAllCarrierConfigurations();
            return Ok(carrierConfigurations);
        }

        [HttpPost]
        public ActionResult CreateCarrierConfiguration([FromBody] CarrierConfigurationDto carrierConfigurationDto)
        {
            try
            {
                _carrierConfigurationService.CreateCarrierConfiguration(carrierConfigurationDto);
                return Ok("Kurye konfigürasyonu başarıyla oluşturuldu!");
            }
            catch (ValidationNotValidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateCarrierConfiguration([FromRoute] int id, [FromBody] CarrierConfigurationDto carrierConfigurationDto)
        {
            try
            {
                _carrierConfigurationService.UpdateCarrierConfiguration(id,carrierConfigurationDto);
                return Ok(String.Format("{0} idli Kurye konfigürasyonu başarıyla güncellendi!", id));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ValidationNotValidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("UpdateCarrierConfiguration: " + ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCarrierConfiguration([FromRoute] int id)
        {
            try
            {
                _carrierConfigurationService.DeleteCarrierConfiguration(id);
                return Ok(String.Format("{0} idli Kurye konfigürasyonu başarıyla silindi!", id));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound($"{id} idli kurye konfigürasyonu bulunamadı.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
