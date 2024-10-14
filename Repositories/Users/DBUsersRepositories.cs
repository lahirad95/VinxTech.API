using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VinxTech.API.Data;
using VinxTech.API.Functions;
using VinxTech.API.Models.Domain;
using VinxTech.API.Models.DTOs;
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
