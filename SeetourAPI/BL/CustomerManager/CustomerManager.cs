using SeetourAPI.BL.ReviewManager;
using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;
using SeetourAPI.Services;
using SeetourAPI.Data.Models.Users;
using SeetourAPI.Data.Models.Photos;

namespace SeetourAPI.BL.CustomerManager
{
	public class CustomerManager : ICustomerManager
	{
		private readonly ITourRepo _tourRepo;
		private readonly IReviewRepo _reviewRepo;
		private readonly IBookedTourRepo _bookedTourRepo;
		private readonly ToursHandler _tourHandler;
		private readonly ICustomerRepo customerRepo;
		private readonly IAzureBlobStorageService _azureBlobStorageService;

		public CustomerManager(IReviewRepo reviewManager, ITourRepo tourRepo, IBookedTourRepo bookedTourRepo,
			ToursHandler tourHandler, ICustomerRepo customerRepo, IAzureBlobStorageService azureBlobStorageService)
		{
			_reviewRepo = reviewManager;
			_tourRepo = tourRepo;
			_bookedTourRepo = bookedTourRepo;
			_tourHandler = tourHandler;
			this.customerRepo = customerRepo;
			_azureBlobStorageService = azureBlobStorageService;
		}

		public int GetBookedTourIdToReview(int tourId, string userId)
		{
			var bookings = _bookedTourRepo.GetAllLit();

			bookings = bookings.Where(b => b.CustomerId == userId)
				.Where(b => b.Status == BookedTourStatus.Completed)
				.Where(b => b.TourId == tourId);

			var BookingToReview = bookings.ToList()
				.FirstOrDefault(b => _reviewRepo.GetBookingReviewId(b.Id) == 0);

			return BookingToReview?.Id ?? 0;
		}

		public ICollection<BookedTourDto> GetIsCompletedTours(string UserId, BookedTourStatus status)
		{
			var bookings = _bookedTourRepo.GetAllLit()
				.Where(t => t.CustomerId == UserId)
				.Where(t => t.Status == status);

			if (bookings == null) return Array.Empty<BookedTourDto>();

			bookings.ToList().ForEach(booking =>
			{
				booking.Tour = _tourRepo.GetTourByIdLiteIncluded(booking.TourId);
				booking.ReviewId = _reviewRepo.GetBookingReviewId(booking.Id);
			});

			if (status == BookedTourStatus.Booked)
			{
				bookings = bookings.OrderBy(b => b.Tour!.DateFrom);
			}
			else
			{
				bookings = bookings.OrderByDescending(b => b.Tour!.DateFrom);
			}

			return GetBookedTourDtos(bookings, UserId);
		}

		private ICollection<BookedTourDto> GetBookedTourDtos(IEnumerable<BookedTour> Bookings, string UserId)
		{
			var tours = Bookings.Select(t => t.Tour!);
			var time = DateTime.Now;

			return Bookings.Select(t => new BookedTourDto(
						id: t.Id,
						createdAt: t.LastEditedAt.ToString(),
						seats: t.Seats,
						canCancel: t.Tour!.CanCancel ? 1 : 0,
						canReview: t.ReviewId == 0 ? 1 : 0,
						tourCard: _tourHandler.GetTourCardDto(t.Tour!, UserId)
					)
				).ToList();
		}

        public Customer GetCustomerById(string id)
        {
            var cust = customerRepo.GetCustomerById(id);
            return cust;
        }

		public bool PostReview(string userId, ICollection<IFormFile> files, ReviewDto review)
		{
			BookedTour? booking = _bookedTourRepo.GetByIdLite(review.bookedTourId);

			if (booking == null || booking.CustomerId != userId) { return false; }

			ICollection<string> urls;
			try
			{
				urls = _azureBlobStorageService.UploadBlobAsyncImgs(files).Result;
			}
			catch { return false; }

			Review newReview = new Review()
			{
				Rating = review.rating,
				Comment = review.reviewBody,
				BookedTourId = review.bookedTourId,
				Photos = urls.Select(url =>

					new ReviewPhoto()
					{
						Photo = new Photo()
						{
							Url = url
						}
					}
				).ToList()
			};

			_reviewRepo.AddReviewPlain(newReview);

			return _reviewRepo.SaveChanges();
		}

		public bool ToggleTourLike(string userId, CustomerTourSaveDto tourLike)
		{
			var TourLikedBefore = isTourLiked(userId, tourLike.tourId);

			if ((tourLike.isAdded == 1) == (TourLikedBefore != null))
			{
				return false;
			}

			if (TourLikedBefore != null)
			{
				_tourRepo.RemoveTourLike(TourLikedBefore);
			}
			else
			{
				_tourRepo.AddTourLike(userId, tourLike.tourId);
			}

			return _tourRepo.SaveChanges();
		}

		public bool ToggleTourWishlist(string userId, CustomerTourSaveDto tourWish)
		{
			var TourWishedBefore = isTourWished(userId, tourWish.tourId);

			if ((tourWish.isAdded == 1) == (TourWishedBefore != null))
			{
				return false;
			}

			if (TourWishedBefore != null)
			{
				_tourRepo.RemoveTourWish(TourWishedBefore);
			}
			else
			{
				_tourRepo.AddTourWish(userId, tourWish.tourId);
			}

			return _tourRepo.SaveChanges();
		}

		public CustomerWishlist? isTourWished(string userId, int tourId)
		{
			var tourWishlists = _tourRepo.GetTourWishlist(tourId);
			if (tourWishlists == null) return null;

			return tourWishlists.FirstOrDefault(l => l.CustomerId == userId);
		}

		public CustomerLikes? isTourLiked(string userId, int tourId)
		{
			var tourLikes = _tourRepo.GetTourLikes(tourId);
			if (tourLikes == null) return null;

			return tourLikes.FirstOrDefault(l => l.CustomerId == userId);
		}
	}
}
