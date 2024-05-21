using Microsoft.AspNetCore.Identity;

namespace mandiri_test.Services.AuthAPI.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string Name { get; set; }
	}
}
