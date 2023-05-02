using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;
using System.Runtime.Intrinsics.X86;

namespace SeetourAPI.DAL.Repos
{
    public class AdminRepo : IAdminRepo
    {
        private readonly UserManager<SeetourUser> _Manger;
        public SeetourContext _Context { get; }

        public AdminRepo(SeetourContext context, UserManager<SeetourUser> Manger)
        {
            _Context = context;
            _Manger = Manger;
        }

        public IEnumerable<SeetourUser> GetAll()
        {
            var users = _Context.Users
                     .Include(u => u.Customer)
                     .Include(u => u.TourGuide)
                     .ToList();
            if (users == null)
            {
                return Enumerable.Empty<SeetourUser>();
            }
            else
                return users;

        }

        public IEnumerable<SeetourUser> GetUsers()
        {
            var users = _Context.Users.Include(u => u.Customer).Where(c => c.SecurityLevel.ToLower() == "user");
            if(users!=null)
            {
                return users;
            }
            return Enumerable.Empty<SeetourUser>();
        }

        public IEnumerable<SeetourUser> GetTourGuides()
        {
            var users = _Context.Users.Include(u => u.TourGuide).Where(c => c.SecurityLevel.ToLower() == "tourguide");
            if (users != null)
            {
                return users;
            }
            return Enumerable.Empty<SeetourUser>();
        }

        public SeetourUser GetSeeTourUserById(string id)
        {
            var user = _Context.Users.Select(u => u.Id == id);
            if(user!=null)
            {
                return (SeetourUser)user;
            }
            else return new SeetourUser();
        }

        public void EditCustomer(string id, SeetourUser seetourUser)
        {
            var user = _Context.Users.Find(id);
            if(user!=null )
            {
                user.Customer.IsBlocked = seetourUser.Customer.IsBlocked;
            }
        }
        public void EditTourGuide(string id, SeetourUser seetourUser)
        {
            var user = _Context.Users.Find(id);
            if(user!=null)
            {
                user.TourGuide.Status= seetourUser.TourGuide.Status;
            }
        }

        public void DeleteSeeTourUser(string id)
        {
            var user = _Context.Users
                                .Include(u => u.Customer)
                                .Include(u => u.TourGuide)
                                .FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                if (user.Customer != null)
                {
                    _Context.Customers.Remove(user.Customer);
                }

                if (user.TourGuide != null)
                {
                    _Context.TourGuides.Remove(user.TourGuide);
                }

                _Context.Users.Remove(user);
                _Context.SaveChanges();
            }
        }


        public void updateRole(string id, string securitylevel)
        {
            var user= _Context.Users.Find(id);
            if(user!=null)
            {
                user.SecurityLevel = securitylevel.ToLower();
            }
        }

		public bool EditRequest(AdminTourPostRequestDto postRequestDto)
		{
            try
            {
                var editRequest = new EditRequest()
                {
                    AdminComments = postRequestDto.EditRequest,
                    TourId = postRequestDto.TourId,
                };

                _Context.EditRequests.Add(editRequest);
                return true;
            }
            catch { return false; }
		}

		public bool SaveChanges()
		{
			return _Context.SaveChanges() > 0;
		}





















































































		//public void AddCustomer(SeetourUser seeTourUser)
		//{
		//    if(seeTourUser != null)
		//    _Context.Users.Add(seeTourUser);
		//    _Context.SaveChanges();
		//}

		//public void DeleteSeeTourUser(string id)
		//{
		//    var user = _Context.Users.Find(id);
		//    if (user!=null)
		//    {
		//        _Context.Users.Remove(user);
		//        _Context.SaveChanges();
		//    }
		//}

		//public SeetourUser? EditSeeTourUser(string id, SeetourUser seetourUser)
		//{
		//    var user= _Context.Users.Find(id);
		//    if (user!=null)
		//    {
		//       user.UserName= seetourUser.UserName;
		//        user.ProfilePic= seetourUser.ProfilePic;
		//        user.SSN= seetourUser.SSN;
		//        user.FullName= seetourUser.FullName;
		//        user.Email= seetourUser.Email;
		//        user.TourGuide.RecipientAccountNumberOrIBAN=seetourUser.TourGuide.RecipientAccountNumberOrIBAN;
		//        user.TourGuide.RecipientBankNameAndAddress = seetourUser.TourGuide.RecipientBankNameAndAddress;
		//        user.TourGuide.RecipientBankSwiftCode= seetourUser.TourGuide.RecipientBankSwiftCode;
		//        user.TourGuide.RecipientNameAndAddress=seetourUser.TourGuide.RecipientNameAndAddress;
		//        user.TourGuide.TaxRegistrationNumber= seetourUser.TourGuide.TaxRegistrationNumber;
		//        user.Email=seetourUser.Email;
		//        user.PhoneNumber=seetourUser.PhoneNumber;
		//        user.IDCardPhoto= seetourUser.IDCardPhoto;
		//        _Context.SaveChanges();
		//    }
		//    return user;
		//}

		//public IEnumerable<SeetourUser> GetAll()
		//{
		//  var users=  _Context.Users.ToList();
		//    if(users !=null)
		//    {
		//        return users;
		//    }
		//    else { return new List<SeetourUser>();}
		//}

		//public SeetourUser GetSeeTourUserById(string id)
		//{
		//  var user=  _Context.Users.Find(id);
		//    if (user == null)
		//    {
		//      return new SeetourUser();
		//    }
		//    else return user;
		//}

		//public void updateRole(string id,string SecurityLevel)
		//{
		//    var UserToUpdateRole= _Context.Users.Find(id);
		//    if (UserToUpdateRole != null)
		//    {
		//        UserToUpdateRole.SecurityLevel= SecurityLevel;
		//        _Context.SaveChanges();
		//    }
		//}
	}
}
