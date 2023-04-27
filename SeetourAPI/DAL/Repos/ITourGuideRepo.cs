using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.Repos
{
    public interface ITourGuideRepo
    {
        public TourGuide? GetTourGuide(string id);
    }
}
