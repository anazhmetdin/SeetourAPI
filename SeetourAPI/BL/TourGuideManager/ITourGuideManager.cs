using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Context.DTOs;

namespace SeetourAPI.BL.TourGuideManager
{
    public interface ITourGuideManager
    {
		bool ChangeTourGuideStatus(TGStatusDto statusDto);
		public ICollection<TourCardDto>? CompletedTourCards(string tourguideId, bool isCompleted, ToursFilterDto toursFilter);
        public ICollection<TourCardDto>? CompletedTourCards(string tourguideId, bool isCompleted);
        TourGuideInfoDto? GetInfo(string id);
        public TourGuideStatistics GetTStatistics(string id);
		TourGuideDto? GetApplicant(string id);
		public ICollection<TourGuideInfoDto> GetApplicants();
		TourGuideInfoDto? GetInfo(string id);
    }
}
