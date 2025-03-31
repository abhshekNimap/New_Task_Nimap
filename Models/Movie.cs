using System.ComponentModel.DataAnnotations;

namespace NewMovieReleaseAPI.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }

        [Required]
        public string? Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
