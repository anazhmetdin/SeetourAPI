using SeetourAPI.Data.Models;

namespace SeetourAPI.DAL.DTO
{
    public record TGToursDto(TourGuideInfoDto TourGuide, IEnumerable<Tour> Tours);
}
