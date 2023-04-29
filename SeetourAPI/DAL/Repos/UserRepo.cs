using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.Repos
{
    public class UserRepo : IUserRepo
    {

        private readonly SeetourContext _context;

        public UserRepo(SeetourContext context)
        {
            _context = context;
        }

        public SeetourUser? GetUser(string Id)
        {
            return _context.Users.Find(Id);
        }

        public UserBasicInfoDto? GetUserBasicInfo(string id)
        {
            return _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UserBasicInfoDto(id, u.FullName, u.ProfilePic))
                .FirstOrDefault();
        }
    }
}
