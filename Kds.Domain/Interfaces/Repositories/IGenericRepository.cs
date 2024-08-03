namespace Kds.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetListAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<Guid> InsertAsync(T entity);
        Task<T> UpdateAsync(T entry);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetByIdAsync(Guid id);
    }
}
