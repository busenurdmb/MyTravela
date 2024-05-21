using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travela.WebUI.Dtos;
using Travela.WebUI.Dtos.Features;

namespace Travela.WebUI.ViewComponents
{
    public class _AdminGaleryComponents : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminGaleryComponents(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7221/api/File");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGaleryDto>>(jsonData);
                return View(values);
            }
            return View();

        }
    }
}
