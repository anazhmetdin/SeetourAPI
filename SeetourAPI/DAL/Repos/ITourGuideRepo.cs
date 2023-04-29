using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.Repos
{
    public interface ITourGuideRepo
    {
        bool CheckTourGuide(string id);
        public TourGuide? GetTourGuide(string id);
        public TourGuide? GetTourGuideLite(string id);
    }
}
