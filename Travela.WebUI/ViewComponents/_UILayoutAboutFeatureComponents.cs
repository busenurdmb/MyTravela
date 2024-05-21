using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travela.WebUI.Dtos.About;
using Travela.WebUI.Dtos.AboutFeatures;

namespace Travela.WebUI.ViewComponents
{
    public class _UILayoutAboutFeatureComponents : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutAboutFeatureComponents(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
