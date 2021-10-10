using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using Yol.Services.DTOs;

namespace Yol.Services.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null);

        Task<IPagedList<T>> GetPagedList(
            RequestParams requestParams,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null);

        Task<IPagedList<T>> SearchPagedList(
            RequestParams requestParams,
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null);

        Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null);

        Task Insert(T entity);

        Task InsertRange(IEnumerable<T> entities);

        void Delete(T entity);

        Task DeleteRange(IEnumerable<T> entities);

        void Update(T entity);
    }
}
