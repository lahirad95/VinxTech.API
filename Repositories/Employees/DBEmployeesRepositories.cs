using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using VinxTech.API.Data;
using VinxTech.API.Models.Domain;
using VinxTech.API.Models.DTOs;
using VinxTech.API.Models.DTOs.Employees;
using VinxTech.API.Models.DTOs.Services;
using VinxTech.API.Models.ResponseDTOs;

namespace VinxTech.API.Repositories.Employees
{
    public class DBEmployeesRepositories : IEmployeesRepositories
    {
        private readonly VinxDbContext vinxDbContext;

        public DBEmployeesRepositories(VinxDbContext vinxDbContext)
        {
            this.vinxDbContext = vinxDbContext;
        }
        public async Task<Models.Domain.Employees> Add(AddEmployeeRequestDTO addEmployeeRequestDTO)
        {
            Models.Domain.Employees employee = new Models.Domain.Employees();
            var employeeExist = await this.vinxDbContext.Employees.FirstOrDefaultAsync(x => x.IdNumber == addEmployeeRequestDTO.IdNumber);

            if (employeeExist != null)
            {
                employeeExist.UpdatedAt = DateTime.Now;
                await vinxDbContext.SaveChangesAsync();
            }
            else
            {
                employee.firstNameEn = addEmployeeRequestDTO.firstNameEn;
                employee.lastNameEn = addEmployeeRequestDTO.lastNameEn;
                employee.firstNameAr = addEmployeeRequestDTO.firstNameAr;
                employee.lastNameAr = addEmployeeRequestDTO.lastNameAr;
                employee.Email = addEmployeeRequestDTO.Email;
                employee.MobileNumber = addEmployeeRequestDTO.MobileNumber;
                employee.DOB = addEmployeeRequestDTO.DOB;
                employee.IdNumber = addEmployeeRequestDTO.IdNumber;
                employee.HireDate = addEmployeeRequestDTO.HireDate;
                employee.IdExpiryDate = addEmployeeRequestDTO.IdExpiryDate;
                employee.IsActive = true;
                employee.Branch = addEmployeeRequestDTO.Branch;
                employee.CretedBy = addEmployeeRequestDTO.CretedBy;
                employee.UpdatedAt = DateTime.Now;
                employee.CreatedAt = DateTime.Now;
                employee.Image = addEmployeeRequestDTO.Image;   
                employee.Gender = addEmployeeRequestDTO.Gender;
                employee.Nationality = addEmployeeRequestDTO.Nationality;
                await vinxDbContext.Employees.AddAsync(employee);
                await vinxDbContext.SaveChangesAsync();
            }

            EmployeeServices employeeServices = new EmployeeServices();

            foreach (var item in addEmployeeRequestDTO.Services)
            {
                var serviceExist = await this.vinxDbContext.EmployeeServices.FirstOrDefaultAsync(x => x.EmployeeId == addEmployeeRequestDTO.IdNumber && x.ServiceID == item);

                if (serviceExist != null)
                {
                    serviceExist.UpdatedDate = DateTime.Now;
                    await vinxDbContext.SaveChangesAsync();
                }
                else
                {
                    employeeServices.EmployeeId = addEmployeeRequestDTO.IdNumber;
                    employeeServices.ServiceID = item;
                    employeeServices.Id = Guid.NewGuid();
                    employeeServices.CreatedDate = DateTime.Now;
                    employeeServices.UpdatedDate = DateTime.Now;
                    await vinxDbContext.EmployeeServices.AddAsync(employeeServices);
                    await vinxDbContext.SaveChangesAsync();
                }
            }
            return employee;
        }

        public async Task<Int64> Delete(Int64 id)
        {
            var employee = await vinxDbContext.Employees.FirstOrDefaultAsync(e => e.IdNumber == id);

            if (employee != null)
            {
                vinxDbContext.Employees.Remove(employee);
                await vinxDbContext.SaveChangesAsync();
            }

            var employeeServices = await vinxDbContext.EmployeeServices
                .Where(e => e.EmployeeId == id)
                .ToListAsync();

            if (employeeServices != null)
            {
                vinxDbContext.EmployeeServices.RemoveRange(employeeServices);
                await vinxDbContext.SaveChangesAsync();
            }


            return id;
        }

