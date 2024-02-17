using Microsoft.AspNetCore.Mvc;
using SinavOlusturma.DataLayer;
using SinavOlusturma.Models;

namespace SinavOlusturma.Controllers
{
    public class SinavOlusturmaController : Controller
    {
        private readonly ProjeDbContext _projeDbContext;

        public SinavOlusturmaController(ProjeDbContext projeDbContext)
        {
            _projeDbContext = projeDbContext;
        }

        [HttpGet]
        public IActionResult Index(string title)
        {
            var rssItem = _projeDbContext.rssItems.SingleOrDefault(i => i.Title == title);
            if (rssItem != null)
            {
                ViewBag.Title = rssItem.Title;
                ViewBag.Description = rssItem.Description;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sinav sinav)
        {
            Sinav exam = new Sinav
            {
                Baslik = sinav.Baslik,
                Aciklama = sinav.Aciklama,
                OlusturmaTarihi = DateTime.Now.Date,
                Sorular = new List<Soru>()
            };
            _projeDbContext.sinavs.Add(exam);
            _projeDbContext.SaveChanges();

            foreach (var item in sinav.Sorular.ToList())
            {
                Soru soru = new Soru
                {
                    soruMetni = item.soruMetni,
                    secenekA = item.secenekA,
                    secenekB = item.secenekB,
                    secenekC = item.secenekC,
                    secenekD = item.secenekD,
                    dogruCevap = item.dogruCevap,
                    SinavId = exam.Id
                };
                _projeDbContext.sorus.Add(soru);
            }
            _projeDbContext.SaveChanges();

            return RedirectToAction("Index", "SinavList");
        }
    }
}