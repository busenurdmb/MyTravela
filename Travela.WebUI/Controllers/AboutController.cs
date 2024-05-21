using Microsoft.AspNetCore.Mvc;

namespace Travela.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
