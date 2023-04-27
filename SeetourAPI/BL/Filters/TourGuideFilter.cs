using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SeetourAPI.BL.AdminManger;
using SeetourAPI.Data.Enums;

namespace SeetourAPI.BL.Filters
{
    public class TourGuideFilter : IActionFilter
    {
        private readonly IAdminManger _tourGuideService;

        public TourGuideFilter(IAdminManger tourGuideService)
        {
            _tourGuideService = tourGuideService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Check if the user is a tour guide and is not blocked
            var userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                var tourGuide = _tourGuideService.GetSeeTourUserById(userId);
                if (tourGuide != null && tourGuide.TourGuide.Status== TourGuideStatus.Blocked)
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
