using Microsoft.AspNetCore.Mvc;
using static mandiri_test.Web.Utility.SD;


namespace mandiri_test.Web.Models
{
	public class RequestDto
	{
		public ApiType ApiType { get; set; } = ApiType.GET;
		public string Url { get; set; } 
		public object Data { get; set; } 
		public string AccessToken { get; set; } 

	}
}
