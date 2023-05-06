
namespace SeetourAPI.DAL.DTO
{
    public record BookTourDto
    (
         string TourGuideName,
         string TourName,
         DateTime DateFrom,
         DateTime DateTo,
         string LocationFrom,
         decimal Price
    );
}
