using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Travela.EntityLayer.Concrete;

namespace Travela.WebUI.ViewComponents
{
    public class _AdminUserComponents : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AdminUserComponents(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userInfo = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.id = userInfo.Id;
            ViewBag.name = userInfo.Name;
            ViewBag.surname = userInfo.SurName;
            return View();
        }
    }
}
