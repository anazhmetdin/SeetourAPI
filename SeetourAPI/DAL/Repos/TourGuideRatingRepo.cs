using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.Repos
{
    public class TourGuideRatingRepo : ITourGuideRatingRepo
    {
        private readonly SeetourContext _context;

        public TourGuideRatingRepo(SeetourContext context)
        {
            _context = context;
        }

        public bool TryUpdateAll()
        {
            try
            {
                //_context.TourGuideRatings.Load();

                foreach (var p in _context.TourGuideRatings)
                {
                    _context.Entry(p).State = EntityState.Deleted;
                }

                var ratings = _context.Reviews
                    .Include(r => r.BookedTour)
                    .ThenInclude(r => r.Tour)
                    .GroupBy(r => r.BookedTour!.Tour!.TourGuideId)
                    .Select(g => new TourGuideRating()
                    {
                        Id = g.Key,
                        Rating = (int)Math.Round(g.Average(r => r.Rating)),
                        RatingCount = g.Count()
                    });

                _context.TourGuideRatings.AddRange(ratings);

                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
