using Microsoft.AspNetCore.Mvc;

namespace Travela.WebUI.ViewComponents
{
    public class _UILayoutNavbarComponents : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
