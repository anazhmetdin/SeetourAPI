namespace SeetourAPI.DAL.DTO
{
    public record ReviewCardDto (
        int Id,
        int BookedTourId,
        string BookedTourTitle,
        string TourGuideId,
        string CustomerName,
        string Comment,
        int Rating,
        string CreatedAt,
        string[] Photos
    );
}
