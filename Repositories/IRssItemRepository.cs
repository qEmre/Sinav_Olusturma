using SinavOlusturma.Models;

namespace SinavOlusturma.Repositories
{
    public interface IRssItemRepository : IRepository<RssItem>
    {
        void Kaydet();
    }
}
