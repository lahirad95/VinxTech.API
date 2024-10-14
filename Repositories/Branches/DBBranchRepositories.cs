using Microsoft.EntityFrameworkCore;
using VinxTech.API.Data;
using VinxTech.API.Models.Domain;
using VinxTech.API.Models.DTOs;

namespace VinxTech.API.Repositories
{
    public class DBBranchRepositories : IBranchRepositories
    {
        private readonly VinxDbContext dbContext;

        public DBBranchRepositories(VinxDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Branches> Add(BranchRequestDTO branchRequestDTO)
        {
            Branches branches = new Branches();
            branches.UpdatedAt = DateTime.Now;
            branches.CreatedAt = DateTime.Now;
            branches.DescriptionEn = branchRequestDTO.DescriptionEn;
            branches.DescriptionAr = branchRequestDTO.DescriptionAr;
            branches.NameEn = branchRequestDTO.NameEn;
            branches.NameAr = branchRequestDTO.NameAr;

            await dbContext.Branches.AddAsync(branches);
            await dbContext.SaveChangesAsync();
            return branches;
        }

        public async Task<Int32> Delete(Int32 id)
        {
            var branch = await dbContext.Branches.FindAsync(id);
            dbContext.Branches.Remove(branch);
            await dbContext.SaveChangesAsync();

            return id;    
        }

        public async Task<Branches> Edit(Int32 id,  EditBranchRequestDTO editBranchRequestDTO)
        {
            var branch = await dbContext.Branches.FindAsync(id);

            branch.DescriptionEn = editBranchRequestDTO.DescriptionEn;
            branch.DescriptionAr = editBranchRequestDTO.DescriptionAr;
            branch.NameEn = editBranchRequestDTO.NameEn;
            branch.NameAr = editBranchRequestDTO.NameAr;
            branch.UpdatedAt = DateTime.Now;    
            dbContext.Branches.Update(branch);
            await dbContext.SaveChangesAsync();
            return branch;
        }

        public async Task<List<Branches>> Get(Int32 id)
        {
            IQueryable<Branches> query = dbContext.Branches;

            if (id >= 1000)
            {
                query = query.Where(x => x.Id == id);
            }
            var branches = await query.ToListAsync();
            return branches;
        }
    }
}
