using SeetourAPI.BL.ReviewManager;
using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;
using SeetourAPI.Services;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.BL.CustomerManager
{
	public class CustomerManager : ICustomerManager
	{
		private readonly ITourRepo _tourRepo;
		private readonly IReviewRepo _reviewRepo;
		private readonly IBookedTourRepo _bookedTourRepo;
		private readonly ToursHandler _tourHandler;
		private readonly ICustomerRepo customerRepo;

		public CustomerManager(IReviewRepo reviewManager, ITourRepo tourRepo, IBookedTourRepo bookedTourRepo,
			ToursHandler tourHandler, ICustomerRepo customerRepo)
		{
			_reviewRepo = reviewManager;
			_tourRepo = tourRepo;
			_bookedTourRepo = bookedTourRepo;
			_tourHandler = tourHandler;
            this.customerRepo = customerRepo;
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
	}
}
