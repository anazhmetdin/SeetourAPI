using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeetourAPI.BL.BookingManager;
using SeetourAPI.BL.CustomerManager;
using SeetourAPI.BL.Filters;
using SeetourAPI.BL.ReviewManager;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Policies;
using System.Security.Claims;

namespace SeetourAPI.Controllers
{
    [TypeFilter(typeof(TourGuideFilter))]
    [TypeFilter(typeof(CustomerFilter))]
    [Route("api/[controller]")]
	[ApiController]
	[Authorize(policy: Policies.AllowCustomers)]
	public class BookingController : ControllerBase
	{
		private readonly IBookingManager _bookingManager;

		public BookingController(IBookingManager bookingManager)
		{
			_bookingManager = bookingManager;
		}

		[HttpDelete("{Id}")]
		public IActionResult CancelBooking(int Id)
		{
			var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

			bool done = _bookingManager.CancelBooking(UserId, Id);

			if (!done)
			{
				return BadRequest();
			}

			return Ok();
		}
	}
}
