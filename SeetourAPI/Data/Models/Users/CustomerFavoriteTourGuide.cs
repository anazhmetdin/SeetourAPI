namespace SeetourAPI.Data.Models.Users
{
	public class CustomerFavoriteTourGuide
	{
		public int Id { get; set; }
		public string CustomerId { get; set; } = string.Empty;
		public virtual Customer? Customer { get; set; }
		public string TourGuideId { get; set; } = string.Empty;
		public virtual TourGuide? TourGuide { get; set; }
	}
}
