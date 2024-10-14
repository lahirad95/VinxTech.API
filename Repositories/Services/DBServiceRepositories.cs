using Microsoft.EntityFrameworkCore;
using VinxTech.API.Data;
using VinxTech.API.Models.Domain;
using VinxTech.API.Models.DTOs;
using VinxTech.API.Models.DTOs.Services;
using VinxTech.API.Models.Domain;
//using VinxTech.API.Models.DTOs.Services;

namespace VinxTech.API.Repositories.Services
{
    public class DBServiceRepositories : IServiceRepositories
    {
        private readonly VinxDbContext vinxDbContext;

        public DBServiceRepositories(VinxDbContext vinxDbContext)
        {
            this.vinxDbContext = vinxDbContext;
        }

        public async Task<Models.Domain.Services> Add(ServiceRequestDTO serviceRequestDTO)
        {
            Models.Domain.Services services = new Models.Domain.Services();
            services.UpdatedAt = DateTime.Now;
            services.CreatedAt = DateTime.Now;
            services.ServiceDescriptionAr = serviceRequestDTO.ServiceNameAr;
            services.ServiceDescriptionEn = serviceRequestDTO.ServiceDescriptionEn;
            services.ServiceNameEn = serviceRequestDTO.ServiceNameEn;
            services.ServiceNameAr = serviceRequestDTO.ServiceNameEn;

            await vinxDbContext.Services.AddAsync(services);
            await vinxDbContext.SaveChangesAsync();
            return services;
        }

        public async Task<int> Delete(int id)
        {
            var service = await vinxDbContext.Services.FindAsync(id);
            vinxDbContext.Services.Remove(service);
            await vinxDbContext.SaveChangesAsync();
            return id;
        }

        public async Task<Models.Domain.Services> Edit(int id, EditServiceRequestDTO editServiceRequestDTO)
        {
            var service = await vinxDbContext.Services.FindAsync(id);

            service.ServiceDescriptionEn = editServiceRequestDTO.ServiceDescriptionEn;
            service.ServiceDescriptionAr = editServiceRequestDTO.ServiceDescriptionAr;
            service.ServiceNameEn = editServiceRequestDTO.ServiceNameEn;
            service.ServiceNameAr = editServiceRequestDTO.ServiceNameAr;
            service.UpdatedAt = DateTime.Now;
            vinxDbContext.Services.Update(service);
            await vinxDbContext.SaveChangesAsync();
            return service;
        }

        public async Task<List<Models.Domain.Services>> Get(int id)
        {
            IQueryable<Models.Domain.Services> query = vinxDbContext.Services;

            if (id >= 3001)
            {
                query = query.Where(x => x.Id == id);
            }
            var services = await query.ToListAsync();
            return services;
        }
    }
}
