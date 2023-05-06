using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Models;

namespace SeetourAPI.BL.TourManger
{
    public interface ITourQuestionManger
    {
        IEnumerable<TourQuestion> GetAll();
        public TourQuestion GetById(int id);
        public bool AddQuestion(QuestionDto questionDto);
        public IEnumerable<QuestionAnswerDto> GetAllWithAnswers(int tourId);
        public void UpdateQuestion(int id, TourQuestion question);
        public void DeleteQuestion(int id);
        int SaveChanges();
    }
}
