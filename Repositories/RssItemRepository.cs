using SinavOlusturma.DataLayer;
using SinavOlusturma.Models;

namespace SinavOlusturma.Repositories
{
    public class RssItemRepository : Repository<RssItem>, IRssItemRepository
    {
        private ProjeDbContext _projeDbContext;

        public RssItemRepository( ProjeDbContext projeDbContext) : base(projeDbContext)
        {
            _projeDbContext = projeDbContext;
        }

        public void Kaydet()
        {
            _projeDbContext.SaveChanges();
        }
    }
}
