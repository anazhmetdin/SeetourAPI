namespace SeetourAPI.DAL.DTO
{
    public record TourCardDto(
        int Id,
        string[] Photos,
        string LocationTo,
        decimal Price,
        int Likes,
        bool isLiked,
        int Bookings,
        int Capacity,
        string TourGuideId,
        string TourGuideName,
        decimal TourGuideRating,
        int TourGuideRatingCount,
        string DateFrom,
        string DateTo,
        string Category,
        string Title,
        bool AddedToWishList
    );
}
