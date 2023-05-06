using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Enums;

namespace SeetourAPI.BL.BookingManager
{
	public class BookingManager : IBookingManager
	{
		private readonly ITourRepo _tourRepo;
		private readonly IReviewRepo _reviewRepo;
		private readonly IBookedTourRepo _bookedTourRepo;
		private readonly ICustomerRepo _customerRepo;

		public BookingManager(IReviewRepo reviewManager, ITourRepo tourRepo,
			IBookedTourRepo bookedTourRepo, ICustomerRepo customerRepo)
		{
			_reviewRepo = reviewManager;
			_tourRepo = tourRepo;
			_bookedTourRepo = bookedTourRepo;
			_customerRepo = customerRepo;
		}

		public bool CancelBooking(string userId, int bookingId)
		{
			var booking = _bookedTourRepo.GetByIdLite(bookingId);
			if (booking == null || booking.CustomerId != userId || booking.Status == BookedTourStatus.Cancelled)
			{
				return false;
			}

			var tour = _tourRepo.GetTourByIdLite(booking.TourId);
			if (tour == null || (booking.Status == BookedTourStatus.Booked && !tour.CanCancel)) return false;

			booking.Status = BookedTourStatus.Cancelled;

			_bookedTourRepo.UpdateBooking(booking);

			return _bookedTourRepo.SaveChanges();
		}
	}
}
