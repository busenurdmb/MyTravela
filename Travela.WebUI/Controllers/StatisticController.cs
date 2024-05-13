using Microsoft.AspNetCore.Mvc;

namespace MyTravela.WebUI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7221/api/Category/CategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.c = jsonData;
            return View();
        }
    }
}
