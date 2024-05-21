using Microsoft.AspNetCore.Mvc;

namespace Travela.WebUI.ViewComponents
{
    public class _UILayoutHeadComponents:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
