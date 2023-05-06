namespace SeetourAPI.DAL.Repos
{
	public interface ITrendingTourRepo
	{
		Task<bool> TryUpdateAll();
	}
}