        public async Task<EditEmployeeResponseDTO> Edit(long id, EditEmployeeRequestDTO editEmployeeRequestDTO)
        {
            EditEmployeeResponseDTO editEmployeeResponseDTO = new EditEmployeeResponseDTO();

            var employee = await vinxDbContext.Employees.FirstOrDefaultAsync(e => e.IdNumber == id);

            if (employee != null)
            {
                employee.firstNameEn = editEmployeeRequestDTO.firstNameEn;
                employee.lastNameEn = editEmployeeRequestDTO.lastNameEn;
                employee.firstNameAr = editEmployeeRequestDTO.firstNameAr;
                employee.lastNameAr = editEmployeeRequestDTO.lastNameAr;
                employee.Email = editEmployeeRequestDTO.Email;
                employee.MobileNumber = editEmployeeRequestDTO.MobileNumber;
                employee.DOB = editEmployeeRequestDTO.DOB;
                employee.HireDate = editEmployeeRequestDTO.HireDate;
                employee.IdExpiryDate = editEmployeeRequestDTO.IdExpiryDate;
                //employee.IsActive = true;
                employee.Branch = editEmployeeRequestDTO.Branch;
                employee.CretedBy = editEmployeeRequestDTO.CretedBy;
                employee.UpdatedAt = DateTime.Now;
                employee.Image = editEmployeeRequestDTO.Image;
                employee.Gender = editEmployeeRequestDTO.Gender;
                employee.Nationality = editEmployeeRequestDTO.Nationality;
                await vinxDbContext.SaveChangesAsync();
            }

            var employeeServices = await vinxDbContext.EmployeeServices
                .Where(e => e.EmployeeId == id)
                .ToListAsync();

            if (employeeServices != null)
            {
                vinxDbContext.EmployeeServices.RemoveRange(employeeServices);
                await vinxDbContext.SaveChangesAsync();
            }

            EmployeeServices emp = new EmployeeServices();
            foreach (var item in editEmployeeRequestDTO.Services)
            {
                emp.EmployeeId = id;
                emp.ServiceID = item;
                emp.Id = Guid.NewGuid();
                emp.CreatedDate = DateTime.Now;
                emp.UpdatedDate = DateTime.Now;
                await vinxDbContext.EmployeeServices.AddAsync(emp);
                await vinxDbContext.SaveChangesAsync();
            }

            editEmployeeResponseDTO.firstNameEn = editEmployeeRequestDTO.firstNameEn;
            editEmployeeResponseDTO.lastNameEn = editEmployeeRequestDTO.lastNameEn;
            editEmployeeResponseDTO.firstNameAr = editEmployeeRequestDTO.firstNameAr;
            editEmployeeResponseDTO.lastNameAr = editEmployeeRequestDTO.lastNameAr;
            editEmployeeResponseDTO.Email = editEmployeeRequestDTO.Email;
            editEmployeeResponseDTO.MobileNumber = editEmployeeRequestDTO.MobileNumber;
            editEmployeeResponseDTO.DOB = editEmployeeRequestDTO.DOB;
            editEmployeeResponseDTO.IdNumber = id;
            editEmployeeResponseDTO.HireDate = editEmployeeRequestDTO.HireDate;
            editEmployeeResponseDTO.IdExpiryDate = editEmployeeRequestDTO.IdExpiryDate;
            //editEmployeeResponseDTO.IsActive = true;
            editEmployeeResponseDTO.CretedBy = editEmployeeRequestDTO.CretedBy;

            var Getbrach = await vinxDbContext.Branches
              .FirstOrDefaultAsync(e => e.Id == editEmployeeRequestDTO.Branch);

            editEmployeeResponseDTO.Branch = new List<Branch>
            {
                new Branch
                {
                    Id = editEmployeeRequestDTO.Branch,
                    NameEn           = Getbrach.NameEn,
                    NameAr           = Getbrach.NameAr,
                    DescriptionEn    = Getbrach.DescriptionEn,
                    DescriptionAr    = Getbrach.DescriptionAr,
                }
            };

            if (editEmployeeResponseDTO.Services == null)
            {
                editEmployeeResponseDTO.Services = new List<Service>();
            }

            foreach (var item in editEmployeeRequestDTO.Services)
            {
                var employeeServiceWithService = await (
                    from es in vinxDbContext.EmployeeServices
                    join s in vinxDbContext.Services
                    on es.ServiceID equals s.Id
                    where es.EmployeeId == id && es.ServiceID == Convert.ToInt32(item)
                    select new
                    {
                        EmployeeId = es.EmployeeId,
                        ServiceID = es.ServiceID,
                        ServiceNameEn = s.ServiceNameEn,
                        ServiceNameAr = s.ServiceNameAr,
                        ServiceDescriptionEn = s.ServiceDescriptionEn,
                        ServiceDescriptionAr = s.ServiceDescriptionAr,
                    }
                ).FirstOrDefaultAsync();

                if (employeeServiceWithService != null)
                {
                    // Add each service to the existing Services list
                    editEmployeeResponseDTO.Services.Add(new Service
                    {
                        Id = employeeServiceWithService.ServiceID,
                        ServiceNameEn = employeeServiceWithService.ServiceNameEn,
                        ServiceNameAr = employeeServiceWithService.ServiceNameAr,
                        ServiceDescriptionEn = employeeServiceWithService.ServiceDescriptionEn,
                        ServiceDescriptionAr = employeeServiceWithService.ServiceDescriptionAr,
                    });
                }
            }
            return editEmployeeResponseDTO;
        }

