using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeetourAPI.Data.Models
{
    public class TourBookingPayment
    {
        public int Id { get; set; }
        public virtual BookedTour? BookedTour { get; set; }
        public int BookedTourId { get; set; }
        public decimal Total { get; set; }
        
        [StringLength(3)]
        public string Currency { get; set; } = string.Empty;
        
        [StringLength(20)]
        public string PaymentMethod { get; set; } = string.Empty;

        // Additional properties for Visa card information
        [CreditCard]
        [Column(TypeName = "varchar(19)")]
        public string CardNumber { get; set; } = string.Empty;

        [RegularExpression(@"^(0[1-9]|1[0-2])\/([0-9]{2})$")]
        [Column(TypeName = "varchar(5)")]
        public string ExpirationDate { get; set; } = string.Empty;
        
        [RegularExpression(@"^[0-9]{3}$")]
        [Column(TypeName = "varchar(3)")]
        public string Cvc { get; set; } = string.Empty;
        
        [StringLength(50)]
        public string CardholderName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
