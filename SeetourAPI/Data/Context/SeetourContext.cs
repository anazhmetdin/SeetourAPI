using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.Data.Context
{
    public class SeetourContext: IdentityDbContext<SeetourUser>
    {
        public SeetourContext(DbContextOptions<SeetourContext> options)
        : base(options)
        {

        }
    }
}
