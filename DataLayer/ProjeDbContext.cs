using Microsoft.EntityFrameworkCore;
using SinavOlusturma.Models;

namespace SinavOlusturma.DataLayer
{
    public class ProjeDbContext : DbContext
    {

        public ProjeDbContext(DbContextOptions<ProjeDbContext> options) : base(options)
        {

        }
        
        public DbSet<RssItem> rssItems { get; set; }
        public DbSet<Soru> sorus { get; set; }
        public DbSet<Sinav> sinavs { get; set; }
    }
}
