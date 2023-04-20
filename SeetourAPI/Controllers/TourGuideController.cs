using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeetourAPI.BL.Filters;
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
        private readonly UserManager<SeetourUser> _usermanager;
        private readonly ITourGuideManager _tourGuideManager;

        public TourGuideController(ITourGuideManager tourGuideManager, UserManager<SeetourUser> usermanager)
        {
            _tourGuideManager = tourGuideManager;
            _usermanager = usermanager;
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
    }
}
