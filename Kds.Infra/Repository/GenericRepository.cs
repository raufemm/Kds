using Kds.Domain.Entities;
using Kds.Domain.Interfaces.Repositories;
using Kds.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Kds.Infra.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext Context;
        
        public GenericRepository(
        ApplicationDbContext dbContext)
        {
            Context = dbContext;
        }

        public async Task<T> GetAsync(Guid id)
        {
            try
            {
                var response = await Context.Set<T>().FindAsync(id);

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var response = await Context.Set<T>().AsNoTracking().ToListAsync();

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<T>> GetListAsync(Guid id)
        {
            try
            {
                var entity = await Context.Set<T>().FindAsync(id);

                if (entity != null)
                {
                    return new List<T> { entity };
                }

                return Enumerable.Empty<T>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Guid> InsertAsync(T entity)
        {
            try
            {
                Context.Add(entity);
                await Context.SaveChangesAsync();
                var entityEntry = Context.Entry(entity);
                return (Guid)entityEntry.Property("Id").CurrentValue!;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> UpdateAsync(T entry)
        {
            try
            {
                Context.Update<T>(entry);

                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return entry;
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                Context.Remove(entity);
                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<T>> GetByIdAsync(Guid id)
        {
            var entity = await Context.Set<T>().FindAsync(id);

            if (entity != null)
            {
                return new List<T> { entity };
            }

            return Enumerable.Empty<T>();
        }
    }
}
