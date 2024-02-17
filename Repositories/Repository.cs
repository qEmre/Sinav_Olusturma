using Microsoft.EntityFrameworkCore;
using SinavOlusturma.DataLayer;
using System.Linq.Expressions;


namespace SinavOlusturma.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ProjeDbContext _projeDbContext;
        internal DbSet<T> dbSet;

        public Repository(ProjeDbContext projeDbContext)
        {
            _projeDbContext = projeDbContext;
            this.dbSet = _projeDbContext.Set<T>();
        }

        public void Ekle(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filtre, string? link = null)
        {
            IQueryable<T> sorgu = dbSet;
            sorgu = sorgu.Where(filtre);

            if (!string.IsNullOrEmpty(link))
            {
                foreach (var item in link.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    sorgu = sorgu.Include(item);
                }
            }
            return sorgu.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? link = null)
        {
            IQueryable<T> sorgu = dbSet;
            if (!string.IsNullOrEmpty(link))
            {
                foreach (var item in link.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    sorgu = sorgu.Include(item);
                }
            }
            return sorgu.ToList();
        }

        public void Sil(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
