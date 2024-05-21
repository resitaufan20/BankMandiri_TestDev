using mandiri_test.Web.Models;

namespace mandiri_test.Web.Service.IService
{
	public interface IBukuService
	{
		Task<ResponseDto?> GetAllBukusAsync();
		Task<ResponseDto?> GetBukuByIdAsync(int id);

		Task<ResponseDto?> CreateBukuAsync(BukuDto BukuDto);
		Task<ResponseDto?> UpdateBukuAsync(BukuDto BukuDto);
		Task<ResponseDto?> DeleteBukuByIdAsync(int id);
	}
}
