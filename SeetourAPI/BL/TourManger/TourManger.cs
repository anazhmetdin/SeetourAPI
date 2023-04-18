using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Models;

namespace SeetourAPI.BL.TourManger
{
    public class TourManger : ITourManger
    {
        public ITourRepo TourRepo { get; }
        public TourManger(ITourRepo tourRepo)
        {
            TourRepo = tourRepo;
        }


        public void AddTour(Tour tour)
        {
            TourRepo.AddTour(tour);
        }

        public void DeleteTour(int id)
        {
           TourRepo.DeleteTour(id);
        }

        public Tour? EditTour(int id, Tour tour)
        {
          return TourRepo.EditTour(id, tour);
        }

        public void EditTourBYAdmin(int id, Tour tour)
        {
            TourRepo.EditTourBYAdmin(id, tour);
        }

        public IEnumerable<Tour> GetAll()
        {
          return TourRepo.GetAll();
        }

        public Tour? GetTourById(int id)
        {
            return TourRepo.GetTourById(id);
        }
    }
}
