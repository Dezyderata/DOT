using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeightWatcherApp.Infrastructure.Model;

namespace WeightWatcherApp.Infrastructure.Repository
{
    public interface IMeasurementRepository : IRepository<Measurement>
    {
        Task<IEnumerable<Measurement>> GetAll(long id);
        Task<IEnumerable<Measurement>> GetByDate(DateTime start, DateTime stop);
    }
}