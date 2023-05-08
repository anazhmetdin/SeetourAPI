using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Models;

namespace SeetourAPI.BL.TourAnswerManager
{
    public class TourAnswerManager : ITourAnswerManager
    {
        private readonly ITourAnswerRepo _tourAnswerRepo;
        private readonly ITourQuestionRepo _tourQuestionRepo;

        public TourAnswerManager(
            ITourAnswerRepo tourAnswerRepo,
            ITourQuestionRepo tourQuestionRepo

    
            )
        {
            _tourAnswerRepo = tourAnswerRepo;
            _tourQuestionRepo = tourQuestionRepo;
        }
        public AnswerDto AddAnswer(AnswerDto tourAnswerDto)
        {
            var question = _tourQuestionRepo.GetById(tourAnswerDto.tourQuestionId);
            if((question.TourAnswerId == null ) && (tourAnswerDto.answer !=null))
            {

               var answer = new TourAnswer()
               {
                TourQuestionId = tourAnswerDto.tourQuestionId,
                Answer = tourAnswerDto.answer

               };
               _tourAnswerRepo.AddAnswer(answer);

                // Update TourQuestion with TourAnswer ID
                question.TourAnswerId = answer.Id;
                _tourQuestionRepo.UpdateQuestion(answer.TourQuestionId,question);



                return tourAnswerDto;
            }
            return null ;
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
