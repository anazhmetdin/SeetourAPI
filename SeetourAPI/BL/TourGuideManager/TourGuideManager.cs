﻿using Microsoft.AspNetCore.Identity;
using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Context.DTOs;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;
using SeetourAPI.Services;
using System.Linq;
using System.Security.Claims;

namespace SeetourAPI.BL.TourGuideManager
{
    public class TourGuideManager : ITourGuideManager
    {
        private readonly ITourGuideRepo _tourguideRepo;
        private readonly ITourGuideDashBoardRepo _tourGuideDashBoard;
        private readonly ITourRepo _tourRepo;
        private readonly ToursHandler _handler;
        private readonly HttpContextAccessor _contextAccessor;
        private readonly UserManager<SeetourUser> _userManager;
        public TourGuideManager(ITourRepo tourRepo, ITourGuideRepo tourguideRepo,ITourGuideDashBoardRepo tourGuideDashBoard, ToursHandler handler, HttpContextAccessor contextAccessor, UserManager<SeetourUser> userManager)
        {
            _tourRepo = tourRepo;
            _tourguideRepo = tourguideRepo;
            _tourGuideDashBoard = tourGuideDashBoard;
            _handler = handler;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public string GetCurrentUserId()
        {
            var userId = _contextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId ?? "82712fd4-3d4c-4569-bbb7-a29e65de36ec";
        }
        public TourGuideStatistics GetTStatistics(string id)
        {
            var tourGuide = _tourguideRepo.GetTourGuideLite(id);

            if (tourGuide is null)
            {
                return null;
            }
            else
            {
                var statistcs = new TourGuideStatistics
                {
                    PastToursCount = _tourGuideDashBoard.PastToursCount(id),
                   // Top10Tours = _tourGuideDashBoard.Top10Tours(id).ToList(),
                    UpComingToursCount = _tourGuideDashBoard.UpComingToursCount(id),
                    CancelledInPastTourscount = _tourGuideDashBoard.cancelledInPastTourscount(id),
                    FullyBookedPastToursCount = _tourGuideDashBoard.FullyBookedPastTourscount(id),
                    FullyBookedUpcomingToursCount = _tourGuideDashBoard.FullyBookedUpComingTourscount(id),
                    ToursInCartCount = _tourGuideDashBoard.UpComingToursInCartListCount(id),
                    AvgPastoursPrice=_tourGuideDashBoard.AveragePastToursPrice(id),
                    TotalPastToursPrice=_tourGuideDashBoard.TotalPastToursPrice(id),
                    TotalUpcomingToursPrice=_tourGuideDashBoard.TotalUpcomingToursPrice(id),
                    AvgUpcomingToursPrice=_tourGuideDashBoard.AveragePastToursPrice(id),
                    TotalUpcomingTourSeats=_tourGuideDashBoard.TotalUpcomingTourSeats(id),
                    avgUpcomingTourSeats=_tourGuideDashBoard.AvgUpcomingTourSeats(id)
                    

                };
                return statistcs;

            }

        }
        public TourGuideInfoDto? GetInfo(string id)
        {
            var tourGuide = _tourguideRepo.GetTourGuideLite(id);

            if (tourGuide is null)
            {
                return null;
            }

            return GetTourGuideInfoDto(tourGuide);
        }

        private TourGuideInfoDto GetTourGuideInfoDto(TourGuide tourguide)
        {
            return new TourGuideInfoDto(
                Id: tourguide.Id,
                Name: tourguide.User?.FullName??"",
                ProfilePic: tourguide.User?.ProfilePic??"",
                Rating: tourguide.Rating,
                RatingCount: tourguide.RatingCount
            );
        }

        private TGToursDto? GetTours(string tourguideId)
        {
            var tourguide = GetInfo(tourguideId);

            if (tourguide == null)
            {
                return null;
            }

            var tours = _tourRepo.GetTourGuideToursLite(tourguide.Id);

			foreach (var tour in tours)
			{
				tour.Likes = _tourRepo.GetTourLikes(tour.Id).ToList();
				tour.Wishlist = _tourRepo.GetTourWishlist(tour.Id).ToList();
				tour.Photos = _tourRepo.GetTourPhotos(tour.Id).ToList();
			}

			return new TGToursDto(tourguide, tours.Where(t=>t.TourPostingStatus == TourPostingStatus.Accepted));
        }

        public ICollection<TourCardDto>? CompletedTourCards(string tourguideId,
            bool isCompleted)
        {
            var TGTours = GetTours(tourguideId);

            if (TGTours == null)
                return null;

            return GetToursCompleted(TGTours.Tours, isCompleted);
        }

        private ICollection<TourCardDto> GetToursCompleted(
            IEnumerable<Tour> tours, bool isCompleted)
        {
            return _handler.GetTourCardDto(tours.Where(t => isCompleted == t.IsCompleted));
        }


        //private TGToursDto FilterTours(ToursFilterDto toursFilter, TGToursDto TGTours)
        //{
        //    IEnumerable<Tour> tours = TGTours.Tours.ToList();

        //    tours = _handler.Filter(tours, toursFilter);

        //    TGTours = new TGToursDto(TGTours.TourGuide, tours);
        //    return TGTours;
        //}

        public ICollection<TourCardDto>? CompletedTourCards(
            string tourguideId, bool isCompleted, ToursFilterDto toursFilter)
        {
            var TGTours = GetTours(tourguideId);

            if (TGTours == null)
                return null;

            TGTours = FilterTours(toursFilter, TGTours);

            return GetToursCompleted(TGTours.Tours, isCompleted);
        }
        //public ICollection<TourCardDto>? CompletedTourCards(string tourguideId, bool isCompleted, ToursFilterDto toursFilter)
        //{
        //    var TGTours = GetTours(tourguideId);

        //    if (TGTours == null)
        //        return null;

        //    TGTours = FilterTours(toursFilter, TGTours);

        //    return GetToursCompleted(TGTours, isCompleted);
        //}

        private static TGToursDto FilterTours(ToursFilterDto toursFilter, TGToursDto TGTours)
        {
            IEnumerable<Tour> tours = TGTours.Tours;

            if (toursFilter.HasSeats != null)
                tours = tours.Where(t => toursFilter.HasSeats + t.BookingsCount <= t.Capacity);

            if (toursFilter.MinRating != null)
                tours = tours.Where(t => toursFilter.MinRating <= TGTours.TourGuide.Rating);

            if (toursFilter.CapacityFrom != null)
                tours = tours.Where(t => toursFilter.CapacityFrom <= t.Capacity);

            if (toursFilter.CapacityTo != null)
                tours = tours.Where(t => toursFilter.CapacityTo >= t.Capacity);

            if (toursFilter.DateFrom != null)
                tours = tours.Where(t => toursFilter.DateFrom <= t.DateFrom);

            if (toursFilter.DateTo != null)
                tours = tours.Where(t => toursFilter.DateTo >= t.DateTo);

            if (toursFilter.PriceFrom != null)
                tours = tours.Where(t => toursFilter.PriceFrom <= t.Price);

            if (toursFilter.PriceTo != null)
                tours = tours.Where(t => toursFilter.PriceTo >= t.Price);

            if (toursFilter.LocationFrom != null)
                tours = tours.Where(t => t.LocationFrom.IndexOf(toursFilter.LocationFrom, StringComparison.OrdinalIgnoreCase) >= 0);

            if (toursFilter.LocationTo != null)
                tours = tours.Where(t => t.LocationTo.IndexOf(toursFilter.LocationTo, StringComparison.OrdinalIgnoreCase) >= 0);

            TGTours = new TGToursDto(TGTours.TourGuide, tours);
            return TGTours;
        }

		public ICollection<TourGuideInfoDto> GetApplicants()
		{
            var tourguides = _tourguideRepo.GetAll();
            tourguides = tourguides.Where(t => t.Status == TourGuideStatus.Applied);
            return tourguides.Select(GetTourGuideInfoDto).ToList();
		}

		public TourGuideDto? GetApplicant(string id)
		{
			var tourguide = _tourguideRepo.GetTourGuideLite(id);

            if (tourguide == null) return null;

			return GetTourGuideDto(tourguide);
		}

		private TourGuideDto GetTourGuideDto(TourGuide tourguide)
		{
            return new TourGuideDto(
                Id: tourguide.Id,
                Name: tourguide.User?.FullName ?? "",
                Username: tourguide.User?.UserName?? "",
                ProfilePic: tourguide.User?.ProfilePic ?? "",
                RecipientBankNameAndAddress: tourguide.RecipientBankNameAndAddress,
                RecipientAccountNumberOrIBAN: tourguide.RecipientAccountNumberOrIBAN,
                RecipientBankSwiftCode: tourguide.RecipientBankSwiftCode,
                RecipientNameAndAddress: tourguide.RecipientNameAndAddress,
                TaxRegistrationNumber: tourguide.TaxRegistrationNumber,
                IDCardPhoto: tourguide.IDCardPhoto,
                SSN: tourguide.User?.SSN??"",
                Email: tourguide.User?.Email??"",
                Phone: tourguide.User?.PhoneNumber??""
            );
		}

		public bool ChangeTourGuideStatus(TGStatusDto statusDto)
		{
			if (Enum.TryParse(statusDto.Status, out TourGuideStatus tourGuideStatus))
            {
                var tourguide = _tourguideRepo.GetTourGuideLite(statusDto.Id);
                if (tourguide == null) { return false; }
                tourguide.Status = tourGuideStatus;
				return _tourguideRepo.SaveChanges();
            }
            else
            {
                return false;
            }
		}

        public ICollection<dynamic> GetAllQuestions()
        {
            string id = GetCurrentUserId();
            var Questions = _tourguideRepo.GetAllQustionss(id);
            if (Questions == null)
                return null;
            return Questions.ToList(); 
        }
    }
}
