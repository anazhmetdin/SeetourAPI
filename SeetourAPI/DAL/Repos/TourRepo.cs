﻿using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models.Photos;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Enums;

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
        public void AddPhotos(ICollection<TourPhoto> tourPhotos)
        {
            _Context.TourPhoto.AddRange(tourPhotos);
            _Context.SaveChanges();
        }


        public void DeleteTour(int id)
        {

            var tour = _Context.Tours.Find(id);
            if (tour != null)
            {
                if (tour.TourPostingStatus == Data.Enums.TourPostingStatus.Accepted)
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
                    t.LocationFrom = tour.LocationFrom;
                    t.LocationTo = tour.LocationTo;
                    t.LocationToUrl = tour.LocationToUrl;
                    t.LocationFromUrl = tour.LocationFromUrl;
                    t.Category = tour.Category;
                    t.HasTransportation = tour.HasTransportation;
                    t.LastDateToCancel = tour.LastDateToCancel;
                    t.Capacity = tour.Capacity;
                    t.TourGuideId = tour.TourGuideId;
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
                    t.TourPostingStatus = tour.TourPostingStatus;
                    _Context.SaveChanges();
                }
            }
        }
        public IEnumerable<Tour> GetAll()
        {
            var tours = _Context.Tours
                .Include(t => t.Photos)
                .Include(t => t.Likes)
                .Include(t => t.Wishlist)
                .Include(t => t.Bookings)
                .Include(t => t.TourGuide)
                .ThenInclude(t => t!.User);
            return tours;
        }
        public IEnumerable<Tour> GetAllLite()
        {
            var tours = _Context.Tours
                .Include(t => t.Photos)
                .Include(t => t.Likes)
                .Include(t => t.Wishlist)
                .Include(t => t.TourGuide)
                .ThenInclude(t => t!.User);
            return tours;
        }

        public Tour? GetTourById(int id)
        {
            var tour = _Context.Tours
                .Include(a => a.Photos)
                .Include(a => a.Likes)
                .Include(t => t.Wishlist)
                .Include(a => a.Questions)
                .Include(a => a.Bookings)
                .ThenInclude(a => a.Review)
                .Include(a => a.TourGuide)
                .ThenInclude(a => a.User)
                .FirstOrDefault(a => a.Id == id);

            if (tour != null)
            {
                return tour;

            }
            else return null;
        }

        public IEnumerable<Tour> GetTourGuideTours(string id)
        {
            return _Context.Tours
                .Include(t => t.Photos)
                .Include(t => t.Likes)
                .Include(t => t.Wishlist)
                .Where(t => t.TourGuideId == id);
        }

        public IEnumerable<Tour> GetTourRequests()
        {
            return _Context.Tours
                .Include(t => t.TourGuide)
                .ThenInclude(t => t!.User)
                .Include(t => t.Photos)
                .Where(t => t.TourPostingStatus == TourPostingStatus.Pending);
        }

        public bool SaveChanges()
        {
            return _Context.SaveChanges() > 0;
        }

		public Tour? GetTourByIdLite(int tourId)
		{
			return _Context.Tours.Find(tourId);
		}

		public Tour? GetTourByIdLiteIncluded(int tourId)
		{
			return _Context.Tours
				.Include(t => t.Photos)
				.Include(t => t.Likes)
				.Include(t => t.Wishlist)
				.Include(t => t.TourGuide)
				.ThenInclude(t => t!.User)
				.FirstOrDefault(t => t.Id == tourId);
		}

        public bool bookTour(BookedTour bookedTour)
        {
            if (_Context.BookedTours.FirstOrDefault(t => t.CustomerId == bookedTour.CustomerId) != null)
            {
                return false;
            }
            _Context.BookedTours.Add(bookedTour);
            //_Context.SaveChanges();
            return SaveChanges();
        }

        public Tour? GetTourByIdLite2(int id)
        {
            var tour = _Context.Tours
                .Include(a => a.Photos)
                .Include(a => a.Questions)
                .Include(a => a.Bookings)
                .ThenInclude(a => a.Review)
                .FirstOrDefault(a => a.Id == id);

            if (tour != null)
            {
                return tour;

            }
            else return null;
        }
    }
}
