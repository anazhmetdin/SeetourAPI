using Microsoft.EntityFrameworkCore;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models;
using System.Linq;

namespace SeetourAPI.DAL.Repos
{
	public class TrendingTourRepo : ITrendingTourRepo
	{
		private readonly SeetourContext _context;

		public TrendingTourRepo(SeetourContext context)
		{
			_context = context;
		}

		public record TGPoints(int tourId, int points);

		public Task<bool> TryUpdateAll()
		{
			try
			{
				foreach (var p in _context.TrendingTours)
				{
					_context.Entry(p).State = EntityState.Deleted;
				}

				var time = DateTime.UtcNow.AddDays(-30);

				//likes in the last x days
				List<TGPoints> likes = _context.CustomerLikes
					.Include(l => l.Tour)
					.Where(l => l.Tour!.TourGuide!.Status != Data.Enums.TourGuideStatus.Blocked)
					.Where(t => t.CreatedAt >= time)
					.ToList()
					.Where(l => !l.Tour!.IsCompleted)
					.GroupBy(t => t.TourId)
					.Select(t => new TGPoints(t.Key, t.Count()))
					.ToList();
				//wishlists in the last x days
				List<TGPoints> wishlists = _context.CustomerWishlists
					.Include(l => l.Tour)
					.Where(l => l.Tour!.TourGuide!.Status != Data.Enums.TourGuideStatus.Blocked)
					.Where(t => t.CreatedAt >= time)
					.ToList()
					.Where(l => !l.Tour!.IsCompleted)
					.GroupBy(t => t.TourId)
					.Select(t => new TGPoints(t.Key, t.Count()))
					.ToList();

				likes.AddRange(wishlists);

				var all =likes.GroupBy(l => l.tourId)
					.Select(l => new TGPoints(
						l.Key,
						l.Sum(t => t.points)
						)
					);

				if (all == null) return Task.FromResult(true);

				all = all.OrderByDescending(l => l.points);

				_context.TrendingTours.AddRange(all
					.Take(10)
					.Select(l => new TrendingTour()
					{
						TourId = l.tourId,
					}));

				_context.SaveChanges();

				return Task.FromResult(true);
			}
			catch (Exception ex)
			{
				return Task.FromResult(false);
			}
		}
	}
}
