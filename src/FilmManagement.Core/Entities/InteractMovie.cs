using FilmManagement.Core.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmManagement.Core.Entities
{
    [Table("InteractMovie")]
    public class InteractMovie : GuidEntity
    {
        [ForeignKey("MovieId")]
        public string MovieId { get; set; }
        public string UserId { get; set; }
        public bool? IsLike { get; set; }
        public Movie Movie { get; set; }
    }
}
