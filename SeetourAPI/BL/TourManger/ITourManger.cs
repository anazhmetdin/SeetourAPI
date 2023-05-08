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
        public int  AddTour( AddTourDto addTourDto);
        public void DeleteTour(int id);
        public TourDetailsDto? Details(int id);
        public TourCardDto? DetailsCard(int id);
        public TourDto? DetailsTour(int id);
        public string GetCurrentUserId();
        public Tour? getSomeDetails(int id);
        public Task<BookTourDto?> BookTourDetailsAsync(int id);
        public string BookTour(int id, int seatsNum, string userId);
        public void EditTourBYAdmin(int id, Tour tour);
        ICollection<TourCardDto> GetAllCards(ToursFilterDto toursFilter);
        ICollection<TourCardDto> GetIsCompletedCards(bool isCompleted, ToursFilterDto toursFilter);
        public void PostPastTourPics(int tourid,ICollection<photoDto> photoDtos);
		ICollection<TourCardDto> GetIsTrendingCards();
	}
}
