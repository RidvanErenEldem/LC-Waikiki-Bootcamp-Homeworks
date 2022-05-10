using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Response;

namespace Repositories.Interfaces
{
    public interface IDirectorRepository : IRepository<Director>
    {
        Task<List<Director>> GetByNameAsync(string name);
        Task<List<Director>> GetByBirthDateAsync(DateTime birthDate);
    }
}