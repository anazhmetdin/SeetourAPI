namespace SeetourAPI.DAL.DTO
{
    public record ToursFilterDto(
        DateTime? DateFrom, DateTime? DateTo,
        string? LocationFrom, string? LocationTo,
        decimal? PriceFrom, decimal? PriceTo,
        int? CapacityFrom, int? CapacityTo,
        int? HasSeats,
        decimal? MinRating);
}
