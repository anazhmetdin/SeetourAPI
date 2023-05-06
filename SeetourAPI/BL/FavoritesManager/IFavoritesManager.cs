namespace SeetourAPI.BL.FavoritesManager
{
	public interface IFavoritesManager
	{
		bool isFavorite(string customerId, string tourGuideId);
		public bool ToggleTourGuideFavorite(string customerId, string tourguideId, bool add);
	}
}
