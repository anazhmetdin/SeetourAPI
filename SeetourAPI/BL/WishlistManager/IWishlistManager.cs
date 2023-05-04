using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Models;

namespace SeetourAPI.BL.WishlistManager
{
    public interface IWishlistManager
    {
        public string AddToWishlist(int  tourid);
        ICollection<WishlistToursDto> GetCustomerToursInWishliist();
    }
}
