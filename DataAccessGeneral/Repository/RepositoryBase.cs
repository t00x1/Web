using DataAccess.ModelsDB;
using Microsoft.EntityFrameworkCore;
using DomainGeneral.Interfaces.Repository.DataAccess;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessGeneral.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected InspireoContext RepositoryContext { get; set; }
        public RepositoryBase(InspireoContext RepositoryContext)
        {
            this.RepositoryContext = RepositoryContext;
        }
        public async Task<List<T>> FindAll() => await RepositoryContext.Set<T>().AsNoTracking().ToListAsync();
        public async Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression) =>
           await RepositoryContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        public async Task Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public async Task Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public async Task Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        




    }
}
