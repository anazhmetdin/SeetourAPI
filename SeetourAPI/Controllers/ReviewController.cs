using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeetourAPI.BL.ReviewManager;
using SeetourAPI.BL.TourManger;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Policies;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public IReviewManager _reviewManger { get; }
        public ReviewController(IReviewManager reviewManger)
        {
            _reviewManger = reviewManger;
        }

        [HttpPost]
        [Authorize(Policy = Policies.AllowCustomers)]
        public ActionResult CreateReview(Review review)
        {
            _reviewManger.AddReview(review);
            return Created("", review);
        }

        [HttpPut]
        [Authorize(Policy = Policies.AllowCustomers)]
        public ActionResult EditReview(int id, Review review)
        {
            if (review.Id != id)
            {
                return BadRequest();
            }
            else
            {
                _reviewManger.EditReview(id, review);
                return Ok();
            }
        }

        [HttpDelete]
        [Authorize(Policy = Policies.AllowCustomers)]
        public ActionResult DeleteReview(int id)
        {
            _reviewManger.DeleteReview(id);
            return NoContent();
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int id)
        {
            var t = _reviewManger.GetReviewById(id);
            if (t == null)
            {
                return NotFound();
            }
            return Ok(t);
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            var Reviews = _reviewManger.GetAll();
            if (Reviews == null)
            {
                return NotFound();
            }
            return Ok(_reviewManger.GetAll());
        }
    }
}
