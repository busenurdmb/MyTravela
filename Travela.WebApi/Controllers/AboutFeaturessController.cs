using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutFeaturessController : ControllerBase
    {
        private readonly IAboutFeatureService _aboutfeatureService;

        public AboutFeaturessController(IAboutFeatureService aboutfeatureService)
        {
            _aboutfeatureService = aboutfeatureService;
        }

        [HttpGet]
        public IActionResult AboutFeaturesList()
        {
            var values = _aboutfeatureService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAboutFeatures(AboutFeatures AboutFeatures)
        {
            _aboutfeatureService.TInsert(AboutFeatures);
            return Ok("Rota başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteAboutFeatures(int id)
        {
            _aboutfeatureService.TDelete(id);
            return Ok("Rota başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateAboutFeatures(AboutFeatures AboutFeatures)
        {
            _aboutfeatureService.TUpdate(AboutFeatures);
            return Ok("Güncelleme yapıldı");
        }

        [HttpGet("GetAboutFeatures")]
        public IActionResult GetAboutFeatures(int id)
        {
            return Ok(_aboutfeatureService.TGetById(id));
        }
    }
}


