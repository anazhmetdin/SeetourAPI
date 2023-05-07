using SeetourAPI.BL.ReviewManager;
using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace SeetourAPI.Services
{
    public class ToursHandler
    {
        private HttpContextAccessor _contextAccessor;
        private ITourRepo _tourRepo;
        private IReviewManager _reviewManager;

		public ToursHandler(HttpContextAccessor contextAccessor, ITourRepo tourRepo, IReviewManager reviewManager)
		{
			_contextAccessor = contextAccessor;
			_tourRepo = tourRepo;
			_reviewManager = reviewManager;
		}

		public IEnumerable<Tour> Filter(IEnumerable<Tour> tours, ToursFilterDto toursFilter)
        {
            if (toursFilter.query != null && toursFilter.query.Length >= 3)
            {
				List<Tour> temp = new List<Tour>();

				temp.AddRange(
                    tours.Where(t => t.LocationFrom.Contains(toursFilter.query, StringComparison.OrdinalIgnoreCase)));
                temp.AddRange(tours
                        .Where(t => t.LocationTo.Contains(toursFilter.query, StringComparison.OrdinalIgnoreCase)));

				temp.AddRange(tours
						.Where(t => t.DateFrom.ToString().Contains(toursFilter.query, StringComparison.OrdinalIgnoreCase)));
				temp.AddRange(tours
						.Where(t => t.DateTo.ToString().Contains(toursFilter.query, StringComparison.OrdinalIgnoreCase)));

				temp.AddRange(tours
						.Where(t => t.Title.Contains(toursFilter.query, StringComparison.OrdinalIgnoreCase)));
				temp.AddRange(tours
						.Where(t => t.Description.Contains(toursFilter.query, StringComparison.OrdinalIgnoreCase)));

				temp.AddRange(tours
						.Where(t => t.TourGuide!.User!.FullName.Contains(toursFilter.query, StringComparison.OrdinalIgnoreCase)));

                tours = temp;
			}

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

            if(toursFilter.Take != -1)
                tours = tours.Take(toursFilter.Take);

            return tours;
        }

        public ICollection<TourCardDto> GetTourCardDto(
            IEnumerable<Tour> tours)
        {
            string userId = _contextAccessor.HttpContext?.User
                .FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";

            return tours.Select(t => GetTourCardDto(t, userId)).ToList();
        }

        public TourCardDto GetTourCardDto(Tour tour, string userId)
        {

            return new TourCardDto(
                Id: tour.Id,
                Photos: tour.Photos!.Select(p => p.Url).ToArray(),
                LocationTo: tour.LocationTo,
                Price: tour.Price,
                Likes: tour.Likes?.Count ?? 0,
                isLiked: tour.Likes?.Any(l => l.CustomerId == userId) ?? false,
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
                AddedToWishList: tour.Wishlist?.Any(l => l.CustomerId == userId) ?? false
                //hasTransportation: tour.HasTransportation
            );
        }


        public TourDto GetTourDto(Tour tour, string userId)
        {

            return new TourDto(
                Id: tour.Id,
                Photos: tour.Photos.Select(p => p.Url).ToArray(),
                LocationTo: tour.LocationTo,
                LocationFrom: tour.LocationFrom,
                TourguideId: tour.TourGuideId,
                Price: tour.Price,
                Likes: tour.Likes.Count,
                Bookings: tour.BookingsCount,
                Capacity: tour.Capacity,
                DateFrom: tour.DateFrom.Date.ToString(),
                DateTo: tour.DateTo.Date.ToString(),
                Title: tour.Title,
                hasTransportation: tour.HasTransportation,
                Description:tour.Description,
                Reviews: _reviewManager.GetAllTourReviews(tour.Id).ToArray(),
                Rating: tour.Reviews.Select(r => r.Rating).ToArray()
            );
        }

		public ICollection<TourCardDto> ReattachToursInfo(ToursFilterDto toursFilter, IEnumerable<Tour> tours)
		{
			tours = Filter(tours, toursFilter);

			foreach (var tour in tours)
			{
				tour.Likes = _tourRepo.GetTourLikes(tour.Id).ToList();
				tour.Wishlist = _tourRepo.GetTourWishlist(tour.Id).ToList();
				tour.Photos = _tourRepo.GetTourPhotos(tour.Id).ToList();
			}

			return GetTourCardDto(tours);
		}

	}
}
