using Domain.Repositories.Base;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private const int CdEmpresa = 1;

        protected readonly SessionDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(SessionDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity == null) return false;
            _dbSet.Remove(entity);
            return true;
        }

        public async Task<T?> GetAsync(int codigo) => await _dbSet.FindAsync(codigo, CdEmpresa);

        public async Task<List<T>> ListarAsync() => await _dbSet.ToListAsync();

        public IQueryable<T> Pesquisar(Expression<Func<T, bool>>? func = null)
            => func == null ? _dbSet.AsQueryable() : _dbSet.Where(func).AsQueryable();

        public void Update(T entity) => _dbSet.Update(entity);

        public async Task<T> AddAsync(T entity) => (await _dbSet.AddAsync(entity)).Entity;

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
