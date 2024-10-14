using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VinxTech.API.CustomActionFilters;
using VinxTech.API.Models.DTOs;
using VinxTech.API.Models.DTOs.Services;
using VinxTech.API.Models.ResponseDTOs;
using VinxTech.API.Repositories.Services;

namespace VinxTech.API.Controllers
{
    [Route("test/api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepositories serviceRepositories;

        public ServiceController(IServiceRepositories serviceRepositories)
        {
            this.serviceRepositories = serviceRepositories;
        }

        [HttpPost("add")]
        [ValidateModel]
        public async Task<IActionResult> Add([FromBody] ServiceRequestDTO serviceRequestDTO)
        {
            try
            {
                var branch = await serviceRepositories.Add(serviceRequestDTO);
                var responseData = new ResponseDTO
                {
                    Status = "True",
                    Message = "Service Submitted Successfully.",
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
                    Message = "Issue in Add Service.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData);
            }
        }

        [HttpGet("get/{id:int}")]
        [ValidateModel]
        public async Task<IActionResult> GetAll([FromRoute] int id)
        {
            try
            {
                var branch = await serviceRepositories.Get(id);
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
                    Message = "Issue in fetching Services.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData);
            }
        }

        [HttpPost("edit/{id:int}")]
        [ValidateModel]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] EditServiceRequestDTO editServiceRequestDTO)
        {
            try
            {
                var branch = await serviceRepositories.Edit(id, editServiceRequestDTO);
                var responseData = new ResponseDTO
                {
                    Status = "True",
                    Message = "Service Updated Successfully",
                    Data = new { },
                    Errors = new List<string>()
                };
                return Ok(responseData);
            }
            catch (Exception ex)
            {

                var responseData = new ResponseDTO
                {
                    Status = "False",
                    Message = "Issue in Updated Service.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData);
            }
        }

        [HttpPost("delete/{id:int}")]
        [ValidateModel]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var branch = await serviceRepositories.Delete(id);
                var responseData = new ResponseDTO
                {
                    Status = "True",
                    Message = "Service Deleted Successfully",
                    Data = new { },
                    Errors = new List<string>()
                };
                return Ok(responseData);
            }
            catch (Exception ex)
            {

                var responseData = new ResponseDTO
                {
                    Status = "False",
                    Message = "Issue in Deleting Service.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData);
            }
        }
    }
}
