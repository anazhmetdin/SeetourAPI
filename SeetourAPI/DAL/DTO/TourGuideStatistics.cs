using SeetourAPI.Data.Models;

namespace SeetourAPI.Data.Context.DTOs
{
    public class TourGuideStatistics
    {
        public int PastToursCount { get; set; }
        //public List<Tour> Top10Tours { get; set; } = new List<Tour>();
        public int CancelledInPastTourscount { get; set; }
        public decimal TotalPastToursPrice { get; set; }
        public decimal AvgPastoursPrice { get; set; }
        public int FullyBookedPastToursCount { get; set; }
        public int UpComingToursCount { get; set; }
       public decimal TotalUpcomingToursPrice { get; set; }
        public decimal AvgUpcomingToursPrice { get; set; }
        public int TotalUpcomingTourSeats { get; set; }

        public double avgUpcomingTourSeats { get; set; }
        public int FullyBookedUpcomingToursCount { get; set; }
        public int ToursInCartCount { get; set; }

    }
}
