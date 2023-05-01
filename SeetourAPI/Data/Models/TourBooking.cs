using System.ComponentModel.DataAnnotations.Schema;

namespace SeetourAPI.Data.Models
{
    public class TourBooking
    {
        [ForeignKey("Tour")]
        public int Id { get; set; }
        public virtual Tour? Tour { get; set; }
        public int BookingsCount { get; set; }
    }
}
