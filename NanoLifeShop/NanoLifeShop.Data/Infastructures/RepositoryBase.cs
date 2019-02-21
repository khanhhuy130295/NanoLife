    using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoLifeShop.Data.Infastructures
{
    public abstract class RepositoryBase<T> : IRepository<T>  where T:class
    {
        #region Property

        private NanoLifeShopDBContext dBContext;
        private readonly IDbSet<T> dbSet;

        protected IDBFactory DBFactory
        {
            get;
            private set;
        }

        protected NanoLifeShopDBContext DbContext
        {
            get
            {
                return dBContext ?? (dBContext = DBFactory.Initialize());
            }
        }

        #endregion Property

        public RepositoryBase(IDBFactory dBFactory)
        {
            DBFactory = dBFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implementaion

        public virtual T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public virtual bool CheckContains(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return dBContext.Set<T>().Count<T>(predicate) > 0;
        }

        public virtual int Count(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return dbSet.Count(where);
        }

        public virtual void Delete(T entity)
        {
            var result = dbSet.Remove(entity);
        }

        //Over Write
        public virtual T Delete(int id)
        {
            var entity = dbSet.Find(id);
            return dbSet.Remove(entity);
        }

        public virtual void DeleteMulti(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual IEnumerable<T> GetAll(string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dBContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }

            return dBContext.Set<T>().AsQueryable();
        }

        public virtual IEnumerable<T> GetMulti(System.Linq.Expressions.Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dBContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(predicate).AsQueryable<T>();
            }

            return dBContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IEnumerable<T> GetMultiPaging(System.Linq.Expressions.Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            int skipCount = index * size;
            IEnumerable<T> _resetSet;

            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dBContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                _resetSet = predicate != null ? query.Where<T>(predicate).AsQueryable() : query.AsQueryable();
            }
            else
            {
                _resetSet = predicate != null ? dBContext.Set<T>().Where<T>(predicate).AsQueryable() : dBContext.Set<T>().AsQueryable();
            }

            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public virtual T GetSingleByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression, string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dBContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault(expression);
            }

            return dBContext.Set<T>().FirstOrDefault(expression);
        }

        public virtual T GetSingleById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            var result = dBContext.Entry(entity).State = EntityState.Modified;
        }

        #endregion Implementaion
    }
}
