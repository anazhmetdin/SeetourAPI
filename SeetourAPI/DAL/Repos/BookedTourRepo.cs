using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.Repos
{
	public class BookedTourRepo : IBookedTourRepo
	{
		private readonly SeetourContext _Context;

		public BookedTourRepo(SeetourContext context)
		{
			_Context = context;
		}

		public IEnumerable<BookedTour> GetAll()
		{
			return _Context.BookedTours
				.Include(b => b.Tour)
				.ThenInclude(b => b!.Wishlist)
				.Include(b => b.Tour)
				.ThenInclude(b => b!.Likes)
				.Include(b => b.Tour)
				.ThenInclude(b => b!.Photos);
		}

		public IEnumerable<BookedTour> GetAllLit()
		{
			return _Context.BookedTours;
		}

		public BookedTour? GetByIdLite(int bookedTourId)
		{
			return _Context.BookedTours.Find(bookedTourId);
		}

		public bool SaveChanges()
		{
			return _Context.SaveChanges() > 0;
		}

		public void UpdateBooking(BookedTour booking)
		{
			_Context.BookedTours.Entry(booking).State = EntityState.Modified;
		}
	}
}
