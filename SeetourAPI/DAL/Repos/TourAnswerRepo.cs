using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.Repos
{
    public class TourAnswerRepo : ITourAnswerRepo
    {
        private readonly SeetourContext _context;

        public TourAnswerRepo(SeetourContext context)
        {
            _context = context;
        }
        public void AddAnswer(TourAnswer tourAnswer)
        {
            _context.TourAnswers.Add(tourAnswer);
            _context.SaveChanges();
        }

        public void DeleteAnswer(int id)
        {
            var answer = _context.TourAnswers.Find(id);
            if(answer != null)
            {
                _context.TourAnswers.Remove(answer); 
                _context.SaveChanges();
            }
        }

        public TourAnswer? EditAnswer(int id, TourAnswer tourAnswer)
        {
            var answer = _context.TourAnswers.Find(id);
            if (answer != null)
            {
                answer.Answer = tourAnswer.Answer;
                _context.SaveChanges();
                return tourAnswer;
            }
            return new TourAnswer();
        }

        public IEnumerable<TourAnswer> GetAll()
        {
            return _context.TourAnswers.ToList();
        }

        public TourAnswer? GetAnswerById(int id)
        {
            var answer = _context.TourAnswers.Find(id);
            if (answer != null)
            {
                return answer;
            }
            return new TourAnswer();
        }
    }
}
