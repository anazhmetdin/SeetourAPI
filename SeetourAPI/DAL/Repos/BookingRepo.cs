using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models.Users;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.Repos
{
	public class BookingRepo : IBookingRepo
	{
		public SeetourContext _Context { get; }

		public BookingRepo(SeetourContext context)
		{
			_Context = context;
		}

		public async Task<bool> TryUpdateAll()
		{
			try
			{
				var time = DateTime.UtcNow;

				//completed tours
				var completed = _Context.TourBookings
					.Include(b => b.Tour)
					.Where(b => !b.Tour!.TourBooking!.IsCompleted)
					.Where(b => b.Tour!.DateFrom < time);

				var bookings = _Context.BookedTours
					.Where(b => completed.Any(t => t.Id == b.TourId));

				//delete completed cart
				var cart = bookings.Where(b => b.Status == BookedTourStatus.Cart);
				_Context.BookedTours.RemoveRange(cart);

				//change completed booked tours status
				await bookings.Where(b => b.Status == BookedTourStatus.Booked)
					.ForEachAsync(b => b.Status = BookedTourStatus.Completed);

				//change tour status
				await completed.ForEachAsync(t => t.IsCompleted = true);

				_Context.SaveChanges();

				return true;
			}
			catch (Exception ex) { 
				return false;
			}
		}
	}
}
