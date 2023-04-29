using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.Repos
{
    public interface IReviewRepo
    {
        public IEnumerable<Review> GetAll();
        public Review GetReviewById(int id);
        public Review? EditReview(int id, Review review);
        public void AddReview(Review review);
        public void DeleteReview(int id);
        public IEnumerable<Review> GetTourGuideReviews(string Id);
        public IEnumerable<int> GetTourGuideRatings(string id);
    }
}
