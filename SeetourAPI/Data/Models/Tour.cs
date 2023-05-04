using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models.Photos;
using SeetourAPI.Data.Models.Users;
using SeetourAPI.Data.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeetourAPI.Data.Models
{
    public class Tour
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 16)]
        public string Title { get; set; } = string.Empty;
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;


        [FutureDateRange(1)] // 1 day in the future
        public DateTime DateFrom { get; set; }
        [FutureDateRange(0, "DateFrom")] // at least 0 days after DateFrom
        public DateTime DateTo { get; set; }


        [Range(0, (double)decimal.MaxValue)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Url)]
        [StringLength(512)]
        public string LocationFromUrl { get; set; } = string.Empty;
        [StringLength(128, MinimumLength = 4)]
        public string LocationFrom { get; set; } = string.Empty;
        [DataType(DataType.Url)]
        [StringLength(512)]
        public string LocationToUrl { get; set; } = string.Empty;
        [StringLength(128, MinimumLength = 4)]
        public string LocationTo { get; set; } = string.Empty;
        public TourCategory Category { get; set; } = TourCategory.Other;
        public bool HasTransportation { get; set; }
        [FutureDateRange(0, dateBefore: "DateFrom")] // at most 0 days before after datefrom
        public DateTime LastDateToCancel { get; set; }
        [Range(1, 100)]
        public int Capacity { get; set; }
        // TODO: use all photos in thumbnail gallery
        public virtual ICollection<TourPhoto>? Photos { get; set; } = new HashSet<TourPhoto>();
        public virtual ICollection<CustomerLikes>? Likes { get; set; } = new HashSet<CustomerLikes>();
        public virtual ICollection<CustomerWishlist>? Wishlist { get; set; } = new HashSet<CustomerWishlist>();
        public virtual ICollection<BookedTour>? Bookings { get; set; } = new HashSet<BookedTour>();
        [NotMapped]
        public ICollection<BookedTour> PaidBookings { get => Bookings.Where(b => b.Status == BookedTourStatus.Booked || b.Status == BookedTourStatus.Completed).ToList(); }
        [NotMapped]
        public double Rating { get => Reviews.DefaultIfEmpty<Review>(new Review()).Average(a => a.Rating); }
        [NotMapped]
        public int RatingCount { get => Reviews.Count; }
        [NotMapped]
        public ICollection<Review> Reviews { get => PaidBookings.Where(a => a.Review != null).Select(a=>a.Review!).ToList(); }
        [NotMapped]
        public int BookingsCount { get => TourBooking?.BookingsCount??0; }
        public string TourGuideId { get; set; } = string.Empty;
        public virtual TourGuide? TourGuide { get; set; }
        public TourPostingStatus TourPostingStatus { get; set; }
        public virtual ICollection<EditRequest>? EditRequests { get; set; } = new HashSet<EditRequest>();
        public virtual ICollection<TourQuestion>? Questions { get; set; } = new HashSet<TourQuestion>();
        [NotMapped]
        public bool IsCompleted { get => TourBooking?.IsCompleted??DateFrom<DateTime.Now; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;

        public virtual TourBooking? TourBooking { get; set; }
        [NotMapped]
        public bool CanCancel { get => DateTime.Now < LastDateToCancel; }
    }
}
