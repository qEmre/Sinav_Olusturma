using Microsoft.AspNetCore.Mvc;

namespace SinavOlusturma.Controllers
{
    public class GirisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string kullaniciAdi, string sifre)
        {
            if (kullaniciAdi == "admin" && sifre == "1905Eemre.")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.HataMesaj = "Kullanıcı adı veya şifre yanlış.";
                return View();
            }
        }
    }
}
