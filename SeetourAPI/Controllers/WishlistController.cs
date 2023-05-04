using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeetourAPI.BL.WishlistManager;
using Microsoft.AspNetCore.Identity;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Models.Users;
using SeetourAPI.Services;
using System.Security.Claims;
using SeetourAPI.Data.Context;
using Microsoft.AspNetCore.Authorization;
using SeetourAPI.Data.Policies;


namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistManager _wishlistManager;
      
        private readonly SeetourContext _context;

        public WishlistController(IWishlistManager wishlistManager )
        {
            _wishlistManager = wishlistManager;
           
        }

        
        [HttpPost]
        public ActionResult AddToWoshlist(int tourid)
        {

            if(_wishlistManager.AddToWishlist(tourid))
               return Ok("Added");
            else
                return BadRequest("AlreadyAdded");

        }



        [HttpGet]
        [Authorize(Policy = Policies.AllowCustomers)]

        public ActionResult GetWishList()
        {
           

            var wishlist=_wishlistManager.GetCustomerToursInWishliist();
            if (wishlist is null)
                return NotFound();

            return Ok(wishlist);

        }
    }
}
