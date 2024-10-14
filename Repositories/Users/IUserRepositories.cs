using VinxTech.API.Models.Domain;
using VinxTech.API.Models.DTOs;

namespace VinxTech.API.Repositories
{
    public interface IUserRepositories
    {
        Task<(Users,string Error)> register(UsersRequestDTO usersRequestDTO);

        Task<bool> login(LoginRequestDTO loginRequestDTO);

        Task<bool> updatepassword(updatePasswordRequestDTO updatePasswordRequestDTO);

        Task<bool> userActivation(userActivationRequestDTO userActivationRequestDTO);
    }
}
