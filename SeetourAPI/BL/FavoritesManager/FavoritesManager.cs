using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.BL.FavoritesManager
{
	public class FavoritesManager: IFavoritesManager
	{
		private readonly IFavoritesRepo _favoritesRepo;

		public FavoritesManager(IFavoritesRepo favoritesRepo)
		{
			_favoritesRepo = favoritesRepo;
		}

		public bool isFavorite(string customerId, string tourGuideId)
		{
			var favorite = _favoritesRepo.GetFavorite(customerId, tourGuideId);
			if (favorite == null) return false;
			return true;
		}

		public bool ToggleTourGuideFavorite(string customerId, string tourguideId, bool add)
		{
			var favorite = _favoritesRepo.GetFavorite(customerId, tourguideId);

			if (add == (favorite != null))
			{
				return false;
			}

			if (favorite != null)
			{
				_favoritesRepo.RemoveTourguideFavorite(favorite);
			}
			else
			{
				_favoritesRepo.AddTourguideFavorite(customerId, tourguideId);
			}

			return _favoritesRepo.SaveChanges();
		}
	}
}
