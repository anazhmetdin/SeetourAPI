using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.Data.Context
{
    public class SeetourContext: IdentityDbContext<SeetourUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TourGuide> TourGuides { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<TourQuestion> TourQuestions { get; set; }
        public DbSet<BookedTour> BookedTours { get; set; }
        public DbSet<CustomerLikes> CustomerLikes { get; set; }
        public DbSet<CustomerWishlist> CustomerWishlists { get; set; }

        public SeetourContext(DbContextOptions<SeetourContext> options)
        : base(options)
        {

        }

        // TODO: add data seeding, onmodelcreating
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region User
            builder.Entity<SeetourUser>(b =>
            {
                b.HasOne(u => u.TourGuide)
                    .WithOne(tg => tg.User)
                    .HasForeignKey<TourGuide>(t => t.Id);

                b.HasOne(u => u.Customer)
                    .WithOne(c => c.User)
                    .HasForeignKey<Customer>(c => c.Id);
            });
            #endregion
            #region Customer
            builder.Entity<Customer>(b =>
            {
                b.HasKey(x => x.Id);

                b.HasMany(c => c.Wishlist)
                    .WithOne(w => w.Customer)
                    .HasForeignKey(c => c.CustomerId);

                b.HasMany(c => c.Likes)
                    .WithOne(w => w.Customer)
                    .HasForeignKey(c => c.CustomerId);

                b.HasMany(c => c.BookedTours)
                    .WithOne(w => w.Customer)
                    .HasForeignKey(c => c.CustomerId);
            });
            #endregion
            #region TourGuide
            builder.Entity<TourGuide>(b =>
            {
                b.HasKey(x => x.Id);

                b.HasMany(tg => tg.Tours)
                    .WithOne(b => b.TourGuide)
                    .HasForeignKey(b => b.TourGuideId)
                    .OnDelete(DeleteBehavior.Restrict);

                //b.Property(tg => tg.Status)
                //    .HasConversion(new EnumToStringConverter<TourGuideStatus>());
            });
            #endregion
            #region Tour
            builder.Entity<Tour>(b =>
            {
                b.HasMany(t => t.Likes)
                    .WithOne(l => l.Tour)
                    .HasForeignKey(l => l.TourId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasMany(t => t.Wishlist)
                    .WithOne(l => l.Tour)
                    .HasForeignKey(l => l.TourId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasMany(t => t.Photos);

                b.HasMany(t => t.Bookings)
                    .WithOne(b => b.Tour)
                    .HasForeignKey(b => b.TourId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasMany(t => t.Questions)
                    .WithOne(b => b.Tour)
                    .HasForeignKey(b => b.TourId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasMany(t => t.EditRequests)
                    .WithOne(l => l.Tour)
                    .HasForeignKey(l => l.TourId);

                b.HasMany(t => t.Photos);

                b.HasIndex(t => t.TourGuideId);
                b.HasIndex(t => t.Category);
                b.HasIndex(t => t.DateFrom);
                b.HasIndex(t => t.DateTo);
                b.HasIndex(t => t.HasTransportation);
                b.HasIndex(t => t.LocationFrom);
                b.HasIndex(t => t.LocationTo);

                //b.Property(t => t.TourPostingStatus)
                //    .HasConversion(new EnumToStringConverter<TourPostingStatus>());

                //b.Property(t => t.Category)
                //    .HasConversion(new EnumToStringConverter<TourCategory>());
            });
            #endregion
            #region Likes
            builder.Entity<CustomerLikes>(b =>
            {
                b.HasIndex(l => l.CustomerId);
            });
            #endregion
            #region Wishlist
            builder.Entity<CustomerWishlist>(b =>
            {
                b.HasIndex(wl => wl.CustomerId);
            });
            #endregion
            #region Bookings
            builder.Entity<BookedTour>(b =>
            {
                b.HasOne(bt => bt.Review)
                    .WithOne(r => r.BookedTour)
                    .HasForeignKey<Review>(r => r.BoodedTourId);

                b.HasOne(bt => bt.TourBookingPayment)
                    .WithOne(p => p.BookedTour)
                    .HasForeignKey<BookedTour>(bt => bt.TourBookingPaymentId);

                //b.Property(bt => bt.Status)
                //    .HasConversion(new EnumToStringConverter<BookedTourStatus>());
            });
            #endregion
            #region Questions
            builder.Entity<TourQuestion>(b =>
            {
                b.HasOne(q => q.TourAnswer)
                    .WithOne(a => a.TourQuestion)
                    .HasForeignKey<TourQuestion>(q => q.TourAnswerId);
            });
            #endregion
            #region Reviews
            builder.Entity<Review>(b =>
            {
                b.HasMany(r => r.Photos);
            });
            #endregion
        }
    }
}
