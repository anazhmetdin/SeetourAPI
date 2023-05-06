using Microsoft.AspNetCore.Identity;
using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;
using System.Security.Claims;

namespace SeetourAPI.BL.TourManger
{
    public class TourQuestionManger : ITourQuestionManger
    {
        private readonly ITourRepo tourRepo;
        private readonly ITourQuestionRepo _tourQuestionRepo;
        private readonly UserManager<SeetourUser> _userManager;
        private readonly HttpContextAccessor _HttpContextAccessor;

        public TourQuestionManger(ITourRepo tourRepo, ITourQuestionRepo tourQuestionRepo,
            UserManager<SeetourUser> userManager,
            HttpContextAccessor _httpContextAccessor)
        {
            this.tourRepo = tourRepo;
            _tourQuestionRepo = tourQuestionRepo;
            _userManager = userManager;
            _HttpContextAccessor = _httpContextAccessor;
        }

        public string GetCurrentUserId()
        {
            var userId = _HttpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId ?? "82712fd4-3d4c-4569-bbb7-a29e65de36ec";
        }

        public bool AddQuestion(QuestionDto questionDto)
        {
            var tour = tourRepo.GetTourByIdLite(questionDto.TourId);
            if (tour != null)
            {
                var question = new TourQuestion()
                {
                    Question = questionDto.Question,
                    TourId = questionDto.TourId,
                    CustomerId = GetCurrentUserId()
                };
                _tourQuestionRepo.AddQuestion(question);
                return true;
            }
            return false;
        }

        public IEnumerable<QuestionAnswerDto> GetAllWithAnswers(int tourId)
        {
            var questAns = _tourQuestionRepo.GetAllWithAnswers(tourId);
            if(questAns == null)
            {
                return null;
            }

            return _tourQuestionRepo.GetAllWithAnswers(tourId).Select(QuestionAns).ToList();
        }

        private QuestionAnswerDto QuestionAns (TourQuestion questionAnswer){
            return new QuestionAnswerDto
            (
                QuestionId : questionAnswer.Id,
                Question : questionAnswer.Question,
                AnswerId: questionAnswer.TourAnswerId,
                Answer : questionAnswer.TourAnswer?.Answer??""
            );
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
