using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.DTO
{
    public record TourDto
    (
        int Id,
        string[] Photos,
        string LocationTo,
        string LocationFrom,
        string TourguideId,
        decimal Price,
        int Likes,
        int Bookings,
		int Capacity,
		string Category,
		string DateFrom,
		string DateTo,
		string DateToCancel,
		string Title,
        bool hasTransportation,
        string Description,
        ReviewCardDto[] Reviews,
        int[] Rating
    );
}
