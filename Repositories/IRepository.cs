using System.Linq.Expressions;

namespace SinavOlusturma.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Ekle(T entity);
        void Sil(T entity);
        IEnumerable<T> GetAll(string? link = null);
        T Get(Expression<Func<T, bool>> filtre, string? link = null);
    }
}