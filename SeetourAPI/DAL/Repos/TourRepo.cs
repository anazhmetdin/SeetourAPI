using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.Repos
{
    public class TourRepo : ITourRepo
    {
        private readonly SeetourContext _Context;

        public TourRepo(SeetourContext context)
        {
            this._Context = context;
        }
        public void AddTour(Tour tour)
        {
            _Context.Tours.Add(tour);
            _Context.SaveChanges();
        }

        public void DeleteTour(int id)
        {

            var tour = _Context.Tours.Find(id);
            if (tour != null)
            {
              if(tour.TourPostingStatus==Data.Enums.TourPostingStatus.Accepted)
                {
                    return;
                }
                _Context.Tours.Remove(tour);

                _Context.SaveChanges();
            }
        }

        

        public Tour? EditTour(int id, Tour tour)
        {
            if (tour.Id == id)
            {
                var t = _Context.Tours.Find(id);
                if (t != null)
                {
                    t.Title = tour.Title;
                    t.Description = tour.Description;
                    t.DateFrom = tour.DateFrom;
                    t.DateTo = tour.DateTo;
                    t.Price = tour.Price;
                    t.LocationFrom= tour.LocationFrom;
                    t.LocationTo= tour.LocationTo;
                    t.LocationToUrl= tour.LocationToUrl;
                    t.LocationFromUrl= tour.LocationFromUrl;
                    t.Category= tour.Category;
                    t.HasTransportation= tour.HasTransportation;
                    t.LastDateToCancel= tour.LastDateToCancel; 
                    t.Capacity= tour.Capacity;
                    t.TourGuideId= tour.TourGuideId;
                    _Context.SaveChanges();
                    return tour;        
                }
            }
            return new Tour();
        }

        public void EditTourBYAdmin(int id, Tour tour)
        {
            if (tour.Id == id)
            {
                var t = _Context.Tours.Find(id);
                if (t != null)
                {
                    t.TourPostingStatus= tour.TourPostingStatus;
                    _Context.SaveChanges();
                }
            }
        }
        public IEnumerable<Tour> GetAll()
        {
            var tours = _Context.Tours.ToList();
            return tours;
        }

        public Tour? GetTourById(int id)
        {
            var tour= _Context.Tours.Find(id);
            if(tour != null)
            { 
                return tour;

            }
            else return new Tour();
        }


    }
}
