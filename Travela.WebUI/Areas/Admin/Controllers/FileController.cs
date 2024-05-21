using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Travela.WebUI.Dtos.Contact;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/File")]
    public class FileController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FileController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("List")]
        public IActionResult List()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<JsonResult> Add(CreateViewDto p)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(p);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync("https://localhost:7221/api/File/upload1", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return Json("Ok");
        //    }

        //    return Json("Hata");
        //}
    }
}
