using SeetourAPI.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeetourAPI.Data.Models.Users
{
    public class TourGuide
    {
        [ForeignKey("User")]
        public string Id { get; set; } = string.Empty;
        public virtual SeetourUser? User { get; set; }
        public virtual ICollection<Tour> Tours { get; set; } = new HashSet<Tour>();
        [Required(ErrorMessage = "Recipient bank name and address is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Recipient bank name and address must be between 5 and 100 characters")]
        public string RecipientBankNameAndAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Recipient account number or IBAN is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Recipient account number or IBAN must be between 5 and 50 characters")]
        public string RecipientAccountNumberOrIBAN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Recipient bank SWIFT code is required")]
        [StringLength(11, MinimumLength = 8, ErrorMessage = "Recipient bank SWIFT code must be between 8 and 11 characters")]
        public string RecipientBankSwiftCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Recipient name and address is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Recipient name and address must be between 5 and 100 characters")]
        public string RecipientNameAndAddress { get; set; } = string.Empty;
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Tax registration number must be between 5 and 20 characters")]
        public string TaxRegistrationNumber { get; set; } = string.Empty;
        [DataType(DataType.ImageUrl)]
        [StringLength(512)]
        public string IDCardPhoto { get; set; } = string.Empty;
        // TODO: add it to claims for authorization
        public TourGuideStatus Status { get; set; }

        [NotMapped]
        public double Rating { get => Tours.SelectMany(t => t.Reviews.Select(r=>r.Rating)).DefaultIfEmpty(0).Average(); }
        [NotMapped]
        public int RatingCount { get => Tours.Sum(t => t.Reviews.Count); }
    }
}
