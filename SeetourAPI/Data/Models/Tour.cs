﻿using SeetourAPI.Data.Enums;
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
        public decimal Price { get; set; }
        [DataType(DataType.Url)]
        [StringLength(512)]
        public string LocationFrom { get; set; } = string.Empty;
        [DataType(DataType.Url)]
        [StringLength(512)]
        public string LocationTo { get; set; } = string.Empty;
        public TourCategory Category { get; set; } = TourCategory.OTHER;
        public bool HasTransportation { get; set; }
        [FutureDateRange(0, dateBefore: "DateFrom")] // at most 0 days before after datefrom
        public DateTime LastDateToCancel { get; set; }
        [Range(1, 100)]
        public int Capacity { get; set; }
        [DataType(DataType.ImageUrl)]
        [StringLength(512)]
        public ICollection<string> Photos { get; set; } = new List<string>();
        public virtual ICollection<CustomerLikes> Likes { get; set; } = new HashSet<CustomerLikes>();
        public virtual ICollection<CustomerWishlist> Wishlist { get; set; } = new HashSet<CustomerWishlist>();
        public virtual ICollection<BookedTour> Bookings { get; set; } = new HashSet<BookedTour>();
        [NotMapped]
        public int BookingsCount { get => Bookings.Where(b => b.Status == BookedTourStatus.Booked).Count(); }
        public string TourGuideId { get; set; } = string.Empty;
        public virtual TourGuide? TourGuide { get; set; }
    }
}
