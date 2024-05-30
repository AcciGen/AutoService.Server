using AutoService.Domain.Entities.Models.CarModels;
using Microsoft.AspNetCore.Identity;


namespace AutoService.Domain.Entities.Models.UserModels
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public virtual List<UserCar> Cars { get; set; } 
    }
}
