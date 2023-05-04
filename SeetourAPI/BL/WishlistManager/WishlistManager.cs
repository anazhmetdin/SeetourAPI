using Castle.Core.Resource;
using Microsoft.AspNetCore.Identity;
using SeetourAPI.BL.TourManger;
using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;
using System.Security.Claims;

namespace SeetourAPI.BL.WishlistManager
{
    public class WishlistManager : IWishlistManager
    {

        #region Injection
        private readonly IWishlistRepo _wishlistRepo;
        private readonly ITourRepo _tourRepo;
        private readonly UserManager<SeetourUser> _userManager;
        private readonly HttpContextAccessor _HttpContextAccessor;
        public WishlistManager(IWishlistRepo wishlistRepo, ITourRepo tourRepo, UserManager<SeetourUser> userManager, HttpContextAccessor _httpContextAccessor)
        {
            _wishlistRepo = wishlistRepo;
            _tourRepo = tourRepo;
            _userManager = userManager;
            _HttpContextAccessor = _httpContextAccessor;

        }
        #endregion

        # region GetcurrentuserId
        private string GetCurrentUserId()
        {
            var userId = _HttpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId ?? "82712fd4-3d4c-4569-bbb7-a29e65de36ec";
        }
        #endregion
        public bool AddToWishlist(int tourid)
        {
            string cusId = GetCurrentUserId();
                var wishlist = new CustomerWishlist
                {
                    CustomerId = cusId,
                    TourId = tourid
                };


                if (_wishlistRepo.AddToWishlist(wishlist))
                {
                    return true;
                }
                return false;

            

        }


        public ICollection<WishlistToursDto> GetCustomerToursInWishliist()
        {
            var id = GetCurrentUserId();
            var wishliist = _wishlistRepo.GetCustomerToursInWishlist(id);
            if (wishliist is null)
            {
                return null;
            }

            return _wishlistRepo.GetCustomerToursInWishlist(id).Select(wishlist).ToList();
            //var x= _wishlistRepo.GetCustomerToursInWishlist(id).
        }
        private WishlistToursDto wishlist(CustomerWishlist customerWishlist)
        {
            return new WishlistToursDto
            (
                id: customerWishlist?.Id ?? 0,
                tourId: customerWishlist?.Tour?.Id ?? 0,
                tourGuideId: customerWishlist?.Tour?.TourGuideId ?? "N/A",
                capacity: customerWishlist?.Tour?.Capacity ?? 0,
                price: customerWishlist?.Tour?.Price ?? 0,
                customername: customerWishlist?.Customer?.User?.FullName ?? "N/A",
                title: customerWishlist?.Tour?.Title ?? "N/A",
                tourGuidename: customerWishlist?.Tour?.TourGuide?.User?.FullName ?? "N/A",
                photoUrl: customerWishlist?.Tour?.Photos?.FirstOrDefault()?.Url ?? "N/A"
            );
        }
    }
}
