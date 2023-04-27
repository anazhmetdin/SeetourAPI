using SeetourAPI.Data.Models;
using System.Numerics;

namespace SeetourAPI.DAL.Repos
{
    public interface ITourRepo
    {
       public IEnumerable<Tour> GetAll();
        public Tour? GetTourById(int id);
        public Tour? EditTour(int id,Tour tour);
        public void AddTour(Tour tour);
        public void DeleteTour(int id);
      

        public void EditTourBYAdmin(int id, Tour tour);
    }
}
