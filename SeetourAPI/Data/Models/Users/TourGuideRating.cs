using System.ComponentModel.DataAnnotations.Schema;

namespace SeetourAPI.Data.Models.Users
{
    public class TourGuideRating
    {
        [ForeignKey("TourGuide")]
        public string Id { get; set; } = string.Empty;
        public virtual TourGuide? TourGuide { get; set; }
        public int Rating { get; set; }
        public int RatingCount { get; set; }
    }
}
