using VinxTech.API.Models.Domain;
using VinxTech.API.Models.DTOs;
using VinxTech.API.Models.DTOs.Services;

namespace VinxTech.API.Repositories.Services
{
    public interface IServiceRepositories
    {
        Task<Models.Domain.Services> Add(ServiceRequestDTO serviceRequestDTO);

        Task<List<Models.Domain.Services>> Get(Int32 id);

        Task<Models.Domain.Services> Edit(Int32 id, EditServiceRequestDTO editServiceRequestDTO);

        Task<Int32> Delete(Int32 id);
    }
}
