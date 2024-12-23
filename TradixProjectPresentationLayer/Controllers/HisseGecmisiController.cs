using Microsoft.AspNetCore.Mvc;

namespace TradixProjectPresentationLayer.Controllers
{
    public class HisseGecmisiController: Controller
    {
        // Giriş Sayfası (GET)
        [HttpGet]
        public IActionResult History()
        {
            return View();
        }
    }
}
