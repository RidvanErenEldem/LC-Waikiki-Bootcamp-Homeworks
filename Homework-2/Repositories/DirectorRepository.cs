using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contexts;
using Extensions;
using Models;
using Repositories.Interfaces;
using Response;

namespace Repositories
{
    public class DirectorRepository : Repository<Director>, IDirectorRepository
    {
        public DirectorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Director>> GetByNameAsync(string name)
        {
            var searchQuery = table.Where(x => x.Name == name);
            List<Director> directors = await searchQuery.ToListAsync();
            return directors;
        }
        public async Task<List<Director>> GetByBirthDateAsync(DateTime birthDate)
        {
            var searchQuery = table.Where(x => x.Birthday == birthDate);
            List<Director> directors = await searchQuery.ToListAsync();
            return directors;
        }
    }
}