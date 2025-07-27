using D_Domain_Layer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace D_Persistence_Layer.Repositories.Interface
{
    public interface IRepository<T> where T : new()
    {

        Task<PageResult<T>> GetPagedResult(Expression<Func<T,bool>> filter = null,
        Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null,
         int pageNumber = 1,int pageSize = 10);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();

        Task<T> Add(T entity);
       Task<T> Update(Guid id,T entity);
       Task Delete(Guid id);

        Task<bool> IsAnyItem(Expression<Func<T, bool>> filter = null);
      
    }
}
