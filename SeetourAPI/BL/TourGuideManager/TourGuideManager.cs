using Microsoft.AspNetCore.Identity;
using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.BL.TourGuideManager
{
    public class TourGuideManager : ITourGuideManager
    {
        private readonly ITourGuideRepo _tourguideRepo;
        private readonly ITourRepo _tourRepo;
        public TourGuideManager(ITourRepo tourRepo, ITourGuideRepo tourguideRepo)
        {
            _tourRepo = tourRepo;
            _tourguideRepo = tourguideRepo;
        }

        public ICollection<TourCardDto>? PastTourCards(string tourguideId)
        {
            var tourguide = _tourguideRepo.GetTourGuide(tourguideId);

            if (tourguide == null)
            {
                return null;
            }

            return GetTourCardDto(tourguide.Tours.Where(t => t.IsCompleted));
        }

        public ICollection<TourCardDto>? TourCards(string tourguideId)
        {
            var tourguide = _tourguideRepo.GetTourGuide(tourguideId);

            if (tourguide == null)
            {
                return null;
            }

            return GetTourCardDto(tourguide.Tours);
        }

        public ICollection<TourCardDto>? UpcomingTourCards(string tourguideId)
        {
            var tourguide = _tourguideRepo.GetTourGuide(tourguideId);

            if (tourguide == null)
            {
                return null;
            }

            return GetTourCardDto(tourguide.Tours.Where(t => !t.IsCompleted));
        }

        private ICollection<TourCardDto> GetTourCardDto(IEnumerable<Tour> tours)
        {
            return tours.Select(tour =>
            {
                return new TourCardDto(
                    Id: tour.Id,
                    Photos: tour.Photos.Select(p => p.Url).ToArray(),
                    LocationTo: tour.LocationTo,
                    Price: tour.Price,
                    Likes: tour.Likes.Count,
                    isLiked: false,
                    Bookings: tour.BookingsCount,
                    Capacity: tour.Capacity,
                    TourGuideId: tour.TourGuideId,
                    TourGuideName: tour.TourGuide?.User?.FullName ?? "",
                    TourGuideRating: (int)tour.Rating,
                    TourGuideRatingCount: tour.RatingCount,
                    DateFrom: tour.DateFrom.Date.ToString(),
                    DateTo: tour.DateTo.Date.ToString(),
                    Category: tour.Category.ToString(),
                    Title: tour.Title,
                    AddedToWishList: false
                );
            }).ToList();
        }
    }
}
