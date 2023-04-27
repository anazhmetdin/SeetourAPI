using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.Repos
{
    public interface ITourQuestionRepo
    {
        IEnumerable<TourQuestion> GetAll();
        public TourQuestion GetById(int id);
        public void AddQuestion(TourQuestion question);
        public void UpdateQuestion( int id ,TourQuestion question);
        public void DeleteQuestion(int id);
        int SaveChanges();
    }
}
