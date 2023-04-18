﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeetourAPI.BL.AdminManger;
using SeetourAPI.Data.Models.Users;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        private readonly IAdminManger _adminManager;

        public AdminController(IAdminManger adminManager)
        {
            _adminManager = adminManager;
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
    }

}
