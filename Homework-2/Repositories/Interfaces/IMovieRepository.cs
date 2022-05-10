using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Repositories.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<List<Movie>> GetAllAsyncWithForegin();
        Task<List<Movie>> GetByTitleAsync(string title);
        Task<List<Movie>> GetByDirectorIdAsync(int directorId);
    }
}