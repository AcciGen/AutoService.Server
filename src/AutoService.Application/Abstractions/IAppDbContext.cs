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

namespace AutoService.Application.Abstractions
{
    public interface IAppDbContext
    {
        DbSet<UserRequests> UserRequests { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<CompanyCategory> CompanyCategories { get; set; }
        DbSet<AutoServiceModel> AutoServices { get; set; }
        DbSet<AutoServiceRating> AutoServiceRatings { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<ServiceCategory> ServiceCategories { get; set; }
        DbSet<UserCar> Cars { get; set; }
        DbSet<CarRecord> CarRecords { get; set; }
        DbSet<News> news { get; set; }
        DbSet<NewsComment> newsComments { get; set; }
        DbSet<CarSeat> CarSeats { get; set; }
        DbSet<CarSeatBrand> CarSeatBrands { get; set; }
        DbSet<CarSeatCategory> CarSeatCategories { get; set; }

        ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default!);
    }
}
