using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.DTO
{
    public class TourCardDto
    {
        public string Url { get; set; }=string.Empty;
        public string LocationTo { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Likes { get; set; }
        public int Bookings { get; set; }
        public virtual TourGuide? TourGuide { get; set; }
    }
}
