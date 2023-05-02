using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.DTO
{
    public record TourDto
    (
        //int Id,
        //string[] Photos,
        //string LocationTo,
        //decimal Price,
        //int Likes,
        //int Bookings,
        //int Capacity,
        //string TourGuideId,
        //string TourGuideName,
        //string DateFrom,
        //string DateTo,
        //string Category,
        //string Title,
        TourCardDto TourCard,
        bool hasTransportation,
        string Description,
        String[] Reviews
    );
}
