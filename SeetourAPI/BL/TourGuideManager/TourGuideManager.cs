using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;
using System.Linq;

namespace SeetourAPI.BL.TourGuideManager
{
    public class TourGuideManager : ITourGuideManager
    {
        private readonly ITourGuideRepo _tourguideRepo;
        private readonly ITourRepo _tourRepo;
        private readonly IUserRepo _userRepo;
        private readonly IReviewRepo _reviewRepo;

        public TourGuideManager(ITourRepo tourRepo, ITourGuideRepo tourguideRepo, IUserRepo userRepo, IReviewRepo reviewRepo)
        {
            _tourRepo = tourRepo;
            _tourguideRepo = tourguideRepo;
            _userRepo = userRepo;
            _reviewRepo = reviewRepo;
        }

        public TourGuideInfoDto? GetInfo(string id)
        {
            var exist = _tourguideRepo.CheckTourGuide(id);

            if (!exist)
            {
                return null;
            }

            var user = _userRepo.GetUserBasicInfo(id)!;

            var ratings = _reviewRepo.GetTourGuideRatings(id).ToArray();

            return GetTourGuideInfoDto(user, ratings);
        }

        private TourGuideInfoDto GetTourGuideInfoDto(UserBasicInfoDto user,
            IEnumerable<int> ratings)
        {
            return new TourGuideInfoDto(
                Id: user.Id,
                Name: user.Name,
                ProfilePic: user.Picture??"",
                Rating: (int)ratings.DefaultIfEmpty(0).Average(),
                RatingCount: ratings.Count()
            );
        }

        private TourGuideInfoDto GetTourGuideInfoDto(TourGuide tourguide)
        {
            return new TourGuideInfoDto(
                Id: tourguide.Id,
                Name: tourguide.User?.FullName??"",
                ProfilePic: tourguide.User?.ProfilePic??"",
                Rating: (int)tourguide.Rating,
                RatingCount: tourguide.RatingCount
            );
        }

        private TGToursDto? GetTours(string tourguideId)
        {
            var tourguide = GetInfo(tourguideId);

            if (tourguide == null)
            {
                return null;
            }

            var tours = _tourRepo.GetTourGuideTours(tourguide.Id);
            return new TGToursDto(tourguide, tours);
        }

        public ICollection<TourCardDto>? CompletedTourCards(string tourguideId,
            bool isCompleted)
        {
            var TGTours = GetTours(tourguideId);

            if (TGTours == null)
                return null;

            return GetToursCompleted(TGTours, isCompleted);
        }

        private ICollection<TourCardDto> GetToursCompleted(TGToursDto TGTours,
            bool isCompleted)
        {
            return GetTourCardDto(TGTours.TourGuide, TGTours.Tours.Where(t => isCompleted == t.IsCompleted));
        }

        private ICollection<TourCardDto> GetTourCardDto(TourGuideInfoDto tourGuide,
            IEnumerable<Tour> tours)
        {
            return tours.Select(tour => new TourCardDto(
                Id: tour.Id,
                Photos: tour.Photos.Select(p => p.Url).ToArray(),
                LocationTo: tour.LocationTo,
                Price: tour.Price,
                Likes: tour.Likes.Count,
                isLiked: false,
                Bookings: tour.BookingsCount,
                Capacity: tour.Capacity,
                TourGuideId: tourGuide.Id,
                TourGuideName: tourGuide.Name,
                TourGuideRating: tourGuide.Rating,
                TourGuideRatingCount: tourGuide.RatingCount,
                DateFrom: tour.DateFrom.Date.ToString(),
                DateTo: tour.DateTo.Date.ToString(),
                Category: tour.Category.ToString(),
                Title: tour.Title,
                AddedToWishList: false
            )).ToList();
        }

        public ICollection<TourCardDto>? CompletedTourCards(string tourguideId, bool isCompleted, ToursFilterDto toursFilter)
        {
            var TGTours = GetTours(tourguideId);

            if (TGTours == null)
                return null;

            TGTours = FilterTours(toursFilter, TGTours);

            return GetToursCompleted(TGTours, isCompleted);
        }

        private static TGToursDto FilterTours(ToursFilterDto toursFilter, TGToursDto TGTours)
        {
            IEnumerable<Tour> tours = TGTours.Tours.ToList();

            if (toursFilter.HasSeats != null)
                tours = tours.Where(t => toursFilter.HasSeats + t.BookingsCount <= t.Capacity);

            if (toursFilter.MinRating != null)
                tours = tours.Where(t => toursFilter.MinRating <= TGTours.TourGuide.Rating);

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
                tours = tours.Where(t => t.LocationFrom.IndexOf(toursFilter.LocationFrom, StringComparison.OrdinalIgnoreCase) >= 0);

            if (toursFilter.LocationTo != null)
                tours = tours.Where(t => t.LocationTo.IndexOf(toursFilter.LocationTo, StringComparison.OrdinalIgnoreCase) >= 0);

            TGTours = new TGToursDto(TGTours.TourGuide, tours);
            return TGTours;
        }
    }
}
