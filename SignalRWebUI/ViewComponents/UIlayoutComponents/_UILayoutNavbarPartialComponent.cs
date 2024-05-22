using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UIlayoutComponents
{
    public class _UILayoutNavbarPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
