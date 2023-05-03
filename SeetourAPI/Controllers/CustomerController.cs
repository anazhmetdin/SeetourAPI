using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeetourAPI.BL.CustomerManager;
using SeetourAPI.BL.ReviewManager;
using SeetourAPI.BL.TourGuideManager;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Policies;
using System.Security.Claims;

namespace SeetourAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(policy:Policies.AllowCustomers)]
	public class CustomerController : ControllerBase
	{
		private readonly IReviewManager _reviewManager;
		private readonly ICustomerManager _customerManager;

		public CustomerController(IReviewManager reviewManager, ICustomerManager customerManager)
		{
			_reviewManager = reviewManager;
			_customerManager = customerManager;
		}

		[HttpGet("tour/upcoming")]
		public IActionResult GetUpcomingBookedTours()
		{
			var Id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

			var bookings = _customerManager.GetIsCompletedTours(Id, BookedTourStatus.Booked);

			return Ok(bookings);
		}

		[HttpGet("tour/completed")]
		public IActionResult GetCompletedBookedTours()
		{
			var Id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

			var bookings = _customerManager.GetIsCompletedTours(Id, BookedTourStatus.Completed);

			return Ok(bookings);
		}

		[HttpGet("tour/cancelled")]
		public IActionResult GetCancelledBookedTours()
		{
			var Id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

			var bookings = _customerManager.GetIsCompletedTours(Id, BookedTourStatus.Cancelled);

			return Ok(bookings);
		}
	}
}
