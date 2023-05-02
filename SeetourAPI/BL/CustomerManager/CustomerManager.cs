using SeetourAPI.DAL.Repos;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.BL.CustomerManager
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepo customerRepo;

        public CustomerManager(ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public Customer GetCustomerById(string id)
        {
            var cust = customerRepo.GetCustomerById(id);
            return cust;
        }
    }
}
