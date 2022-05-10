using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models 
{ 
    public class Movie 
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte? Rating { get; set; }
        [Display(Name = "Name")]
        public virtual int DirectorId { get; set; }
        [ForeignKey("DirectorId")]
        public virtual Director Directors { get; set; }
    } 
}