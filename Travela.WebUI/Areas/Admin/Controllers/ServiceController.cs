using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Travela.WebUI.Dtos.Services;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("/Admin/Service")]
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("ServiceList")]
        public async Task<IActionResult> ServiceList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7221/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServicesDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateService")]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateService")]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7221/api/Service", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ServiceList");
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7221/api/Service/GetService?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7221/api/Service", stringContent);
            return RedirectToAction("ServiceList");
        }
    }
}
