using SeetourAPI.Data.Models.Users;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;

namespace SeetourAPI.BL.CustomerManager
{
	public interface ICustomerManager
	{
        public Customer GetCustomerById(string id);
		int GetBookedTourIdToReview(int tourId, string userId);
		ICollection<BookedTourDto> GetIsCompletedTours(string UserId, BookedTourStatus status);
		bool PostReview(string userId, ReviewDto review);
		bool ToggleTourLike(string userId, CustomerTourSaveDto tourLike);
		bool ToggleTourWishlist(string userId, CustomerTourSaveDto tourWish);
		CustomerWishlist? isTourWished(string userId, int tourId);
		CustomerLikes? isTourLiked(string userId, int tourId);
	}
}
