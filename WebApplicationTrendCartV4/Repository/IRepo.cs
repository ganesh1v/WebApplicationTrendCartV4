namespace WebApplicationTrendCartV4.Repository
{
    public interface IRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T t);
        Task Update(T t);
        Task DeleteById(int id);
    }
}
