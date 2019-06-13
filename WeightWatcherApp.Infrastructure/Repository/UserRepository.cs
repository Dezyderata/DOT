using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeightWatcherApp.Infrastructure.Context;
using WeightWatcherApp.Infrastructure.Model;

namespace WeightWatcherApp.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
            private readonly WeightWatcherContext _weightWatcherContext;

            public UserRepository(WeightWatcherContext weightWatcherContext)
            {
                _weightWatcherContext = weightWatcherContext;
            }

            public async Task<User> GetById(long id)
            {
                var user = await _weightWatcherContext.User
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
                await _weightWatcherContext.Entry(user).Collection(x => x.Measurements).LoadAsync();
                Console.Out.WriteLine("-------------------------------");
                foreach (var x in user.Measurements)
                {
                    Console.Out.WriteLine("**********");
                    Console.Out.WriteLine(x.Weight);
                    Console.Out.WriteLine("**********");
                }
                Console.Out.WriteLine("-------------------------------");



                return user;
            }

            public async Task Add(User entity)
            {
                entity.DateOfCreation = DateTime.Today;
                await _weightWatcherContext.User.AddAsync(entity);
                await _weightWatcherContext.SaveChangesAsync();
            }

            public async Task Update(User entity)
            {
                var userToUpdate = await _weightWatcherContext.User
                    .SingleOrDefaultAsync(x => x.Id == entity.Id);
                if (userToUpdate != null)
                {
                    userToUpdate.FirstName = entity.FirstName;
                    userToUpdate.LastName = entity.LastName;
                    userToUpdate.Hight = entity.Hight;
                    userToUpdate.DateOfUpdate = DateTime.Now;
                    await _weightWatcherContext.SaveChangesAsync();
                }
            }

            public async Task Delete(long id)
            {
                var userToDelete = await _weightWatcherContext.User.SingleOrDefaultAsync(person => person.Id == id);
                if (userToDelete != null)
                {
                    _weightWatcherContext.User.Remove(userToDelete);
                    await _weightWatcherContext.SaveChangesAsync();
                }
            }
        }
    }
