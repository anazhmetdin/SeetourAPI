using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SeetourAPI.Data.Models.Users
{
    public class SeetourUser : IdentityUser
    {
        // TODO: add admin claim for authorization
        [DataType(DataType.ImageUrl)]
        [StringLength(512)]
        public string? ProfilePic { get; set; }
        [StringLength(14)]
        public string SSN { get; set; } = string.Empty;
        [StringLength(maximumLength: 50, MinimumLength = 4)]
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SecurityLevel { get; set; } = string.Empty;
        public virtual Customer? Customer { get; set; }
        public virtual TourGuide? TourGuide { get; set; }
        
      
    }
}
