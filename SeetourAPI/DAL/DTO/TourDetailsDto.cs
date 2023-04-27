using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.DTO
{
    public class TourDetailsDto
    {
       public ICollection<CustomerLikes> Likes { get; set; } = new HashSet<CustomerLikes>();
        public ICollection<CustomerWishlist> Wishlist { get; set; } = new HashSet<CustomerWishlist>();
        public ICollection<BookedTour> Bookings { get; set; } = new HashSet<BookedTour>();
    }
}
