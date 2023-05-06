using SeetourAPI.Data.Context;
using SeetourAPI.Data.Enums;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.DAL.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly SeetourContext context;

        public CustomerRepo(SeetourContext context) {
            this.context = context;
        }
        public Customer GetCustomerById(string id)
        {
            var cust = context.Customers
				.Where(t => !t.IsBlocked)
				.FirstOrDefault(c => c.Id == id);
            return cust;
        }
    }
}
