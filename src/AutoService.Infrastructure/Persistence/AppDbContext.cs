using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models.AutoServiceModels;
using AutoService.Domain.Entities.Models.CarModels;
using AutoService.Domain.Entities.Models.CompanyModels;
using AutoService.Domain.Entities.Models.NewsModels;
using AutoService.Domain.Entities.Models.ServiceModels;
using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;
using AutoService.Domain.Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get ; set ; }
        public DbSet<UserRequests> UserRequests { get ; set ; }
        public DbSet<Company> Companies { get ; set ; }
        public DbSet<CompanyCategory> CompanyCategories { get ; set ; }
        public DbSet<AutoServiceModel> AutoServices { get ; set ; }
        public DbSet<AutoServiceRating> AutoServiceRatings { get ; set ; }
        public DbSet<Service> Services { get ; set ; }
        public DbSet<ServiceCategory> ServiceCategories { get ; set ; }
        public DbSet<UserCar> Cars { get ; set ; }
        public DbSet<CarRecord> CarRecords { get ; set ; }
        public DbSet<News> news { get ; set ; }
        public DbSet<NewsComment> newsComments { get ; set ; }
        public DbSet<CarSeat> CarSeats { get ; set ; }
        public DbSet<CarSeatBrand> CarSeatBrands { get ; set ; }
        public DbSet<CarSeatCategory> CarSeatCategories { get ; set ; }
    }
}
