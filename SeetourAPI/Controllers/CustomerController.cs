using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeetourAPI.BL.CustomerManager;
using SeetourAPI.BL.ReviewManager;
using SeetourAPI.BL.TourGuideManager;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Policies;
using System.Security.Claims;
using System.Text.Json;

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

		[HttpGet("tour/cart")]
		public IActionResult GetCartTours()
		{
			var Id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

			var bookings = _customerManager.GetIsCompletedTours(Id, BookedTourStatus.Cart);

			return Ok(bookings);
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

		[HttpGet("Tour/{TourId}/Review/Check")]
		public IActionResult CheckCanReview(int TourId)
		{
			var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

			int BookedTourToReviewId = _customerManager.GetBookedTourIdToReview(TourId, UserId);

			return Ok(BookedTourToReviewId);
		}

		[HttpPost("Tour/Review")]
		public IActionResult PostReview(ICollection<IFormFile> files, [FromForm]ReviewDto review)
		{
			var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

			bool posted = _customerManager.PostReview(UserId, files, review);

			if (!posted)
			{
				return BadRequest();
			}

			return Ok();
		}

		[HttpPost("Tour/Like")]
		public IActionResult LikeTour(CustomerTourSaveDto tourLike)
		{
			var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

			bool done = _customerManager.ToggleTourLike(UserId, tourLike);

			if (!done)
			{
				return BadRequest();
			}

			return Ok();
		}

		[HttpPost("Tour/Wish")]
		public IActionResult WishTour(CustomerTourSaveDto tourWish)
		{
			var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

			bool done = _customerManager.ToggleTourWishlist(UserId, tourWish);

			if (!done)
			{
				return BadRequest();
			}

			return Ok();
		}
	}
}
