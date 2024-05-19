using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.EntityLayer.Concrete;
using Travela.BusinessLayer.Abstract;

namespace Travela.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _featureService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(Feature Feature)
        {
            _featureService.TInsert(Feature);
            return Ok("Rota başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            _featureService.TDelete(id);
            return Ok("Rota başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateFeature(Feature Feature)
        {
            _featureService.TUpdate(Feature);
            return Ok("Güncelleme yapıldı");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            return Ok(_featureService.TGetById(id));
        }
    }
}

