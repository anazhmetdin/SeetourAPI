using Microsoft.AspNetCore.Http.HttpResults;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.Repos
{
    public class TourQuestionRepo : ITourQuestionRepo
    {
        private readonly SeetourContext _context;
        public TourQuestionRepo(SeetourContext context)
        {
            _context = context;
        }
        
        public void AddQuestion(TourQuestion question)
        {
            _context.TourQuestions.Add(question);
            _context.SaveChanges();
        }

        public void DeleteQuestion(int id)
        {
            var quest = _context.TourQuestions.Find(id);
            if (quest != null)
            {
                _context.TourQuestions.Remove(quest);
                _context.SaveChanges();

            }
        }

        public IEnumerable<TourQuestion> GetAll()
        {
            return _context.TourQuestions.ToList();
        }

        public TourQuestion GetById(int id)
        {
            var quest = _context.TourQuestions.Find(id);
            if(quest != null)
            {
                return quest;
            }
            return new TourQuestion();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void UpdateQuestion(int id, TourQuestion question)
        {
            var quest =_context.TourQuestions.Find(id);
            if (quest != null)
            {
                quest.Question = question.Question;
                _context.SaveChanges();
                
            }
        }
    }
}
