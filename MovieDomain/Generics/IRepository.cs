using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDomain.Generics
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        T Add(T entity);
        void Update(T entity);
        T Delete(T entity);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetBy(Func<T, bool> predicate);
        T GetById(int ID);

        int Commit();
    }
}
