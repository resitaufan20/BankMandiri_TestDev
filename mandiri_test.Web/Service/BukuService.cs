using mandiri_test.Web.Models;
using mandiri_test.Web.Service.IService;
using mandiri_test.Web.Utility;


namespace mandiri_test.Web.Service
{
	public class BukuService : IBukuService
	{
		private readonly IBaseService _baseService;
		public BukuService(IBaseService baseService)
		{
			_baseService = baseService;
		}

		public async Task<ResponseDto?> CreateBukuAsync(BukuDto BukuDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = BukuDto,
				Url = SD.BukuAPIBase + "/api/buku"
			});
		}

		

		public async Task<Models.ResponseDto?> DeleteBukuByIdAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.DELETE,
				Url = SD.BukuAPIBase + "/api/Buku/" + id
			});

		}

		public async Task<ResponseDto?> GetAllBukusAsync()
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.BukuAPIBase + "/api/Buku"
			});
		}

		public async Task<ResponseDto?> GetBukuAsync(string BukuCode)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.BukuAPIBase + "/api/Buku/GetByCode/" + BukuCode
			});
		}

		public async Task<ResponseDto?> GetBukuByIdAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.BukuAPIBase + "/api/Buku/" + id
			});
		}

		public async Task<ResponseDto?> UpdateBukuAsync(BukuDto BukuDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.PUT,
				Data = BukuDto,
				Url = SD.BukuAPIBase + "/api/Buku"
			});
		}

		
	}
}
