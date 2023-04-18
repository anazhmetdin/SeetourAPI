﻿using Microsoft.EntityFrameworkCore;
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
            return _context.Reviews.Include(r => r.BookedTour).ToList();
        }

        public Review GetReviewById(int id)
        {
            var review = _context.Reviews.Include(r => r.BookedTour).FirstOrDefault(r => r.Id == id);
            return review;
        }
    }
}