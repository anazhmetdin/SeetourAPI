using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.BL.AdminManger
{
    public interface IAdminManger
    {
        public IEnumerable<SeetourUser> GetAll();
        public IEnumerable<SeetourUser> GetUsers();
        public IEnumerable<SeetourUser> GetTourGuides();
        public SeetourUser GetSeeTourUserById(string id);
        public void EditTourGuide(string id, SeetourUser seetourUser);
        public void EditCustomer(string id, SeetourUser seetourUser);
        public void DeleteSeeTourUser(string id);
        public void updateRole(string id, string securitylevel);
    }
}
