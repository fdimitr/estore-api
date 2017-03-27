using estore_repository;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.OData;

namespace estore_logic
{
    public abstract class BaseLogic<T> : IDisposable
        where T : class
    {
        protected StoreDB DbContext { get; set; }

        public BaseLogic()
        {
            DbContext = new StoreDB();
        }

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public async Task<T> GetById(int id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> Create(T entity)
        {
            var result = DbContext.Set<T>().Add(entity);
            await DbContext.SaveChangesAsync();
            return result;
        }

        public async Task<bool> Patch(int id, Delta<T> patch)
        {
            T entity = await GetById(id);
            if (entity != null)
            {
                patch.Patch(entity);

                try
                {
                    int result = await DbContext.SaveChangesAsync();
                    return result > 0 ? true : false;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (EntityExists(id))
                    {
                        throw;
                    }
                }
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            T entity = await DbContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            DbContext.Set<T>().Remove(entity);
            var result = await DbContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        protected bool EntityExists(int id)
        {
            return DbContext.Set<T>().Find(id) != null;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
