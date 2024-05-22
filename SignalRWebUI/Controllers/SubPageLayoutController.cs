using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class SubPageLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
