using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Models;

namespace SeetourAPI.BL.ReviewManager
{
    public interface IReviewManager
    {
        public IEnumerable<Review> GetAll();
        public Review GetReviewById(int id);
        public Review? EditReview(int id, Review review);
        public void AddReview(Review review);
        public void DeleteReview(int id);
        public ICollection<ReviewCardDto> GetAllTourGuideReviews(string Id);
        public ICollection<ReviewCardDto> GetAllTourReviews(int Id);
    }
}
