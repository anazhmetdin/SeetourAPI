using System.ComponentModel.DataAnnotations;

namespace SeetourAPI.Data.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int BookedTourId { get; set; }
        public virtual BookedTour? BookedTour { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
        [StringLength(512, MinimumLength = 32)]
        public string Comment { get; set; } = string.Empty;
        public virtual ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
        public DateTime LastEditedAt { get; set; } = DateTime.UtcNow;
    }
}
