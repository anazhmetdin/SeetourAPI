namespace SeetourAPI.DAL.DTO
{
	public record ReviewDto(int BookedTourId, int Rating, string ReviewBody, int[] photos);
}
