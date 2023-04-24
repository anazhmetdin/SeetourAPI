using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeetourAPI.BL.TourManger;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Context.DTOs;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ILogger<TourController> _logger;
        private readonly SeetourContext _context;

        public ITourManger ITourManger { get; }
        public TourController(ITourManger ITourManger, ILogger<TourController> logger, SeetourContext context)
        {
            this.ITourManger = ITourManger;
            _logger = logger;
            _context = context;
        }
        [HttpPost]
        public ActionResult CreateTour(Tour tour)
        {
            ITourManger.AddTour(tour);
            return Created("", tour);
        }
        [HttpPut]
        public ActionResult EditTour(int id, Tour tour)
        {
            if (tour.Id != id)
            {
                return BadRequest();
            }
            else
            {
                ITourManger.EditTour(id, tour);
                return Ok();
            }
        }
        [HttpDelete]
        public ActionResult DeleteTour(int id)
        {
            ITourManger.DeleteTour(id);
            return NoContent();
        }
        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById(int id)
        {
            var t = ITourManger.GetTourById(id);
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
            if (tours == null)
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
                return Ok(ITourManger.Details(id));

            }
            return NotFound();
        }

        [HttpGet]
        [Route("Getbooks")]
        public IActionResult TourGuidStatistics()
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


            //UpcomingToursInCartList
            var ToursInCartList = _context.Tours
            .Where(t => t.Bookings.Any(b => b.Status == BookedTourStatus.Cart) && t.DateFrom > DateTime.Now)
            .ToList();




            var DashboardObj = new TourGuideStatistics
            {

                //The PastTours Count
                PastToursCount = PastToursList.Count(),

                //The Top10Tours Order By Rate
                Top10Tours = Top10Tourss,

                //cancelledInPastTourscount
                CancelledInPastTourscount = cancelledInPastTours,

                // Get the total price of all Past tours
                TotalPastToursPrice = PastToursList.Sum(x => x.Price),

                //// Get the average price of all Past tours
                AvgPastoursPrice = PastToursList.Average(t => t.Price),


                //UpComingTousCount
                UpComingToursCount = UpComingToursList.Count(),

                // Get the total price of all upcoming tours
                TotalUpcomingToursPrice = UpComingToursList.Sum(t => t.Price),

                // Get the average price of all upcoming tours
                AvgUpcomingToursPrice = UpComingToursList.Average(t => t.Price),

                // Get the total number of seats available in all upcoming tours
                TotalUpcomingTourSeats = UpComingToursList.Sum(t => t.Capacity),

                // Get the average number of seats available per upcoming tour
                avgUpcomingTourSeats = (decimal)UpComingToursList.Average(t => t.Capacity),

                //FullyBookedPastToursCount
                FullyBookedPastToursCount = fullyBookedPastToursCount,
                //FullyBookedPastToursCount
                FullyBookedUpcomingToursCount = fullyBookedupcomingToursCount,

                //ToursInCartCount

                ToursInCartCount = ToursInCartList.Count


            };

            return Ok(DashboardObj);
        }
    }
}
