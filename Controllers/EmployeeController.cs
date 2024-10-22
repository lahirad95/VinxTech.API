using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VinxTech.API.CustomActionFilters;
using VinxTech.API.Models.Domain;
using VinxTech.API.Models.DTOs;
using VinxTech.API.Models.DTOs.Employees;
using VinxTech.API.Models.DTOs.Services;
using VinxTech.API.Models.ResponseDTOs;
using VinxTech.API.Repositories;
using VinxTech.API.Repositories.Employees;

namespace VinxTech.API.Controllers
{
    [Route("test/api/[controller]")]
    [ApiController]


    //testing command line added
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeesRepositories employeesRepositories;
        public EmployeeController(IEmployeesRepositories employeesRepositories)
        {
            this.employeesRepositories = employeesRepositories;
        }

        [HttpPost("add")]
        [ValidateModel]

        public async Task<IActionResult> Add([FromBody] AddEmployeeRequestDTO addEmployeeRequestDTO)
        {
            try
            {
                var employee = await employeesRepositories.Add(addEmployeeRequestDTO);
                var responseData = new ResponseDTO
                {
                    Status = "True",
                    Message = "Employee Submitted Successfully.",
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
                    Message = "Issue in Add Employee.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData);
            }
        }

        [HttpPost("delete/{id:long}")]
        [ValidateModel]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            try
            {
                var employee = await employeesRepositories.Delete(id);
                var responseData = new ResponseDTO
                {
                    Status = "True",
                    Message = "Employee Deleted Successfully.",
                    Data = new { employee },
                    Errors = new List<string>()
                };
                return Ok(responseData);
            }
            catch (Exception ex)
            {

                var responseData = new ResponseDTO
                {
                    Status = "False",
                    Message = "Issue in Deleting Employee.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData);
            }
        }

        [HttpPost("edit/{id:long}")]
        [ValidateModel]
        public async Task<IActionResult> Edit([FromRoute] long id, [FromBody] EditEmployeeRequestDTO editEmployeeRequestDTO)
        {
            try
            {
                var employee = await employeesRepositories.Edit(id,editEmployeeRequestDTO);
                var responseData = new ResponseDTO
                {
                    Status = "True",
                    Message = "Employee Updated Successfully.",
                    Data = new { employee },
                    Errors = new List<string>()
                };
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                var responseData = new ResponseDTO
                {
                    Status = "False",
                    Message = "Issue in Update Employee.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData);
            }
        }

        [HttpGet("get/{id:long}")]
        [ValidateModel]

        public async Task<IActionResult> GetbyId([FromRoute] long id)
        {
            try
            {
                var employee = await employeesRepositories.GetbyId(id);
                var responseData = new ResponseDTO
                {
                    Status = "True",
                    Message = "",
                    Data = new { employee },
                    Errors = new List<string>()
                };
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                var responseData = new ResponseDTO
                {
                    Status = "False",
                    Message = "Issue in Get Employee.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData);
            }
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] Int32 PageNumber, [FromQuery] Int32 Pazesize)
        {

            try
            {
                var(employee, count) = await employeesRepositories.GetAll(PageNumber, Pazesize);

                var responseData = new
                {
                    Status = "True",
                    Message = "",
                    Count = count,
                    Data = new { employee },
                    Errors = new List<string>(),
                };

                return Ok(responseData);
            }
            catch (Exception ex)
            {
                var responseData = new ResponseDTO
                {
                    Status = "False",
                    Message = "Issue in Get Employee.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData);
            }
        }

        [HttpPost("employeeActivation")]
        [ValidateModel]

        public async Task<IActionResult> employeeActivation([FromBody] EmployeeActivationRequestDTO employeeActivationRequestDTO)
        {
            try
            {

                bool status = await employeesRepositories.userActivation(employeeActivationRequestDTO);

                if (status)
                {
                    var responseData = new ResponseDTO
                    {
                        Status = "success",
                        Message = "Status Updated Successfully",
                        Data = new { },
                        Errors = new List<string>()
                    };
                    return Ok(responseData);
                }
                else
                {
                    var responseData = new ResponseDTO
                    {
                        Status = "False",
                        Message = "Invalid UserName.",
                        Data = new { },
                        Errors = new List<string>()
                    };
                    return BadRequest(responseData);
                }
            }
            catch (Exception ex)
            {

                var responseData = new ResponseDTO
                {
                    Status = "False",
                    Message = "Invalid UserName.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData); throw;
            }
        }
    }
}
