using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Travela.WebUI.Dtos.AboutFeatures;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("/Admin/AboutFeatures")]
    public class AboutFeaturesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AboutFeaturesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("AboutFeaturesList")]
        public async Task<IActionResult> AboutFeaturesList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7221/api/AboutFeaturess");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutFeaturesDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateAboutFeatures")]
        public IActionResult CreateAboutFeatures()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateAboutFeatures")]
        public async Task<IActionResult> CreateAboutFeatures(CreateAboutFeaturesDto createAboutFeaturesDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAboutFeaturesDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7221/api/AboutFeaturess", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AboutFeaturesList");
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateAboutFeatures/{id}")]
        public async Task<IActionResult> UpdateAboutFeatures(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7221/api/AboutFeaturess/GetAboutFeatures?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateAboutFeaturesDto>(jsonData);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateAboutFeatures/{id}")]
        public async Task<IActionResult> UpdateAboutFeatures(UpdateAboutFeaturesDto updateAboutFeaturesDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAboutFeaturesDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7221/api/AboutFeaturess", stringContent);
            return RedirectToAction("AboutFeaturesList");
        }
    }
}
