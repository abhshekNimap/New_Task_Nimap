namespace MovieDetailsAPI.Models
{
    public class MovieBooking
    {
        public int Id { get; set; }         
        public string UserId { get; set; }  
        public int MovieId { get; set; }    
        public DateTime BookingDate { get; set; }
    }
}
