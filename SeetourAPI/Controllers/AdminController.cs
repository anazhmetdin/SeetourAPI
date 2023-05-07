using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeetourAPI.BL.AdminManger;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;
using SeetourAPI.Data.Policies;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Policy = Policies.AllowAdmins)]
    public class DashboardController : ControllerBase
    {
        private readonly IAdminManger _adminManager;
        private readonly SeetourContext _context;

        public DashboardController(IAdminManger adminManager,SeetourContext context)
        {
            _adminManager = adminManager;
            _context = context;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<SeetourUser>> GetAllUsers()
        {
            var users = _adminManager.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<SeetourUser> GetUserById(string id)
        {
            var user = _adminManager.GetSeeTourUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("users")]
        public ActionResult<IEnumerable<SeetourUser>> GetUsers()
        {
            var users = _adminManager.GetUsers();
            return Ok(users);
        }

        [HttpGet("guides")]
        public ActionResult<IEnumerable<SeetourUser>> GetTourGuides()
        {
            var guides = _adminManager.GetTourGuides();
            return Ok(guides);
        }

        [HttpPut("{id}/role")]
        public ActionResult UpdateRole(string id, [FromBody] string securitylevel)
        {
            _adminManager.updateRole(id, securitylevel);
            return NoContent();
        }

        [HttpPut("{id}/customer")]
        public ActionResult EditCustomer(string id, [FromBody] SeetourUser seetourUser)
        {
            _adminManager.EditCustomer(id, seetourUser);
            return NoContent();
        }

        [HttpPut("{id}/tourguide")]
        public ActionResult EditTourGuide(string id, [FromBody] SeetourUser seetourUser)
        {
            _adminManager.EditTourGuide(id, seetourUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSeeTourUser(string id)
        {
            _adminManager.DeleteSeeTourUser(id);
            return NoContent();
        }




        

			return Ok();
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
        public IActionResult GetWebsiteViews()
        {
            // Retrieve the WebsiteViews instance from the database
            var websiteViews = _context.Views.FirstOrDefault();

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
            if (tour != null)
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
                .Select(g => new { tourid = g.Key, tourCount = g.Count() })
                .FirstOrDefault();

            var tour = _context.Tours.FirstOrDefault(t => t.Id == mostBookedTour.tourid);
            if (tour != null)
            {
                return Ok(tour.Price * mostBookedTour.tourCount);

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
