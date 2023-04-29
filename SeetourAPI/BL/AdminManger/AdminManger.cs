using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.BL.AdminManger
{
    public class AdminManger:IAdminManger
    {
        private readonly IAdminRepo adminRepo;

        public AdminManger(IAdminRepo adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        public void DeleteSeeTourUser(string id)
        {
            adminRepo.DeleteSeeTourUser(id);
        }

        public void EditCustomer(string id, SeetourUser seetourUser)
        {
            adminRepo.EditCustomer(id, seetourUser);
        }

        public void EditTourGuide(string id, SeetourUser seetourUser)
        {
            adminRepo.EditTourGuide(id, seetourUser);
        }

        public IEnumerable<SeetourUser> GetAll()
        {
           return adminRepo.GetAll();
        }

        public SeetourUser GetSeeTourUserById(string id)
        {
           return adminRepo.GetSeeTourUserById(id);
        }

        public IEnumerable<SeetourUser> GetTourGuides()
        {
           return adminRepo.GetTourGuides();
        }

        public IEnumerable<SeetourUser> GetUsers()
        {
           return  adminRepo.GetUsers();
        }

        public void updateRole(string id, string securitylevel)
        {
           adminRepo.updateRole(id, securitylevel);
        }
    }
}
