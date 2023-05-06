using SeetourAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.Repos
{
    public interface ITourGuideRepo
    {
        bool CheckTourGuide(string id);
		IEnumerable<TourGuide> GetAll();
		public TourGuide? GetTourGuide(string id);
        public TourGuide? GetTourGuideLite(string id);
       public IEnumerable<dynamic> GetAllQustionss(string id);
		bool SaveChanges();
	}
}
