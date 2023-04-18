using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;
using System.Security.Claims;

namespace SeetourAPI.BL.TourManger
{
    public class TourManger : ITourManger
    {
        private readonly UserManager<SeetourUser> _userManager;

        public ITourRepo TourRepo { get; }
        public TourManger(ITourRepo tourRepo, UserManager<SeetourUser> userManager)
        {
            TourRepo = tourRepo;
            _userManager = userManager;
        }


        public void AddTour( AddTourDto AddTourDto)
        {
            var userId = (_userManager.GetUserId(ClaimsPrincipal.Current))?? "default";
            var tour = new Tour
            {
                Title = AddTourDto.Title,
                Description = AddTourDto.Description,
                DateFrom = AddTourDto.DateFrom,
                DateTo = AddTourDto.DateTo,
                Price = AddTourDto.Price,
                LocationFromUrl = AddTourDto.LocationFromUrl,
                LocationFrom = AddTourDto.LocationFrom,
                LocationToUrl = AddTourDto.LocationToUrl,
                LocationTo = AddTourDto.LocationTo,
                Category = AddTourDto.Category,
                HasTransportation = AddTourDto.HasTransportation,
                LastDateToCancel = AddTourDto.LastDateToCancel,
                Capacity = AddTourDto.Capacity,
                TourPostingStatus = AddTourDto.TourPostingStatus,
                CreatedAt = AddTourDto.CreatedAt,
                PostedAt = AddTourDto.PostedAt,
                TourGuideId = userId??"default"
        };

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
        public TourDetailsDto? Details(int id)
        {
            var tour = TourRepo.GetTourById(id);
            if (tour != null)
            {
                var tourDetails = TourRepo.GetAll()
                .Where(t => t.Id == tour.Id)
                .Select(t => new TourDetailsDto
                {
                    Likes = t.Likes,
                    Wishlist = t.Wishlist,
                    Bookings = t.Bookings
                })
                .FirstOrDefault();
                return tourDetails;
            }
            return new TourDetailsDto();
        }

        public  TourCardDto? DetailsCard(int id)
        {
            var tour =  TourRepo.GetTourById(id);
      

            if (tour == null)
            {
                return null;
            }

            return new TourCardDto
            {
                Url = tour.Photos.FirstOrDefault(i=>i.Id==0).Url,
                LocationTo = tour.LocationTo,
                Price = tour.Price,
                Likes = tour.Likes.ToList().Count(),
                Bookings = tour.BookingsCount,
                TourGuide = tour.TourGuide,
            };
        }
    }
}
