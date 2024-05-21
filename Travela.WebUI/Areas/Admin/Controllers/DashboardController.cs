using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travela.WebUI.Dtos;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/Dashboard")]
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            await LoadUserInformationAsync();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7221/api/Destination/DestinationChart");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<DestinationChartView>>(jsonData);
                ViewBag.ChartData = JsonConvert.SerializeObject(values);
                return View(values);
            }
            return View();
        }
        public async Task LoadUserInformationAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7221/api/Category/CategoryCount");
            var jsonData1 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.category = jsonData1;

            var responseMessage2 = await client.GetAsync("https://localhost:7221/api/Contact/ContactCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.contact = jsonData2;

            var responseMessage3 = await client.GetAsync("https://localhost:7221/api/Destination/DestinationCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.Destination = jsonData3;

            var responseMessage4 = await client.GetAsync("https://localhost:7221/api/Service/ServiceCount");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.Service = jsonData4;
        }
    }
}
