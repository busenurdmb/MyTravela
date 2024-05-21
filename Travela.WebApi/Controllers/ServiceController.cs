
using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _ServiceService;

        public ServiceController(IServiceService serviceService)
        {
            _ServiceService = serviceService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _ServiceService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateService(Services Service)
        {
            _ServiceService.TInsert(Service);
            return Ok("Rota başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            _ServiceService.TDelete(id);
            return Ok("Rota başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateService(Services Service)
        {
            _ServiceService.TUpdate(Service);
            return Ok("Güncelleme yapıldı");
        }

        [HttpGet("GetService")]
        public IActionResult GetService(int id)
        {
            return Ok(_ServiceService.TGetById(id));
        }
    }
}
