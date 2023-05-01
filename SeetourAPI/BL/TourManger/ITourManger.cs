using Microsoft.AspNetCore.Identity;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Models;

namespace SeetourAPI.BL.TourManger
{
    public interface ITourManger
    {
        public IEnumerable<Tour> GetAll();
        public Tour? GetTourById(int id);
        public Tour? EditTour(int id, Tour tour);
        public void  AddTour( AddTourDto addTourDto);
        public void DeleteTour(int id);
        public TourDetailsDto? Details(int id);
        public TourCardDto? DetailsCard(int id);
        public TourDto? DetailsTour(int id);
        public string GetCurrentUserId();

        public void EditTourBYAdmin(int id, Tour tour);
        ICollection<TourCardDto> GetAllCards(ToursFilterDto toursFilter);
        ICollection<TourCardDto> GetIsCompletedCards(bool isCompleted, ToursFilterDto toursFilter);
    }
}
