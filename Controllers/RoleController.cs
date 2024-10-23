using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VinxTech.API.CustomActionFilters;
using VinxTech.API.Models.ResponseDTOs;
using VinxTech.API.Repositories.Roles;

namespace VinxTech.API.Controllers
{
    [Route("test/api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRolesRepositories rolesRepositories;

        public RoleController(IRolesRepositories rolesRepositories)
        {
            this.rolesRepositories = rolesRepositories;
        }
        [HttpGet("getAll")]
        [ValidateModel]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var branch = await rolesRepositories.get();
                var responseData = new ResponseDTO
                {
                    Status = "True",
                    Message = "",

                    Data = branch,
                    Errors = new List<string>()
                };
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                var responseData = new ResponseDTO
                {
                    Status = "False",
                    Message = "Issue in fetching Roles.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData);
            }
        }
    }
}
