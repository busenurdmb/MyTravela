using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Travela.WebUI.Dtos.Contact;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("/Admin/Contact")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("ContactList")]
        public async Task<IActionResult> ContactList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7221/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    
       
    }
}
