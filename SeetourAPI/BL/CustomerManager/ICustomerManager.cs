using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.BL.CustomerManager
{
    public interface ICustomerManager
    {
        public Customer GetCustomerById(string id);
    }
}
