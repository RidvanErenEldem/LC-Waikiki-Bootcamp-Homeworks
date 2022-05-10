using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resources
{
    public class SaveDirectorResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}