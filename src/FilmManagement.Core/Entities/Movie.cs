using FilmManagement.Core.SharedKernel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmManagement.Core.Entities
{
    public class Movie : GuidEntity
    {
        [StringLength(20)]
        public string Code { get; set; }
        [StringLength(500)]
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<InteractMovie> InteractMovies { get; set; }
    }
}
