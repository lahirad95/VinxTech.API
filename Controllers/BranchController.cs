using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VinxTech.API.CustomActionFilters;
using VinxTech.API.Models.DTOs;
using VinxTech.API.Models.ResponseDTOs;
using VinxTech.API.Repositories;

namespace VinxTech.API.Controllers
{
    [Route("test/api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepositories branchRepositories;
        //add extra line for git test lahir ad
        public BranchController(IBranchRepositories branchRepositories)
        {
            this.branchRepositories = branchRepositories;
        }

        [HttpGet("get/{id:int}")]
        [ValidateModel]
        public async Task<IActionResult> GetAll([FromRoute] int id)
        {
            try
            {
                var branch = await branchRepositories.Get(id);
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
                    Message = "Issue in fetching Branch.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData);
            }
        }

        [HttpPost("add")]
        [ValidateModel]
        public async Task<IActionResult> Add([FromBody] BranchRequestDTO branchRequestDTO)
        {
            try
            {
                var branch = await branchRepositories.Add(branchRequestDTO);
                var responseData = new ResponseDTO
                {
                    Status = "True",
                    Message = "Branch Submitted Successfully.",
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
                    Message = "Issue in Add Branch.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData);
            }
        }


        [HttpPost("edit/{id:int}")]
        [ValidateModel]
        public async Task<IActionResult> Edit([FromRoute] int id ,[FromBody] EditBranchRequestDTO editBranchRequestDTO)
        {
            try
            {
                var branch = await branchRepositories.Edit(id,editBranchRequestDTO);
                var responseData = new ResponseDTO
                {
                    Status = "True",
                    Message = "Branch Updated Successfully",
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
                    Message = "Issue in Updated Branch.",
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
                var branch = await branchRepositories.Delete(id);
                var responseData = new ResponseDTO
                {
                    Status = "True",
                    Message = "Branch Deleted Successfully",
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
                    Message = "Issue in Deleting Branch.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData);
            }
        }

      
    }
}
