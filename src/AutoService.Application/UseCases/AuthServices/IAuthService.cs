using AutoService.Domain.Entities.Models.UserModels;


namespace AutoService.Application.UseCases.AuthServices
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
    }

}
