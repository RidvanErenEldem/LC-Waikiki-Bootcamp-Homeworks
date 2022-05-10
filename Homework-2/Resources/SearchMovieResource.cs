using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resources
{
    public class SearchMovieResource
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public int? DirectorId { get; set; }
    }
}