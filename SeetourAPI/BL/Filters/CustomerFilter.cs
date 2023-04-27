using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SeetourAPI.BL.AdminManger;

namespace SeetourAPI.BL.Filters
{
    public class CustomerFilter : IActionFilter
    {
        private readonly IAdminManger _tourGuideService;

        public CustomerFilter(IAdminManger tourGuideService)
        {
            _tourGuideService = tourGuideService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Check if the user is a customer and blocked
            var userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                var Customer = _tourGuideService.GetSeeTourUserById(userId);
                if (Customer != null && Customer.Customer.IsBlocked==true)
                {
                    context.Result = new ForbidResult();
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do nothing
        }
    }

}
