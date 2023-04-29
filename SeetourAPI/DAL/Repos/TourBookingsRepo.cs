using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Enums;

namespace SeetourAPI.DAL.Repos
{
    public class TourBookingsRepo : ITourGuideRatingRepo
    {
        private readonly SeetourContext _context;

        public TourBookingsRepo(SeetourContext context)
        {
            _context = context;
        }

        public bool TryUpdateAll()
        {
            try
            {
                //_context.TourGuideRatings.Load();

                foreach (var p in _context.TourBookings)
                {
                    _context.Entry(p).State = EntityState.Deleted;
                }

                var bookings = _context.BookedTours
                    .Where(b=>b.Status == BookedTourStatus.Booked || b.Status == BookedTourStatus.Completed)
                    .GroupBy(r => r.TourId)
                    .Select(g => new TourBooking()
                    {
                        Id = g.Key,
                        BookingsCount = g.Count(),
                    });

                _context.TourBookings.AddRange(bookings);

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
