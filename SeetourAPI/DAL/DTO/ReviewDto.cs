namespace SeetourAPI.DAL.DTO
{
	public record ReviewDto(int bookedTourId, int rating, string reviewBody, string[] Base64Images);
}
