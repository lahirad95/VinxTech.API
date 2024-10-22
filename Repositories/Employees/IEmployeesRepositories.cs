using VinxTech.API.Models.Domain;
using VinxTech.API.Models.DTOs;
using VinxTech.API.Models.DTOs.Employees;
using VinxTech.API.Models.DTOs.Services;
using VinxTech.API.Models.ResponseDTOs;

namespace VinxTech.API.Repositories.Employees
{
    public interface IEmployeesRepositories
    {
        Task<Models.Domain.Employees> Add(AddEmployeeRequestDTO addEmployeeRequestDTO);
        Task<Int64> Delete(Int64 id);
        Task<EditEmployeeResponseDTO> Edit(Int64 id, EditEmployeeRequestDTO editEmployeeRequestDTO);
        Task<EmployeebyIdResponse> GetbyId(Int64 id);
        Task<(List<EmployeebyIdResponse>,Int32 TotalCount)> GetAll(Int32 PageNumber,Int32 PageSize);
        Task<bool> userActivation(EmployeeActivationRequestDTO employeeActivationRequestDTO);

    }
}
