using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TakeAway.Order.Application.Interfaces;

public interface IRepository<T,TId> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(TId id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(TId id);
    Task<T> GetFilterAsync(Expression<Func<T, bool>> predicate);

}
