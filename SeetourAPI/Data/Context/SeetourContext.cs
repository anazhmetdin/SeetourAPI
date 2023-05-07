using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using SeetourAPI.Data.Models.Photos;
using SeetourAPI.Data.Claims;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeetourAPI.Data.Context
{
    public class SeetourContext: IdentityDbContext<SeetourUser>
    {
        private readonly IWebHostEnvironment _env;
        private readonly PasswordHasher<SeetourUser> _passwordHasher;

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<TourGuide> TourGuides { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<TourQuestion> TourQuestions { get; set; }
        public DbSet<TourAnswer> TourAnswers { get; set; }
        public DbSet<BookedTour> BookedTours { get; set; }
        public DbSet<CustomerLikes> CustomerLikes { get; set; }
        public DbSet<CustomerWishlist> CustomerWishlists { get; set; }
        public DbSet<TourBookingPayment> payments { get; set; }
        public DbSet<Views> Views { get; set; }
        public DbSet<TourGuideRating> TourGuideRatings { get; set; }
        public DbSet<TourBooking> TourBookings { get; set; }
        public DbSet<TourPhoto> TourPhoto { get; set; }
        public DbSet<CustomerFavoriteTourGuide> CustomerFavoriteTourGuides { get; set; }
        public DbSet<EditRequest> EditRequests { get; set; }
        public DbSet<TrendingTour> TrendingTours { get; set; }

		public SeetourContext(DbContextOptions<SeetourContext> options, IWebHostEnvironment env)
        : base(options)
        {
            _env = env;
            _passwordHasher = new PasswordHasher<SeetourUser>();
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

                SeetourUser[] seetourUsers = GetUsers("jsons/seetourusers.json", builder);
                b.HasData(seetourUsers);
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

                Customer[] customers = GetData<Customer>("jsons/customers.json");
                b.HasData(customers);
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

                    b.Navigation(b => b.TourGuideRating)
                        .AutoInclude(true);

                    //b.Property(tg => tg.Status)
                    //    .HasConversion(new EnumToStringConverter<TourGuideStatus>());

                    TourGuide[] customers = GetData<TourGuide>("jsons/tourGuides.json");
                    b.HasData(customers);
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

                b.HasMany(t => t.Photos)
                    .WithOne(p => p.Tour)
                    .HasForeignKey(p => p.TourId);

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

                b.HasMany(t => t.Photos)
                    .WithOne(p => p.Tour)
                    .HasForeignKey(p => p.TourId);

                b.Navigation(t => t.TourBooking)
                    .AutoInclude(true);

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

                Tour[] customers = GetData<Tour>("jsons/tours.json");
                b.HasData(customers);
            });
            #endregion
            #region Likes
            builder.Entity<CustomerLikes>(b =>
            {
                b.HasIndex(l => l.CustomerId);

                CustomerLikes[] customers = GetData<CustomerLikes>("jsons/likes.json");
                b.HasData(customers);
            });
            #endregion
            #region Wishlist
            builder.Entity<CustomerWishlist>(b =>
            {
                b.HasIndex(wl => wl.CustomerId);

                CustomerWishlist[] customers = GetData<CustomerWishlist>("jsons/wishlists.json");
                b.HasData(customers);
            });
            #endregion
            #region Bookings
            builder.Entity<BookedTour>(b =>
            {
                b.HasOne(bt => bt.Review)
                    .WithOne(r => r.BookedTour)
                    .HasForeignKey<Review>(r => r.BookedTourId);

                b.HasOne(bt => bt.TourBookingPayment)
                    .WithOne(p => p.BookedTour)
                    .HasForeignKey<BookedTour>(bt => bt.TourBookingPaymentId);

                b.HasIndex(b => b.CustomerId);
                b.HasIndex(b => b.TourId);
                b.HasIndex(b => b.Status);
                b.HasIndex(b => b.ReviewId);

                //b.Property(bt => bt.Status)
                //    .HasConversion(new EnumToStringConverter<BookedTourStatus>());

                BookedTour[] customers = GetData<BookedTour>("jsons/bookings.json");
                b.HasData(customers);
            });
            #endregion
            #region Questions
            builder.Entity<TourQuestion>(b =>
            {
                b.HasOne(q => q.TourAnswer)
                    .WithOne(a => a.TourQuestion)
                    .HasForeignKey<TourQuestion>(q => q.TourAnswerId);

                TourQuestion[] customers = GetData<TourQuestion>("jsons/questions.json");
                b.HasData(customers);
            });
            #endregion
            #region Answers
            builder.Entity<TourAnswer>(b =>
            {
                b.HasOne(q => q.TourQuestion)
                    .WithOne(a => a.TourAnswer)
                    .HasForeignKey<TourAnswer>(q => q.TourQuestionId);

                TourAnswer[] customers = GetData<TourAnswer>("jsons/answers.json");
                b.HasData(customers);
            });
            #endregion
            #region Reviews
            builder.Entity<Review>(b =>
            {
                b.HasMany(r => r.Photos);

                b.HasMany(t => t.Photos)
                    .WithOne(p => p.Review)
                    .HasForeignKey(p => p.ReviewId);

                b.HasIndex(t => t.BookedTourId);

                Review[] customers = GetData<Review>("jsons/reviews.json");
                b.HasData(customers);
            });
            #endregion
            #region Photos
            builder.Entity<Photo>(b =>
            {
                Photo[] customers = GetData<Photo>("jsons/photos.json");
                b.HasData(customers);
            });
            #endregion
            #region TourPhotos
            builder.Entity<TourPhoto>(b =>
            {
                b.HasOne(p => p.Photo);

                b.Navigation(b => b.Photo)
                    .AutoInclude(true);

                TourPhoto[] customers = GetData<TourPhoto>("jsons/tourphotos.json");
                b.HasData(customers);
            });
            #endregion
            #region ReviewPhoto
            builder.Entity<ReviewPhoto>(b =>
            {
                b.HasOne(p => p.Photo);

                b.Navigation(b => b.Photo)
                    .AutoInclude(true);

                ReviewPhoto[] customers = GetData<ReviewPhoto>("jsons/reviewphotos.json");
                b.HasData(customers);
            });
            #endregion
            #region Payments
            builder.Entity<TourBookingPayment>(b =>
            {
                b.HasOne(p => p.BookedTour)
                    .WithOne(bt => bt.TourBookingPayment)
                    .HasForeignKey<BookedTour>(p => p.TourBookingPaymentId);

                TourBookingPayment[] customers = GetData<TourBookingPayment>("jsons/payments.json");
                b.HasData(customers);
            });
            #endregion
            #region EditRequests
            builder.Entity<EditRequest>(b =>
            {
                b.HasOne(p => p.Tour)
                    .WithMany(bt => bt.EditRequests)
                    .HasForeignKey(bt => bt.TourId);

                EditRequest[] customers = GetData<EditRequest>("jsons/editrequests.json");
                b.HasData(customers);
            });
            #endregion

            #region TGRatings
            builder.Entity<TourGuideRating>(b =>
            {
                b.HasKey(tg => tg.Id);

                b.HasOne(p => p.TourGuide)
                    .WithOne(bt => bt.TourGuideRating)
                    .HasForeignKey<TourGuideRating>(bt => bt.Id);
            });
            #endregion
            #region TourBookings
            builder.Entity<TourBooking>(b =>
            {
                b.HasKey(b => b.Id);
                b.HasOne(b => b.Tour)
                    .WithOne(b => b.TourBooking)
                    .HasForeignKey<TourBooking>(bt => bt.Id);
            });
            #endregion
            #region CustomerFavoriteTourGuides
            builder.Entity<CustomerFavoriteTourGuide>(b =>
			{
				b.HasOne(c => c.TourGuide)
					.WithMany(c => c.Favorites)
					.HasForeignKey(c => c.TourGuideId)
                    .OnDelete(DeleteBehavior.Restrict);

				b.HasOne(c => c.Customer)
					.WithMany(c => c.Favorites)
					.HasForeignKey(c => c.CustomerId)
					.OnDelete(DeleteBehavior.Restrict);
			});
			#endregion
		}

		private T[] GetData<T> (string jsonfile)
        {
            // Get the content root path of the application
            string contentRootPath = _env.ContentRootPath;

            // Build the path to the people.json file
            string filePath = Path.Combine(contentRootPath, jsonfile);

            // Read the contents of the JSON file into a string
            string json = File.ReadAllText(filePath);

            // Deserialize the JSON string into an array of Person objects using the JsonSerializer class
            T[]? TList = JsonSerializer.Deserialize<T[]>(json);

            return TList ?? Array.Empty<T>();
        }

        private SeetourUser[] GetUsers(string jsonfile,
            ModelBuilder builder)
        {

            // Get the content root path of the application
            string contentRootPath = _env.ContentRootPath;

            // Build the path to the people.json file
            string filePath = Path.Combine(contentRootPath, jsonfile);

            // Read the contents of the JSON file into a string
            string json = File.ReadAllText(filePath);

            // Deserialize the JSON string into an array of Person objects using the JsonSerializer class
            //JsonElement[] TList = JsonSerializer.Deserialize<JsonElement[]>(json) ?? Array.Empty<JsonElement>();
            // Deserialize the JSON string into an array of Person objects using the JsonSerializer class
            SeetourUser[]? seetourUsers = JsonSerializer.Deserialize<SeetourUser[]>(json) ?? Array.Empty<SeetourUser>();
            
            int claimsIndex = 1;
            
            for (int i = 0; i < seetourUsers.Length; i++)
            {
                SeetourUser seetourUser = seetourUsers[i];
                //JsonElement user = TList[i];

                //// Hash the user's password
                //string hashedPassword = _passwordHasher.HashPassword(seetourUser, user.GetProperty("Password").GetString()!);

                //// Set the user's password hash
                //seetourUser.PasswordHash = hashedPassword;

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,seetourUser.Id),
                    new Claim(ClaimTypes.Role,seetourUser.SecurityLevel),
                    new Claim(ClaimType.Status, "Allowed")
                };

                foreach (var claim in claims)
                {
                    builder.Entity<IdentityUserClaim<string>>().HasData(
                        new IdentityUserClaim<string>
                        {
                            Id = claimsIndex,
                            UserId = seetourUser.Id,
                            ClaimType = claim.Type,
                            ClaimValue = claim.Value
                        }
                    );
                    claimsIndex++;
                }
            }

            return seetourUsers;
        }
    }
}
