using System.Threading.Tasks;
using System.Collections.Generic;

namespace LighthouseData.Repository
{
    public interface IRepositoryBase<T>
    {
        public Task<T> Get(string id);
        public Task<List<T>> GetAll();
        public Task<T> Create(T obj);
    }
}