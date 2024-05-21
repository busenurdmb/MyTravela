using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Travela.WebUI.Dtos;
using Travela.WebUI.Dtos.About;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("/Admin/About")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("AboutList")]
        public async Task<IActionResult> AboutList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7221/api/Abouts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateAbout")]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAboutDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7221/api/Abouts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AboutList");
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7221/api/Abouts/GetAbout?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAboutDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7221/api/Abouts", stringContent);
            return RedirectToAction("AboutList");
        }
    }
}
