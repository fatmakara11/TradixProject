using Microsoft.AspNetCore.Mvc;

namespace TradixProjectPresentationLayer.Controllers
{
    public class HistoryController: Controller
    {
        // Giriş Sayfası (GET)
        [HttpGet]
        public IActionResult History()
        {
            return View();
        }
    }
}
