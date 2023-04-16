using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models.Users;
using System.Runtime.Intrinsics.X86;

namespace SeetourAPI.DAL.Repos
{
    public class AdminRepo : IAdminRepo
    {
        public AdminRepo(SeetourContext context)
        {
            _Context = context;
        }

        public SeetourContext _Context { get; }

        public void AddSeeTourUser(SeetourUser seeTourUser)
        {
            if(seeTourUser != null)
            _Context.Users.Add(seeTourUser);
            _Context.SaveChanges();
        }

        public void DeleteSeeTourUser(string id)
        {
            var user = _Context.Users.Find(id);
            if (user!=null)
            {
                _Context.Users.Remove(user);
                _Context.SaveChanges();
            }
        }

        public SeetourUser? EditSeeTourUser(string id, SeetourUser seetourUser)
        {
            var user= _Context.Users.Find(id);
            if (user!=null)
            {
               user.UserName= seetourUser.UserName;
                user.ProfilePic= seetourUser.ProfilePic;
                user.SSN= seetourUser.SSN;
                user.FullName= seetourUser.FullName;
                user.Email= seetourUser.Email;
                user.TourGuide.RecipientAccountNumberOrIBAN=seetourUser.TourGuide.RecipientAccountNumberOrIBAN;
                user.TourGuide.RecipientBankNameAndAddress = seetourUser.TourGuide.RecipientBankNameAndAddress;
                user.TourGuide.RecipientBankSwiftCode= seetourUser.TourGuide.RecipientBankSwiftCode;
                user.TourGuide.RecipientNameAndAddress=seetourUser.TourGuide.RecipientNameAndAddress;
                user.TourGuide.TaxRegistrationNumber= seetourUser.TourGuide.TaxRegistrationNumber;
                user.Email=seetourUser.Email;
                user.PhoneNumber=seetourUser.PhoneNumber;
                user.IDCardPhoto= seetourUser.IDCardPhoto;
                _Context.SaveChanges();
            }
            return user;
        }

        public IEnumerable<SeetourUser> GetAll()
        {
          var users=  _Context.Users.ToList();
            if(users !=null)
            {
                return users;
            }
            else { return new List<SeetourUser>();}
        }

        public SeetourUser GetSeeTourUserById(string id)
        {
          var user=  _Context.Users.Find(id);
            if (user == null)
            {
              return new SeetourUser();
            }
            else return user;
        }

        public void updateRole(string id,string SecurityLevel)
        {
            var UserToUpdateRole= _Context.Users.Find(id);
            if (UserToUpdateRole != null)
            {
                UserToUpdateRole.SecurityLevel= SecurityLevel;
                _Context.SaveChanges();
            }
        }
    }
}
