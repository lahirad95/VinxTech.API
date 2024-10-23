
using Microsoft.EntityFrameworkCore;
using VinxTech.API.Data;
using VinxTech.API.Models.Domain;

namespace VinxTech.API.Repositories.Roles
{
    public class DBRolesRepositories : IRolesRepositories
    {
        private readonly VinxDbContext dbContext;

        public DBRolesRepositories(VinxDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Models.Domain.Roles>> get()
        {
            IQueryable<Models.Domain.Roles> query = dbContext.Roles;
           
            var roles = await query.ToListAsync();
            return roles;
        }
    }
}
