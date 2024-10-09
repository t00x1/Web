

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using System.Threading.Tasks;

namespace DomainGeneral.Interfaces.Repository.DataAccess
{
    public interface IRepositoryBase<T>
    {

        Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression);

        Task<List<T>> FindAll();
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);

    }
}