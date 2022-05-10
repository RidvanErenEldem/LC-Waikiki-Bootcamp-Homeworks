using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resources
{
    public class SaveMovieResource
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(20)]
        public string Genre { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public sbyte? Rating { get; set; }
        [Required]
        public int DirectorId { get; set; }
    }
}