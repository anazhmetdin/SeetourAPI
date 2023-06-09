using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Photos;
using System.Numerics;

namespace SeetourAPI.DAL.Repos
{
    public interface ITourRepo
    {
        public IEnumerable<Tour> GetAll();
        public IEnumerable<Tour> GetAllLite();
        public IEnumerable<Tour> GetAllPlain();
		public Tour? GetTourById(int id);
        public Tour? EditTour(int id,Tour tour);
        public int AddTour(Tour tour);
        public void DeleteTour(int id);

        public void AddPhotos(ICollection<TourPhoto> tourPhotos);
        public void EditTourBYAdmin(int id, Tour tour);
		IEnumerable<Tour> GetTourGuideTours(string id);
		IEnumerable<Tour> GetTourGuideToursLite(string id);
		Tour? GetTourByIdLite(int tourId);
		IEnumerable<Tour> GetTourRequests();
		bool SaveChanges();
		bool UpdatePostingStatus(int tourId, TourPostingStatus status);

       // bool SaveChanges();
        public bool bookTour(BookedTour bookedTour);
        public Tour? GetTourByIdLite2(int id);

		Tour? GetTourByIdLiteIncluded(int tourId);

        public IEnumerable<CustomerLikes> GetTourLikes(int tourId);
        public IEnumerable<CustomerWishlist> GetTourWishlist(int tourId);

		public IEnumerable<TourPhoto> GetTourPhotos(int tourId);
		void RemoveTourLike(CustomerLikes customerLike);
		void AddTourLike(string userId, int tourId);
		void RemoveTourWish(CustomerWishlist tourWishedBefore);
		void AddTourWish(string userId, int tourId);
		IEnumerable<Tour> GetTrendingPlain();
	}
}
