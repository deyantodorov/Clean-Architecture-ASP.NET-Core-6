using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Persistance.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> Get(int id);

        public Task<IReadOnlyList<T>> GetAll();

        public Task<T> Add(T entity);

        public Task<T> Update(T entity);

        public Task<T> Delete(T entity);
    }
}
