using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Enums;

namespace SeetourAPI.BL.CustomerManager
{
	public interface ICustomerManager
	{
		ICollection<BookedTourDto> GetIsCompletedTours(string UserId, BookedTourStatus status);
	}
}
