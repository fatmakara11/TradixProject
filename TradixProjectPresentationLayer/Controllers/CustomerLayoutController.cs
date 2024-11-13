using Microsoft.AspNetCore.Mvc;

namespace TradixProjectPresentationLayer.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
