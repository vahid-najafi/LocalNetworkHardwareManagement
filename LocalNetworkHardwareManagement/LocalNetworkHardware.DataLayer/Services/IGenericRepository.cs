using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace LocalNetworkHardware.DataLayer.Services
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetSingleByKey(object key);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> expression);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object key);
    }
}
