using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Models;

namespace SeetourAPI.BL.TourAnswerManager
{
    public class TourAnswerManager : ITourAnswerManager
    {
        private readonly ITourAnswerRepo _tourAnswerRepo;

        public TourAnswerManager(ITourAnswerRepo tourAnswerRepo)
        {
            _tourAnswerRepo = tourAnswerRepo;
        }
        public void AddAnswer(TourAnswer tourAnswer)
        {
            _tourAnswerRepo.AddAnswer(tourAnswer);
        }

        public void DeleteAnswer(int id)
        {
            _tourAnswerRepo.DeleteAnswer(id);
        }

        public TourAnswer? EditAnswer(int id, TourAnswer tourAnswer)
        {
            if(id == tourAnswer.Id)
            {
                return _tourAnswerRepo.EditAnswer(id, tourAnswer);
            }
            return new TourAnswer();
        }

        public IEnumerable<TourAnswer> GetAll()
        {
            return _tourAnswerRepo.GetAll();
        }

        public TourAnswer? GetAnswerById(int id)
        {
           return  _tourAnswerRepo.GetAnswerById(id);
        }
    }
}
