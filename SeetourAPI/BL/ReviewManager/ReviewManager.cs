using Microsoft.EntityFrameworkCore;
using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Models;
using System.Linq;

namespace SeetourAPI.BL.ReviewManager
{
    public class ReviewManager : IReviewManager
    {
        private readonly IReviewRepo _reviewRepo;

        public ReviewManager(IReviewRepo reviewRepo)
        {
            _reviewRepo = reviewRepo;
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
            return _reviewRepo.GetAll()
                .Where(r => r.BookedTour!.Tour!.TourGuideId == Id)
                .Select(GetReviewCardDto)
                .ToList();
        }

        public ICollection<ReviewCardDto> GetAllTourReviews(int Id)
        {
            return _reviewRepo.GetAll()
                .Where(r => r.BookedTour!.Tour!.Id == Id)
                .Select(GetReviewCardDto)
                .ToList();
        }

        private ReviewCardDto GetReviewCardDto(Review review)
        {
            return new ReviewCardDto(
                    Id: review.Id,
                    BookedTourId: review.BookedTour?.Tour?.Id ?? 0,
                    BookedTourTitle: review.BookedTour?.Tour?.Title ?? "N/A",
                    TourGuideId: review.BookedTour?.Tour?.TourGuideId ?? "",
                    CustomerName: review.BookedTour?.Customer?.User?.FullName ?? "N/A",
                    Comment: review.Comment,
                    Rating: review.Rating,
                    CreatedAt: review.LastEditedAt.Date.ToString(),
                    Photos: review.Photos.Select(p => p.Url).ToArray());
        }
    }
}