        public async Task<(List<EmployeebyIdResponse>, int TotalCount)> GetAll(int PageNumber, int PageSize)
        {
            // Initialize the response list
            List<EmployeebyIdResponse> employeebyIdResponses = new List<EmployeebyIdResponse>();

            var EmpCount = await vinxDbContext.Employees.Where(q=> q.IsActive == true).CountAsync();  

            // Query to get the employee data with paging
            var employees = await (
                from es in vinxDbContext.Employees
                join s in vinxDbContext.Branches
                on es.Branch equals s.Id
                where es.IsActive == true
                select new
                {
                    CreateDate = es.CreatedAt,
                    NameEn = s.NameEn,
                    NameAr = s.NameAr,
                    DescriptionEn = s.DescriptionEn,
                    DescriptionAr = s.DescriptionAr,
                    Id = s.Id,
                    firstNameEn = es.firstNameEn,
                    lastNameEn = es.lastNameEn,
                    firstNameAr = es.firstNameAr,
                    lastNameAr = es.lastNameAr,
                    Email = es.Email,
                    MobileNumber = es.MobileNumber,
                    DOB = es.DOB,
                    IdNumber = es.IdNumber,
                    HireDate = es.HireDate,
                    IdExpiryDate = es.IdExpiryDate,
                    IsActive = es.IsActive,
                    Branch = es.Branch,
                    CretedBy = es.CretedBy,
                    Image = es.Image,
                    Gender = es.Gender,
                    Nationality = es.Nationality,
                }
            )
            .Skip((PageNumber - 1) * PageSize) // Skip the previous pages' data
            .Take(PageSize).OrderBy(es => es.CreateDate)                    // Take the number of records equal to PageSize
            .ToListAsync();                    // Get list of employees

            // If employees are found, process each one
            if (employees != null && employees.Count > 0)
            {
                foreach (var emp in employees)
                {
                    // Create a new EmployeebyIdResponse for each employee
                    EmployeebyIdResponse employeebyIdResponse = new EmployeebyIdResponse
                    {
                        firstNameEn = emp.firstNameEn,
                        lastNameEn = emp.lastNameEn,
                        firstNameAr = emp.firstNameAr,
                        lastNameAr = emp.lastNameAr,
                        Email = emp.Email,
                        MobileNumber = emp.MobileNumber,
                        DOB = emp.DOB,
                        IdNumber = emp.IdNumber,
                        HireDate = emp.HireDate,
                        IdExpiryDate = emp.IdExpiryDate,
                        IsActive = emp.IsActive,
                        CretedBy = emp.CretedBy,
                        Image = emp.Image,
                        Gender = emp.Gender,
                        Nationality = emp.Nationality,
                        // Assign branch information
                        Branch = new List<EmployeeBranch>
                {
                    new EmployeeBranch
                    {
                        Id = emp.Branch,
                        NameEn = emp.NameEn,
                        NameAr = emp.NameAr,
                        DescriptionEn = emp.DescriptionEn,
                        DescriptionAr = emp.DescriptionAr,
                    }
                }
                    };

                    // Query to get the services for the current employee
                    var employeeServiceWithService = await (
                        from es in vinxDbContext.EmployeeServices
                        join s in vinxDbContext.Services
                        on es.ServiceID equals s.Id
                        where es.EmployeeId == emp.IdNumber
                        select new
                        {
                            ServiceID = es.ServiceID,
                            ServiceNameEn = s.ServiceNameEn,
                            ServiceNameAr = s.ServiceNameAr,
                            ServiceDescriptionEn = s.ServiceDescriptionEn,
                            ServiceDescriptionAr = s.ServiceDescriptionAr,
                        }
                    ).ToListAsync();

                    // Populate services for the employee
                    employeebyIdResponse.Services = new List<EmployeeService>();
                    foreach (var item in employeeServiceWithService)
                    {
                        employeebyIdResponse.Services.Add(new EmployeeService
                        {
                            Id = item.ServiceID,
                            ServiceNameEn = item.ServiceNameEn,
                            ServiceNameAr = item.ServiceNameAr,
                            ServiceDescriptionEn = item.ServiceDescriptionEn,
                            ServiceDescriptionAr = item.ServiceDescriptionAr,
                        });
                    }

                    // Add the filled response object to the list
                    employeebyIdResponses.Add(employeebyIdResponse);
                }
            }

            // Return the list of responses
            return (employeebyIdResponses, EmpCount);
        }

