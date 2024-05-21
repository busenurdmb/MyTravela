using Microsoft.AspNetCore.Mvc;

namespace Travela.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
