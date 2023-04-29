using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeetourAPI.BL.Filters;
using SeetourAPI.BL.ReviewManager;
using SeetourAPI.BL.TourManger;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;
using SeetourAPI.Data.Policies;

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
        
        [Authorize(Policy = Policies.AcceptedTourGuides)]
        [HttpPost]
        public ActionResult CreateTour(AddTourDto addTourDto)
        {
              ITourManger.AddTour(addTourDto);
                return Created("", addTourDto);    
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
            // PastToursList
            var PastToursList = _context.Tours.Where(x => x.Bookings.Any(b => b.Status == BookedTourStatus.Completed) && x.DateFrom < DateTime.Now).ToList();


            //The Top10Tours Order By Rate
            var Top10Tourss = _context.Tours
                .OrderByDescending(t => t.Bookings.Where(b => b.Status == BookedTourStatus.Completed && t.DateFrom < DateTime.Now)
                    .Average(b => b.Review != null ? b.Review.Rating : 0))
                .Take(10)
                .ToList();


            //     //cancelledInPastTourscount
            var cancelledInPastTours = _context.Tours
       .Where(x => x.DateFrom < DateTime.Now && x.Bookings.Any(b => b.Status == BookedTourStatus.Cancelled))
       .ToList().Count;

            //FullyBookedPastToursCount
            var fullyBookedPastToursCount = _context.Tours

    .Select(t => t.DateFrom < DateTime.Now && t.Bookings.Any(b => b.Status == BookedTourStatus.Booked) && t.BookingsCount == t.Capacity).ToList().Count;



            //UpComingTours

            var UpComingToursList = _context.Tours.Where(x => x.Bookings.Any(b => b.Status != BookedTourStatus.Completed) && x.DateFrom > DateTime.Now).ToList();

            //FullyBookedUpcomingToursCount
            var fullyBookedupcomingToursCount = _context.Tours

    .Select(t => t.Bookings.Any(b => b.Status == BookedTourStatus.Booked) && t.BookingsCount == t.Capacity && t.DateFrom > DateTime.Now).ToList().Count;

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
        public IActionResult GetAllCards()
        {
            var tours = ITourManger.GetAllCards();

            if (tours == null)
            {
                return NotFound();
            }

            return Ok(tours);
        }

        [HttpGet("Upcoming")]
        public IActionResult GetUpcomingCards()
        {
            var tours = ITourManger.GetIsCompletedCards(false);

            if (tours == null)
            {
                return NotFound();
            }

            return Ok(tours);
        }

        [HttpGet("Past")]
        public IActionResult GetPastCards()
        {
            var tours = ITourManger.GetIsCompletedCards(true);

            if (tours == null)
            {
                return NotFound();
            }

            return Ok(tours);
        }
    }
}
