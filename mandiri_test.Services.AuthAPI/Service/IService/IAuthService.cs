using mandiri_test.Services.AuthAPI.Models.Dto;
//using mandiri_test.Services.AuthAPI.Models.Dto;

namespace mandiri_test.Services.AuthAPI.Service.IService
{
	public interface IAuthService
	{
		Task<string> Register(RegistrationRequestDto registrationRequestDto);
		Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
		Task<bool> AssignRole(string email, string roleName);
	}
}
