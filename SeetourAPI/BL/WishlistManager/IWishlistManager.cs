using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Models;

namespace SeetourAPI.BL.WishlistManager
{
    public interface IWishlistManager
    {
        public bool AddToWishlist(int  tourid);
        ICollection<WishlistToursDto> GetCustomerToursInWishliist();
    }
}
