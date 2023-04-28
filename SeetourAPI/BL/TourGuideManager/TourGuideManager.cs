using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Models;
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

        public TourGuideInfoDto? GetInfo(string id)
        {
            var tourguide = _tourguideRepo.GetTourGuide(id);

            if (tourguide == null)
            {
                return null;
            }

            return GetTourGuideInfoDto(tourguide);
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

        public ICollection<TourCardDto>? PastTourCards(string tourguideId)
        {
            var tourguide = GetInfo(tourguideId);

            if (tourguide == null)
            {
                return null;
            }

            var tours = _tourRepo.GetTourGuideTours(tourguide.Id);

            return GetTourCardDto(tourguide, tours.Where(t => t.IsCompleted));
        }

        public ICollection<TourCardDto>? UpcomingTourCards(string tourguideId)
        {
            var tourguide = GetInfo(tourguideId);

            if (tourguide == null)
            {
                return null;
            }

            var tours = _tourRepo.GetTourGuideTours(tourguide.Id);

            return GetTourCardDto(tourguide, tours.Where(t => !t.IsCompleted));
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
    }
}
