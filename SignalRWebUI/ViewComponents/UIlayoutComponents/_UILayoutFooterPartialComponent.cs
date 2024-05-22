using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UIlayoutComponents
{
    public class _UILayoutFooterPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}