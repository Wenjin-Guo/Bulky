using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        //T - Category
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null, 
            string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, 
            string? includeProperties = null,bool tracked= false); 
        //last bool track make sure entity framework not track object that get from database
        void Add(T entity); 
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
