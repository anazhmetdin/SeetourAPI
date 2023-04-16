using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.Repos
{
    public interface IAdminRepo
    {
        //for Seetour user cause it has all the properties
        public IEnumerable<SeetourUser> GetAll();
        public SeetourUser GetSeeTourUserById(string id);
        public SeetourUser? EditSeeTourUser(string id, SeetourUser seetourUser );
        public void AddSeeTourUser(SeetourUser seeTourUser);
        public void DeleteSeeTourUser(string id);

        //also to update role  must have 
        public void updateRole(string id,string securitylevel);

    }
}
