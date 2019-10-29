using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoalPassDAL.Abstractions
{
    public interface IAsyncRepository<T> where T : class
    {
        Task Add(T item);
        Task Remove(T item);
        Task Remove(string id);
        Task<T> Get(string id);
        Task<IEnumerable<T>> GetAll();
    }
}