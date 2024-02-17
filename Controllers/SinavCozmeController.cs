using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SinavOlusturma.DataLayer;

namespace SinavOlusturma.Controllers
{
    public class SinavCozmeController : Controller
    {
        private readonly ProjeDbContext _projeDbContext;

        public SinavCozmeController(ProjeDbContext projeDbContext)
        {
            _projeDbContext = projeDbContext;
        }

        [HttpGet]
        public IActionResult SinavCoz(int? id)
        {
            var sinav = _projeDbContext.sinavs.Include(s => s.Sorular).FirstOrDefault(s => s.Id == id);

            return View(sinav);
        }
    }
}