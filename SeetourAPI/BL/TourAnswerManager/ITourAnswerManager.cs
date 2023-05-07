using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Models;

namespace SeetourAPI.BL.TourAnswerManager
{
    public interface ITourAnswerManager
    {
        public IEnumerable<TourAnswer> GetAll();
        public TourAnswer? GetAnswerById(int id);
        public TourAnswer? EditAnswer(int id, TourAnswer tourAnswer);
        public AnswerDto AddAnswer(AnswerDto tourAnswerDto);
        public void DeleteAnswer(int id);
        
    }
}
