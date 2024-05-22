using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UIlayoutComponents
{
    public class _UILayoutHeadPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
