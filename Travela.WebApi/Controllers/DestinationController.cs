using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.EntityLayer.Concrete;
using Travela.BusinessLayer.Abstract;

namespace Travela.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService _destinationService;
        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet]
        public IActionResult DestinationList()
        {
            var values = _destinationService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDestination(Destination destination)
        {
            _destinationService.TInsert(destination);
            return Ok("Rota başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteDestination(int id)
        {
            _destinationService.TDelete(id);
            return Ok("Rota başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateDestination(Destination destination)
        {
            _destinationService.TUpdate(destination);
            return Ok("Güncelleme yapıldı");
        }

        [HttpGet("GetDestination")]
        public IActionResult GetDestination(int id)
        {
            return Ok(_destinationService.TGetById(id));
        }
    }
}
