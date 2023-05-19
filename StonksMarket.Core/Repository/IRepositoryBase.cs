namespace StonksMarket.Core.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task<T> GetById(int id);
        Task<T> Update(T entity);
    }
}