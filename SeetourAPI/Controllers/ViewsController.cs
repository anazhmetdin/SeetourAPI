using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeetourAPI.BL.AdminManger;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly SeetourContext _context;

        public DashBoardController(IAdminManger adminManager, SeetourContext context)
        {
           
          
            _context = context;
        }




        [HttpPost("incrementviews")]
        public async Task<IActionResult> IncrementViews()
        {
            // Retrieve the WebsiteViews instance from the database
            var websiteViews = _context.Views.FirstOrDefault();

            if (websiteViews == null)
            {
                // If there are no records in the database, create a new one with Views set to 1
                websiteViews = new Views { ViewsNo = 1 };
                _context.Views.Add(websiteViews);
            }
            else
            {
                // Otherwise, increment the Views property and update the record
                websiteViews.ViewsNo++;
                _context.Update(websiteViews);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the updated views count as integer value
            return Ok(websiteViews.ViewsNo);
        }



        [HttpGet("websiteviews")]
        public async Task<IActionResult> GetWebsiteViews()
        {
            // Retrieve the WebsiteViews instance from the database
            var websiteViews = await _context.Views.FirstOrDefaultAsync();

            if (websiteViews == null)
            {
                // If there are no records in the database, return 0 views
                return Ok(0);
            }

            // Return the views count
            return Ok(websiteViews.ViewsNo);
        }



        [HttpGet("CompletedTours")]
        public IActionResult GetCompletedTours()
        {
            var completed = _context.Tours.Select(a => a.DateFrom < DateTime.UtcNow).Count();

            return Ok(completed);
        }



        [HttpGet("TopTourRevenueName")]
        public IActionResult GetTopTourRevenue()
        {
            var mostBookedTour = _context.BookedTours
                .GroupBy(bt => bt.TourId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            var tour = _context.Tours.FirstOrDefault(t => t.Id == mostBookedTour);
            if(tour != null)
            {
            return Ok(tour.Title);

            }
            else
                return Ok("");
        }



        [HttpGet("TopTourRevenueMoney")]
        public IActionResult GetTopTourRevenueDollers()
        {
            var mostBookedTour = _context.BookedTours
                .GroupBy(bt => bt.TourId)
                .OrderByDescending(g => g.Count())
                .Select (g => new {tourid=g.Key ,tourCount=g.Count()} )
                .FirstOrDefault();

            var tour = _context.Tours.FirstOrDefault(t => t.Id == mostBookedTour.tourid);
            if (tour != null)
            {
                return Ok(tour.Price*mostBookedTour.tourCount);

            }
            else
                return Ok("");
        }



      
        [HttpGet("refundRate")]
        public IActionResult RefundPerformance()
        {
            int Refunded = _context.BookedTours
            .Where(t => t.Status == BookedTourStatus.Cancelled
            && t.Tour.LastDateToCancel < DateTime.Now).Count();
            int completed = _context.BookedTours.Select(a => a.Status == BookedTourStatus.Completed).Count();

            decimal refundRate = completed == 0 ? 0 : ((decimal)Refunded / completed) * 100;

            return Ok($"Refund rate: {refundRate}%");
        }


        [HttpPost("TourGuideName")]
        public IActionResult Search(string Name)
        {

            var matchedUsers = _context.Users
                 .Where(u => u.FullName.ToLower().Contains(Name.ToLower()))
                 .Select(u => u.FullName)
                 .ToList();

            if (matchedUsers.Count > 0)
            {
                return Ok(matchedUsers);
            }
            else
                return Ok("");

            


        }





    }
}
