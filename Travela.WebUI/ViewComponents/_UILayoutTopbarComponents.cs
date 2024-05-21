using Microsoft.AspNetCore.Mvc;

namespace Travela.WebUI.ViewComponents
{
    public class _UILayoutTopbarComponents : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
