using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.Repos
{
	public interface IFavoritesRepo
	{
		bool SaveChanges();
		public void RemoveTourguideFavorite(CustomerFavoriteTourGuide favorite);
		public void AddTourguideFavorite(string customerId, string tourguideId);
		CustomerFavoriteTourGuide? GetFavorite(string customerId, string tourguideId);
	}
}
