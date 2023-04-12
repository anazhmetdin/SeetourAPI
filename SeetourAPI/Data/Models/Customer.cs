using System.ComponentModel.DataAnnotations.Schema;

namespace SeetourAPI.Data.Models
{
    public class Customer
    {
        [ForeignKey("User")]
        public string Id { get; set; } = string.Empty;
        public virtual SeetourUser? User { get; set; }
        public virtual ICollection<CustomerLikes> Likes { get; set; } = new HashSet<CustomerLikes>();
        public virtual ICollection<CustomerWishlist> Wishlist { get; set; } = new HashSet<CustomerWishlist>();
    }
}
