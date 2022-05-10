using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Response
{
    public class MovieResponse : BaseResponse
    {
        public Movie movie {get; set; }
        
        private MovieResponse(bool success, string message, Movie movie) : base(success, message)
        {
            this.movie = movie;
        }

        public MovieResponse(Movie movie): this(true, string.Empty, movie) { }

        public MovieResponse(string message) : this(false, message,null) { }
    }
}