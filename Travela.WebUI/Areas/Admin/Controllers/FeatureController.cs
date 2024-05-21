using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Travela.WebUI.Dtos.Features;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("/Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("FeatureList")]
        public async Task<IActionResult> FeatureList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7221/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeaturesDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateFeature")]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeaturesDto createFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeatureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7221/api/Features", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("FeatureList");
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7221/api/Features/GetFeature?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateFeaturesDto>(jsonData);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(UpdateFeaturesDto updateFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7221/api/Features", stringContent);
            return RedirectToAction("FeatureList");
        }
    }
}
