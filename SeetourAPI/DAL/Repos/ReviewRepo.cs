using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.Repos
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly SeetourContext _context;

        public ReviewRepo(SeetourContext context)
        {
            _context = context;
        }
        public void AddReview(Review review)
        {

            var bookedTour = _context.BookedTours.FirstOrDefault(bt => bt.Id == review.BookedTourId);
            if (bookedTour != null && bookedTour.Status == Data.Enums.BookedTourStatus.Completed)
            {
                _context.Reviews.Add(review);
                _context.SaveChanges();
            }

           
            _context.Reviews.Add(review);
            _context.SaveChanges();

        }

        public void DeleteReview(int id)
        {
            var review = _context.Reviews.Find(id);
            if(review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }
        }

        public Review? EditReview(int id, Review review)
        {
            var rev = _context.Reviews.Find(id);
            if (rev != null)
            {
                rev.Rating = review.Rating;
                rev.Comment = review.Comment;
                _context.SaveChanges();
                return review;
            }
            return new Review();
        }

        public IEnumerable<Review> GetAll()
        {
            return GetIncludes();
        }

        public Review GetReviewById(int id)
        {
            var review = _context.Reviews.Find(id);
            return review;
        }

        public IEnumerable<int> GetTourGuideRatings(string id)
        {
            return GetTourGuideReviews(id)
                .Select(r => r.Rating);
        }

        public IEnumerable<Review> GetTourGuideReviews(string Id)
        {
            return _context.Reviews
                .Where(r => r.BookedTour!.Tour!.TourGuideId == Id);
        }

        private IQueryable<Review> GetIncludes()
        {
            return _context.Reviews
                .Include(r => r.BookedTour)
                .ThenInclude(r => r.Tour)
                .ThenInclude(r => r.TourGuide)
                .Include(r => r.BookedTour)
                .ThenInclude(r => r.Customer)
                .ThenInclude(r => r.User);
        }
    }
}
