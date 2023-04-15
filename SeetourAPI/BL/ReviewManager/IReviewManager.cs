using SeetourAPI.Data.Models;

namespace SeetourAPI.BL.ReviewManager
{
    public interface IReviewManager
    {
        public IEnumerable<Review> GetAll();
        public ICollection<Review> GetReviewById(int id);
        public Review? EditReview(int id, Review review);
        public void AddReview(Review review);
        public void DeleteReview(int id);
    }
}
