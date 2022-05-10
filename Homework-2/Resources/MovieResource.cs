using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resources
{
    public class MovieResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public sbyte Rating { get; set; }
        public int DirectorId { get; set; }
    }
}