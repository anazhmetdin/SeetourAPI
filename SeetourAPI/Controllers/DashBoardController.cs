using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeetourAPI.BL.AdminManger;
using SeetourAPI.BL.TourGuideManager;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;
using SeetourAPI.Data.Policies;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Policy = Policies.AllowAdmins)]
    public class AdminController : ControllerBase
    {
        private readonly SeetourContext context;
        private readonly IAdminManger _adminManager;
        private readonly ITourGuideManager _tourGuideManager;
        private readonly SeetourContext _context;

        public AdminController(SeetourContext context ,IAdminManger adminManager, ITourGuideManager tourGuideManager)
        {
            this.context = context;
            _adminManager = adminManager;
            _tourGuideManager = tourGuideManager;
        }

        [HttpGet("allUsers")]
        public ActionResult<IEnumerable<SeetourUser>> GetAllUser()
        {
            var users = context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<SeetourUser>> GetAllUsers()
        {
            var users = _adminManager.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<SeetourUser> GetUserById(string id)
        {
            var user = _adminManager.GetSeeTourUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("users")]
        public ActionResult<IEnumerable<SeetourUser>> GetUsers()
        {
            var users = _adminManager.GetUsers();
            return Ok(users);
        }

        [HttpGet("guides")]
        public ActionResult<IEnumerable<SeetourUser>> GetTourGuides()
        {
            var guides = _adminManager.GetTourGuides();
            return Ok(guides);
        }

        [HttpPut("{id}/role")]
        public ActionResult UpdateRole(string id, [FromBody] string securitylevel)
        {
            _adminManager.updateRole(id, securitylevel);
            return NoContent();
        }

        [HttpPut("{id}/customer")]
        public ActionResult EditCustomer(string id, [FromBody] SeetourUser seetourUser)
        {
            _adminManager.EditCustomer(id, seetourUser);
            return NoContent();
        }

        [HttpPut("{id}/tourguide")]
        public ActionResult EditTourGuide(string id, [FromBody] SeetourUser seetourUser)
        {
            _adminManager.EditTourGuide(id, seetourUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSeeTourUser(string id)
        {
            _adminManager.DeleteSeeTourUser(id);
            return NoContent();
		}

		[HttpGet("Tour/Request")]
		public IActionResult GetTourRequests()
		{
			return Ok(_adminManager.GetTourRequests());
		}

		[HttpPost("Tour/Request")]
		public IActionResult EditPostRequest(AdminTourPostRequestDto postRequestDto)
		{
            if (_adminManager.UpdateTourStatus(postRequestDto))
                return NoContent();

            return BadRequest();
		}

		[HttpGet("TourGuide/Applicant")]
		public IActionResult GetApplicants()
		{
			return Ok(_tourGuideManager.GetApplicants());
		}

		[HttpGet("TourGuide/Applicant/{Id}")]
		public IActionResult GetApplicants(string Id)
		{
			var applicant = _tourGuideManager.GetApplicant(Id);

			if (applicant == null)
			{
				return NotFound();
			}

			return Ok(applicant);
		}

		[HttpPatch("TourGuide/Applicant")]
		public IActionResult GetApplicants(TGStatusDto statusDto)
		{
			var updated = _tourGuideManager.ChangeTourGuideStatus(statusDto);

			if (!updated)
			{
				return BadRequest();
			}

			return Ok();
		}
	}

}
