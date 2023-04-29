using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeetourAPI.BL.Filters;
using SeetourAPI.BL.ReviewManager;
using SeetourAPI.BL.TourGuideManager;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Models.Users;
using SeetourAPI.Data.Policies;
using System;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[Authorize(Policy = Policies.AcceptedTourGuides)]
    public class TourGuideController : ControllerBase
    {
        private readonly ITourGuideManager _tourGuideManager;
        private readonly IReviewManager _reviewManager;

        public TourGuideController(ITourGuideManager tourGuideManager,
            IReviewManager reviewManager)
        {
            _tourGuideManager = tourGuideManager;
            _reviewManager = reviewManager;
        }

        [HttpGet("{Id}/UpcomingTours")]
        public IActionResult GetUpcomingTours(string Id)
        {
            var tours = _tourGuideManager.UpcomingTourCards(Id);
            if (tours == null)
            {
                return NotFound();
            }
            return Ok(tours);
        }

        [HttpGet("{Id}/PastTours")]
        public IActionResult GetPastTours(string Id)
        {
            var tours = _tourGuideManager.PastTourCards(Id);
            if (tours == null)
            {
                return NotFound();
            }
            return Ok(tours);
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
    }
}
