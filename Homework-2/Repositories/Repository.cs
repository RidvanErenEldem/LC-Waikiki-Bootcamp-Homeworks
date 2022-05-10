using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext context;
        protected readonly DbSet<T> table;

        public Repository(AppDbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }
        public void Remove(T obj)
        {
            context.Remove(obj);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await table.FindAsync(id);
        }

        public async Task Insert(T obj)
        {
            await context.AddAsync(obj);
        }

        public void Update(T obj)
        {
            table.Update(obj);
        }
    }
}