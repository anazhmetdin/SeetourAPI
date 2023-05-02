using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Photos;
using System.Numerics;

namespace SeetourAPI.DAL.Repos
{
    public interface ITourGuideDashBoardRepo
    {
       
            // PastToursList
            public ICollection<Tour> PastTours(string id);

            // PastToursListCount
            public int PastToursCount(string id);

            //The Top10Tours Ordered By Rate
            public ICollection<Tour> Top10Tours(string id);

            //cancelledInPastTours
            public ICollection<Tour> cancelledInPastTours(string id);

            //cancelledInPastTourscount
            public int cancelledInPastTourscount(string id);


            //FullyBookedPastTours
            public ICollection<Tour> FullyBookedPastTours(string id);

            //FullyBookedPastToursCount
            public int FullyBookedPastTourscount(string id);

            //UpComingTours
            public ICollection<Tour> UpComingTours(string id);

            //UpComingToursCount
            public int UpComingToursCount(string id);

            //FullyBookedUpComingours
            public ICollection<Tour> FullyBookedUpcomingTours(string id);

            //FullyBookedUpComingoursCount
            public int FullyBookedUpComingTourscount(string id);

            //UpcomingToursInCartList

            public ICollection<Tour> UpcomingToursInCartList(string id);

            //UpcomingToursInCartListCount
            public int UpComingToursInCartListCount(string id);
        
    }
}
