using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VinxTech.API.Data;
using VinxTech.API.Functions;
using VinxTech.API.Models.Domain;
using VinxTech.API.Models.DTOs;
using VinxTech.API.Models.DTOs.Employees;
using VinxTech.API.Models.DTOs.Users;
using VinxTech.API.Models.ResponseDTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VinxTech.API.Repositories
{
    public class DBUsersRepositories : IUserRepositories
    {
        private readonly VinxDbContext vinxDbContext;
        public DBUsersRepositories(VinxDbContext vinxDbContext)
        {
            this.vinxDbContext = vinxDbContext;
        }
        public async Task<bool> Delete(string UserId)
        {
            try
            {

                var userExists = await vinxDbContext.Users.FirstOrDefaultAsync(u => u.Username == UserId && u.IsActive == true);

                if (userExists != null)
                {
                    vinxDbContext.Users.Remove(userExists);
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

                return false;
            }
        }
        public async Task<(List<UserGetAllResponseDTO>, int TotalCount)> GetAll(int PageNumber, int PageSize)
        {
            List<UserGetAllResponseDTO> userGetAllResponseDTOs = new List<UserGetAllResponseDTO>();

            var UserCount = await vinxDbContext.Users.Where(q => q.IsActive == true).CountAsync();

            // Query to get the employee data with paging
            var users = await(
                from es in vinxDbContext.Users 
                join s in vinxDbContext.Branches
                on es.Breanch  equals s.Id
                join r in vinxDbContext.Roles 
                on es.Role equals r.Id
                where es.IsActive == true
                select new
                {

                    Username = es.Username,
                    firstNameEn = es.firstNameEn,
                    lastNameEn = es.lastNameEn,
                    firstNameAr = es.firstNameAr,
                    lastNameAr = es.lastNameAr,
                    Email = es.Email,
                    MobileNumber = es.MobileNumber,
                    DOB = es.DOB,
                    IdNumber = es.IdNumber,
                    IdExpiryDate = es.IdExpiryDate,
                    Role = es.Role,
                    HireDate = es.HireDate,
                    IsActive = es.IsActive,
                    Image = es.Image,
                    CreatedDate = es.CreatedAt,
                    Gender = es.Gender,
                    Nationality = es.Nationality,

                    BreanchAr = s.NameAr,
                    BreanchEn = s.NameEn,
                    BreanchId = s.Id,
                    BreanchDescriptionEn = s.DescriptionEn,
                    BreanchDescriptionAr = s.DescriptionAr,

                    RoleName = r.Name,
                    RoleDescription = r.Description,
                    RoleId = r.Id,


                }
            )
            .Skip((PageNumber - 1) * PageSize) // Skip the previous pages' data
            .Take(PageSize).OrderBy(es => es.CreatedDate)                    // Take the number of records equal to PageSize
            .ToListAsync();

            if (users != null && users.Count > 0)
            {
                foreach (var usr in users)
                {
                    // Create a new EmployeebyIdResponse for each employee
                    UserGetAllResponseDTO userGetAllResponse = new UserGetAllResponseDTO
                    {
                        Username    = usr.Username,
                        firstNameEn = usr.firstNameEn,
                        lastNameEn = usr.lastNameEn,
                        firstNameAr = usr.firstNameAr,
                        lastNameAr = usr.lastNameAr,
                        Email = usr.Email,
                        MobileNumber = usr.MobileNumber,
                        DOB = usr.DOB,
                        IdNumber = usr.IdNumber,
                        HireDate = usr.HireDate,
                        IdExpiryDate = usr.IdExpiryDate,
                        IsActive = usr.IsActive,
                        Image = usr.Image,
                        Gender = usr.Gender,
                        Nationality = usr.Nationality,

                        Breanch = usr.BreanchId,
                        BreanchEn = usr.BreanchEn,
                        BreanchAr = usr.BreanchAr,
                        BreanchDescriptionEn = usr.BreanchDescriptionEn,
                        BreanchDescriptionAr = usr.BreanchDescriptionAr,

                        RoleName = usr.RoleName,
                        RoleDescription = usr.RoleDescription,
                        RoleId = usr.RoleId,
                    };
                    userGetAllResponseDTOs.Add(userGetAllResponse);
                }
            }
            return (userGetAllResponseDTOs, UserCount);
        }
        public async Task<bool> login(LoginRequestDTO loginRequestDTO)
        {
            try
            {

                var userExists = await vinxDbContext.Users.AnyAsync(u=>u.Username == loginRequestDTO.Username && 
                                                                    u.PasswordHash == CommonFunctions.HashPassword(loginRequestDTO.Password) &&
                                                                    u.IsActive == true); 

                if(userExists)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public async Task<(Users,string Error)> register(UsersRequestDTO usersRequestDTO)
        {
            string Error = "";
            var users = new Users();

            try
            {
                List<Roles> roles = new List<Roles>();
                roles = await vinxDbContext.Roles.ToListAsync();

                var usernameExists = await vinxDbContext.Users.AnyAsync(u => u.Username == usersRequestDTO.Username);
                if (usernameExists)
                {
                    Error = "The username is already taken. Please choose a different username.";
                    return (users, Error);
                }

                users = new Users
                {
                    Id = Guid.NewGuid(),
                    Username = usersRequestDTO.Username,
                    PasswordHash = Functions.CommonFunctions.HashPassword(usersRequestDTO.Password),
                    firstNameEn = usersRequestDTO.firstNameEn,
                    lastNameEn = usersRequestDTO.lastNameEn,
                    firstNameAr = usersRequestDTO.firstNameAr,
                    lastNameAr = usersRequestDTO.lastNameAr,
                    Email = usersRequestDTO.Email,
                    MobileNumber = usersRequestDTO.MobileNumber,
                    Role = roles.Where(x => x.Id == usersRequestDTO.Role).Select(x => x.Id).FirstOrDefault(),
                    HireDate = usersRequestDTO.HireDate,
                    IsActive = true,
                    LastLogin = null,
                    CretedBy = usersRequestDTO.Username,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,

                    DOB = usersRequestDTO.DOB,
                    IdNumber = usersRequestDTO.IdNumber,
                    IdExpiryDate = usersRequestDTO.IdExpiryDate,
                    Breanch = usersRequestDTO.Breanch,
                    Image = usersRequestDTO.Image,  

                    Gender = usersRequestDTO.Gender,
                    Nationality = usersRequestDTO.Nationality,
                };
                await vinxDbContext.Users.AddAsync(users);
                await vinxDbContext.SaveChangesAsync();
                Logger.LogEvent("inseer success");
                return (users, Error);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return (users, Error);
            }
        }
        public async Task<UpdateRequestDTO> Update(string UserId,UpdateRequestDTO updateRequestDTO)
        {

            var user = await vinxDbContext.Users.FirstOrDefaultAsync(e => e.Username == UserId);

            if (user != null)
            {
                user.firstNameEn = updateRequestDTO.firstNameEn;
                user.lastNameEn = updateRequestDTO.lastNameEn;
                user.firstNameAr = updateRequestDTO.firstNameAr;
                user.lastNameAr = updateRequestDTO.lastNameAr;
                user.Email = updateRequestDTO.Email;
                user.MobileNumber = updateRequestDTO.MobileNumber;
                user.DOB = updateRequestDTO.DOB;
                user.HireDate = updateRequestDTO.HireDate;
                user.IdExpiryDate = updateRequestDTO.IdExpiryDate;
                user.IsActive = true;
                user.Breanch = updateRequestDTO.Breanch;
                user.UpdatedAt = DateTime.Now;
                user.Image = updateRequestDTO.Image;
                user.Gender = updateRequestDTO.Gender;
                user.Nationality = updateRequestDTO.Nationality;
                await vinxDbContext.SaveChangesAsync();
            }

            return updateRequestDTO;
        }
        public async Task<bool> updatepassword(updatePasswordRequestDTO updatePasswordRequestDTO)
        {
            try
            {

                var userExists = await vinxDbContext.Users.FirstOrDefaultAsync(u => u.Username == updatePasswordRequestDTO.Username 
                                                                    && u.PasswordHash == CommonFunctions.HashPassword(updatePasswordRequestDTO.OldPassword)
                                                                    && u.IsActive == true);

                if (userExists != null)
                {
                    userExists.PasswordHash = CommonFunctions.HashPassword(updatePasswordRequestDTO.NewPassword);
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

                return false;
            }
        }
        public async Task<bool> userActivation(userActivationRequestDTO userActivationRequestDTO)
        {
            try
            {
                var userExists = await vinxDbContext.Users.FirstOrDefaultAsync(u => u.Username == userActivationRequestDTO.Username);

                if (userExists != null)
                {
                    userExists.IsActive = userActivationRequestDTO.Status;
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
