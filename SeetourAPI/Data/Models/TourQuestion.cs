using SeetourAPI.Data.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace SeetourAPI.Data.Models
{
    public class TourQuestion
    {
        public int Id { get; set; }
        [StringLength(128, MinimumLength = 32)]
        public string Question { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;
        public virtual Customer? Customer { get; set; }
        public int TourId { get; set; }
        public virtual Tour? Tour { get; set; }
        public virtual TourAnswer? TourAnswer { get; set; }
        public int? TourAnswerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
