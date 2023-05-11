using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeetourAPI.BL.ReviewManager;
using SeetourAPI.BL.TourManger;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Policies;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly SeetourContext _Context;

        public IReviewManager _reviewManger { get; }
        public ReviewController(SeetourContext context,IReviewManager reviewManger)
        {
            _Context = context;
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
        [Authorize(Policy = Policies.AllowAdmins)]
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

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<object>> GetAllReviews()
        {
            var result = _Context.Reviews
                .Include(r => r.BookedTour)
                .Include(r => r.Photos)
                .Select(r => new {
                    ReviewId = r.Id,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    TourName = r.BookedTour.Tour.Title,
                    PhotoCount = r.Photos.Count,
                    tourId=r.BookedTour.TourId,
                    tourGuideName=r.BookedTour.Tour.TourGuide.User.FullName,
                    userPhoto=r.BookedTour.Customer.User.ProfilePic,
                    CustomerUserName=r.BookedTour.Customer.User.FullName
                })
                .ToList();

            return Ok(result);
        }

    }
}