        public async Task<EmployeebyIdResponse> GetbyId(long id)
        {

            EmployeebyIdResponse employeebyIdResponse = new EmployeebyIdResponse();

            var employee = await (
                   from es in vinxDbContext.Employees
                   join s in vinxDbContext.Branches
                   on es.Branch equals s.Id
                   where es.IdNumber == id && es.IsActive == true
                   select new
                   {
                       NameEn = s.NameEn,
                       NameAr = s.NameAr,
                       DescriptionEn = s.DescriptionEn,
                       DescriptionAr = s.DescriptionAr,
                       Id = s.Id,
                       firstNameEn = es.firstNameEn,
                       lastNameEn = es.lastNameEn,
                       firstNameAr = es.firstNameAr,
                       lastNameAr = es.lastNameAr,
                       Email = es.Email,
                       MobileNumber = es.MobileNumber,
                       DOB = es.DOB,
                       IdNumber = es.IdNumber,
                       HireDate = es.HireDate,
                       IdExpiryDate = es.IdExpiryDate,
                       IsActive = es.IsActive,
                       Branch = es.Branch,
                       CretedBy = es.CretedBy,
                       Image = es.Image,
                       Gender = es.Gender,
                       Nationality = es.Nationality,
                   }
               ).FirstOrDefaultAsync();


            employeebyIdResponse.firstNameEn = employee.firstNameEn;
            employeebyIdResponse.lastNameEn = employee.lastNameEn;
            employeebyIdResponse.firstNameAr = employee.firstNameAr;
            employeebyIdResponse.lastNameAr = employee.lastNameAr;
            employeebyIdResponse.Email = employee.Email;
            employeebyIdResponse.MobileNumber = employee.MobileNumber;
            employeebyIdResponse.DOB = employee.DOB;
            employeebyIdResponse.IdNumber = id;
            employeebyIdResponse.HireDate = employee.HireDate;
            employeebyIdResponse.IdExpiryDate = employee.IdExpiryDate;
            employeebyIdResponse.IsActive = true;
            employeebyIdResponse.CretedBy = employee.CretedBy;
            employeebyIdResponse.Image = employee.Image;
            employeebyIdResponse.Gender = employee.Gender;
            employeebyIdResponse.Nationality = employee.Nationality;
            employeebyIdResponse.Branch = new List<EmployeeBranch>
            {
                new EmployeeBranch
                {
                    Id               = employee.Branch,
                    NameEn           = employee.NameEn,
                    NameAr           = employee.NameAr,
                    DescriptionEn    = employee.DescriptionEn,
                    DescriptionAr    = employee.DescriptionAr,
                }
            };


            var employeeServiceWithService = await (
                    from es in vinxDbContext.EmployeeServices
                    join s in vinxDbContext.Services
                    on es.ServiceID equals s.Id
                    where es.EmployeeId == id
                    select new
                    {
                        EmployeeId = es.EmployeeId,
                        ServiceID = es.ServiceID,
                        ServiceNameEn = s.ServiceNameEn,
                        ServiceNameAr = s.ServiceNameAr,
                        ServiceDescriptionEn = s.ServiceDescriptionEn,
                        ServiceDescriptionAr = s.ServiceDescriptionAr,
                    }
                ).ToListAsync();

            employeebyIdResponse.Services = new List<EmployeeService>();

            foreach (var item in employeeServiceWithService)
            {
                employeebyIdResponse.Services.Add(new EmployeeService
                {
                    Id = item.ServiceID,
                    ServiceNameEn = item.ServiceNameEn,
                    ServiceNameAr = item.ServiceNameAr,
                    ServiceDescriptionEn = item.ServiceDescriptionEn,
                    ServiceDescriptionAr = item.ServiceDescriptionAr,
                });
            }

            return employeebyIdResponse;

        }

        public async Task<bool> userActivation(EmployeeActivationRequestDTO employeeActivationRequestDTO)
        {
            try
            {
                ///
                var userExists = await vinxDbContext.Employees.FirstOrDefaultAsync(u => u.IdNumber == employeeActivationRequestDTO.IdNumber);

                if (userExists != null)
                {
                    userExists.IsActive = employeeActivationRequestDTO.Status;
                    await vinxDbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
