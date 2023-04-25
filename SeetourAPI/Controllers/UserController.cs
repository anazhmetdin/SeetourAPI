using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Text;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SeetourContext context;

        public UserManager<SeetourUser> Usermanger { get; }

        public UserController(UserManager<SeetourUser> _Usermanger, IConfiguration configuration, SeetourContext context)
        {
            Usermanger = _Usermanger;
            _configuration = configuration;
            this.context = context;
        }





        [HttpPost]
        [Route("CustomerRegistration")]
        public async Task<ActionResult<TokenDto>> Register(CustomerRegistrationDto registrationDto)
        {

            var UserToAdd = new SeetourUser()
            {
                UserName = registrationDto.UserName,
                SecurityLevel = registrationDto.SecurityLevel,
                ProfilePic = registrationDto.profilepic,
                SSN = registrationDto.SSN,
                FullName = registrationDto.FullName,
                Email = registrationDto.Email,
                PhoneNumber = registrationDto.PhoneNumber

            };

            var result = await Usermanger.CreateAsync(UserToAdd, registrationDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,UserToAdd.Id),
                new Claim(ClaimTypes.Role,registrationDto.SecurityLevel)
            };
            await Usermanger.AddClaimsAsync(UserToAdd, claims);

            var customerToAdd = new Customer()
            {
                Id = UserToAdd.Id,
                IsBlocked = false,
                // add any other properties you want to set for the customer object here
            };
            context.Customers.Add(customerToAdd);
            await context.SaveChangesAsync();
            return NoContent();

        }



        [HttpPost]
        [Route("TourGuideRegistration")]
        public async Task<ActionResult<TokenDto>> Register(TourGuideRegistrationDto registrationDto)
        {

            var UserToAdd = new SeetourUser()
            {
                UserName = registrationDto.UserName,
                SecurityLevel = registrationDto.SecurityLevel,
                ProfilePic = registrationDto.profilepic,
                SSN = registrationDto.SSN,
                FullName = registrationDto.FullName,
                Email = registrationDto.Email,
                PhoneNumber = registrationDto.PhoneNumber
            };
            var result = await Usermanger.CreateAsync(UserToAdd, registrationDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,UserToAdd.Id),
                new Claim(ClaimTypes.Role,registrationDto.SecurityLevel)
            };
            await Usermanger.AddClaimsAsync(UserToAdd, claims);
            var tourguideToAdd = new TourGuide()
            {
                Id = UserToAdd.Id,
                RecipientAccountNumberOrIBAN = registrationDto.RecipientAccountNumberOrIBAN,
                RecipientBankNameAndAddress = registrationDto.RecipientBankNameAndAddress,
                RecipientBankSwiftCode = registrationDto.RecipientBankSwiftCode,
                RecipientNameAndAddress = registrationDto.RecipientNameAndAddress,
                //TaxRegistrationNumber = registrationDto.TaxRegistrationNumber,
                IDCardPhoto = registrationDto.IDCardPhoto,
                // add any other properties you want to set for the customer object here
            };
            context.TourGuides.Add(tourguideToAdd);
            await context.SaveChangesAsync();


            return NoContent();

        }






        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var user = await Usermanger.FindByNameAsync(loginDto.username);
            if (user == null)
            {
                return NotFound();
            }
            var isAuthenticated = await Usermanger.CheckPasswordAsync(user, loginDto.password);
            if (!isAuthenticated)
            {
                return Unauthorized();
            }
            var claimsList = new List<Claim>
            {
                new Claim("AnyKey","Some Value"),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Email, "somemail@gmail.com"),
            };

            //Geenerate Sectet Key Object
            var secretKeyString = _configuration.GetValue<string>("SecretKey") ?? string.Empty;
            var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
            var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

            //Combination SecretKey, HashingAlgorithm
            var siginingCreedentials = new SigningCredentials(secretKey,
                SecurityAlgorithms.HmacSha256Signature);

            var expiry = DateTime.Now.AddDays(1);

            var token = new JwtSecurityToken(
                claims: claimsList,
                expires: expiry,
                signingCredentials: siginingCreedentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new TokenDto(tokenString, expiry));

        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<ActionResult> GetUser(string username)
        {
            var user = await Usermanger.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

    }
}


