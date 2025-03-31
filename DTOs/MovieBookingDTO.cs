namespace MovieDetailsAPI.DTOs
{
    public class MovieBookingDTO
    {
        public int BookingId { get; set; }  
        public string FullName { get; set; } 
        public string Email { get; set; }    
        public int MovieId { get; set; }     
        public string MovieTitle { get; set; } 
        public string Genre { get; set; }    
        public DateTime BookingDate { get; set; }
    }
}
