using System;
using System.ComponentModel.DataAnnotations;

namespace FilmManagement.Core.Models.Movie.Request
{
    public class FilterMovieRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PageIndex { get; set; }
        [Required]
        [Range(1, 100)]
        public int PageSize { get; set; }
    }
}
