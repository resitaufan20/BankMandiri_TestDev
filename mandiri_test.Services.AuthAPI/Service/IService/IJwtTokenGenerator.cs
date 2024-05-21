using mandiri_test.Services.AuthAPI.Models;

namespace mandiri_test.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
