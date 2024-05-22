using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UIlayoutComponents
{
    public class _UILayoutScriptPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}