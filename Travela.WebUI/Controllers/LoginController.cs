using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Travela.EntityLayer.Concrete;
using Travela.WebUI.Dtos;


namespace Travela.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("CategoryList", "Category", new { area = "Admin" });
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
