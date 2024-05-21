using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Travela.WebUI.Controllers
{
    [AllowAnonymous]
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
