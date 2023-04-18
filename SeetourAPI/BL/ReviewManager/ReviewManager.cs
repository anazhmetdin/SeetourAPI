using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Models;

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
    }
}
