using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using VinxTech.API.Models.Domain;

namespace VinxTech.API.Data
{
    public class VinxDbContext : DbContext
    {
        public VinxDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Branches> Branches { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<EmployeeServices> EmployeeServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Username)
                      .HasColumnType("nvarchar(200)")
                      .IsRequired();
                

                entity.Property(e => e.PasswordHash)
                      .HasColumnType("nvarchar(256)")
                 .IsRequired();

                entity.Property(e => e.firstNameEn)
                      .HasColumnType("nvarchar(100)")
                       .IsRequired();

                entity.Property(e => e.lastNameEn)
                      .HasColumnType("nvarchar(100)")
                       .IsRequired();

                entity.Property(e => e.firstNameAr)
                      .HasColumnType("nvarchar(100)")
                       .IsRequired();

                entity.Property(e => e.lastNameAr)
                      .HasColumnType("nvarchar(100)")
                       .IsRequired();

                entity.Property(e => e.Email)
                      .HasColumnType("nvarchar(256)")
                       .IsRequired();

                entity.Property(e => e.MobileNumber)
                      .HasColumnType("nvarchar(15)")
                       .IsRequired();

                entity.Property(e => e.CretedBy)
                      .HasColumnType("nvarchar(200)")
                       .IsRequired();
                entity.Property(e => e.Image)
                      .HasColumnType("nvarchar(max)")
                       .IsRequired();
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Image)
                      .HasColumnType("nvarchar(max)")
                      .IsRequired();
            });

                modelBuilder.Entity<EmployeeServices>()
                       .HasIndex(es => new { es.EmployeeId, es.ServiceID })
                       .IsUnique();

            modelBuilder.Entity<Users>().HasKey(u => u.Id);

            modelBuilder.Entity<Users>().HasIndex(u => u.Username).IsUnique();

            var roles = new List<Roles>
            {
                new Roles
                {
                    Id = 1,
                    Name = "Super Admin",
                    Description = "Has full access to all system features and can manage all users, settings, and roles.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt =  DateTime.UtcNow,
                },
                new Roles
                {
                    Id = 2,
                    Name = "Admin",
                    Description = "Can manage users and settings, but has limited access to sensitive system configurations.",
                    CreatedAt =  DateTime.UtcNow,
                    UpdatedAt =  DateTime.UtcNow,
                },
                new Roles
                {
                    Id = 3,
                    Name = "Employee",
                    Description = "Has access to basic features and functionalities necessary for daily operations.",
                    CreatedAt =  DateTime.UtcNow,
                    UpdatedAt =  DateTime.UtcNow,
                },
                new Roles
                {
                    Id = 4,
                    Name = "Cashier",
                    Description = "Responsible for handling transactions and managing customer payments.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                },
                new Roles
                {
                    Id = 5,
                    Name = "Branch Manager",
                    Description = "Responsible for handling the Branch.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                }

            };

            modelBuilder.Entity<Roles>().HasData(roles);
            modelBuilder.Entity<Branches>().HasKey(u => u.Id);
            modelBuilder.Entity<Services>().HasKey(u => u.Id);
            modelBuilder.Entity<Employees>().HasKey(u => u.Id);
            modelBuilder.Entity<EmployeeServices>().HasKey(u => u.Id);
        }
    }
}
