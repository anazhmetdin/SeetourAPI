using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.Repos
{
	public class FavoritesRepo : IFavoritesRepo
	{
		private readonly SeetourContext _context;

		public FavoritesRepo(SeetourContext context)
		{
			_context = context;
		}

		public bool SaveChanges()
		{
			return _context.SaveChanges() > 0;
		}

		public void RemoveTourguideFavorite(CustomerFavoriteTourGuide favorite)
		{
			_context.CustomerFavoriteTourGuides.Remove(favorite);
		}

		public void AddTourguideFavorite(string customerId, string tourguideId)
		{
			_context.CustomerFavoriteTourGuides.Add(new CustomerFavoriteTourGuide()
			{
				CustomerId = customerId,
				TourGuideId = tourguideId
			});
		}

		public CustomerFavoriteTourGuide? GetFavorite(string customerId, string tourguideId)
		{
			return _context.CustomerFavoriteTourGuides
				.FirstOrDefault(f => f.CustomerId == customerId && f.TourGuideId == tourguideId);
		}
	}
}
