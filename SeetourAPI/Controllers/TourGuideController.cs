using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeetourAPI.BL.Filters;
using SeetourAPI.BL.ReviewManager;
using SeetourAPI.BL.TourGuideManager;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Models.Users;
using System;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(TourGuideFilter))]
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

        [HttpGet("UpcomingTours/{id}")]
        public IActionResult GetUpcomingTours(string Id)
        {
            var tours = _tourGuideManager.UpcomingTourCards(Id);
            if (tours == null)
            {
                return NotFound();
            }
            return Ok(tours);
        }

        [HttpGet("PastTours/{id}")]
        public IActionResult GetPastTours(string Id)
        {
            var tours = _tourGuideManager.PastTourCards(Id);
            if (tours == null)
            {
                return NotFound();
            }
            return Ok(tours);
        }

        [HttpGet("Reviews/{id}")]
        public IActionResult GetReviews(string Id)
        {
            var reviews = _reviewManager.GetAllTourGuideReviews(Id);
            return Ok(reviews);
        }
    }
}
