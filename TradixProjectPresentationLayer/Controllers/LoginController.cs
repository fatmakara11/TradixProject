using Microsoft.AspNetCore.Mvc;

namespace TradixProjectPresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        // Giriş Sayfası (GET)
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Views/Login/Login.cshtml dosyasını yükler
        }

        // Giriş İşlemi (POST)
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (email == "fatmaka646@gmail.com" && password == "1234") // Örnek doğrulama

            {
                return RedirectToAction("Index", "CustomerLayout");
                // Giriş başarılıysa yönlendirme
            }

            ViewBag.ErrorMessage = "Geçersiz e-posta veya şifre!";
            return View();
        }

        // Şifremi Unuttum Sayfası (GET)
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View(); // Views/Login/ForgotPassword.cshtml dosyasını yükler
        }

        // Şifre Sıfırlama Maili Gönder (POST)
        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            // Örnek mail gönderme işlemi
            if (!string.IsNullOrEmpty(email))
            {
                TempData["SuccessMessage"] = "Şifre sıfırlama talimatları e-posta adresinize gönderildi.";
            }
            else
            {
                TempData["ErrorMessage"] = "Lütfen geçerli bir e-posta adresi girin.";
            }

            return RedirectToAction("ForgotPassword");
        }
    }
}