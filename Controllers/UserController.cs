using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VinxTech.API.CustomActionFilters;
using VinxTech.API.Models.Domain;
using VinxTech.API.Models.DTOs;
using VinxTech.API.Models.DTOs.Users;
using VinxTech.API.Models.ResponseDTOs;
using VinxTech.API.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VinxTech.API.Controllers
{
    [Route("test/api/[controller]")]
    [ApiController]

    //testing
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


        [HttpPost("delete/{UserId}")]
        [ValidateModel]

        public async Task<IActionResult> Delete([FromRoute] string UserId)
        {
            try
            {

                bool status = await userRepositories.Delete(UserId);

                if (status)
                {
                    var responseData = new ResponseDTO
                    {
                        Status = "success",
                        Message = "User Deleted Successfully",
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
                        Message = "Issue in Delete User",
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
                return BadRequest(responseData);
            }
        }

        [HttpPost("update/{UserId}")]
        [ValidateModel]

        public async Task<IActionResult> Update([FromRoute] string UserId,[FromBody] UpdateRequestDTO updateRequestDTO)
        {
            try
            {
                var user = await userRepositories.Update(UserId, updateRequestDTO);
                var responseData = new ResponseDTO
                {
                    Status = "True",
                    Message = "User Updated Successfully",
                    Data = new { user },
                    Errors = new List<string>()
                };
                return Ok(user);
            }
            catch (Exception ex)
            {
                var responseData = new ResponseDTO
                {
                    Status = "False",
                    Message = "Issue in Update.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData);
            }
        }

        [HttpGet("GetAll")]
        [ValidateModel]

        public async Task<IActionResult> GetAll([FromQuery] Int32 PageNumber, [FromQuery] Int32 Pazesize)
        {
            try
            {
                var (user, count) = await userRepositories.GetAll(PageNumber, Pazesize);

                var responseData = new
                {
                    Status = "True",
                    Message = "",
                    Count = count,
                    Data = new { user },
                    Errors = new List<string>(),
                };

                return Ok(responseData);
            }
            catch (Exception ex)
            {
                var responseData = new ResponseDTO
                {
                    Status = "False",
                    Message = "Issue in Get Users.",
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
                var employee = await userRepositories.GetbyId(id);
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
                    Message = "Issue in Get User.",
                    Data = new { },
                    Errors = new List<string>()
                };
                return BadRequest(responseData);
            }
        }

    }
}
