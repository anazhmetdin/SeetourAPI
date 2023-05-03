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
        public Tour? GetTourById(int id);
        public Tour? EditTour(int id,Tour tour);
        public void AddTour(Tour tour);
        public void DeleteTour(int id);

        public void AddPhotos(ICollection<TourPhoto> tourPhotos);
        public void EditTourBYAdmin(int id, Tour tour);
        IEnumerable<Tour> GetTourGuideTours(string id);
		Tour? GetTourByIdLite(int tourId);
		IEnumerable<Tour> GetTourRequests();
        public bool bookTour(BookedTour bookedTour);
        public Tour? GetTourByIdLite2(int id);

        bool SaveChanges();
	}
}
