using AutoService.Domain.Entities.Models.UserModels;


namespace AutoService.Domain.Entities.Models.CarModels
{
    public class UserCar
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Brand { get; set; }
        public string CarModel { get; set; }
        public string ProdYear { get; set; }
        public string VINcode { get; set; }
        public string UsersId { get; set; }
        public virtual User Users { get; set; }
    }
}
