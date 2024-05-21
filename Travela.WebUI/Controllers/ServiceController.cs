using Microsoft.AspNetCore.Mvc;

namespace Travela.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
