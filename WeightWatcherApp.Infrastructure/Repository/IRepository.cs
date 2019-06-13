using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeightWatcherApp.Infrastructure.Repository
{
    public interface IRepository<TEntity>
    {
        //Task<IEnumerable<TEntity>> GetAll();
        //Task<TEntity> GetById(long id);
        Task Add(TEntity entity);
        //Task Update(TEntity entity);
        Task Delete(long id);
    }
}