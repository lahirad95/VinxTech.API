using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VinxTech.API.CustomActionFilters;
using VinxTech.API.Models.Domain;
using VinxTech.API.Models.DTOs;
using VinxTech.API.Models.ResponseDTOs;
using VinxTech.API.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VinxTech.API.Controllers
{
    [Route("test/api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositories userRepositories;
        private readonly IConfiguration configuration;

        public UserController(IUserRepositories userRepositories,IConfiguration configuration)
        {
            this.userRepositories = userRepositories;
            this.configuration = configuration;
        }


        [HttpPost("register")]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody] UsersRequestDTO usersRequestDTO)
        {

            try
            {
                var (users, error) = await userRepositories.register(usersRequestDTO);

                if (error.Any())
                {
                    var responseData = new ResponseDTO
                    {
                        Status = "Failure",
                        Message = "User not Created.",
                        Data = new { },
                        Errors = new List<string> { error }
                    };
                    return BadRequest(responseData);
                }
                else
                {
                    var responseData = new ResponseDTO
                    {
                        Status = "success",
                        Message = "User Created successfully.",
                        Data = new { Username = users.Username, IsActive = users.IsActive },
                        Errors = new List<string>()
                    };
                    return Ok(responseData);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        [ValidateModel] 
        public async Task<IActionResult> login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            try
            {
                bool status = await userRepositories.login(loginRequestDTO);

                if (status)
                {
                    var responseData = new ResponseDTO
                    {
                        Status = "success",
                        Message = "",
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
                        Message = "Invalid UserName and Password.",
                        Data = new {  },
                        Errors = new List<string>()
                    };
                    return BadRequest(responseData);
                }

            }
            catch (Exception)
            {
                var responseData = new ResponseDTO
                {
                    Status = "False",
                    Message = "Invalid UserName and Password.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData); 
            }
        }

        [HttpPost("updatePassword")]
        [ValidateModel]
        public async Task<IActionResult> updatePassword([FromBody] updatePasswordRequestDTO updatePassword)
        {
            try
            {
                bool status = await userRepositories.updatepassword(updatePassword);

                if (status)
                {
                    var responseData = new ResponseDTO
                    {
                        Status = "success",
                        Message = "Password Updated Successfully",
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
                        Message = "Invalid UserName and Password.",
                        Data = new { },
                        Errors = new List<string>()
                    };
                    return BadRequest(responseData);
                }

            }
            catch (Exception)
            {
                var responseData = new ResponseDTO
                {
                    Status = "False",
                    Message = "Invalid UserName and Password.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData); throw;
            }
        }

        [HttpPost("userActivation")]
        [ValidateModel]

        public async Task<IActionResult> userActivation([FromBody] userActivationRequestDTO userActivationRequestDTO)
        {
            try
            {

                bool status = await userRepositories.userActivation(userActivationRequestDTO);

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
