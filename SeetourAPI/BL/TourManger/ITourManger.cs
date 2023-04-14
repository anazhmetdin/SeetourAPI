using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Models;

namespace SeetourAPI.BL.TourManger
{
    public interface ITourManger
    {
        public IEnumerable<Tour> GetAll();
        public Tour? GetTourById(int id);
        public Tour? EditTour(int id, Tour tour);
        public void AddTour(Tour tour);
        public void DeleteTour(int id);
        public TourDetailsDto? Details(int id);

        public void EditTourBYAdmin(int id, Tour tour);
    }
}
