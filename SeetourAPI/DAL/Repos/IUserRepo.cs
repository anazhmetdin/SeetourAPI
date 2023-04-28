using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.Repos
{
    public interface IUserRepo
    {
        public SeetourUser? GetUser(string Id);
        UserBasicInfoDto? GetUserBasicInfo(string id);
    }
}
