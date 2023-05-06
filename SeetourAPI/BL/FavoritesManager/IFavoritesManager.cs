using SeetourAPI.DAL.DTO;

namespace SeetourAPI.BL.FavoritesManager
{
	public interface IFavoritesManager
	{
		ICollection<TourCardDto> GetTours(string userId, ToursFilterDto toursFilter);
		bool isFavorite(string customerId, string tourGuideId);
		public bool ToggleTourGuideFavorite(string customerId, string tourguideId, bool add);
	}
}
