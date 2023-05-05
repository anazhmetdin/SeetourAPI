using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeetourAPI.BL.Filters;
using SeetourAPI.BL.ReviewManager;
using SeetourAPI.BL.TourGuideManager;
using SeetourAPI.BL.TourManger;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Models.Users;
using SeetourAPI.Data.Policies;
using System;
using System.Security.Claims;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[Authorize(Policy = Policies.AcceptedTourGuides)]
    public class TourGuideController : ControllerBase
    {
        private readonly ITourGuideManager _tourGuideManager;
        private readonly IReviewManager _reviewManager;
        private readonly ITourManger _tourManger;

        public TourGuideController(ITourGuideManager tourGuideManager,
            IReviewManager reviewManager,ITourManger tourManger)
        {
            _tourGuideManager = tourGuideManager;
            _reviewManager = reviewManager;
            _tourManger = tourManger;
        }

        [HttpGet("{Id}/UpcomingTours")]
        public IActionResult GetUpcomingTours(string Id,
            [FromQuery] ToursFilterDto toursFilter)
        {
            return GetTours(Id, false, toursFilter);
        }

        [NonAction]
        private IActionResult GetTours(string Id, bool isCompleted, ToursFilterDto toursFilter)
        {
            var tours = _tourGuideManager.CompletedTourCards(Id, isCompleted, toursFilter);
            if (tours == null)
            {
                return NotFound();
            }
            return Ok(tours);
        }

        [HttpGet("{Id}/PastTours")]
        public IActionResult GetPastTours(string Id,
            [FromQuery] ToursFilterDto toursFilter)
        {
            return GetTours(Id, true, toursFilter);
        }

        [HttpGet("{Id}/Reviews")]
        public IActionResult GetReviews(string Id)
        {
            var reviews = _reviewManager.GetAllTourGuideReviews(Id);
            return Ok(reviews);
        }

        [HttpGet("{Id}")]
        public IActionResult GetInfo(string Id)
        {
            var info = _tourGuideManager.GetInfo(Id);
            if (info == null)
            {
                return NotFound();
            }
            return Ok(info);
        }

        [Authorize(policy:Policies.AllowTourGuide)]
        [HttpGet]
        public IActionResult GetInfo()
        {
            var Id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";

			var info = _tourGuideManager.GetInfo(Id);
			if (info == null)
			{
				return NotFound();
			}
			return Ok(info);
		}

        [HttpGet]
        [Route("Get Statistics")]
        public IActionResult GetStatistics()
        {
            string userid = _tourManger.GetCurrentUserId();
            var s=  _tourGuideManager.GetTStatistics(userid);
            if(s!=null)
            { return Ok(s); } 
            return NotFound();
         }
    }
}
