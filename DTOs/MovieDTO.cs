namespace NewMovieReleaseAPI.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Description { get; set; }
    }
}
