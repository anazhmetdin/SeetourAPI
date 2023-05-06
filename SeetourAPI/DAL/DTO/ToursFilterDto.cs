using SeetourAPI.Data.Enums;

namespace SeetourAPI.DAL.DTO
{
    public record ToursFilterDto(
        DateTime? DateFrom = null, DateTime? DateTo = null,
        string? LocationFrom = null, string? LocationTo = null,
        decimal? PriceFrom = null, decimal? PriceTo = null,
        int? CapacityFrom = null, int? CapacityTo = null,
        int? HasSeats = null,
        decimal? MinRating = null,
        string? TourCategory = null,
        bool? HasTransportation = null,
        
        int Take = -1,
        string? query = null);
}
