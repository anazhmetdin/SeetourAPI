using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeetourAPI.BL.TourManger;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Policies;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourQuestionController : ControllerBase
    {
        private readonly SeetourContext _Context;
        private readonly ITourQuestionManger ITourQuestionManger;
        public TourQuestionController(SeetourContext context ,ITourQuestionManger ITourQuestionManger)
        {
            this._Context = context;
            this.ITourQuestionManger = ITourQuestionManger;
           
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var quest = ITourQuestionManger.GetAll();
            if(quest == null)
            {
                return NotFound();
            }
            return Ok(ITourQuestionManger.GetAll());
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var q = ITourQuestionManger.GetById(id);
            if(q == null)
            {
                return BadRequest();
            }
            return Ok(q);
        }

        [HttpPost]
        [Authorize(Policy = Policies.AllowCustomers)]
        public IActionResult createTourQuestion(TourQuestion question )
        {
            ITourQuestionManger.AddQuestion( question);
            return Created("Created Successfully", question);
        }

        [HttpPut]
        [Authorize(Policy = Policies.AllowAdmins)]
        public IActionResult EditTourQuesrion(int id , TourQuestion question)
        {
            if(question.Id != id)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete]
        [Authorize(Policy = Policies.AllowAdmins)]
        public IActionResult DeleteTourQuestion(int id)
        {
            ITourQuestionManger.DeleteQuestion(id);
            return NoContent();
        }

        [HttpGet("questions-and-answers")]
        public IActionResult GetQuestionsAndAnswers()
        {
            var questionsAndAnswers = _Context.TourQuestions
                .Include(q => q.TourAnswer)
                .Select(q => new
                {
                    Question = q.Question,
                    Answer = q.TourAnswer != null ? q.TourAnswer.Answer : ""
                })
                .ToList();

            return Ok(questionsAndAnswers);
        }


    }
}
