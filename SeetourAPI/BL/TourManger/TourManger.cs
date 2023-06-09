﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SeetourAPI.BL.CustomerManager;
using SeetourAPI.BL.TourGuideManager;
using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Photos;
using SeetourAPI.Data.Models.Users;
using SeetourAPI.Services;
using System;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SeetourAPI.BL.TourManger
{
    public class TourManger : ITourManger
    {
        private readonly UserManager<SeetourUser> _userManager;
        private readonly HttpContextAccessor _HttpContextAccessor;
        private readonly ToursHandler _handler;
        private readonly SeetourContext context;
        private readonly ITourGuideManager tourGuideManager;
        private readonly ICustomerManager customerManager;

        public ITourRepo TourRepo { get; }
        public TourManger(SeetourContext context,ITourGuideManager tourGuideManager, ICustomerManager customerManager, ITourRepo tourRepo,
            UserManager<SeetourUser> userManager, HttpContextAccessor _httpContextAccessor, ToursHandler filter)
        {
            this.context = context;
            this.tourGuideManager = tourGuideManager;
            this.customerManager = customerManager;
            TourRepo = tourRepo;
            _userManager = userManager;
            _HttpContextAccessor = _httpContextAccessor;
            _handler = filter;
        }
        public string GetCurrentUserId()
        {
            var userId = _HttpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId ?? "82712fd4-3d4c-4569-bbb7-a29e65de36ec";
        }


        public int AddTour(AddTourDto AddTourDto)
        {
            string id = GetCurrentUserId();

            var tour = new Tour
            {
                Id=0,
                Description = AddTourDto.Description,
                DateFrom = AddTourDto.DateFrom,
                Price = AddTourDto.Price,
                LocationFrom = AddTourDto.LocationFrom,
                LocationTo = AddTourDto.LocationTo,
                HasTransportation = AddTourDto.HasTransportation,
                LastDateToCancel = AddTourDto.LastDateToCancel,
                Capacity = AddTourDto.Capacity,
                Category = AddTourDto.category,
                LocationFromUrl = AddTourDto.LocationFromUrl,
                LocationToUrl = AddTourDto.LocationToUrl,
                DateTo = AddTourDto.dateTo,
                Title = AddTourDto.Title,
                Photos = AddTourDto.Photos.Select(a => new TourPhoto
                {
                    Id = a.Id,
                    PhotoId = a.PhotoId,
                    TourId = a.TourId,

                }


                ).ToList(),
                TourGuideId = id
            };
            
            int tourid= TourRepo.AddTour(tour);
            return tourid;
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
            (
                Id: tour.Id,
                Photos: tour.Photos.Select(p => p.Url).ToArray(),
                LocationTo: tour.LocationTo,
                Price: tour.Price,
                Likes: tour.Likes.Count,
                isLiked: false,
                Bookings: tour.BookingsCount,
                Capacity: tour.Capacity,
                TourGuideId: tour.TourGuideId,
                TourGuideName: tour.TourGuide?.User?.FullName ?? "",
                TourGuideRating: (int)tour.Rating,
                TourGuideRatingCount: tour.RatingCount,
                DateFrom: tour.DateFrom.Date.ToString(),
                DateTo: tour.DateTo.Date.ToString(),
                Category: tour.Category.ToString(),
                Title: tour.Title,
                AddedToWishList: false
            //,hasTransportation:false
            );
        }

        public ICollection<TourCardDto> GetAllCards(ToursFilterDto toursFilter)
		{
			var tours = TourRepo.GetAllPlain()
				.Where(t => t.TourPostingStatus == TourPostingStatus.Accepted);

			return _handler.ReattachToursInfo(toursFilter, tours);
		}

		public ICollection<TourCardDto> GetIsCompletedCards(bool isCompleted, ToursFilterDto toursFilter)
        {
            var tours = TourRepo.GetAllPlain()
                .Where(t => t.TourPostingStatus == TourPostingStatus.Accepted)
                .Where(t => t.IsCompleted == isCompleted);            

			return _handler.ReattachToursInfo(toursFilter, tours);
        }

        public void PostPastTourPics(int tourid, ICollection<photoDto> photoDtos)
        {

            var Photos = photoDtos.Select(a => new TourPhoto
            {
                Id = a.Id,
                PhotoId = a.PhotoId,
                TourId = tourid,

            }).ToList();

            TourRepo.AddPhotos(Photos);
        }


        public TourDto? DetailsTour(int id)
        {
            var tour = TourRepo.GetTourByIdLite2(id);

            if (tour == null)
            {
                return null;
            }

            return _handler.GetTourDto(tour, id.ToString());
            //    new TourDto
            //(
            //    DetailsCard(id),
            //    hasTransportation: false,
            //    Description: tour.Description,
            //    Reviews: tour.Reviews.Select(r => r.Comment).ToArray()
            //);
        }


        public string BookTour(int id , int seatsNum , string userId)
        {
            var tour = TourRepo.GetTourByIdLite2(id);

            if (tour == null)
            {
                return "Completed"; // tour not found
            }

            var bookedTour = new BookedTour() { 
                Seats = seatsNum , 
                CustomerId = userId, 
                TourId = id ,
                Status = BookedTourStatus.Cart
            };

            if (!TourRepo.bookTour(bookedTour))
            {

                return "Already Booked";
            }

            return $"{bookedTour.Id}";
        }

        public async Task<BookTourDto?> BookTourDetailsAsync(int id)
        {
            var tour = TourRepo.GetTourByIdLite2(id);

            if (tour == null)
            {
                return null; // tour not found
            }

            //get tour guide name by id
            var tourguideId = tour.TourGuideId;
            var tourguide = tourGuideManager.GetInfo(tourguideId);

            return new BookTourDto
                (
                TourName: tour.Title,
                TourGuideName: tourguide.Name,
                DateFrom: tour.DateFrom,
                DateTo: tour.DateTo,
                LocationFrom: tour.LocationFrom,
                Price :  tour.Price
                );
        }

		public ICollection<TourCardDto> GetIsTrendingCards()
		{
			var tours = TourRepo.GetTrendingPlain()
				.Where(t => t.TourPostingStatus == TourPostingStatus.Accepted)
				.Where(t => !t.IsCompleted);

			return _handler.ReattachToursInfo(new ToursFilterDto(), tours);
		}

        public Tour? getSomeDetails(int id )
        {
            var tour = TourRepo.GetTourByIdLite(id);
            return tour;
        }
	}
}
