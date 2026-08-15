using System.Linq.Expressions;

namespace Domain.Repositories.Base
{
    public interface IGenericRepository<T>
    {
        public Task<T?> GetAsync(int codigo);
        public Task<List<T>> ListarAsync();
        public IQueryable<T> Pesquisar(Expression<Func<T, bool>>? func = null);
        public Task<bool> DeleteAsync(int codigo);
        public void Update(T entity);
        public Task<T> AddAsync(T entity);
        public Task SaveChangesAsync();
    }
}
