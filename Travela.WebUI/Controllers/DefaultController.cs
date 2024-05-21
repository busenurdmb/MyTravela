using Microsoft.AspNetCore.Mvc;

namespace Travela.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
