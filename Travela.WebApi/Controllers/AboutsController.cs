using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.EntityLayer.Concrete;
using Travela.BusinessLayer.Abstract;

namespace Travela.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(About About)
        {
            _aboutService.TInsert(About);
            return Ok("Rota başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            _aboutService.TDelete(id);
            return Ok("Rota başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(About About)
        {
            _aboutService.TUpdate(About);
            return Ok("Güncelleme yapıldı");
        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            return Ok(_aboutService.TGetById(id));
        }
    }
}

