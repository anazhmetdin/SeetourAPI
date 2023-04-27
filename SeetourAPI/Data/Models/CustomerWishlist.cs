using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.Data.Models
{
    public class CustomerWishlist
    {
        public int Id { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public virtual Customer? Customer { get; set; }
        public int TourId { get; set; }
        public virtual Tour? Tour { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
