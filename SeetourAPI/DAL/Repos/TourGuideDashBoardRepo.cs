using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models.Photos;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Enums;

namespace SeetourAPI.DAL.Repos
{
    public class TourGuideDashBoardRepo:ITourGuideDashBoardRepo
    {
        private readonly SeetourContext _Context;

        public TourGuideDashBoardRepo(SeetourContext context)
        {
            this._Context = context;
        }
        public ICollection<Tour> PastTours(string id)
        {
            var PastToursList = _Context.Tours.Where(x => x.TourGuideId == id && x.DateFrom < DateTime.Now && x.Bookings.Any(b => b.Status == BookedTourStatus.Completed)).ToList();
            if (PastToursList != null)
            {

            return PastToursList;
            }
             return new List<Tour>();
        }

        public int PastToursCount(string id)
        {
            return PastTours(id).Count();
        }

        public ICollection<Tour> Top10Tours(string id)
        {
            var Top10Tourss = _Context.Tours
    .Where(t => t.TourGuideId == id && t.DateFrom < DateTime.Now && t.Bookings.Any(b => b.Status == BookedTourStatus.Completed))
    .OrderByDescending(t => t.Bookings.Where(b => b.Status == BookedTourStatus.Completed)
        .Average(b => b.Review != null ? b.Review.Rating : 0))
    .Take(10)
    .ToList();
            if(Top10Tourss != null)
            {

            return Top10Tourss;
            }
            return new List<Tour>();

        }

        public ICollection<Tour> cancelledInPastTours(string id)
        {
            var cancelledtours = _Context.Tours
       .Where(x => x.TourGuideId == id && x.DateFrom < DateTime.Now && x.Bookings.Any(b => b.Status == BookedTourStatus.Cancelled))
       .ToList();
            if(cancelledtours != null)
            {

            return cancelledtours;
            }
            return new List<Tour>();
        }
        public int cancelledInPastTourscount(string id)
        {
            return cancelledInPastTours(id).Count();
        }

        public ICollection<Tour> FullyBookedPastTours(string id)
        {
            var fullybooked = _Context.Tours.Where(t => t.TourGuideId == id
                        && t.DateFrom < DateTime.Now
                        && t.Bookings.Any(b => b.Status == BookedTourStatus.Booked)
                        && t.BookingsCount == t.Capacity)
              .ToList();

            if (fullybooked != null)
            {

            return fullybooked;
               
            }
            return new List<Tour>();
        }
        public int FullyBookedPastTourscount(string id)
        {
            return FullyBookedPastTours(id).Count();
        }

        public ICollection<Tour> UpComingTours(string id)
        {
            var upcoming = _Context.Tours.
                Where(x => x.TourGuideId == id && x.Bookings.
                Any(b => b.Status != BookedTourStatus.Completed) && x.DateFrom > DateTime.Now).ToList();

            if (upcoming != null)
            {

            return upcoming;
               

            }
            return new List<Tour>();

        }

        public int UpComingToursCount(string id)
        {
            return UpComingTours(id).Count();
        }

        public ICollection<Tour> FullyBookedUpcomingTours(string id)
        {
            var fullybooked = _Context.Tours.Where(t => t.TourGuideId == id
                        && t.DateFrom > DateTime.Now
                        && t.Bookings.Any(b => b.Status == BookedTourStatus.Booked)
                        && t.BookingsCount == t.Capacity)
              .ToList();


            if (fullybooked != null)
            {

            return fullybooked;

            }
            return new List<Tour>();



        }

        public int FullyBookedUpComingTourscount(string id)
        {
            return FullyBookedUpcomingTours(id).Count();
        }

        public ICollection<Tour> UpcomingToursInCartList(string id)
        {
            var ToursInCartList = _Context.Tours
           .Where(t => t.Bookings.
           Any(b => b.Status == BookedTourStatus.Cart)
           && t.DateFrom > DateTime.Now)
           .ToList();

            if (ToursInCartList != null)
            {

                return ToursInCartList;

            }
            return new List<Tour>();

        }
        public int UpComingToursInCartListCount(string id)
        {
            return UpcomingToursInCartList(id).Count();
        }
    }
}
