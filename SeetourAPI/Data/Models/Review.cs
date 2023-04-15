using System.ComponentModel.DataAnnotations;
using SeetourAPI.Data.Models.Photos;

namespace SeetourAPI.Data.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int BoodedTourId { get; set; }
        public virtual BookedTour? BookedTour { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
        [StringLength(512, MinimumLength = 32)]
        public string Comment { get; set; } = string.Empty;
        public virtual ICollection<ReviewPhoto> Photos { get; set; } = new HashSet<ReviewPhoto>();
        public DateTime LastEditedAt { get; set; } = DateTime.UtcNow;
    }
}
