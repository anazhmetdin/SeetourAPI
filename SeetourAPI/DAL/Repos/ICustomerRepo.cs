using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.Repos
{
    public interface ICustomerRepo
    {
        public Customer GetCustomerById(string id);
    }
}
