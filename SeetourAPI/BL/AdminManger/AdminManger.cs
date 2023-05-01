using SeetourAPI.DAL.DTO;
using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models.Users;
using SeetourAPI.Services;

namespace SeetourAPI.BL.AdminManger
{
    public class AdminManger:IAdminManger
    {
        private readonly IAdminRepo adminRepo;
        private readonly ITourRepo _tourRepo;
        private readonly ToursHandler _tourHandler;

		public AdminManger(IAdminRepo adminRepo, ITourRepo tourRepo, ToursHandler tourHandler)
		{
			this.adminRepo = adminRepo;
			_tourRepo = tourRepo;
			_tourHandler = tourHandler;
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

		public ICollection<TourCardDto> GetTourRequests()
		{
            var tours = _tourRepo.GetTourRequests();

            tours = tours
                .OrderBy(t => t.DateFrom)
                .ThenBy(t => t.PostedAt)
                .Where(t => !t.IsCompleted);

			return _tourHandler.GetTourCardDto(tours);
		}

		public IEnumerable<SeetourUser> GetUsers()
        {
           return  adminRepo.GetUsers();
        }

        public void updateRole(string id, string securitylevel)
        {
           adminRepo.updateRole(id, securitylevel);
        }

		public bool UpdateTourStatus(AdminTourPostRequestDto postRequestDto)
		{
			if (Enum.TryParse(postRequestDto.Status, out TourPostingStatus status))
            {
                if (!_tourRepo.UpdatePostingStatus(postRequestDto.TourId, status))
                {
                    return false;
                }

                if (status == TourPostingStatus.EditRequested)
                {
                    return adminRepo.EditRequest(postRequestDto) && adminRepo.SaveChanges() && _tourRepo.SaveChanges();
                }

                return _tourRepo.SaveChanges();
            }

            return false;
		}
	}
}
