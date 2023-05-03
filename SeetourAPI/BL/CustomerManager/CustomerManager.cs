using SeetourAPI.BL.ReviewManager;
using SeetourAPI.BL.TourGuideManager;
using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;
using SeetourAPI.Services;

namespace SeetourAPI.BL.CustomerManager
{
	public class CustomerManager : ICustomerManager
	{
		private readonly ITourRepo _tourRepo;
		private readonly IReviewRepo _reviewRepo;
		private readonly IBookedTourRepo _bookedTourRepo;
		private readonly ToursHandler _tourHandler;
		private readonly ILogger<ICustomerManager> _logger;

		public CustomerManager(IReviewRepo reviewManager, ITourRepo tourRepo, IBookedTourRepo bookedTourRepo,
			ToursHandler tourHandler, ILogger<ICustomerManager> logger)
		{
			_reviewRepo = reviewManager;
			_tourRepo = tourRepo;
			_bookedTourRepo = bookedTourRepo;
			_tourHandler = tourHandler;
			_logger = logger;
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
						tourCard: _tourHandler.GetTourCardDto(t.Tour!, UserId)
					)
				).ToList();
		}
	}
}
