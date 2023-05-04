using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.Repos
{
    public interface IWishlistRepo
    {
        public SeetourUser GetCustomerByID(int id);
        public bool AddToWishlist(CustomerWishlist customerWishlist);
        IEnumerable<CustomerWishlist> GetCustomerToursInWishlist(string id);

        int SaveChanges();
    }
}
