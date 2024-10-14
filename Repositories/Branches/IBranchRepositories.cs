using VinxTech.API.Models.Domain;
using VinxTech.API.Models.DTOs;

namespace VinxTech.API.Repositories
{
    public interface IBranchRepositories
    {
        Task<Branches> Add(BranchRequestDTO branchRequestDTO);

        Task<List<Branches>> Get(Int32 id);

        Task<Branches> Edit(Int32 id,EditBranchRequestDTO editBranchRequestDTO);

        Task<Int32> Delete(Int32 id);
    }
}
