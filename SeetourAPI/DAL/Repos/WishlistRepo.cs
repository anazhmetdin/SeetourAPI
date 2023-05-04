using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.Repos
{
    public class WishlistRepo : IWishlistRepo
    {
        #region Injection
        private readonly SeetourContext _context;

        public WishlistRepo(SeetourContext context)
        {
            _context = context;
        }
        #endregion


        #region AddToWishList
        public bool AddToWishlist(CustomerWishlist customerWishlist)
        {
            var cuswishlist = _context.CustomerWishlists.FirstOrDefault(w => w.CustomerId == customerWishlist.CustomerId && w.TourId==customerWishlist.TourId);
            if(cuswishlist != null) 
            { 
            
            return false;
            }
               _context.CustomerWishlists.Add(customerWishlist);
                _context.SaveChanges();
                return true;
        }

        public SeetourUser GetCustomerByID(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region GetCustomerWisList
        public IEnumerable<CustomerWishlist> GetCustomerToursInWishlist(string id)
        {
            return _context.CustomerWishlists.
                Where(x => x.CustomerId == id).
                Include(x=>x.Customer).
                ThenInclude(x=>x.User).
                Include(x => x.Tour).
                 ThenInclude(p => p.Photos).
                Include(x => x.Tour).
                 ThenInclude(p => p.TourGuide).
                  ThenInclude(s => s.User);
                
                
        }
        #endregion
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }



    }
}
