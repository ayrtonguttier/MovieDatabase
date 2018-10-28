using MovieDomain.Generics;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Generics
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected DbContext context;
        protected DbSet<T> dbSet;
        public Repository(DbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        public T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public T Delete(T entity)
        {
            return dbSet.Remove(entity);
        }

        public void Dispose()
        {
            dbSet = null;
            context = null;
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public IEnumerable<T> GetBy(Func<T, bool> predicate)
        {
            return dbSet.Where(predicate);
        }

        public T GetById(int ID)
        {
            return dbSet.Find(ID);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
