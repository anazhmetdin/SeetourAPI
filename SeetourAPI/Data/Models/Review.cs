using System.ComponentModel.DataAnnotations;

namespace SeetourAPI.Data.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int BoodedTourId { get; set; }
        public virtual BookedTour BookedTour { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
        [StringLength(512, MinimumLength = 32)]
        public string Comment { get; set; } = string.Empty;
        [DataType(DataType.ImageUrl)]
        [StringLength(512)]
        public ICollection<string> Photos { get; set; } = new List<string>();
    }
}
