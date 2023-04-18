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
        private readonly HttpContextAccessor _HttpContextAccessor;

        public ITourRepo TourRepo { get; }
        public TourManger(ITourRepo tourRepo, 
            UserManager<SeetourUser> userManager,HttpContextAccessor _httpContextAccessor)
        {
            TourRepo = tourRepo;
            _userManager = userManager;
            _HttpContextAccessor = _httpContextAccessor;
        }
        public string GetCurrentUserId()
        {
            var userId = _HttpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId?? "82712fd4-3d4c-4569-bbb7-a29e65de36ec";
        }


        public void AddTour(AddTourDto AddTourDto)
        {
            var id = GetCurrentUserId();

            var tour = new Tour
            {
                Description = AddTourDto.Description,
                DateFrom = AddTourDto.DateFrom,
                Price = AddTourDto.Price,
                LocationFrom = AddTourDto.LocationFrom,
                LocationTo = AddTourDto.LocationTo,
                HasTransportation = AddTourDto.HasTransportation,
                LastDateToCancel = AddTourDto.LastDateToCancel,
                Capacity = AddTourDto.Capacity,
                TourGuideId = id 
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

        public TourCardDto? DetailsCard(int id)
        {
            var tour = TourRepo.GetTourById(id);


            if (tour == null)
            {
                return null;
            }

            return new TourCardDto
            {
                Url = tour.Photos.FirstOrDefault(i => i.Id == 0).Url,
                LocationTo = tour.LocationTo,
                Price = tour.Price,
                Likes = tour.Likes.ToList().Count(),
                Bookings = tour.BookingsCount,
                TourGuide = tour.TourGuide,
            };
        }
    }
}
