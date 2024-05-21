using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Travela.EntityLayer.Concrete;

namespace Travela.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/AdminLayout")]
    public class AdminLayoutController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminLayoutController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
        return View();
        }
 
    }
}
