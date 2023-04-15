using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Models;

namespace SeetourAPI.BL.TourManger
{
    public class TourQuestionManger : ITourQuestionManger
    {
        private readonly ITourQuestionRepo _tourQuestionRepo;


        public TourQuestionManger(ITourQuestionRepo tourQuestionRepo)
        {
            _tourQuestionRepo = tourQuestionRepo;
        }

        public void AddQuestion(TourQuestion question)
        {
            _tourQuestionRepo.AddQuestion(question);
        }

        public void DeleteQuestion(int id)
        {
            _tourQuestionRepo.DeleteQuestion(id);
        }

        public IEnumerable<TourQuestion> GetAll()
        {
            return _tourQuestionRepo.GetAll();
        }

        public TourQuestion GetById(int id)
        {
            return _tourQuestionRepo.GetById(id);
        }

        public int SaveChanges()
        {
            return _tourQuestionRepo.SaveChanges();
        }

        public void UpdateQuestion(int id, TourQuestion question)
        {
            _tourQuestionRepo.UpdateQuestion(id, question);
        }
    }
}
