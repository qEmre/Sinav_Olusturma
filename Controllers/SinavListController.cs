using Microsoft.AspNetCore.Mvc;
using SinavOlusturma.DataLayer;
using SinavOlusturma.Models;

namespace SinavOlusturma.Controllers
{
    public class SinavListController : Controller
    {
        private readonly ProjeDbContext _projeDbContext;


        public SinavListController(ProjeDbContext projeDbContext)
        {
            _projeDbContext = projeDbContext;
        }

        public IActionResult Index()
        {
            List<Sinav> sinavList = _projeDbContext.sinavs.ToList();
            return View(sinavList);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var sinav = _projeDbContext.sinavs.FirstOrDefault(s => s.Id == id);

            if (sinav == null)
            {
                return NotFound();
            }

            _projeDbContext.sinavs.Remove(sinav);
            _projeDbContext.SaveChanges();

            return RedirectToAction("Index", "SinavList");
        }
    }
}
