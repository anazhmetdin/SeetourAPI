using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeetourAPI.BL.TourManger;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Policies;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourQuestionController : ControllerBase
    {
        private readonly ITourQuestionManger ITourQuestionManger;
        public TourQuestionController(ITourQuestionManger ITourQuestionManger)
        {
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

    }
}
