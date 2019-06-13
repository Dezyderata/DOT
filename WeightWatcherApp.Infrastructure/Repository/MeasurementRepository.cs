using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeightWatcherApp.Infrastructure.Context;
using WeightWatcherApp.Infrastructure.Model;

namespace WeightWatcherApp.Infrastructure.Repository
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly WeightWatcherContext _weightWatcherContext;

        public MeasurementRepository(WeightWatcherContext weightWatcherContext)
        {
            _weightWatcherContext = weightWatcherContext;
        }

        public async Task<IEnumerable<Measurement>> GetAll(long id)
        {
            var measurements = await _weightWatcherContext.Measurement
                .Where(x => x.User.Id == id)
                .ToListAsync();
            return measurements;
        }

        public async Task<IEnumerable<Measurement>> GetByDate(DateTime start, DateTime stop)
        {
            var measurements = await _weightWatcherContext.Measurement
                .Where(x => x.DateOfCreation >= start )
                .Where(x => x.DateOfCreation <= stop)
                .ToListAsync();
            return measurements;
        }

        /*public async Task<Measurement> GetById(long id)
        {
            var measurements = await _weightWatcherContext.Measurement
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            return measurements;
        }

        //For one user
        public async Task<IEnumerable<Measurement>> GetByPersonId(long id)
        {
            var measurements = await _weightWatcherContext.Measurement
                .Where(x => x.User.Id == id)
                .ToListAsync();
            return measurements;
        }*/
        public async Task Add(Measurement entity)
        {
            entity.DateOfCreation = DateTime.Now;
            entity.countBmi(); //dyskusyjne
            await _weightWatcherContext.Measurement
                .Include(x => x.User)
                .FirstAsync();
            await _weightWatcherContext.Measurement.AddAsync(entity);
            await _weightWatcherContext.SaveChangesAsync();
        }

        /*public async Task Update(Measurement entity)
        {
            throw new System.NotImplementedException();
        }*/

        public async Task Delete(long id)
        {
            var measurementToDelete =
                _weightWatcherContext.Measurement.SingleOrDefaultAsync(measurement => measurement.Id == id);
            if (measurementToDelete != null)
            {
                _weightWatcherContext.Remove(measurementToDelete);
                await _weightWatcherContext.SaveChangesAsync();
            }
        }
    }
}