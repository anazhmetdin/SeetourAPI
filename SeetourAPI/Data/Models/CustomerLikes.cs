using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.Data.Models
{
    public class CustomerLikes
    {
        public int Id { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public virtual Customer? Customer { get; set; }
        public int TourId { get; set; }
        public virtual Tour? Tour { get; set; }
    }
}
