using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Response
{
    public class DirectorResponse : BaseResponse
    {
        public Director director {get; set; }

        private DirectorResponse(bool success, string message, Director director) : base (success, message)
        {
            this.director = director;
        }

        public DirectorResponse(Director director) : this (true, string.Empty, director){}

        public DirectorResponse(string message) : this (false, message,null) {}
    }
}