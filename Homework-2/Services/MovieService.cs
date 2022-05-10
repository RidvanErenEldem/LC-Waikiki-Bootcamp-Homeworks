using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Models;
using Repositories.Interfaces;
using Resources;
using Response;
using Services.Interfaces;

namespace Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;
        private readonly IUnitOfWork unitOfWork;

        public MovieService(IMovieRepository movieRepository, IUnitOfWork unitOfWork)
        {
            this.movieRepository = movieRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<MovieResponse> DeleteAsync(int id)
        {
            var existing = await movieRepository.GetByIdAsync(id);

            if(existing == null)
                return new MovieResponse("Movie Not Found");
            
            try
            {
                movieRepository.Remove(existing);
                await unitOfWork.CompleteAsync();

                return new MovieResponse(existing);
            }
            catch (Exception ex)
            {
                return new MovieResponse($"An error occurred while removing movie: {ex.Message}");
            }
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await movieRepository.GetAllAsyncWithForegin();
        }

        public async Task<MovieResponse> SaveAsync(Movie movie)
        {
            try
            {
                await movieRepository.Insert(movie);
                await unitOfWork.CompleteAsync();

                return new MovieResponse(movie);
            }
            catch (Exception ex)
            {
                return new MovieResponse($"An error occurred when saving movie: {ex.Message}");
            }
        }

        public async Task<MovieResponse> UpdateAsync(int id, Movie movie)
        {
            var existing = await movieRepository.GetByIdAsync(id);

            if(existing == null)
                return new MovieResponse("Movie Not Found");
            
            existing.Title = movie.Title;
            existing.Genre = movie.Genre;
            existing.ReleaseDate = movie.ReleaseDate;
            existing.Rating = movie.Rating;
            existing.DirectorId = movie.DirectorId;

            try
            {
                movieRepository.Update(existing);
                await unitOfWork.CompleteAsync();

                return new MovieResponse(existing);
            }
            catch (Exception ex)
            {
                return new MovieResponse($"An error occurred when updating movie: {ex.Message}");
            }
        }
        public async Task<List<Movie>> Search(SearchMovieResource resource)
        {
            if (resource == null)
                return null;
            var list = new List<Movie>();

            if(resource.Id != null)
            {
                var existing = await movieRepository.GetByIdAsync(resource.Id);
                list.Add(existing);
            }
            if(resource.Title != null)
            {
                var existing = await movieRepository.GetByTitleAsync(resource.Title);
                foreach(var exist in existing)
                {
                    list.Add(exist);
                }
            }
            if(resource.DirectorId != null)
            {
                var existing = await movieRepository.GetByDirectorIdAsync((int)resource.DirectorId);
                foreach(var exist in existing)
                {
                    list.Add(exist);
                }
            }
            return list;
        }
    }
}