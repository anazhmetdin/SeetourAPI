using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeetourAPI.BL.FavoritesManager;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Policies;
using System.Security.Claims;

namespace SeetourAPI.Controllers
{
	public record TourGuideIdDto(string tourGuideId);

	[Route("api/[controller]")]
	[ApiController]
	[Authorize(policy:Policies.AllowCustomers)]
	public class FavoritesController : ControllerBase
	{
		private readonly IFavoritesManager _favoriteManager;

		public FavoritesController(IFavoritesManager favoriteManager)
		{
			_favoriteManager = favoriteManager;
		}


		[HttpPost]
		public IActionResult AddFavorite(TourGuideIdDto tourGuideId)
		{
			var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

			bool done = _favoriteManager.ToggleTourGuideFavorite(UserId, tourGuideId.tourGuideId, true);

			if (!done)
			{
				return BadRequest();
			}

			return Ok();
		}

		[HttpDelete("{tourGuideId}")]
		public IActionResult RemoveFavorite(string tourGuideId)
		{
			var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

			bool done = _favoriteManager.ToggleTourGuideFavorite(UserId, tourGuideId, false);

			if (!done)
			{
				return BadRequest();
			}

			return Ok();
		}

		[HttpGet("{tourGuideId}")]
		public IActionResult isFavorite(string tourGuideId)
		{
			var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

			bool favorite = _favoriteManager.isFavorite(UserId, tourGuideId);

			if (!favorite)
			{
				return BadRequest();
			}

			return Ok();
		}

		[HttpGet("tour")]
		public IActionResult GetTours([FromQuery] ToursFilterDto toursFilter)
		{
			var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

			ICollection<TourCardDto> tours = _favoriteManager.GetTours(UserId, toursFilter);

			return Ok(tours);
		}
	}
}
