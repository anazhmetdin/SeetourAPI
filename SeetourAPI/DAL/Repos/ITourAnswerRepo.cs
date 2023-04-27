using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.Repos
{
    public interface ITourAnswerRepo
    {
        public IEnumerable<TourAnswer> GetAll();
        public TourAnswer? GetAnswerById(int id);
        public TourAnswer? EditAnswer(int id, TourAnswer tourAnswer);
        public void AddAnswer(TourAnswer tourAnswer);
        public void DeleteAnswer(int id);
    }
}
