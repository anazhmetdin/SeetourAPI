using Microsoft.EntityFrameworkCore;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.Repos
{
    public class TourGuideRepo : ITourGuideRepo
    {
        private readonly SeetourContext _context;

        public TourGuideRepo(SeetourContext context)
        {
            _context = context;
        }

        public bool CheckTourGuide(string id)
        {
            return _context.TourGuides.Any(tg => tg.Id == id);
        }

		public IEnumerable<TourGuide> GetAll()
		{
			return _context.TourGuides
                .Include(t => t.User);
		}

		public TourGuide? GetTourGuide(string id)
        {
            return _context.TourGuides
                .Include(a => a.Tours)
                .ThenInclude(a => a.Photos)
                .Include(a => a.Tours)
                .ThenInclude(a => a.Likes)
                .Include(a => a.Tours)
                .ThenInclude(a => a.Bookings)
                .Include(a => a.Tours)
                .ThenInclude(a => a.Questions)
                .ThenInclude(a => a.TourAnswer)
                .Include(a => a.Tours)
                .ThenInclude(a => a.Bookings)
                .ThenInclude(a => a.Review)
                .Include(a => a.User).FirstOrDefault(t => t.Id == id);
        }

        public TourGuide? GetTourGuideLite(string id)
        {
            return _context.TourGuides
                .Include(t => t.User)
                .FirstOrDefault(t => t.Id == id);
        }

      
        
        public bool SaveChanges()
		{
			return _context.SaveChanges()>0;
		}

        IEnumerable<dynamic> ITourGuideRepo.GetAllQustionss(string id)
        {
            var unansweredQuestions = from question in _context.TourQuestions
                                      join tour in _context.Tours on question.TourId equals tour.Id
                                      where question.TourAnswer == null && tour.TourGuideId == id
                                      select new
                                      {
                                          question.Id,
                                          question.Question,
                                          question.CreatedAt,
                                          TourId = tour.Id,
                                          TourTitle = tour.Title
                                      };

            return (unansweredQuestions.ToList());

        }

    }
}
