using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.Repos
{
	public interface IBookedTourRepo
	{
		IEnumerable<BookedTour> GetAll();
		IEnumerable<BookedTour> GetAllLit();
	}
}
