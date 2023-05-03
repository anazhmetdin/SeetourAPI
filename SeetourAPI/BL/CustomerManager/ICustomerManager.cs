using SeetourAPI.Data.Models.Users;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Enums;

namespace SeetourAPI.BL.CustomerManager
{
	public interface ICustomerManager
	{
        public Customer GetCustomerById(string id);
		int GetBookedTourIdToReview(int tourId, string userId);
		ICollection<BookedTourDto> GetIsCompletedTours(string UserId, BookedTourStatus status);
	}
}
