using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Travela.EntityLayer.Concrete;
using Travela.WebUI.Dtos;

namespace Travela.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            var appUser = new AppUser()
            {
                Name = registerDto.Name,
                SurName = registerDto.Surname,
                Email = registerDto.Mail,
                UserName = registerDto.Username,
                İmageUrl = registerDto.İmageUrl
            };
            var result = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
