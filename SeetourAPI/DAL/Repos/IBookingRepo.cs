namespace SeetourAPI.DAL.Repos
{
	public interface IBookingRepo
	{
		Task<bool> TryUpdateAll();
	}
}
