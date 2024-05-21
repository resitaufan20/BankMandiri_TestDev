using mandiri_test.Web.Models;

namespace mandiri_test.Web.Service.IService
{
	public interface IBaseService
	{
		Task<ResponseDto?> SendAsync(RequestDto requestDto);
	}
}
