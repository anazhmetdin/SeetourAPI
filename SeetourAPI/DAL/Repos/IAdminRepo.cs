using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.Repos
{
    public interface IAdminRepo
    {
        //for Seetour user cause it has all the properties
        public IEnumerable<SeetourUser> GetAll();
        public IEnumerable<SeetourUser> GetUsers();
        public IEnumerable<SeetourUser> GetTourGuides();
        public SeetourUser GetSeeTourUserById(string id);
        public void EditTourGuide(string id, SeetourUser seetourUser );
        public void EditCustomer(string id, SeetourUser seetourUser);
        public void DeleteSeeTourUser(string id);
        public void updateRole(string id,string securitylevel);
		bool EditRequest(AdminTourPostRequestDto postRequestDto);
		bool SaveChanges();
	}
}
