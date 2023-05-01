﻿using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;
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
      

        public void EditTourBYAdmin(int id, Tour tour);
        IEnumerable<Tour> GetTourGuideTours(string id);
		IEnumerable<Tour> GetTourRequests();
		bool UpdatePostingStatus(int tourId, TourPostingStatus status);
		bool SaveChanges();
	}
}
