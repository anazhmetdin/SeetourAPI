using SeetourAPI.DAL.DTO;

namespace SeetourAPI.BL.TourGuideManager
{
    public interface ITourGuideManager
    {
		bool ChangeTourGuideStatus(TGStatusDto statusDto);
		public ICollection<TourCardDto>? CompletedTourCards(string tourguideId, bool isCompleted, ToursFilterDto toursFilter);
        public ICollection<TourCardDto>? CompletedTourCards(string tourguideId, bool isCompleted);
		TourGuideDto? GetApplicant(string id);
		public ICollection<TourGuideInfoDto> GetApplicants();
		TourGuideInfoDto? GetInfo(string id);
    }
}
