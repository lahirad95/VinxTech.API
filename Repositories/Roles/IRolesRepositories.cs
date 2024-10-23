using VinxTech.API.Models.Domain;
using VinxTech.API.Models.DTOs;

namespace VinxTech.API.Repositories.Roles
{
    public interface IRolesRepositories
    {
        Task<List<Models.Domain.Roles>> get();
    }
}
