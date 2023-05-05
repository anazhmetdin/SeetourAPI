using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.Repos
{
	public interface IBookedTourRepo
	{
		IEnumerable<BookedTour> GetAll();
		IEnumerable<BookedTour> GetAllLit();
		BookedTour? GetByIdLite(int bookedTourId);
		bool SaveChanges();
		void UpdateBooking(BookedTour booking);
	}
}
