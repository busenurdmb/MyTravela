using Microsoft.AspNetCore.Mvc;

namespace Travela.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
