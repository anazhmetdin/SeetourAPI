using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.Data.Models
{
    public class BookedTour
    {
        public int Id { get; set; }
        public virtual Customer? Customer { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public virtual Tour? Tour { get; set; }
        public int TourId { get; set; }
        public BookedTourStatus Status { get; set; }
        public int? ReviewId { get; set; }
        public virtual Review? Review { get; set; }
        public int Seats { get; set; }
        public int TourBookingPaymentId { get; set; }
        public virtual TourBookingPayment? TourBookingPayment { get; set; }
        public DateTime LastEditedAt { get; set; } = DateTime.UtcNow;
    }
}
