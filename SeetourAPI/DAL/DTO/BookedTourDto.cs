namespace SeetourAPI.DAL.DTO
{
	public record BookedTourDto(
		int id,
		string createdAt,
		int seats,
		int canCancel,
		int canReview,
		TourCardDto tourCard);
}
