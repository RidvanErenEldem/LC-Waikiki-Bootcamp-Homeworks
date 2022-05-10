using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Resources;
using Response;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        Task<MovieResponse> SaveAsync (Movie movie);
        Task<List<Movie>> GetAllAsync();
        Task<MovieResponse> UpdateAsync(int id, Movie movie);
        Task<MovieResponse> DeleteAsync(int id);
        Task<List<Movie>> Search(SearchMovieResource resource);
    }
}