using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models.AutoServiceModels;
using AutoService.Domain.Entities.Models.CarModels;
using AutoService.Domain.Entities.Models.CompanyModels;
using AutoService.Domain.Entities.Models.NewsModels;
using AutoService.Domain.Entities.Models.ServiceModels;
using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;
using AutoService.Domain.Entities.Models.UserModels;
using AutoService.Domain.Entities.ViewModels.CarSeatViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Infrastracture.Persistance
{
    public class ServiceDbContext : IdentityDbContext<IdentityUser>, IAppDbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<UserRequests> UserRequests { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyCategory> CompanyCategories { get; set; }
        public DbSet<AutoServiceModel> AutoServices { get; set; }
        public DbSet<AutoServiceRating> AutoServiceRatings { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<UserCar> Cars { get; set; }
        public DbSet<CarRecord> CarRecords { get; set; }
        public DbSet<News> news { get; set; }
        public DbSet<NewsComment> newsComments { get; set; }
        public DbSet<CarSeat> CarSeats { get; set; }
        public DbSet<CarSeatBrand> CarSeatBrands { get; set; }
        public DbSet<CarSeatCategory> CarSeatCategories { get; set; }
        public DbSet<Service> Services { get; set; }

        async ValueTask<int> IAppDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
