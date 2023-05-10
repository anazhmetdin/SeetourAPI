using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeetourAPI.BL.AdminManger;
using SeetourAPI.BL.ReviewManager;
using SeetourAPI.BL.TourGuideManager;
using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
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
    public class AdminController : ControllerBase
    {
        private readonly IAdminManger _adminManager;
        private readonly ITourRepo _tourRepo;
        private readonly IReviewManager _reviewManger;
        private readonly ITourGuideManager _tourGuideManager;
        private readonly SeetourContext _context;

		public AdminController(SeetourContext context, IAdminManger adminManager, ITourGuideManager tourGuideManager, ITourRepo tourRepo,IReviewManager reviewManager)
		{
			_context = context;
			_adminManager = adminManager;
			_tourGuideManager = tourGuideManager;
			_tourRepo = tourRepo;
            _reviewManger = reviewManager;
        }

		[HttpGet("allUsers")]
        public ActionResult<IEnumerable<SeetourUser>> GetAllUser()
        {
            var users = _context.Users.ToList();
            return Ok(users);
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
            return Ok(_adminManager.GetSeeTourUserById(id));
        }

		[HttpGet("Tour/Request")]
		public IActionResult GetTourRequests()
		{
			return Ok(_adminManager.GetTourRequests());
		}

		[HttpPost("Tour/Request")]
		public IActionResult EditPostRequest(AdminTourPostRequestDto postRequestDto)
		{
			if (_adminManager.UpdateTourStatus(postRequestDto))
				return NoContent();

			return BadRequest();
		}

		[HttpGet("Tour/isPending/{tourId}")]
		public IActionResult isTourPending(int tourId)
		{
            var tour = _tourRepo.GetTourByIdLite(tourId);
			
            if (tour == null || tour.TourPostingStatus != TourPostingStatus.Pending)
				return BadRequest();

			return Ok();
		}

		[HttpGet("TourGuide/Applicant")]
		public IActionResult GetApplicants()
		{
			return Ok(_tourGuideManager.GetApplicants());
		}

		[HttpGet("TourGuide/Applicant/{Id}")]
		public IActionResult GetApplicants(string Id)
		{
			var applicant = _tourGuideManager.GetApplicant(Id);

            if (applicant == null)        
     			return NotFound();

			return Ok(applicant);
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

            var tour = _context.Tours
                .Where(t => t.Id == mostBookedTour)
                .Select(t => new { Title = t.Title })
                .FirstOrDefault();

            if (tour != null)
            {
                return Ok(tour);
            }
            else
            {
                return Ok("");
            }
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
            .Where(t => t.Status == BookedTourStatus.Cancelled && t.Tour.LastDateToCancel < DateTime.Now).Count();
            int completed = _context.BookedTours.Select(a => a.Status == BookedTourStatus.Completed).Count();

            decimal refundRate = completed == 0 ? 0 : ((decimal)Refunded / completed) * 100;
            refundRate = Math.Round(refundRate, 2);
            return Ok( refundRate);
        }



        [HttpGet("TourGuideName")]
        public IActionResult Search(string Name)
        {

            var matchedUsers = _context.Users.Where(s=>s.SecurityLevel.ToLower()=="tourguide")
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
        [HttpDelete("reviewDelete")]
        
        [Authorize(Policy = Policies.AllowAdmins)]
        public ActionResult DeleteReview(int id)
        {
            _reviewManger.DeleteReview(id);
            return NoContent();
        }




        [HttpPost("tourguidesBlock")]
      
        public IActionResult BlockTourGuide(string id)
        {
            // Call the service method to block the tour guide with the given id
            var tourguide = _context.TourGuides.FirstOrDefault(i=>i.Id==id);
            if (tourguide != null)
            {
                tourguide.Status = TourGuideStatus.Blocked;
                _context.SaveChanges();
                return Ok(new { message = "Blocked" });
            }
            else
                return BadRequest("userNotFound");

          
        }

        [HttpPost("tourguidesUnblock")]
        public IActionResult UnblockTourGuide(string id)
        {
            // Call the service method to block the tour guide with the given id
            var tourguide = _context.TourGuides.FirstOrDefault(i=>i.Id==id);
            if (tourguide != null)
            {
                tourguide.Status = TourGuideStatus.Accepted;
                _context.SaveChanges();
                return Ok(new { message = "UnBlocked" });
            }
            else
                return BadRequest("userNotFound");

        }


        [HttpPost("CustomersBlock")]
        public  IActionResult BlockCustomer(string id)
        {
            var customer =  _context.Customers.FirstOrDefault(u => u.Id == id);
            if (customer != null)
            {
                customer.IsBlocked = true;
                _context.SaveChanges();
                return Ok(new { message = "Blocked" });

            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost("CustomersUnblock")]
        public IActionResult UnBlockCustomer(string id)
        {
            // Call the service method to block the tour guide with the given id
            var customer = _context.Customers.FirstOrDefault(i=>i.Id==id);
            if (customer != null)
            {
                customer.IsBlocked = false;
                _context.SaveChanges();
                return Ok(customer);
            }
            else
                return BadRequest("userNotFound");


        }







        [HttpGet("GettingAllBlockedCustomers")]
        public IActionResult GettingBlockedCustomers ()
        {
            var Customers = _context.Users.Where(c => c.Customer.IsBlocked == true);
            if (Customers != null)
            {
                return Ok(Customers);
            }
            else
                return BadRequest("NoUsers");
        }


        [HttpGet("GettingAllUnblockedCustomers")]
        public IActionResult GettingUnBlockedCustomers()
        {
            var Customers = _context.Users.Where(c => c.Customer.IsBlocked == false);
            if (Customers != null)
            {
                return Ok(Customers);
            }
            else
                return BadRequest("NoUsers");
        }


        [HttpGet("GettingBlockedTourGuides")]
        public IActionResult GettingBlockedTourGuides()
        {
            var TourGuides = _context.Users.Where(c => c.TourGuide.Status==TourGuideStatus.Blocked);
            if (TourGuides != null)
            {
                return Ok(TourGuides);
            }
            else
                return BadRequest("NoUsers");
        }


        [HttpGet("GettingAllUnblockedTourGuides")]
        public IActionResult GettingAllUnblockedTourGuides()
        {
            var TourGuides = _context.Users.Where(c => c.TourGuide.Status == TourGuideStatus.Accepted);
            if (TourGuides != null)
            {
                return Ok(TourGuides);
            }
            else
                return BadRequest("NoUsers");
        }





    }

}
