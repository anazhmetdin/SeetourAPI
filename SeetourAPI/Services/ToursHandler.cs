using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;
using System.Security.Claims;

namespace SeetourAPI.Services
{
    public class ToursHandler
    {
        private HttpContextAccessor _contextAccessor;

        public ToursHandler(HttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public IEnumerable<Tour> Filter(IEnumerable<Tour> tours, ToursFilterDto toursFilter)
        {
            if (toursFilter.HasSeats != null)
                tours = tours.Where(t => toursFilter.HasSeats + t.BookingsCount <= t.Capacity);

            if (toursFilter.MinRating != null)
                tours = tours.Where(t => toursFilter.MinRating <= t.TourGuide?.Rating);

            if (toursFilter.CapacityFrom != null)
                tours = tours.Where(t => toursFilter.CapacityFrom <= t.Capacity);

            if (toursFilter.CapacityTo != null)
                tours = tours.Where(t => toursFilter.CapacityTo >= t.Capacity);

            if (toursFilter.DateFrom != null)
                tours = tours.Where(t => toursFilter.DateFrom <= t.DateFrom);

            if (toursFilter.DateTo != null)
                tours = tours.Where(t => toursFilter.DateTo >= t.DateTo);

            if (toursFilter.PriceFrom != null)
                tours = tours.Where(t => toursFilter.PriceFrom <= t.Price);

            if (toursFilter.PriceTo != null)
                tours = tours.Where(t => toursFilter.PriceTo >= t.Price);

            if (toursFilter.LocationFrom != null)
                tours = tours.Where(t => t.LocationFrom.Contains(toursFilter.LocationFrom, StringComparison.OrdinalIgnoreCase));

            if (toursFilter.LocationTo != null)
                tours = tours.Where(t => t.LocationTo.Contains(toursFilter.LocationTo, StringComparison.OrdinalIgnoreCase));

            if (toursFilter.HasTransportation != null)
                tours = tours.Where(t => t.HasTransportation == toursFilter.HasTransportation);

            if (Enum.TryParse(toursFilter.TourCategory, out TourCategory category))
                tours = tours.Where(t => t.Category == category);

            return tours;
        }

        public ICollection<TourCardDto> GetTourCardDto(
            IEnumerable<Tour> tours)
        {
            string userId = _contextAccessor.HttpContext?.User
                .FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";

            return tours.Select(t => GetTourCardDto(t, userId)).ToList();
        }

        private TourCardDto GetTourCardDto(Tour tour, string userId)
        {

            return new TourCardDto(
                Id: tour.Id,
                Photos: tour.Photos.Select(p => p.Url).ToArray(),
                LocationTo: tour.LocationTo,
                Price: tour.Price,
                Likes: tour.Likes.Count,
                isLiked: tour.Likes.Any(l => l.CustomerId == userId),
                Bookings: tour.BookingsCount,
                Capacity: tour.Capacity,
                TourGuideId: tour.TourGuideId,
                TourGuideName: tour.TourGuide?.User?.FullName ?? "",
                TourGuideRating: tour.TourGuide?.Rating ?? 0,
                TourGuideRatingCount: tour.TourGuide?.RatingCount ?? 0,
                DateFrom: tour.DateFrom.Date.ToString(),
                DateTo: tour.DateTo.Date.ToString(),
                Category: tour.Category.ToString(),
                Title: tour.Title,
                AddedToWishList: tour.Wishlist.Any(l => l.CustomerId == userId)
                //hasTransportation: tour.HasTransportation
            );
        }


        public TourDto GetTourDto(Tour tour, string userId)
        {

            return new TourDto(
                GetTourCardDto(tour,  userId),
                hasTransportation: tour.HasTransportation,
                Description:tour.Description,
                Reviews: tour.Reviews.Select(r => r.Comment).ToArray()
            );
        }

    }
}
