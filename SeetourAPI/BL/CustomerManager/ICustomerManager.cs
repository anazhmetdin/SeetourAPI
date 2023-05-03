using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Enums;

namespace SeetourAPI.BL.CustomerManager
{
	public interface ICustomerManager
	{
		int GetBookedTourIdToReview(int tourId, string userId);
		ICollection<BookedTourDto> GetIsCompletedTours(string UserId, BookedTourStatus status);
	}
}
