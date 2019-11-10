using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoalPassBLL.Services
{
    public interface IService<T> where T : class
    {
        Task Add(T item);
        Task Update(T item);
        Task Remove(string id);
        Task<T> Get(string id);
        Task<IEnumerable<T>> GetAll();
    }
}
