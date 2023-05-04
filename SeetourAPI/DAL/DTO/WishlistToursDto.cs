namespace SeetourAPI.DAL.DTO
{
    public record WishlistToursDto
    (
        int id,
       string photoUrl,
       decimal price,
       string title,
       int capacity,
       int tourId,
       string tourGuideId,
       string tourGuidename,
       string customername
    );
}
