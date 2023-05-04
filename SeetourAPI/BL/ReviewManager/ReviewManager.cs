using Microsoft.EntityFrameworkCore;
using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;
using System.Linq;

namespace SeetourAPI.BL.ReviewManager
{
    public class ReviewManager : IReviewManager
    {
        private readonly IReviewRepo _reviewRepo;
        private readonly IBookedTourRepo _bookedTourRepo;
        private readonly ITourRepo _tourRepo;
        private readonly IUserRepo _userRepo;

		public ReviewManager(IReviewRepo reviewRepo, IBookedTourRepo bookedTourRepo, ITourRepo tourRepo, IUserRepo userRepo)
		{
			_reviewRepo = reviewRepo;
			_bookedTourRepo = bookedTourRepo;
			_tourRepo = tourRepo;
			_userRepo = userRepo;
		}

		public void AddReview(Review review)
        {
            _reviewRepo.AddReview(review);
        }

        public void DeleteReview(int id)
        {
            _reviewRepo.DeleteReview(id);
        }

        public Review? EditReview(int id, Review review)
        {
            if(id == review.Id)
            {
                return _reviewRepo.EditReview(id, review);
            }
            return new Review();
        }

        public IEnumerable<Review> GetAll()
        {
            return _reviewRepo.GetAll();
        }

        public Review GetReviewById(int id)
        {
            return _reviewRepo.GetReviewById(id);
        }

        public ICollection<ReviewCardDto> GetAllTourGuideReviews(string Id)
        {
            return _reviewRepo.GetTourGuideReviews(Id)
                .Select(r => GetReviewCardDto(r, true))
                .ToList();
        }

        public ICollection<ReviewCardDto> GetAllTourReviews(int Id)
        {
            return _reviewRepo.GetTourReviews(Id)
                .Select(r => GetReviewCardDto(r))
                .ToList();
        }

        private ReviewCardDto GetReviewCardDto(Review review, bool includeTour = false)
        {
            review.BookedTour = _bookedTourRepo.GetByIdLite(review.BookedTourId);
            SeetourUser? user = null;

			if (review.BookedTour != null && includeTour)
            {
                review.BookedTour.Tour = _tourRepo.GetTourByIdLite(review.BookedTour.TourId);
                user = _userRepo.GetUser(review.BookedTour.CustomerId);
            }

			return new ReviewCardDto(
                    Id: review.Id,
                    BookedTourId: review.BookedTour?.Tour?.Id ?? 0,
                    BookedTourTitle: review.BookedTour?.Tour?.Title ?? "",
                    TourGuideId: review.BookedTour?.Tour?.TourGuideId ?? "",
                    CustomerName: user?.FullName ?? "",
                    Comment: review.Comment,
                    Rating: review.Rating,
                    CreatedAt: review.LastEditedAt.Date.ToString(),
                    Photos: review.Photos.Select(p => p.Url).ToArray());
        }
    }
}
