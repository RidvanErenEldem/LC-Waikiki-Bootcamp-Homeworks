using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contexts;
using Extensions;
using Models;
using Repositories.Interfaces;

namespace Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly IDirectorRepository directorRepository;
        public MovieRepository(AppDbContext context,IDirectorRepository directorRepository) : base(context)
        {
            this.directorRepository = directorRepository;
        }

        public async Task<List<Movie>> GetAllAsyncWithForegin()
        {
            List<Movie> movies = await GetAllAsync();
            foreach (var movie in movies)
            {
                Director director = await directorRepository.GetByIdAsync(movie.DirectorId);
                movie.Directors = director;
            }
            return movies;
        }

        public async Task<List<Movie>> GetByDirectorIdAsync(int directorId)
        {
            var searchQuery = table.Where(x => x.DirectorId == directorId);
            List<Movie> movies = await searchQuery.ToListAsync();
            return movies;
        }

        public async Task<List<Movie>> GetByTitleAsync(string title)
        {
            var searchQuery = table.Where(x => x.Title == title);
            List<Movie> movies = await searchQuery.ToListAsync();
            return movies;
        }
    }
}