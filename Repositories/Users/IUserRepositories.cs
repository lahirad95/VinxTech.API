using Microsoft.EntityFrameworkCore;
using VinxTech.API.Models.Domain;
using VinxTech.API.Models.DTOs;
using VinxTech.API.Models.DTOs.Users;
using VinxTech.API.Models.ResponseDTOs;

namespace VinxTech.API.Repositories
{
    public interface IUserRepositories
    {
        Task<(Users,string Error)> register(UsersRequestDTO usersRequestDTO);

        Task<bool> login(LoginRequestDTO loginRequestDTO);

        Task<bool> updatepassword(updatePasswordRequestDTO updatePasswordRequestDTO);

        Task<bool> userActivation(userActivationRequestDTO userActivationRequestDTO);

        Task<bool> Delete(string UserId);
        Task<UpdateRequestDTO> Update(string UserId,UpdateRequestDTO updateRequestDTO);

        Task<(List<UserGetAllResponseDTO>, Int32 TotalCount)> GetAll(Int32 PageNumber, Int32 PageSize);

        Task<UserGetAllResponseDTO> GetbyId(Int64 id);
    }
}
