using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using SeetourAPI.BL.Filters;
using SeetourAPI.BL.ReviewManager;
using SeetourAPI.BL.TourManger;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;
using SeetourAPI.Data.Policies;
using System;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[TypeFilter(typeof(TourGuideFilter))]
    public class TourController : ControllerBase
    {
        private readonly UserManager<SeetourUser> manger;
        private readonly IReviewManager _reviewManger;

        public ITourManger ITourManger { get; }
        public TourController(ITourManger ITourManger, UserManager<SeetourUser> Manger, IReviewManager reviewManger)
        {
            this.ITourManger = ITourManger;
            manger = Manger;
            _reviewManger = reviewManger;
        }
        
        [HttpPost]
        [Authorize(Policy = Policies.AcceptedTourGuides)]
        public ActionResult CreateTour(AddTourDto addTourDto)
        {
              ITourManger.AddTour(addTourDto);
                return Created("", addTourDto);    
        }

        [HttpPost]
        [Route("AddPics")]
        [Authorize(Policy = Policies.AcceptedTourGuides)]
        public ActionResult AddPastTourPics(int tourid,ICollection<photoDto> photoDtos)
        {
           var tour= ITourManger.GetTourById(tourid);
            string tourguideid = ITourManger.GetCurrentUserId();
            if(tour.TourGuideId== tourguideid)
            {

            ITourManger.PostPastTourPics(tourid, photoDtos);
            return Created("", photoDtos);
            }
            return Unauthorized();
           
        }

        [Authorize(Policy = Policies.AcceptedTourGuides)]
        [HttpPut]
        public ActionResult EditTour(int id,Tour tour)
        {
            if(tour.Id!=id)
            {
                return BadRequest();
            }
            else
            {
            ITourManger.EditTour(id, tour);
            return Ok();
            }
        }

        [Authorize(Policy = Policies.AllowAdmins)]
        [HttpDelete]
        public ActionResult DeleteTour(int id)
        {
            ITourManger.DeleteTour(id);
            return  NoContent();
        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int id)
        {
          var t=  ITourManger.GetTourById(id);
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
            var tours = ITourManger.GetAll();
            if(tours == null)
            {
                return NotFound();
            }
            return Ok(ITourManger.GetAll());
        }

        [HttpGet]
        [Route("TourDetails")]
        public ActionResult Details(int id)
        {
            var tour = ITourManger.GetTourById(id);
            if (tour?.Id == id)
            {
                return Ok( ITourManger.Details(id));

            }
            return NotFound();
        }

        [HttpGet]
        [Route("CardDetails")]
        public ActionResult DetailsCard(int id)
        {
          var tour=  ITourManger.DetailsCard(id);
            if (tour==null)
            {
            return NotFound();

            }
            else
                return Ok(tour);

        }

        [HttpGet("Reviews/{id}")]
        public IActionResult GetReviews(int Id)
        {
            var reviews = _reviewManger.GetAllTourReviews(Id);
            return Ok(reviews);
        }

        [HttpGet]
        public IActionResult GetAllCards([FromQuery] ToursFilterDto toursFilter)
        {
            var tours = ITourManger.GetAllCards(toursFilter);
            if (tours == null)
            {
                return NotFound();
            }

            return Ok(tours);
        }

        [HttpGet("Upcoming")]
        public IActionResult GetUpcomingCards([FromQuery] ToursFilterDto toursFilter)
        {
            var tours = ITourManger.GetIsCompletedCards(false, toursFilter);

            if (tours == null)
            {
                return NotFound();
            }

            return Ok(tours);
        }

        [HttpGet("Past")]
        public IActionResult GetPastCards([FromQuery] ToursFilterDto toursFilter)
        {
            var tours = ITourManger.GetIsCompletedCards(true, toursFilter);

            if (tours == null)
            {
                return NotFound();
            }

            return Ok(tours);
        }

        [HttpGet("categories")]
        [OutputCache(Duration = 60*60*24)]
        [ResponseCache(Duration = 60*60*24)]
        public IActionResult GetCategories()
        {
            return Ok(Enum.GetNames(typeof(TourCategory)).ToList());
        }

        [HttpGet]
        [Route("tourDet")]
        public ActionResult DetailsTour(int id)
        {
            var tour = ITourManger.DetailsTour(id);
            if (tour == null)
            {
                return NotFound();

            }
            else
                return Ok(tour);

        }
    }
}
