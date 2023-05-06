using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models.Users;
using SeetourAPI.Services;
using System.Reflection.Metadata;

namespace SeetourAPI.BL.FavoritesManager
{
	public class FavoritesManager: IFavoritesManager
	{
		private readonly IFavoritesRepo _favoritesRepo;
		private readonly ITourRepo _tourRepo;
		private readonly ToursHandler _handler;

		public FavoritesManager(IFavoritesRepo favoritesRepo, ITourRepo tourRepo, ToursHandler handler)
		{
			_favoritesRepo = favoritesRepo;
			_tourRepo = tourRepo;
			_handler = handler;
		}

		public ICollection<TourCardDto> GetTours(string userId, ToursFilterDto toursFilter)
		{
			var favorites = _favoritesRepo.GetFavoritesTours(userId);

			var tours = favorites
				.SelectMany(t => t.TourGuide!.Tours)
				.Where(t => !t.IsCompleted);

			return _handler.ReattachToursInfo(toursFilter, tours);
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
